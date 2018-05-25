using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLVenditaDAO : IVenditaDAO
    {
        public bool Aggiorna(Vendita vecchia, Vendita nuova)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Vendita nuova)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(ulong ID)
        {
            throw new NotImplementedException();
        }

        public Vendita Leggi(string ID)
        {
            throw new NotImplementedException();
        }

        public List<Vendita> LeggiTutteVendite()
        {
            throw new NotImplementedException();
        }
    }
}