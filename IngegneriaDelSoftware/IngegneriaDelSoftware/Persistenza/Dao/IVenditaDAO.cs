using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IVenditaDAO
    {
        bool Crea(Vendita nuova);

        bool Aggiorna(Vendita vecchia, Vendita nuova);

        bool Elimina(ulong ID);

        List<Vendita> LeggiTutteVendite();
    }
}
