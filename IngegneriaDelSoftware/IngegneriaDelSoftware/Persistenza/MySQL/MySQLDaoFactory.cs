using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza;
using IngegneriaDelSoftware.Persistenza.Dao;

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

        public static void ApriConnessione() // TODO da cambiare il ritorno
        {

        }

        public static void ChiudiConnessione()
        {
            // TODO da implementare
        }

        #region Getters della Factory
        public override ClienteDAO GetClienteDAO()
        {
            return new MySQLClienteDAO();
        }

        public override PersonaDAO GetPersonaDAO()
        {
            return new MySQLPersonaDAO();
        }
        #endregion
    }
}
