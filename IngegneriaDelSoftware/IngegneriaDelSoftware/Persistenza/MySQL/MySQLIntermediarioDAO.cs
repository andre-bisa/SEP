using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLIntermediarioDAO : IIntermediarioDAO
    {
        public bool Aggiorna(Intermediario vecchio, Intermediario nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Intermediario nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string ID)
        {
            throw new NotImplementedException();
        }

        public Intermediario Leggi(string ID)
        {
            throw new NotImplementedException();
        }
    }
}