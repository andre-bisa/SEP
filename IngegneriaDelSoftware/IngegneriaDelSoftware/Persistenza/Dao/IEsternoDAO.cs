using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IEsternoDAO
    {
        bool Crea(Esterno nuovo);

        Esterno Leggi(string ID);

        bool Aggiorna(Esterno vecchio, Esterno nuovo);

        bool Elimina(string ID);

    }
}
