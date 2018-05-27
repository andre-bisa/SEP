using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;
using MySql.Data.MySqlClient;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLClienteDAO : IClienteDAO
    {

        // Inserisci
        private static readonly string INSERISCI_CLIENTE = "INSERT INTO CLIENTE (IDUTENTE,IDCLIENTE,TIPO,IDPERSONA,NOTE) VALUES (@idutente,@idcliente,@tipoC,@idpersona,@note);";
        private static readonly string INSERISCI_PERSONA = "INSERT INTO PERSONA (IDUTENTE,IDPERSONA,CF,INDIRIZZO,TIPO, NOME, COGNOME, PIVA, RAGIONE_SOCIALE, SEDE_LEGALE) VALUES (@idutente,@idpersona,@cf,@indirizzo,@tipoP,@nome,@cognome,@piva,@ragione_sociale,@sede_legale);";

        // Seleziona
        private static readonly string SELEZIONA_TUTTI_CLIENTI = "SELECT C.IDUTENTE AS IDUTENTE, C.IDCLIENTE AS IDCLIENTE, C.TIPO AS TIPOCLIENTE, C.NOTE AS NOTE, P.CF AS CF, P.INDIRIZZO AS INDIRIZZO, P.TIPO AS TIPOPERSONA, P.NOME AS NOME, P.COGNOME AS COGNOME, P.PIVA AS PIVA, P.RAGIONE_SOCIALE AS RAGIONE_SOCIALE, P.SEDE_LEGALE AS SEDE_LEGALE FROM CLIENTE AS C INNER JOIN PERSONA AS P ON P.IDUTENTE=C.IDUTENTE AND P.IDPERSONA=C.IDPERSONA WHERE C.IDUTENTE=@idutente;";
        private static readonly string SELEZIONA_ULTIMO_ID_PERSONA = "SELECT MAX(IDPERSONA) AS MAX FROM PERSONA WHERE IDUTENTE = @idutente;";

        // Aggiorna
        private static readonly string AGGIORNA_CLIENTE = "UPDATE CLIENTE SET IDCLIENTE=@idcliente,TIPO=@tipoC,NOTE=@note WHERE IDUTENTE=@idutente AND IDCLIENTE=@old_idcliente;";

        // Elimina
        private static readonly string ELIMINA_PERSONA = "DELETE PERSONA.* FROM PERSONA INNER JOIN CLIENTE ON CLIENTE.IDPERSONA=CLIENTE.IDPERSONA AND CLIENTE.IDUTENTE=PERSONA.IDUTENTE WHERE PERSONA.IDUTENTE=@idutente AND CLIENTE.IDCLIENTE=@idcliente;";

        public bool Aggiorna(Cliente clienteVecchio, Cliente clienteNuovo)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += AGGIORNA_CLIENTE;
            InserisciParametriCliente(clienteNuovo, cmd);
            cmd.Parameters.AddWithValue("@old_idcliente", clienteVecchio.IDCliente);

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", "1");       // <-------------- TODO inserire IDUTENTE

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        public bool Crea(Cliente cliente)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            int IDPersona = NuovoNumeroPersonaLibero();

            cmd.CommandText += INSERISCI_PERSONA;
            InserisciParametriPersona(cliente.Persona, cmd);

            if (IDPersona <= 0)
            {
                connessione.Close();
                return false;
            }

            cmd.CommandText += INSERISCI_CLIENTE;
            InserisciParametriCliente(cliente, cmd);

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", "1");       // <-------------- TODO inserire IDUTENTE
            cmd.Parameters.AddWithValue("@idpersona", "" + IDPersona);

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        private void InserisciParametriCliente(Cliente cliente, MySqlCommand cmd)
        {
            string tipoCliente = "";
            switch (cliente.TipoCliente)
            {
                case EnumTipoCliente.Attivo:
                    tipoCliente = "A";
                    break;
                case EnumTipoCliente.Ex:
                    tipoCliente = "E";
                    break;
                case EnumTipoCliente.Potenziale:
                    tipoCliente = "P";
                    break;
            }
            cmd.Parameters.AddWithValue("@idcliente", cliente.IDCliente);
            cmd.Parameters.AddWithValue("@tipoC", tipoCliente);
            cmd.Parameters.AddWithValue("@note", cliente.Nota);
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

        private int NuovoNumeroPersonaLibero()
        {
            int ultimoID = -2;
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            MySqlCommand cmd = connessione.CreateCommand();

            cmd.CommandText = SELEZIONA_ULTIMO_ID_PERSONA;
            cmd.Parameters.AddWithValue("@idutente", "1");   // <-------------- TODO inserire IDUTENTE
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if (reader.IsDBNull(0))
                    ultimoID = 0;
                else
                    ultimoID = reader.GetInt32(0);
            }

            connessione.Close();

            return ultimoID + 1;
        }

        public bool Elimina(string IDCliente)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += ELIMINA_PERSONA;
            cmd.Parameters.AddWithValue("@idcliente", IDCliente);

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", "1");       // <-------------- TODO inserire IDUTENTE

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        public List<Cliente> LeggiTuttiClienti()
        {
            List<Cliente> listaClienti = new List<Cliente>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return listaClienti;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return listaClienti;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += SELEZIONA_TUTTI_CLIENTI;

            cmd.Parameters.AddWithValue("@idutente", "1");

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Persona persona;

                if (reader.GetString("TIPOPERSONA") == "F")
                {
                    persona = new PersonaFisica(reader.GetString("CF"), reader.GetString("INDIRIZZO"), reader.GetString("NOME"), reader.GetString("COGNOME"), reader.GetString("PIVA"));
                }
                else
                {
                    persona = new PersonaGiuridica(reader.GetString("CF"), reader.GetString("INDIRIZZO"), reader.GetString("RAGIONE_SOCIALE"), reader.GetString("SEDE_LEGALE"), reader.GetString("PIVA"));
                }

                EnumTipoCliente tipoCliente;
                switch (reader.GetString("TIPOCLIENTE"))
                {
                    case "A":
                    default:
                        tipoCliente = EnumTipoCliente.Attivo;
                        break;
                    case "E":
                        tipoCliente = EnumTipoCliente.Ex;
                        break;
                    case "P":
                        tipoCliente = EnumTipoCliente.Potenziale;
                        break;
                }

                List<Referente> referenti = null;

                listaClienti.Add(new Cliente(persona, reader.GetString("IDCLIENTE"), referenti, tipoCliente, reader.GetString("NOTE")));
            }

            connessione.Clone();
            return listaClienti;
        }
    }
}
