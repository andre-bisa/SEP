using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IIntermediarioDAO
    {
        bool Crea(Intermediario nuovo);

        Intermediario Leggi(string ID);

        bool Aggiorna(Intermediario vecchio, Intermediario nuovo);

        bool Elimina(string ID);
    }
}
