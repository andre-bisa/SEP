using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.View
{
    class ClienteMostrato<T>
    {
        public Cliente Cliente { get; }
        public T DoveMostrato { get; set; }
        public bool Selezionato { get; set; }

        public ClienteMostrato(Cliente cliente, T doveMostrato, bool selezionato)
        {
            this.Cliente = cliente;
            this.DoveMostrato = doveMostrato;
            this.Selezionato = selezionato;
        }
    }
}
