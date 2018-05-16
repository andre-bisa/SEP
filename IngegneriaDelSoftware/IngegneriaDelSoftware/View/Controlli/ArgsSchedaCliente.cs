using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.View.Controlli
{
    public class ArgsSchedaCliente : ArgsCliente
    {
        public SchedaCliente SchedaCliente { get; private set; }

        public ArgsSchedaCliente(Cliente cliente, SchedaCliente schedaCliente) : base(cliente)
        {
            SchedaCliente = schedaCliente;
        }
    }
}
