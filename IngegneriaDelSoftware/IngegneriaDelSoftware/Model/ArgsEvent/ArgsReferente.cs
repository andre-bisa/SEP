using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsReferente : EventArgs
    {
        public Referente Referente { get; private set; }

        public ArgsReferente (Referente referente)
        {
            this.Referente = referente;
        }
    }
}
