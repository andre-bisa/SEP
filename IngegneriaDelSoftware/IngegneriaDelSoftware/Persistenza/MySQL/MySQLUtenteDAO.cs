using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLUtenteDAO : IUtenteDAO
    {
        public bool Aggiorna(Utente vecchia, Utente nuova)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Utente nuova)
        {
            throw new NotImplementedException();
        }

        public Utente Leggi(string ID)
        {
            throw new NotImplementedException();
        }
    }
}