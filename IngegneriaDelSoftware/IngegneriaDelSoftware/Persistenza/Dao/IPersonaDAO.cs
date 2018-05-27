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
        bool Aggiorna(Persona vecchiaPersona, Persona nuovaPersona);

    }
}
