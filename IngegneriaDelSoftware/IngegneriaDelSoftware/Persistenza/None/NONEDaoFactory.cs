using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.None
{
    public class NONEDaoFactory : PersistenzaFactory
    {
        #region Singleton
        private static NONEDaoFactory _instance = null;

        protected NONEDaoFactory() { }

        public static NONEDaoFactory GetInstance()
        {
            if (_instance == null)
                _instance = new NONEDaoFactory();
            return _instance;
        }
        #endregion

        public override IAppuntamentoDAO GetAppuntamentoDAO()
        {
            return new NoneGenericoDao();
        }

        public override IClienteDAO GetClienteDAO()
        {
            return new NoneGenericoDao();
        }

        public override IDatoreLavoroDAO GetDatoreLavoroDAO()
        {
            return new NoneGenericoDao();
        }

        public override IEsternoDAO GetEsternoDAO()
        {
            return new NoneGenericoDao();
        }

        public override IFatturaDAO GetFatturaDAO()
        {
            return new NoneGenericoDao();
        }

        public override IIntermediarioDAO GetIntermediarioDAO()
        {
            return new NoneGenericoDao();
        }

        public override IMailInviataDAO GetMailInviataDAO()
        {
            return new NoneGenericoDao();
        }

        public override IPersonaDAO GetPersonaDAO()
        {
            return new NoneGenericoDao();
        }

        public override IPreventivoDAO GetPreventivoDAO()
        {
            return new NoneGenericoDao();
        }

        public override IUtenteDAO GetUtenteDAO()
        {
            throw new NotImplementedException();
        }

        public override IVenditaDAO GetVenditaDAO()
        {
            return new NoneGenericoDao();
        }
    }
}
