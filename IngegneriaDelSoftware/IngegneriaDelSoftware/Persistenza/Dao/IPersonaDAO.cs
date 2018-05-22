using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IPersonaDAO
    {
        void Crea(DatiPersona persona, string ID);

        Persona Leggi(string ID);

        bool Aggiorna(Persona personaVecchia, DatiPersona datiPersona, string ID);

        bool Elimina(string ID);

    }
}
