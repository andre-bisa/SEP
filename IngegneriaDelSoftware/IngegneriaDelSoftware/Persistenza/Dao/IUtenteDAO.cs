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
        bool Crea(Utente utente);

        Cliente Leggi(string IDUtente);

        bool Aggiorna(Utente utenteVecchio, Utente utenteNuovo);

        bool Elimina(string IDUtente);

        List<Utente> LeggiTuttiUtenti();

    }
}
