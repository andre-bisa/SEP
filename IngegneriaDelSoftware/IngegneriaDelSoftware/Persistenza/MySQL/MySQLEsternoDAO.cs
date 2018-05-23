using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLEsternoDAO : IEsternoDAO
    {
        public bool Aggiorna(Esterno vecchio, Esterno nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Esterno nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string ID)
        {
            throw new NotImplementedException();
        }

        public Esterno Leggi(string ID)
        {
            throw new NotImplementedException();
        }
    }
}