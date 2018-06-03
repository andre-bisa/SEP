using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza.Dao;
using MySql.Data.MySqlClient;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLPersonaDAO : IPersonaDAO
    {
        private static readonly string AGGIORNA_PERSONA = "UPDATE PERSONA SET CF=@cf,INDIRIZZO=@indirizzo,TIPO=@tipoP,NOME=@nome,COGNOME=@cognome,PIVA=@piva,RAGIONE_SOCIALE=@ragione_sociale,SEDE_LEGALE=@sede_legale WHERE CF=@oldCF AND IDUTENTE=@idutente;";

        private static readonly string ELIMINA_VECCHIA_EMAIL = "DELETE M.* FROM MAIL AS M INNER JOIN PERSONA AS P ON P.IDPERSONA=M.IDPERSONA AND P.IDUTENTE=M.IDUTENTE WHERE M.IDUTENTE=@idutente AND P.CF=@oldCF AND M.MAIL=@email;";

        private static readonly string ELIMINA_VECCHIO_TELEFONO = "DELETE T.* FROM TELEFONO AS T INNER JOIN PERSONA AS P ON P.IDPERSONA=T.IDPERSONA AND P.IDUTENTE=T.IDUTENTE WHERE T.IDUTENTE=@idutente AND P.CF=@oldCF AND T.TELEFONO=@telefono;";

        public bool Aggiorna(Persona vecchiaPersona, Persona nuovaPersona)
        {
            if (vecchiaPersona.TipoPersona != nuovaPersona.TipoPersona)
                return false;

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;


            cmd.CommandText = AGGIORNA_PERSONA;

            InserisciParametriPersona(nuovaPersona, cmd);

            cmd.Parameters.AddWithValue("@oldCF", vecchiaPersona.CodiceFiscale);
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            int modifiche = cmd.ExecuteNonQuery();
            connessione.Close();

            return (modifiche >= 1);
        }

        private int OttieniIDPersona(string codiceFiscale)
        {
            int IDPersona;
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new Persistenza.ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new Persistenza.ExceptionPersistenza();

            cmd.CommandText = "SELECT IDPERSONA FROM PERSONA WHERE IDUTENTE=@idutente AND CF=@cf;";
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
            cmd.Parameters.AddWithValue("@cf", codiceFiscale);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                IDPersona = reader.GetInt32(0);
            else
                throw new Persistenza.ExceptionPersistenza();

            connessione.Close();

            return IDPersona;
        }

        private void InserisciParametriPersona(Persona persona, MySqlCommand cmd)
        {
            string tipoPersona = "";
            switch (persona.TipoPersona)
            {
                case EnumTipoPersona.Fisica:
                    tipoPersona = "F";
                    break;
                case EnumTipoPersona.Giuridica:
                    tipoPersona = "G";
                    break;
            }

            cmd.Parameters.AddWithValue("@cf", persona.CodiceFiscale);
            cmd.Parameters.AddWithValue("@indirizzo", persona.Indirizzo);
            cmd.Parameters.AddWithValue("@tipoP", tipoPersona);

            object nome = DBNull.Value;
            object cognome = DBNull.Value;
            object piva = DBNull.Value;
            object ragione_sociale = DBNull.Value;
            object sede_legale = DBNull.Value;

            switch (persona.TipoPersona)
            {
                case EnumTipoPersona.Fisica:
                    PersonaFisica pf = (PersonaFisica)persona;
                    nome = pf.Nome;
                    cognome = pf.Cognome;
                    piva = pf.PartitaIVA;
                    break;
                case EnumTipoPersona.Giuridica:
                    PersonaGiuridica pg = (PersonaGiuridica)persona;
                    piva = pg.PartitaIVA;
                    ragione_sociale = pg.RagioneSociale;
                    sede_legale = pg.SedeLegale;
                    break;
            }

            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@cognome", cognome);
            cmd.Parameters.AddWithValue("@piva", piva);
            cmd.Parameters.AddWithValue("@ragione_sociale", ragione_sociale);
            cmd.Parameters.AddWithValue("@sede_legale", sede_legale);
        }

        public bool InserisciEmail(Email email, Persona persona)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new Persistenza.ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new Persistenza.ExceptionPersistenza();

            cmd.CommandText = "START TRANSACTION;";

            int IDPersona = OttieniIDPersona(persona.CodiceFiscale);

            cmd.CommandText += "INSERT INTO MAIL(IDUTENTE, IDPERSONA, MAIL, NOTA) VALUES(@idutente,@idpersona,@email,@nota);";
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
            cmd.Parameters.AddWithValue("@idpersona", IDPersona);
            cmd.Parameters.AddWithValue("@nota", email.Nota);
            cmd.Parameters.AddWithValue("@email", email.Indirizzo);

            cmd.CommandText += "COMMIT;";

            int modifiche = cmd.ExecuteNonQuery();
            connessione.Close();

            return (modifiche >= 1);
        }

        public bool RimuoviEmail(Email email, Persona persona)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new Persistenza.ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new Persistenza.ExceptionPersistenza();

            cmd.CommandText = "START TRANSACTION;";

            int IDPersona = OttieniIDPersona(persona.CodiceFiscale);

            cmd.CommandText += ELIMINA_VECCHIA_EMAIL;
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
            cmd.Parameters.AddWithValue("@oldCF", persona.CodiceFiscale);
            cmd.Parameters.AddWithValue("@email", email.Indirizzo);

            cmd.CommandText += "COMMIT;";

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        public bool InserisciTelefono(Telefono telefono, Persona persona)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new Persistenza.ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new Persistenza.ExceptionPersistenza();

            cmd.CommandText = "START TRANSACTION;";

            int IDPersona = OttieniIDPersona(persona.CodiceFiscale);

            cmd.CommandText += "INSERT INTO TELEFONO(IDUTENTE, IDPERSONA, TELEFONO, NOTA) VALUES(@idutente,@idpersona,@telefono,@nota);";
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
            cmd.Parameters.AddWithValue("@idpersona", IDPersona);
            cmd.Parameters.AddWithValue("@telefono", telefono.Numero);
            cmd.Parameters.AddWithValue("@nota", telefono.Nota);

            cmd.CommandText += "COMMIT;";

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        public bool RimuoviTelefono(Telefono telefono, Persona persona)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new Persistenza.ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new Persistenza.ExceptionPersistenza();

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += ELIMINA_VECCHIO_TELEFONO;
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
            cmd.Parameters.AddWithValue("@oldCF", persona.CodiceFiscale);
            cmd.Parameters.AddWithValue("@telefono", telefono.Numero);

            cmd.CommandText += "COMMIT;";

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }
    }
}
