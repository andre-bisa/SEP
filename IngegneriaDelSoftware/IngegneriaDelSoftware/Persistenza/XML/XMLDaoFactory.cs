using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.XML {
    class XMLDaoFactory: PersistenzaFactory {

        private string _clienteXMLFile;
        private string _personaXMLFile;

        public string ClienteXMLFile {
            get {
                return _clienteXMLFile;
            }
        }

        public string PersonaXMLFile {
            get {
                return _personaXMLFile;
            }
        }

        protected XMLDaoFactory(string clienteXMLFile, string personaXMLFile) {
            this._clienteXMLFile = clienteXMLFile;
            this._personaXMLFile = personaXMLFile;
        }

        #region Singleton
        private static XMLDaoFactory _instance = null;

        //TODO fix this;
        public static XMLDaoFactory GetInstance(string clienteXMLFile = null, string personaXMLFile = null) {
            if(_instance == null)
                if(clienteXMLFile == null && personaXMLFile == null) {
                    throw new ArgumentNullException("L'inizializzazione deve avere gli attributi diversi da null");
                }
                _instance = new XMLDaoFactory(clienteXMLFile, personaXMLFile);
            return _instance;
        }
        #endregion
        

        public override IClienteDAO GetClienteDAO() {
            return new XMLClienteDao(this._clienteXMLFile);
        }

        public override IAppuntamentoDAO GetAppuntamentoDAO() {
            throw new NotImplementedException();
        }

        public override IDatoreLavoroDAO GetDatoreLavoroDAO() {
            throw new NotImplementedException();
        }

        public override IEsternoDAO GetEsternoDAO() {
            throw new NotImplementedException();
        }

        public override IFatturaDAO GetFatturaDAO() {
            throw new NotImplementedException();
        }

        public override IIntermediarioDAO GetIntermediarioDAO() {
            throw new NotImplementedException();
        }

        public override IMailInviataDAO GetMailInviataDAO() {
            throw new NotImplementedException();
        }

        public override IPreventivoDAO GetPreventivoDAO() {
            throw new NotImplementedException();
        }

        public override IUtenteDAO GetUtenteDAO() {
            throw new NotImplementedException();
        }

        public override IVenditaDAO GetVenditaDAO() {
            throw new NotImplementedException();
        }

        public override IPersonaDAO GetPersonaDAO()
        {
            throw new NotImplementedException();
        }
    }
}
