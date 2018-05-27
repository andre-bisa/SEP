using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;
using IngegneriaDelSoftware.Persistenza.MySQL;
using MySql.Data.MySqlClient;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLUtenteDAO : IUtenteDAO
    {
        public bool Aggiorna(Utente vecchia, Utente nuova)
        {
            throw new NotImplementedException();
        }

        public int Accesso(string username, string password)
        {
            int IDUtente = -1;
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                throw new ExceptionPersistenza();

            MySqlCommand cmd = connessione.CreateCommand();

            if (cmd == null)
                throw new ExceptionPersistenza();

            cmd.CommandText = "SELECT IDUTENTE FROM UTENTE WHERE USERNAME=@username AND PASSWORD=@password";

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (!reader.IsDBNull(0))
                    IDUtente = reader.GetInt32("IDUTENTE");
                else 
                    IDUtente = -1;  // utente non trovato
            }

            connessione.Close();
            return IDUtente;
        }
    }
}