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

        int Accesso(string username, string password);

        bool Aggiorna(Utente vecchia, Utente nuova);

    }
}
