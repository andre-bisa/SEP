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
    public class MySQLPreventivoDAO : IPreventivoDAO
    {
        // Aggiorna
        private static string AGGIORNA_PREVENTIVO = "UPDATE PREVENTIVO SET DATA=@data,ACCETTATO=@accettato,IDCLIENTE=@idcliente WHERE IDUTENTE=@idutente AND IDPREVENTIVO=@idpreventivo;";

        // Inserisci
        private static string INSERISCI_PREVENTIVO = "INSERT INTO PREVENTIVO(IDUTENTE, IDPREVENTIVO, DATA, ACCETTATO, IDCLIENTE) VALUES (@idutente,@idpreventivo,@data,@accettato,@idcliente);";

        // Seleziona
        private static string SELEZIONA_TUTTI_PREVENTIVI = "SELECT P.IDPREVENTIVO AS IDPREVENTIVO,P.DATA AS DATA, P.ACCETTATO AS ACCETTATO, P.IDCLIENTE FROM PREVENTIVO AS P WHERE IDUTENTE=@idutente;";
        private static string SELEZIONA_TUTTE_VOCI_PREVENTIVO = "SELECT V.NUMERO AS NUMERO, V.DESCRIZIONE AS DESCRIZIONE, V.TIPOLOGIA AS TIPOLOGIA, V.QUANTITA AS QUANTITA, V.IMPORTO AS IMPORTO FROM VOCEPREVENTIVO AS V WHERE IDUTENTE=@idutente AND IDPREVENTIVO=@idpreventivo;";

        public bool Aggiorna(Preventivo vecchio, Preventivo nuovo)
        { // NOT TESTED!
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = AGGIORNA_PREVENTIVO;

            InserisciParametriPreventivo(nuovo, cmd);

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        public bool Crea(Preventivo preventivo)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

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
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

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
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = SELEZIONA_TUTTI_PREVENTIVI;

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = CollezioneClienti.GetInstance().Get(reader.GetString("IDCLIENTE"));
                List<VocePreventivo> voci = OttieniVociPreventivo(reader.GetUInt64("IDPREVENTIVO"));
                Preventivo preventivo = new Preventivo(reader.GetUInt64("IDPREVENTIVO"), cliente, reader.GetDateTime("DATA"), reader.GetBoolean("ACCETTATO"), voci);
                listaPreventivo.Add(preventivo);
            }

            connessione.Close();
            return listaPreventivo;
        }

        private List<VocePreventivo> OttieniVociPreventivo(ulong idPreventivo)
        {
            List<VocePreventivo> vociPreventivo = new List<VocePreventivo>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = SELEZIONA_TUTTE_VOCI_PREVENTIVO;
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
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