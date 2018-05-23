using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IDatoreLavoroDAO
    {
        bool Crea(DatoreLavoro nuovo);

        DatoreLavoro Leggi(string ID);

        bool Aggiorna(DatoreLavoro vecchio, DatoreLavoro nuovo);

        bool Elimina(string ID);

        List<DatoreLavoro> LeggiTuttiDatoriLavoro();
    }
}
