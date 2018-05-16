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
        public int Cliente { get; private set; }
        public UserControl UserControl { get; private set; }

        public ArgsCliente(int cliente, UserControl userControl)
        {
            Cliente = cliente;
            UserControl = userControl;
        }
    }
}
