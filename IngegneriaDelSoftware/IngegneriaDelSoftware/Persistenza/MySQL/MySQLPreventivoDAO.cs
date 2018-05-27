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
    public class MySQLPreventivoDAO : IPreventivoDAO
    {

        // Inserisci
        private static string INSERISCI_PREVENTIVO = "INSERT INTO PREVENTIVO(IDUTENTE, IDPREVENTIVO, DATA, ACCETTATO, IDCLIENTE) VALUES (@idutente,@idpreventivo,@data,@accettato,@idcliente);";

        // Seleziona
        private static string SELEZIONA_TUTTI_PREVENTIVI = "SELECT P.IDPREVENTIVO AS IDPREVENTIVO,P.DATA AS DATA, P.ACCETTATO AS ACCETTATO, P.IDCLIENTE FROM PREVENTIVO AS P WHERE IDUTENTE=@idutente;";
        private static string SELEZIONA_TUTTE_VOCI_PREVENTIVO = "SELECT V.NUMERO AS NUMERO, V.DESCRIZIONE AS DESCRIZIONE, V.TIPOLOGIA AS TIPOLOGIA, V.QUANTITA AS QUANTITA, V.IMPORTO AS IMPORTO FROM VOCEPREVENTIVO AS V WHERE IDUTENTE=@idutente AND IDPREVENTIVO=@idpreventivo;";

        public bool Aggiorna(Preventivo vecchio, Preventivo nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Preventivo preventivo)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += INSERISCI_PREVENTIVO;
            InserisciParametriPreventivo(preventivo, cmd);

            int maxNumeroVoce = 0; // Cerca il max nella tabella
            foreach (VocePreventivo voce in preventivo.Voci)
            {
                cmd.CommandText += "INSERT INTO VOCEPREVENTIVO(IDUTENTE,IDPREVENTIVO,NUMERO,DESCRIZIONE,TIPOLOGIA,QUANTITA,IMPORTO) VALUES(@idutente,@idpreventivo," + maxNumeroVoce + ",'" + voce.Causale + "','" + voce.Tipologia + "'," + voce.Quantita + "," + voce.Importo + ");";
                maxNumeroVoce++;
            }

            cmd.CommandText += "COMMIT;";
            cmd.Parameters.AddWithValue("@idutente", "1");

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        private void InserisciParametriPreventivo(Preventivo preventivo, MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@idpreventivo", preventivo.ID);
            cmd.Parameters.AddWithValue("@data", preventivo.Data);
            cmd.Parameters.AddWithValue("@accettato", preventivo.Accettato);
            cmd.Parameters.AddWithValue("@idcliente", preventivo.Cliente.IDCliente);
        }

        public bool Elimina(ulong ID)
        {
            throw new NotImplementedException();
        }

        public List<Preventivo> LeggiTuttiPreventivi()
        {
            List<Preventivo> listaPreventivo = new List<Preventivo>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return listaPreventivo;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return listaPreventivo;

            cmd.CommandText = SELEZIONA_TUTTI_PREVENTIVI;

            cmd.Parameters.AddWithValue("@idutente", "1");   // TODO AGGIUNSTARE!!

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = CollezioneClienti.GetInstance().Get(reader.GetString("IDCLIENTE"));
                List<VocePreventivo> voci = OttieniVociPreventivo((ulong)reader.GetInt64("IDPREVENTIVO"));
                Preventivo preventivo = new Preventivo((ulong) reader.GetInt64("IDPREVENTIVO"), cliente, reader.GetDateTime("DATA"), reader.GetBoolean("ACCETTATO"), voci);
                listaPreventivo.Add(preventivo);
            }

            connessione.Clone();
            return listaPreventivo;
        }

        private List<VocePreventivo> OttieniVociPreventivo(ulong idPreventivo)
        {
            List<VocePreventivo> vociPreventivo = new List<VocePreventivo>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return vociPreventivo;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return vociPreventivo;

            cmd.CommandText = SELEZIONA_TUTTE_VOCI_PREVENTIVO;
            cmd.Parameters.AddWithValue("@idutente", "1");     // TODO AGGIUNSTARE!!
            cmd.Parameters.AddWithValue("@idpreventivo", idPreventivo);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                VocePreventivo voce = new VocePreventivo(reader.GetString("DESCRIZIONE"), reader.GetDecimal("IMPORTO"), reader.GetString("TIPOLOGIA"), reader.GetInt32("QUANTITA"));
                vociPreventivo.Add(voce);
            }

                connessione.Close();
            return vociPreventivo;
        }
    }
}