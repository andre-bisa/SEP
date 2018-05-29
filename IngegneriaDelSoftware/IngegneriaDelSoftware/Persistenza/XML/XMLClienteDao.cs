using IngegneriaDelSoftware.Persistenza.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using System.Xml;

namespace IngegneriaDelSoftware.Persistenza.XML {
    class XMLClienteDao: IClienteDAO {
        private string _clienteXMLFile;

        public XMLClienteDao(string clienteXMLFile) {
            this._clienteXMLFile = clienteXMLFile;
        }

        public bool Aggiorna(Cliente clienteVecchio, Cliente clienteNuovo) {
            throw new NotImplementedException();
        }

        public bool Aggiorna(Cliente clienteVecchio, DatiCliente datiCliente, DatiPersona datiPersona) {
            throw new NotImplementedException();
        }

        public bool Crea(Cliente cliente) {
            throw new NotImplementedException();
        }

        public void Crea(DatiCliente datiCliente, DatiPersona persona) {
            throw new NotImplementedException();
        }

        public bool Elimina(string IDCliente) {
            throw new NotImplementedException();
        }

        public bool InserisciReferente(Referente referente, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Leggi(string IDCliente) {
            throw new NotImplementedException();
        }

        public List<Cliente> LeggiTuttiClienti() {
            throw new NotImplementedException();
        }

        public bool RimuoviReferente(Referente referente, Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
