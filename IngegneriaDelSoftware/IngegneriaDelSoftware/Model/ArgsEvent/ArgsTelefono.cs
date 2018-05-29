using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsTelefono : EventArgs
    {
        public Telefono Telefono { get; private set; }

        public ArgsTelefono (Telefono telefono)
        {
            this.Telefono = telefono;
        }
    }
}
