/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

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
        private IComparer<Cliente> _comparatore;

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="filtroSuTuttiCampi">Funzione che dato un <see cref="Cliente"/> e data una <see cref="string"/> restituisce <c>true</c> o <c>false</c>.
        /// La funzione verrà usata in <see cref="ImpostaFiltroTuttiParametri(string)"/></param>
        /// <param name="comparatore">Logica di ordinamento degli elementi</param>
        public VisualizzatoreCliente(Func<Cliente, string, bool> filtroSuTuttiCampi = null, IComparer<Cliente> comparatore = null) : base(filtroSuTuttiCampi)
        {
            this._comparatore = comparatore;

            CollezioneClienti.GetInstance().OnAggiunta += this.NuovoCliente;
            CollezioneClienti.GetInstance().OnRimozione += this.RimossoCliente;

            foreach (Cliente c in CollezioneClienti.GetInstance())
            {
                base.Lista.Add(new OggettoVisualizzato<Cliente>(c, false));
            }
            if (_comparatore != null)
                base.Lista.Sort((x, y) => _comparatore.Compare(x.Oggetto, y.Oggetto));
        }

        #region Gestione eventi
        private void RimossoCliente(object sender, ArgsCliente e)
        {
            base.Lista.Remove(base.Lista.Find(c => c.Oggetto.Equals(e.Cliente)));
        }

        private void NuovoCliente(object sender, ArgsCliente e)
        {
            base.Lista.Add(new OggettoVisualizzato<Cliente>(e.Cliente, false));
            if (_comparatore != null)
                base.Lista.Sort((x, y) => _comparatore.Compare(x.Oggetto, y.Oggetto));
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

        /// <summary>
        /// Imposta un nuovo comparatore che permette di dare una logica diversa di ordinamento. L'invocazione di questo metodo comporta in automatico l'invocazione di <see cref="Visualizzatore{T}.Reset"/>
        /// </summary>
        /// <param name="comparatore">Nuova logica di ordinamento degli elementi</param>
        public void ImpostaComparatore(IComparer<Cliente> comparatore)
        {
            if (comparatore == null)
                return;

            this._comparatore = comparatore;
            base.Lista.Sort((x, y) => _comparatore.Compare(x.Oggetto, y.Oggetto));
            base.Reset();
        }
        #endregion
    }

}
