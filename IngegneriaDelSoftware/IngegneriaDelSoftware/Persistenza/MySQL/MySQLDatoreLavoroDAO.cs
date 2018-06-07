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
    public class MySQLDatoreLavoroDAO : IDatoreLavoroDAO
    {
        // Inserisci
        private static readonly string INSERISCI_DATORE_LAVORO = "INSERT INTO DATORE_LAVORO (IDDATORELAVORO,NOME,COGNOME,RAGIONE_SOCIALE,PIVA,CF,TELEFONO,INDIRIZZO,MAIL,IDUTENTE)"
            + " VALUES (@iddatorelavoro,@nome,@cognome,@ragione_sociale,@piva,@cf,@telefono,@indirizzo,@mail,@idutente);";

        // Seleziona
        private static readonly string SELEZIONA_TUTTI_DATORI_LAVORO = "SELECT * "
            + " FROM DATORELAVORO AS D INNER JOIN UTENTE AS U ON D.IDUTENTE=U.IDUTENTE"
            + " WHERE D.IDUTENTE=@idutente;";
        private static readonly string SELEZIONA_DATORE_LAVORO = "SELECT *"
            + " FROM DATORELAVORO"
            + " WHERE IDDATORELAVORO = @iddatorelavoro AND IDUTENTE = @idutente;";

        // Aggiorna
        private static readonly string AGGIORNA_DATORE_LAVORO = "UPDATE DATORELAVORO"
            + " SET IDDATORELAVORO=@iddatorelavoro,NOME=@nome,COGNOME=@cognome,RAGIONE_SOCIALE=@ragione_sociale,PIVA=@piva,CF=@cf,TELEFONO=@telefono,INDIRIZZO=@indirizzo,MAIL=@mail"
            + " WHERE IDUTENTE=@idutente AND IDDATORELAVORO=@old_iddatorelavoro;";

        // Elimina
        private static readonly string ELIMINA_DATORE_LAVORO = "DELETE DATORELAVORO.*"
            + " FROM DATORELAVORO INNER JOIN UTENTE ON DATORELAVORO.IDUTENTE=UTENTE.IDUTENTE"
            + " WHERE DATORELAVORO.IDDATORELAVORO=@iddatorelavoro AND DATORELAVORO.IDUTENTE=@idutente;";

        /// <summary>
        /// Aggiorna un certo DatoreLavoro
        /// </summary>
        /// <param name="vecchio"></param>
        /// <param name="nuovo"></param>
        /// <returns></returns>
        public bool Aggiorna(DatoreLavoro vecchio, DatoreLavoro nuovo)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += AGGIORNA_DATORE_LAVORO;

            //Riempimento dei parametri della query SQL
            cmd.Parameters.AddWithValue("@iddatorelavoro", nuovo.IDDatoreLavoro);
            cmd.Parameters.AddWithValue("@nome", nuovo.Nome);
            cmd.Parameters.AddWithValue("@cognome", nuovo.Cognome);
            cmd.Parameters.AddWithValue("@ragione_sociale", nuovo.RagioneSociale);
            cmd.Parameters.AddWithValue("@piva", nuovo.PartitaIva);
            cmd.Parameters.AddWithValue("@cf", nuovo.CodiceFiscale);
            cmd.Parameters.AddWithValue("@telefono", nuovo.Telefoni.ToString());
            cmd.Parameters.AddWithValue("@indirizzo", nuovo.Indirizzo);
            cmd.Parameters.AddWithValue("@mail", nuovo.Email.ToString());

            cmd.Parameters.AddWithValue("@idutente", "1");       // <-------------- TODO inserire IDUTENTE

            cmd.Parameters.AddWithValue("@old_iddatorelavoro", vecchio.IDDatoreLavoro);

            cmd.CommandText += "COMMIT;";

            //Esecuzione della query
            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        /// <summary>
        /// Inserisce un DatoreLavoro nel DB
        /// </summary>
        /// <param name="nuovo"></param>
        /// <returns></returns>
        public bool Crea(DatoreLavoro nuovo)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += INSERISCI_DATORE_LAVORO;

            //Riempimento dei parametri della query SQL
            cmd.Parameters.AddWithValue("@iddatorelavoro", nuovo.IDDatoreLavoro);
            cmd.Parameters.AddWithValue("@nome", nuovo.Nome);
            cmd.Parameters.AddWithValue("@cognome", nuovo.Cognome);
            cmd.Parameters.AddWithValue("@ragione_sociale", nuovo.RagioneSociale);
            cmd.Parameters.AddWithValue("@piva", nuovo.PartitaIva);
            cmd.Parameters.AddWithValue("@cf", nuovo.CodiceFiscale);
            cmd.Parameters.AddWithValue("@telefono", nuovo.Telefoni.ToString());
            cmd.Parameters.AddWithValue("@indirizzo", nuovo.Indirizzo);
            cmd.Parameters.AddWithValue("@mail", nuovo.Email.ToString());

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            cmd.CommandText += "COMMIT;";

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        /// <summary>
        /// Elimina dal DB un certo DatoreLavoro
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Elimina(string ID)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += ELIMINA_DATORE_LAVORO;
            cmd.Parameters.AddWithValue("@idappuntamento", ID);

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        /// <summary>
        /// Legge un certo DatoreLavoro dal DB
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DatoreLavoro Leggi(string ID)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return null;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return null;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += SELEZIONA_DATORE_LAVORO;
            cmd.Parameters.AddWithValue("@iddatorelavoro", ID);

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            MySqlDataReader reader = cmd.ExecuteReader();

            DatoreLavoro datoreLavoro = new DatoreLavoro(reader.GetString("IDDATORELAVORO"), reader.GetString("NOME"), 
                reader.GetString("COGNOME"), reader.GetString("PIVA"), reader.GetString("CF"), reader.GetString("RAGIONE_SOCIALE"),
                reader.GetString("INDIRIZZO"), (List<Telefono>) reader.GetValue(7),  (Email) reader.GetValue(9));

            connessione.Close();

            return datoreLavoro;
        }

        /// <summary>
        /// Ritorna tutti i DatoreLavoro nel DB per un certo utente
        /// </summary>
        /// <returns>Ritorna tutti i DatoreLavoro nel DB per un certo utente</returns>
        public List<DatoreLavoro> LeggiTuttiDatoriLavoro()
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return null;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return null;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += SELEZIONA_TUTTI_DATORI_LAVORO;

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<DatoreLavoro> risultato = new List<DatoreLavoro>();

            while (reader.Read())
            {
                DatoreLavoro datoreLavoro = new DatoreLavoro(reader.GetString("IDDATORELAVORO"), reader.GetString("NOME"),
                    reader.GetString("COGNOME"), reader.GetString("PIVA"), reader.GetString("CF"), reader.GetString("RAGIONE_SOCIALE"),
                    reader.GetString("INDIRIZZO"), (List<Telefono>)reader.GetValue(7), (Email)reader.GetValue(9));

                risultato.Add(datoreLavoro);
            }
            connessione.Close();

            return risultato;
        }
    }
}