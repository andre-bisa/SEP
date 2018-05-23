using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLPreventivoDAO : IPreventivoDAO
    {
        public bool Aggiorna(Preventivo vecchio, Preventivo nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Preventivo nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string ID)
        {
            throw new NotImplementedException();
        }

        public Preventivo Leggi(string ID)
        {
            throw new NotImplementedException();
        }
    }
}