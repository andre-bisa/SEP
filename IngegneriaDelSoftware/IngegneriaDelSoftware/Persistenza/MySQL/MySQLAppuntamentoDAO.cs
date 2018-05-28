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
    public class MySQLAppuntamentoDAO : IAppuntamentoDAO
    {

        // Inserisci
        private static readonly string INSERISCI_APPUNTAMENTO = "INSERT INTO APPUNTAMENTO (IDUTENTE,IDAPPUNTAMENTO,DATA,ORA,LUOGO,NOTE)"
            + "VALUES (@idutente,@idappuntamento,@data,@ora,@luogo,@note);";
        private static readonly string INSERISCI_UTENTE = "INSERT INTO UTENTE (IDUTENTE,USERNAME,PASSWORD,PIVA,CF,TELEFONO,INDIRIZZO,MAIL,TIPO,NOME,COGNOME,PROVVIGIONE_DEFAULT,RAGIONE_SOCIALE,SEDE_LEGALE)"
            + "VALUES (@idutente,@username,@password,@piva,@cf,@telefono,@indirizzo,@mail,@tipoU,@nome,@cognome,@provvigione_default,@ragione_sociale,@sede_legale);";

        // Seleziona
        private static readonly string SELEZIONA_TUTTI_APPUNTAMENTI = "SELECT A.IDUTENTE AS IDUTENTE, A.IDAPPUNTAMENTO AS IDAPPUNTAMENTO, A.DATA AS DATA, A.ORA AS ORA, A.LUOGO AS LUOGO, A.NOTE AS NOTE, U.USERNAME AS USERNAME, U.PIVA AS PIVA, U.CF AS CF, U.TELEFONO AS TELEFONO, U.INDIRIZZO AS INDIRIZZO, U.MAIL AS MAIL, U.TIPO AS TIPO_UTENTE, U.NOME AS NOME, U.COGNOME AS COGNOME, U.PROVVIGIONE_DEFAULT, U.RAGIONE_SOCIALE AS RAGIONE_SOCIALE, U.SEDE_LEGALE AS SEDE_LEGALE "
            + "FROM APPUNTAMENTO AS A INNER JOIN UTENTE AS U ON A.IDUTENTE=U.IDUTENTE"
            + "WHERE A.IDUTENTE=@idutente;";
        private static readonly string SELEZIONA_APPUNTAMENTO = "SELECT *"
            + "FROM APPUNTAMENTO"
            + "WHERE IDAPPUNTAMENTO = @idappuntamento AND IDUTENTE = @idutente;";

        // Aggiorna
        private static readonly string AGGIORNA_APPUNTAMENTO = "UPDATE APPUNTAMENTO SET IDAPPUNTAMENTO=@idappuntamento,DATA=@data,ORA=@ora,LUOGO=@luogo,NOTE=@note"
            + "WHERE IDUTENTE=@idutente AND IDAPPUNTAMENTO=@old_idappuntamento;";

        // Elimina
        private static readonly string ELIMINA_APPUNTAMENTO = "DELETE APPUNTAMENTO.*"
            + "FROM APPUNTAMENTO INNER JOIN UTENTE ON APPUNTAMENTO.IDUTENTE=UTENTE.IDUTENTE"
            + "WHERE APPUNTAMENTO.IDAPPUNTAMENTO=@idappuntamento AND APPUNTAMENTO.IDUTENTE=@idutente;";

        /// <summary>
        /// Aggiorna un appuntamento
        /// </summary>
        /// <param name="appuntamentoVecchio"></param>
        /// <param name="nuovoAppuntamento"></param>
        /// <returns>true se l'operazione è stata eseguita con successo</returns>
        public bool Aggiorna(Appuntamento appuntamentoVecchio, Appuntamento nuovoAppuntamento)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += AGGIORNA_APPUNTAMENTO;

            //Riempimento dei parametri della query SQL
            cmd.Parameters.AddWithValue("@idappuntamento", nuovoAppuntamento.IDAppuntamento);
            cmd.Parameters.AddWithValue("@data", nuovoAppuntamento.DataOra.Date);
            cmd.Parameters.AddWithValue("@ora", nuovoAppuntamento.DataOra.Hour);
            cmd.Parameters.AddWithValue("@luogo", nuovoAppuntamento.Luogo);
            cmd.Parameters.AddWithValue("@note", nuovoAppuntamento.Note);

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            cmd.Parameters.AddWithValue("@old_idappuntamento", appuntamentoVecchio.IDAppuntamento);

            cmd.CommandText += "COMMIT;";

            //Esecuzione della query
            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        /// <summary>
        /// Inserisce un appuntamento nel DB
        /// </summary>
        /// <param name="appuntamento">Appuntamento da inserire</param>
        /// <returns></returns>
        public bool Crea(Appuntamento appuntamento)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += INSERISCI_APPUNTAMENTO;

            cmd.Parameters.AddWithValue("@idappuntamento", appuntamento.IDAppuntamento);
            cmd.Parameters.AddWithValue("@data", appuntamento.DataOra.Date);
            cmd.Parameters.AddWithValue("@ora", appuntamento.DataOra.Hour);
            cmd.Parameters.AddWithValue("@luogo", appuntamento.Luogo);
            cmd.Parameters.AddWithValue("@note", appuntamento.Note);

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        public bool Elimina(int ID)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += ELIMINA_APPUNTAMENTO;
            cmd.Parameters.AddWithValue("@idappuntamento", ID);

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        public Appuntamento Leggi(string ID)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return null;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return null;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += SELEZIONA_APPUNTAMENTO;
            cmd.Parameters.AddWithValue("@idappuntamento", ID);

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            MySqlDataReader reader = cmd.ExecuteReader();

            //new Appuntamento(string idDatore, Persona conChi, string note, string luogo, DateTime dataOra);

            /*
             * Come prendere da DB un DateTime a partire da date e time di SQL?
             * Come fare ad estrarre una persona a partire dalla tabella APPUNTAMENTICON che ha 
             * 
             * IDUTENTE int not null,
               IDAPPUNTAMENTO int not null,
               IDINTERMEDIARIO varchar(10) not null,
               IDCLIENTE varchar(10) not null,
               IDESTERNO varchar(10) not null,
             * */

            //Appuntamento appuntamento = new Appuntamento(reader.GetString("IDAPPUNTAMENTO"), reader.GetString);

            connessione.Close();

            return null;
        }

        public List<Appuntamento> LeggiTuttiAppuntamenti()
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return null;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return null;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += SELEZIONA_TUTTI_APPUNTAMENTI;

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            MySqlDataReader reader = cmd.ExecuteReader();

            //new Appuntamento(string idDatore, Persona conChi, string note, string luogo, DateTime dataOra);

            /*
             * Come prendere da DB un DateTime a partire da date e time di SQL?
             * Come fare ad estrarre una persona a partire dalla tabella APPUNTAMENTICON che ha 
             * 
             * IDUTENTE int not null,
               IDAPPUNTAMENTO int not null,
               IDINTERMEDIARIO varchar(10) not null,
               IDCLIENTE varchar(10) not null,
               IDESTERNO varchar(10) not null,
             * */

            //Appuntamento appuntamento = new Appuntamento(reader.GetString("IDAPPUNTAMENTO"), reader.GetString);

            connessione.Close();

            return null;
        }
    }
}