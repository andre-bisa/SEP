using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IFatturaDAO
    {
        bool Crea(Fattura nuova);

        Fattura Leggi(string ID);

        bool Aggiorna(Fattura vecchia, Fattura nuova);

        bool Elimina(string ID);

    }
}
