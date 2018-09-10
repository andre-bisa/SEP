/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

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
        private static string INSERISCI_FATTURA = "INSERT INTO FATTURA(IDUTENTE,ANNO,NUMERO,DATA,BASE_IMPONIBILE,SCONTO,TOTALE,TIPOAGENTE,IDDATORELAVORO,IDCLIENTE) VALUES(@idutente,@anno,@numero,@data,@baseimponibile,@sconto,@totale,@tipoagente,@iddatorelavoro,@idcliente);";

        // Aggiorna
        private static string AGGIORNA_FATTURA = "UPDATE FATTURA SET ANNO=@anno,NUMERO=@numero,DATA=@data,BASE_IMPONIBILE=@baseimponibile,SCONTO=@sconto,TOTALE=@totale,TIPOAGENTE=@tipoagente,IDDATORELAVORO=@iddatorelavoro,IDCLIENTE=@idcliente WHERE IDUTENTE=@idutente AND ANNO=@oldAnno AND NUMERO=@oldNumero;";
        
        // Seleziona
        private static string SELEZIONA_TUTTE_FATTURE = "SELECT F.IDCLIENTE AS IDCLIENTE, F.ANNO AS ANNO, F.NUMERO AS NUMERO, F.DATA AS DATA, F.BASE_IMPONIBILE AS BASE_IMPONIBILE, F.SCONTO AS SCONTO, F.TOTALE AS TOTALE, F.TIPOAGENTE AS TIPOAGENTE, F.IDDATORELAVORO AS IDDATORELAVORO FROM FATTURA AS F WHERE IDUTENTE=@idutente;";
        private static string SELEZIONA_TUTTE_VOCI_FATTURA = "SELECT V.ANNO AS ANNO, V.NUMEROFATTURA AS NUMEROFATTURA, V.NUMEROVOCE AS NUMEROVOCE, V.DESCRIZIONE AS DESCRIZIONE, V.TIPOLOGIA AS TIPOLOGIA, V.PERCENTUALE_IVA AS PERCENTUALE_IVA, V.QUANTITA AS QUANTITA, V.IMPORTO AS IMPORTO FROM VOCEFATTURA AS V WHERE IDUTENTE=@idutente AND NUMEROFATTURA=@numerofattura AND ANNO=@annofattura;";
        private static string SELEZIONA_VENDITE_PROVENIENZA = "SELECT VF.IDVENDITA AS IDVENDITA FROM VENDITEFATTURA AS VF WHERE IDUTENTE=@idutente AND NUMERO=@numerofattura AND ANNO=@annofattura;";


        public bool Aggiorna(Fattura vecchia, Fattura nuova)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += AGGIORNA_FATTURA;

            cmd.CommandText += "DELETE FROM VOCEFATTURA WHERE IDUTENTE=@idutente AND ANNO=@oldAnno AND NUMEROFATTURA=@oldNumero;";

            System.Globalization.CultureInfo backup = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            int maxNumeroVoce = 1;
            foreach (VoceFattura voce in nuova)
            {
                cmd.CommandText += "INSERT INTO VOCEFATTURA(IDUTENTE,ANNO,NUMEROFATTURA,NUMEROVOCE,DESCRIZIONE,TIPOLOGIA,PERCENTUALE_IVA,QUANTITA,IMPORTO) VALUES(@idutente,@anno,@numero," + maxNumeroVoce + ",'" + voce.Causale + "','" + voce.Tipologia + "'," + voce.Iva + "," + voce.Quantita + "," + voce.Importo + ");";
                maxNumeroVoce++;
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = backup;

            InserisciParametriFattura(nuova, cmd);

            cmd.Parameters.AddWithValue("@oldAnno", vecchia.Anno);
            cmd.Parameters.AddWithValue("@oldNumero", vecchia.Numero);
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            cmd.CommandText += "COMMIT;";

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
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += INSERISCI_FATTURA;

            foreach (Vendita v in nuova.VenditeDiProvenienza)
            {
                cmd.CommandText += "INSERT INTO VENDITEFATTURA(ANNO, NUMERO, IDUTENTE, IDVENDITA) VALUES(@anno,@numero, @idutente, " + v.ID + ");";
            }

            System.Globalization.CultureInfo backup = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            int maxNumeroVoce = 1;
            foreach (VoceFattura voce in nuova)
            {
                cmd.CommandText += "INSERT INTO VOCEFATTURA(IDUTENTE,ANNO,NUMEROFATTURA,NUMEROVOCE,DESCRIZIONE,TIPOLOGIA,PERCENTUALE_IVA,QUANTITA,IMPORTO) VALUES(@idutente,@anno,@numero," + maxNumeroVoce + ",'" + voce.Causale + "','" + voce.Tipologia + "'," + voce.Iva + "," + voce.Quantita + "," + voce.Importo + ");";
                maxNumeroVoce++;
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = backup;

            InserisciParametriFattura(nuova, cmd);
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            cmd.CommandText += "COMMIT;";

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

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

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
                    fattura = new FatturaScripting(reader.GetInt32("ANNO"), reader.GetString("NUMERO"), cliente, venditeFattura, reader.GetDateTime("DATA"), reader.GetFloat("SCONTO"), voci, false); // TODO aggiustare
                }

                listaFatture.Add(fattura);
            }

            connessione.Close();
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


            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
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
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
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