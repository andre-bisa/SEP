using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLFatturaDAO : IFatturaDAO
    {
        public bool Aggiorna(Fattura vecchia, Fattura nuova)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Fattura nuova)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string ID)
        {
            throw new NotImplementedException();
        }

        public Fattura Leggi(string ID)
        {
            throw new NotImplementedException();
        }
    }
}