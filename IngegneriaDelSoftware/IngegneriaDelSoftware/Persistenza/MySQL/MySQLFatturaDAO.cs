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
    public class MySQLFatturaDAO : IFatturaDAO
    {

        // Seleziona
        private static string SELEZIONA_TUTTE_FATTURE = "SELECT F.ANNO AS ANNO, F.NUMERO AS NUMERO, F.DATA AS DATA, F.BASE_IMPONIBILE AS BASE_IMPONIBILE, F.SCONTO AS SCONTO, F.TOTALE AS TOTALE, F.TIPOAGENTE AS TIPOAGENTE, F.IDDATORELAVORO AS IDDATORELAVORO, F.IDCLIENTE AS IDCLIENTE FROM FATTURA AS F WHERE IDUTENTE=@idutente;";
        private static string SELEZIONA_TUTTE_VOCI_FATTURA = "SELECT V.ANNO AS ANNO, V.NUMEROFATTURA AS NUMEROFATTURA, V.NUMEROVOCE AS NUMEROVOCE, V.DESCRIZIONE AS DESCRIZIONE, V.TIPOLOGIA AS TIPOLOGIA, V.PERCENTUALE_IVA AS PERCENTUALE_IVA, V.QUANTITA AS QUANTITA, V.IMPORTO AS IMPORTO FROM VOCEFATTURA AS V WHERE IDUTENTE=@idutente AND NUMEROFATTURA=@numerofattura AND ANNO=@annofattura;";
        private static string SELEZIONA_VENDITE_PROVENIENZA = "SELECT VF.IDVENDITA AS IDVENDITA FROM VENDITEFATTURA AS VF WHERE IDUTENTE=@idutente AND NUMERO=@numerofattura AND ANNO=@annofattura;";


        public bool Aggiorna(Fattura vecchia, Fattura nuova)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Fattura nuova)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string Inumero, int annoD)
        {
            throw new NotImplementedException();
        }

        public Fattura Leggi(string ID)
        {
            throw new NotImplementedException();
        }

        public List<Fattura> LeggiTutteFatture()
        {
            List<Fattura> listaFatture = new List<Fattura>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return listaFatture;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return listaFatture;

            cmd.CommandText = SELEZIONA_TUTTE_FATTURE;

            cmd.Parameters.AddWithValue("@idutente", "1");   // TODO AGGIUNSTARE!!

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // TODO NON GESTITO IL DATORE DI LAVORO
                Cliente cliente = CollezioneClienti.GetInstance().Get(reader.GetString("IDCLIENTE"));
                List<VoceFattura> voci = OttieniVociFattura(reader.GetUInt64("ANNO"), reader.GetInt32("NUMERO"));

                List<Vendita> venditeFattura = OttieniVenditeDiProvenienza(reader.GetUInt64("ANNO"), reader.GetInt32("NUMERO"));
                Fattura fattura = new Fattura(reader.GetInt32("ANNO"), reader.GetString("NUMERO"), cliente, venditeFattura, reader.GetDateTime("DATA"), reader.GetFloat("SCONTO"), voci, false); // TODO aggiustare
                listaFatture.Add(fattura);
            }

            connessione.Clone();
            return listaFatture;
        }

        private List<Vendita> OttieniVenditeDiProvenienza(ulong anno, int numero)
        {
            List<Vendita> venditeDiProvenienza = new List<Vendita>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return venditeDiProvenienza;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return venditeDiProvenienza;

            cmd.CommandText = SELEZIONA_VENDITE_PROVENIENZA;


            cmd.Parameters.AddWithValue("@idutente", "1");     // TODO AGGIUNSTARE!!
            cmd.Parameters.AddWithValue("@numerofattura", numero);
            cmd.Parameters.AddWithValue("@annofattura", anno);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Vendita vendita = CollezioneVendite.GetInstance().Get(reader.GetUInt32("IDVENDITA"));
                venditeDiProvenienza.Add(vendita);
            }

            connessione.Close();
            return venditeDiProvenienza;
        }

        private List<VoceFattura> OttieniVociFattura(ulong anno, int numero)
        {
            List<VoceFattura> vociFattura = new List<VoceFattura>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return vociFattura;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return vociFattura;

            cmd.CommandText = SELEZIONA_TUTTE_VOCI_FATTURA;
            cmd.Parameters.AddWithValue("@idutente", "1");     // TODO AGGIUNSTARE!!
            cmd.Parameters.AddWithValue("@numerofattura", numero);
            cmd.Parameters.AddWithValue("@annofattura", anno);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                VoceFattura voce = new VoceFattura(reader.GetString("DESCRIZIONE"), reader.GetDecimal("IMPORTO"), reader.GetFloat("PERCENTUALE_IVA"), reader.GetString("TIPOLOGIA"), reader.GetInt32("QUANTITA"));
                vociFattura.Add(voce);
            }

            connessione.Close();
            return vociFattura;
        }
    }
}