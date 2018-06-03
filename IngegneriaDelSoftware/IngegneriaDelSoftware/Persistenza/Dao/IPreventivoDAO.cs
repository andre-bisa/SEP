using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IPreventivoDAO
    {
        bool Crea(Preventivo nuovo);

        bool Aggiorna(Preventivo vecchio, Preventivo nuovo);

        bool Elimina(ulong ID);

        List<Preventivo> LeggiTuttiPreventivi();
    }
}
