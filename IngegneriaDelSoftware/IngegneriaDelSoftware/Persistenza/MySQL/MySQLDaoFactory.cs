using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza;
using IngegneriaDelSoftware.Persistenza.Dao;
using MySql.Data.MySqlClient;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLDaoFactory : PersistenzaFactory
    {
        #region Singleton
        private static MySQLDaoFactory _instance = null;

        protected MySQLDaoFactory() { }

        public static MySQLDaoFactory GetInstance()
        {
            if (_instance == null)
                _instance = new MySQLDaoFactory();
            return _instance;
        }
        #endregion

        private static MySqlConnection connessione;
        public static MySqlConnection ApriConnessione()
        {
            try
            {
                connessione = new MySqlConnection("SERVER=andre-bisa.ddns.net;database=SEP;uid=SEP;password=password");
                if (connessione != null)
                    connessione.Open();
            } catch (MySqlException e)
            {
                connessione = null;
            }
            return connessione;
        }

        public static void ChiudiConnessione()
        {
            if (connessione != null)
                connessione.Close();
        }

        #region Getters della Factory
        public override IClienteDAO GetClienteDAO()
        {
            return new MySQLClienteDAO();
        }

        public override IPersonaDAO GetPersonaDAO()
        {
            return new MySQLPersonaDAO();
        }
        #endregion
    }
}
