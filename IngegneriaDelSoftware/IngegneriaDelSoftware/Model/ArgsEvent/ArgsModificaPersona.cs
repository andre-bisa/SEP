using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsModificaPersona : EventArgs
    {
        public Persona Persona { get; private set; }

        public ArgsModificaPersona(Persona persona)
        {
            Persona = persona ?? throw new ArgumentNullException(nameof(persona));
        }
    }
}
