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
        public static readonly string AGGIORNA_PERSONA = "UPDATE PERSONA SET CF=@cf,INDIRIZZO=@indirizzo,TIPO=@tipoP,NOME=@nome,COGNOME=@cognome,PIVA=@piva,RAGIONE_SOCIALE=@ragione_sociale,SEDE_LEGALE=@sede_legale WHERE CF=@oldCF AND IDUTENTE=@idutente;";

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
            cmd.Parameters.AddWithValue("@idutente", "1");       // <-------------- TODO inserire IDUTENTE

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
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

    }
}
