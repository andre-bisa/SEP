using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsPreventivo : EventArgs
    {
        public Preventivo Preventivo { get; private set; }

        public ArgsPreventivo(Preventivo preventivo)
        {
            this.Preventivo = preventivo;
        }

    }
}
