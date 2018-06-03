using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsVendita : EventArgs
    {
        public Vendita Vendita { get; private set; }

        public ArgsVendita(Vendita vendita)
        {
            this.Vendita = vendita;
        }

    }
}
