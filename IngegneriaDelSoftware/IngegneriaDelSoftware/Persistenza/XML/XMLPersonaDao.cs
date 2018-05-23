using IngegneriaDelSoftware.Persistenza.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Persistenza.XML {
    class XMLPersonaDao: IPersonaDAO {
        private string _personaXMLFile;

        public XMLPersonaDao(string personaXMLFile) {
            this._personaXMLFile = personaXMLFile;
        }

        public bool Aggiorna(Persona personaVecchia, DatiPersona datiPersona) {
            throw new NotImplementedException();
        }

        public bool Aggiorna(Persona personaVecchia, DatiPersona datiPersona, string ID) {
            throw new NotImplementedException();
        }

        public void Crea(DatiPersona persona) {
            throw new NotImplementedException();
        }

        public void Crea(DatiPersona persona, string ID) {
            throw new NotImplementedException();
        }

        public bool Elimina(string CF) {
            throw new NotImplementedException();
        }

        public Persona Leggi(string CF) {
            throw new NotImplementedException();
        }
    }
}
