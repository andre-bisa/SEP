using IngegneriaDelSoftware.Persistenza.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLUtenteDAO : IUtenteDAO
    {
        public bool Aggiorna(Utente utenteVecchio, Utente utenteNuovo)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Utente utente)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string IDUtente)
        {
            throw new NotImplementedException();
        }

        public Cliente Leggi(string IDUtente)
        {
            throw new NotImplementedException();
        }

        public List<Utente> LeggiTuttiUtenti()
        {
            throw new NotImplementedException();
        }
    }
}
