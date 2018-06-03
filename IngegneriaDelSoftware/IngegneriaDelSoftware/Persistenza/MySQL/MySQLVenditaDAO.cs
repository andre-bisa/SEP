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
    public class MySQLVenditaDAO : IVenditaDAO
    {

        // Aggiorna
        private static string AGGIORNA_VENDITA = "UPDATE VENDITA SET IDPREVENTIVO=@idpreventivo,DATA=@data,TIPOAGENTE=@tipoagente,PROVVIGIONE=@provvigione,IDCLIENTE=@idcliente WHERE IDUTENTE=@idutente AND IDVENDITA=@oldidvendita;";

        // Inserisci
        private static string INSERISCI_VENDITA = "INSERT INTO VENDITA(IDUTENTE, IDVENDITA, IDPREVENTIVO, DATA, TIPOAGENTE, PROVVIGIONE, IDCLIENTE) VALUES (@idutente,@idvendita,@idpreventivo,@data,@tipoagente,@provvigione,@idcliente);";

        // Seleziona
        private static string SELEZIONA_TUTTE_VENDITE = "SELECT V.IDPREVENTIVO AS IDPREVENTIVO, V.IDVENDITA AS IDVENDITA, V.DATA AS DATA, V.TIPOAGENTE AS TIPOAGENTE, V.PROVVIGIONE AS PROVVIGIONE, V.IDCLIENTE AS IDCLIENTE FROM VENDITA AS V WHERE IDUTENTE=@idutente;";
        private static string SELEZIONA_TUTTE_VOCI_VENDITA = "SELECT V.PROVVIGIONE AS PROVVIGIONE, V.NUMERO AS NUMERO, V.DESCRIZIONE AS DESCRIZIONE, V.TIPOLOGIA AS TIPOLOGIA, V.QUANTITA AS QUANTITA, V.IMPORTO AS IMPORTO FROM VOCEVENDITA AS V WHERE IDUTENTE=@idutente AND IDVENDITA=@idvendita;";


        public bool Aggiorna(Vendita vecchia, Vendita nuova)
        { // NOT TESTED
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = AGGIORNA_VENDITA;

            InserisciParametriVendita(nuova, cmd);

            cmd.Parameters.AddWithValue("@oldidvendita", vecchia.ID);
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        public bool Crea(Vendita vendita)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += INSERISCI_VENDITA;
            InserisciParametriVendita(vendita, cmd);

            int maxNumeroVoce = 0; // Cerca il max nella tabella
            foreach (VoceVendita voce in vendita.Voci)
            {
                string provvigione = "NULL";
                cmd.CommandText += "INSERT INTO VOCEVENDITA(IDUTENTE,IDVENDITA,NUMERO,DESCRIZIONE,TIPOLOGIA,QUANTITA,PROVVIGIONE,IMPORTO) VALUES(@idutente,@idvendita," + maxNumeroVoce + ",'" + voce.Causale + "','" + voce.Tipologia + "'," + voce.Quantita + "," + provvigione + "," + voce.Importo + ");";
                maxNumeroVoce++;
            }

            cmd.CommandText += "COMMIT;";
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        private void InserisciParametriVendita(Vendita vendita, MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@idvendita", vendita.ID);
            cmd.Parameters.AddWithValue("@data", vendita.Data);
            cmd.Parameters.AddWithValue("@idpreventivo", vendita.PreventivoDiProvenienza);
            cmd.Parameters.AddWithValue("@tipoagente", DBNull.Value); // TODO da aggiustare qui a seconda del tipo di utente
            cmd.Parameters.AddWithValue("@provvigione", DBNull.Value); // TODO da aggiustare se utente agente => mettere il suo valore
            cmd.Parameters.AddWithValue("@idcliente", vendita.Cliente.IDCliente);
        }

        public bool Elimina(ulong ID)
        {
            throw new NotImplementedException();
        }

        public List<Vendita> LeggiTutteVendite()
        {
            List<Vendita> listaVendite = new List<Vendita>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = SELEZIONA_TUTTE_VENDITE;

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = CollezioneClienti.GetInstance().Get(reader.GetString("IDCLIENTE"));
                List<VoceVendita> voci = OttieniVociVendita(reader.GetUInt64("IDVENDITA"));

                Preventivo preventivoProvenienza = null;

                if (! reader.IsDBNull(0))
                {
                    preventivoProvenienza = CollezionePreventivi.GetInstance().Get(reader.GetUInt64("IDPREVENTIVO"));
                }

                Vendita vendita = new Vendita(reader.GetUInt64("IDVENDITA"), cliente, reader.GetDateTime("DATA"), voci, preventivoProvenienza);
                listaVendite.Add(vendita);
            }

            connessione.Close();
            return listaVendite;
        }

        private List<VoceVendita> OttieniVociVendita(ulong idVendita)
        {
            List<VoceVendita> vociVendita = new List<VoceVendita>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = SELEZIONA_TUTTE_VOCI_VENDITA;
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
            cmd.Parameters.AddWithValue("@idvendita", idVendita);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                float provvigione = 0;
                if (! reader.IsDBNull(0))
                {

                }
                VoceVendita voce = new VoceVendita(reader.GetString("DESCRIZIONE"), reader.GetDecimal("IMPORTO"), provvigione, reader.GetString("TIPOLOGIA"), reader.GetInt32("QUANTITA"));
                vociVendita.Add(voce);
            }

            connessione.Close();
            return vociVendita;
        }
    }
}