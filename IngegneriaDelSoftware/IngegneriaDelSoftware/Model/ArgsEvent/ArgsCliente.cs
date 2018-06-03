using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsCliente : EventArgs
    {
        public Cliente Cliente { get; private set; }

        public ArgsCliente(Cliente cliente)
        {
            this.Cliente = cliente;
        }

    }
}
