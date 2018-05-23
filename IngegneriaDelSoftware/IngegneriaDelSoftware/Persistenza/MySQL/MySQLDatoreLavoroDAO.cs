using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLDatoreLavoroDAO : IDatoreLavoroDAO
    {
        public bool Aggiorna(DatoreLavoro vecchio, DatoreLavoro nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Crea(DatoreLavoro nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string ID)
        {
            throw new NotImplementedException();
        }

        public DatoreLavoro Leggi(string ID)
        {
            throw new NotImplementedException();
        }

        public List<DatoreLavoro> LeggiTuttiDatoriLavoro()
        {
            throw new NotImplementedException();
        }
    }
}