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
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += AGGIORNA_VENDITA;

            cmd.CommandText += "DELETE FROM VOCEVENDITA WHERE IDUTENTE=@idutente AND IDVENDITA=@oldidvendita;";

            System.Globalization.CultureInfo backup = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            int maxNumeroVoce = 1;
            foreach (VoceVendita voce in nuova)
            {
                string provvigione = "NULL";
                cmd.CommandText += "INSERT INTO VOCEVENDITA(IDUTENTE,IDVENDITA,NUMERO,DESCRIZIONE,TIPOLOGIA,QUANTITA,PROVVIGIONE,IMPORTO) VALUES(@idutente,@idvendita," + maxNumeroVoce + ",'" + voce.Causale + "','" + voce.Tipologia + "'," + voce.Quantita + "," + provvigione + "," + voce.Importo + ");";
                maxNumeroVoce++;
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = backup;

            InserisciParametriVendita(nuova, cmd);

            cmd.CommandText += "COMMIT;";
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

            System.Globalization.CultureInfo backup = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            int maxNumeroVoce = 1;
            foreach (VoceVendita voce in vendita.Voci)
            {
                string provvigione = "NULL";
                cmd.CommandText += "INSERT INTO VOCEVENDITA(IDUTENTE,IDVENDITA,NUMERO,DESCRIZIONE,TIPOLOGIA,QUANTITA,PROVVIGIONE,IMPORTO) VALUES(@idutente,@idvendita," + maxNumeroVoce + ",'" + voce.Causale + "','" + voce.Tipologia + "'," + voce.Quantita + "," + provvigione + "," + voce.Importo + ");";
                maxNumeroVoce++;
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = backup;

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