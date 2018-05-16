using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.View.Controlli
{
    public class ArgsPannelloCliente : ArgsCliente
    {
        public PannelloCliente PannelloCliente { get; private set; }

        public ArgsPannelloCliente(Cliente cliente, PannelloCliente pannelloCliente) : base(cliente)
        {
            PannelloCliente = pannelloCliente;
        }

    }
}
