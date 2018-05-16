using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.View.Controlli
{
    public class ArgsCliente : EventArgs
    {
        public Cliente Cliente { get; private set; }

        public ArgsCliente(Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}
