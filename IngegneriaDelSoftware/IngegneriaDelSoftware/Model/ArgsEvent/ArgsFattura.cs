using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsFattura : EventArgs
    {
        public Fattura Fattura { get; private set; }

        public ArgsFattura(Fattura fattura)
        {
            this.Fattura = fattura;
        }

    }
}
