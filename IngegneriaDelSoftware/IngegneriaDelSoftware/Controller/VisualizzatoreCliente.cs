using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Controller
{
    public class VisualizzatoreCliente
    {
        private List<Tuple<Cliente, bool>> _lista = new List<Tuple<Cliente, bool>>();

        public VisualizzatoreCliente(CollezioneClienti collezioneClienti)
        {
            collezioneClienti.OnAggiunta += this.NuovoCliente;
            collezioneClienti.OnRimozione += this.RimossoCliente;

            foreach (Cliente c in collezioneClienti)
            {
                _lista.Add(new Tuple<Cliente, bool>(c, false));
            }
        }

        private void RimossoCliente(object sender, ArgsCliente e)
        {
            this._lista.Remove(this._lista.Find(t => t.Item1.Equals(e.Cliente)));
        }

        private void NuovoCliente(object sender, ArgsCliente e)
        {
            this._lista.Add(new Tuple<Cliente, bool>(e.Cliente, false));
        }

        public Cliente ProssimoCliente()
        {
            foreach (Tuple<Cliente, bool> tupla in _lista)
            {
                if (!tupla.Item2)
                {
                    _lista.Add(new Tuple<Cliente, bool>(tupla.Item1, true));
                    _lista.Remove(tupla);
                    return tupla.Item1;
                }
            }
            return null;
        }

    }
}
