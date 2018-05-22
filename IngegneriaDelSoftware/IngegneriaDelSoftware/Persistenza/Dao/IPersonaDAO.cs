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
        void Crea(DatiPersona persona);

        Persona Leggi(string CF);

        bool Aggiorna(Persona personaVecchia, DatiPersona datiPersona);

        bool Elimina(string CF);

    }
}
