using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Controller
{
    public class VisualizzatoreCliente : Visualizzatore<Cliente>
    {

        public VisualizzatoreCliente(CollezioneClienti collezioneClienti)
        {
            collezioneClienti.OnAggiunta += this.NuovoCliente;
            collezioneClienti.OnRimozione += this.RimossoCliente;

            foreach (Cliente c in collezioneClienti)
            {
                base.Lista.Add(new OggettoVisualizzato<Cliente>(c, false));
            }
        }

        #region Gestione eventi
        private void RimossoCliente(object sender, ArgsCliente e)
        {
            this.Lista.Remove(this.Lista.Find(c => c.Oggetto.Equals(e.Cliente)));
        }

        private void NuovoCliente(object sender, ArgsCliente e)
        {
            this.Lista.Add(new OggettoVisualizzato<Cliente>(e.Cliente, false));
        }
        #endregion

        #region Metodi pubblici
        /// <summary>
        /// Imposta un filtro che cerca su tutti i campi di <see cref="Cliente"/>
        /// </summary>
        /// <param name="stringaDaCercare">Stringa con il valore inserito</param>
        public override void FiltraSuTuttiICampi(string stringaDaCercare)
        {
            ImpostaFiltro(new Predicate<Cliente>(c => c.IDCliente.Contains(stringaDaCercare)
            || c.Persona.getDenominazione().Contains(stringaDaCercare) || c.Referenti.Any(r => r.Nome.Contains(stringaDaCercare))));
        }

        /// <summary>
        /// Restituisce il prossimo cliente da visualizzare
        /// </summary>
        /// <returns></returns>
        public Cliente ProssimoCliente()
        {
            return base.Prossimo();
        }
        #endregion
    }

}
