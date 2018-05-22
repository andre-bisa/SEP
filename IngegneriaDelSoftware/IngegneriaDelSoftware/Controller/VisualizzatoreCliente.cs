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

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="collezioneClienti">Collezione di clienti da cui partire</param>
        /// <param name="filtroSuTuttiCampi">Funzione che dato un <see cref="Cliente"/> e data una <see cref="string"/> restituisce <c>true</c> o <c>false</c>.
        /// La funzione verrà usata in <see cref="ImpostaFiltroTuttiParametri(string)"/></param>
        public VisualizzatoreCliente(CollezioneClienti collezioneClienti, Func<Cliente, string, bool> filtroSuTuttiCampi = null) : base(filtroSuTuttiCampi)
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
        /// Restituisce il prossimo <see cref="Cliente"/> da visualizzare, <c>null</c> se sono terminati i <see cref="Cliente"/>
        /// </summary>
        /// <returns>Il <see cref="Cliente"/>, <c>null</c> se sono terminati</returns>
        public Cliente ProssimoCliente()
        {
            return base.Prossimo();
        }
        #endregion
    }

}
