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
                connessione = new MySqlConnection("SERVER=andre-bisa.ddns.net;database=SEP;uid=SEP;pwd=password;SslMode=None");
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

        public override IAppuntamentoDAO GetAppuntamentoDAO()
        {
            return new MySQLAppuntamentoDAO();
        }

        public override IDatoreLavoroDAO GetDatoreLavoroDAO()
        {
            return new MySQLDatoreLavoroDAO();
        }

        public override IEsternoDAO GetEsternoDAO()
        {
            return new MySQLEsternoDAO();
        }

        public override IFatturaDAO GetFatturaDAO()
        {
            return new MySQLFatturaDAO();
        }

        public override IIntermediarioDAO GetIntermediarioDAO()
        {
            return new MySQLIntermediarioDAO();
        }

        public override IMailInviataDAO GetMailInviataDAO()
        {
            return new MySQLMailInviataDAO();
        }

        public override IPreventivoDAO GetPreventivoDAO()
        {
            return new MySQLPreventivoDAO();
        }

        public override IUtenteDAO GetUtenteDAO()
        {
            return new MySQLUtenteDAO();
        }

        public override IVenditaDAO GetVenditaDAO()
        {
            return new MySQLVenditaDAO();
        }

        public override IPersonaDAO GetPersonaDAO()
        {
            return new MySQLPersonaDAO();
        }

        #endregion
    }
}
