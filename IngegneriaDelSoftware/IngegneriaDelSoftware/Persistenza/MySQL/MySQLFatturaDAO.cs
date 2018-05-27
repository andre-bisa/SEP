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
        // Inserisci
        private static string INSERISCI_FATTURA = "INSERT INTO FATTURA(IDUTENTE,ANNO,NUMERO,DATA,BASE_IMPONIBILE,SCONTO,TOTALE,TIPOAGENTE,IDDATORELAVORO,IDCLIENTE) VALUES(@idutente,@anno,@numero,@data,@baseimponibile,@sconto,@totale,@tipoagente,@iddatorelavoto,@idcliente);";

        // Aggiorna
        private static string AGGIORNA_FATTURA = "UPDATE FATTURA SET ANNO=@anno,NUMERO=@numero,DATA=@data,BASE_IMPONIBILE=@baseimponibile,SCONTO=@sconto,TOTALE=@totale,TIPOAGENTE=@tipoagente,IDDATORELAVORO=@iddatorelavoro,IDCLIENTE=@idcliente WHERE IDUTENTE=@idutente AND ANNO=@oldAnno AND NUMERO=@oldNumero;";
        
        // Seleziona
        private static string SELEZIONA_TUTTE_FATTURE = "SELECT F.IDCLIENTE AS IDCLIENTE, F.ANNO AS ANNO, F.NUMERO AS NUMERO, F.DATA AS DATA, F.BASE_IMPONIBILE AS BASE_IMPONIBILE, F.SCONTO AS SCONTO, F.TOTALE AS TOTALE, F.TIPOAGENTE AS TIPOAGENTE, F.IDDATORELAVORO AS IDDATORELAVORO FROM FATTURA AS F WHERE IDUTENTE=@idutente;";
        private static string SELEZIONA_TUTTE_VOCI_FATTURA = "SELECT V.ANNO AS ANNO, V.NUMEROFATTURA AS NUMEROFATTURA, V.NUMEROVOCE AS NUMEROVOCE, V.DESCRIZIONE AS DESCRIZIONE, V.TIPOLOGIA AS TIPOLOGIA, V.PERCENTUALE_IVA AS PERCENTUALE_IVA, V.QUANTITA AS QUANTITA, V.IMPORTO AS IMPORTO FROM VOCEFATTURA AS V WHERE IDUTENTE=@idutente AND NUMEROFATTURA=@numerofattura AND ANNO=@annofattura;";
        private static string SELEZIONA_VENDITE_PROVENIENZA = "SELECT VF.IDVENDITA AS IDVENDITA FROM VENDITEFATTURA AS VF WHERE IDUTENTE=@idutente AND NUMERO=@numerofattura AND ANNO=@annofattura;";


        public bool Aggiorna(Fattura vecchia, Fattura nuova)
        { // NOT TESTED
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = AGGIORNA_FATTURA;

            InserisciParametriFattura(nuova, cmd);

            cmd.Parameters.AddWithValue("@oldAnno", vecchia.Anno);
            cmd.Parameters.AddWithValue("@oldNumero", vecchia.Numero);
            cmd.Parameters.AddWithValue("@idutente", "1");   // TODO AGGIUNSTARE!!

            int modifiche = cmd.ExecuteNonQuery();
            connessione.Close();
            return (modifiche >= 1);
        }

        private void InserisciParametriFattura(Fattura fattura, MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@anno", fattura.Anno);
            cmd.Parameters.AddWithValue("@numero", fattura.Numero);
            cmd.Parameters.AddWithValue("@data", fattura.Data);
            cmd.Parameters.AddWithValue("@baseimponibile", 0); // TODO AGGIUSTARE
            cmd.Parameters.AddWithValue("@sconto", fattura.Sconto);
            cmd.Parameters.AddWithValue("@totale", fattura.Calcola());
            cmd.Parameters.AddWithValue("@tipoagente", DBNull.Value); // TODO da mettere a seconda del tipo di utente corrente
            cmd.Parameters.AddWithValue("@iddatorelavoro", DBNull.Value); // TODO da aggiustare quando la fattura sarà ok con il dato di lavoro
            cmd.Parameters.AddWithValue("@idcliente", fattura.Cliente.IDCliente);
        }

        public bool Crea(Fattura nuova)
        { // NOT TESTED
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = INSERISCI_FATTURA;

            InserisciParametriFattura(nuova, cmd);

            cmd.Parameters.AddWithValue("@idutente", "1");   // TODO AGGIUNSTARE!!

            int modifiche = cmd.ExecuteNonQuery();
            connessione.Close();
            return (modifiche >= 1);
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
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = SELEZIONA_TUTTE_FATTURE;

            cmd.Parameters.AddWithValue("@idutente", "1");   // TODO AGGIUNSTARE!!

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Fattura fattura;

                List<VoceFattura> voci = OttieniVociFattura(reader.GetUInt64("ANNO"), reader.GetInt32("NUMERO"));
                List<Vendita> venditeFattura = OttieniVenditeDiProvenienza(reader.GetUInt64("ANNO"), reader.GetInt32("NUMERO"));

                if (reader.IsDBNull(0)) // Se IDCLIENTE è nullo
                { // Inserisco rivolta a datore lavoro
                    // datore lavoro
                    fattura = null;
                }
                else
                { // Inserisco rivolta a cliente
                    Cliente cliente = CollezioneClienti.GetInstance().Get(reader.GetString("IDCLIENTE"));
                    fattura = new Fattura(reader.GetInt32("ANNO"), reader.GetString("NUMERO"), cliente, venditeFattura, reader.GetDateTime("DATA"), reader.GetFloat("SCONTO"), voci, false); // TODO aggiustare
                }

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
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

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
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

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