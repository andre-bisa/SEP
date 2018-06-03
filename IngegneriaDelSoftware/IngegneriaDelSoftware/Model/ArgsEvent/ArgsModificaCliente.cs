using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsModificaCliente : EventArgs
    {
        /// <summary>
        /// Il cliente modificato
        /// </summary>
        public Cliente Cliente { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente">Il cliente modificato</param>
        /// throw new ArgumentNullException(nameof(persona));
        public ArgsModificaCliente(Cliente cliente)
        {
            if(cliente == null) {
                throw new ArgumentNullException(nameof(cliente));
            }
            Cliente = cliente;
        }
    }
}
