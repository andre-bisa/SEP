using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent {
    public class ArgsAppuntamento: EventArgs {
        public Appuntamento Appuntamento { get; private set; }

        public ArgsAppuntamento(Appuntamento appuntamento) {
            this.Appuntamento = appuntamento;
        }

    }
}