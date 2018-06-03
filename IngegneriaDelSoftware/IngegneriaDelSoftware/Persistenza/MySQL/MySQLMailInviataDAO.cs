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
    public class MySQLMailInviataDAO : IMailInviataDAO
    {

        private readonly static string INSERISCI_MAIL = "INSERT INTO MAILINVIATA(IDUTENTE, IDMAIL, MAIL, DATA, OGGETTO, CORPO) VALUES(@idutente,@idmail,@mail,@data,@oggetto,@corpo);";
        private static readonly string SELEZIONA_ULTIMO_ID_MAIL = "SELECT MAX(IDMAIL) AS MAX FROM MAILINVIATA WHERE IDUTENTE = @idutente;";

        private static readonly string LEGGI_TUTTE_MAIL_INVIATE = "SELECT M.MAIL, M.DATA, M.OGGETTO, M.CORPO FROM MAILINVIATA AS M WHERE IDUTENTE = @idutente;";

        public bool Crea(MailInviata nuova)
        {
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                return false;

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += INSERISCI_MAIL;

            int IDMail = NuovoNumeroMailLibero();

            cmd.Parameters.AddWithValue("@idmail", IDMail);
            cmd.Parameters.AddWithValue("@mail", nuova.Email);
            cmd.Parameters.AddWithValue("@data", nuova.Data);
            cmd.Parameters.AddWithValue("@oggetto", nuova.Oggetto);
            cmd.Parameters.AddWithValue("@corpo", nuova.Corpo);

            cmd.CommandText += "COMMIT;";

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche >= 1);
        }

        private int NuovoNumeroMailLibero()
        {
            int ultimoID = -2;
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = SELEZIONA_ULTIMO_ID_MAIL;

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

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

        public List<MailInviata> GetListaMailInviate()
        {
            List<MailInviata> listaMail = new List<MailInviata>();

            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = "START TRANSACTION;";

            cmd.CommandText += LEGGI_TUTTE_MAIL_INVIATE;

            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MailInviata mail = new MailInviata(reader.GetDateTime("DATA"), reader.GetString("OGGETTO"), reader.GetString("CORPO"), reader.GetString("MAIL"));
                listaMail.Add(mail);
            }

            connessione.Close();

            return listaMail;
        }
    }
}