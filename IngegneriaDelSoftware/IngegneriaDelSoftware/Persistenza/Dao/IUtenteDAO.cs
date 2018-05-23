using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IUtenteDAO
    {
        bool Crea(Utente nuova);

        Utente Leggi(string ID);

        bool Aggiorna(Utente vecchia, Utente nuova);

    }
}
