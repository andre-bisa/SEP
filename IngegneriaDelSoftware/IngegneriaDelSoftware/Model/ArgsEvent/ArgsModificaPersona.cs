using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsModificaPersona : EventArgs
    {
        /// <summary>
        /// La persona modificata
        /// </summary>
        public Persona Persona { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona">La persona modificata</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ArgsModificaPersona(Persona persona)
        {
            if(persona == null) {
                throw new ArgumentNullException(nameof(persona));
            }
            Persona = persona;
        }
    }
}
