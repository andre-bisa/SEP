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

using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller
{
    public abstract class Visualizzatore<T>
    {
        /// <summary>
        /// Lista di <see cref="OggettoVisualizzato{T}"/>
        /// </summary>
        protected List<OggettoVisualizzato<T>> Lista { get; } = new List<OggettoVisualizzato<T>>();

        /// <summary>
        /// Filtro che si applicherà quando verrà richiesto un <see cref="T"/>
        /// </summary>
        protected Predicate<OggettoVisualizzato<T>> Filtro { get; private set; }

        private Func<T, string, bool> _filtroTuttiCampi;

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="filtroTuttiCampi">Funzione che dato un <see cref="T"/> e data una <see cref="string"/> restituisce <c>true</c> o <c>false</c>.
        /// La funzione verrà usata in <see cref="ImpostaFiltroTuttiParametri(string)"/></param>
        protected Visualizzatore(Func<T, string, bool> filtroTuttiCampi = null)
        {
            Filtro = new Predicate<OggettoVisualizzato<T>>(o => true); // di base accetta tutto
            this._filtroTuttiCampi = filtroTuttiCampi; // può essere null
        }

        /// <summary>
        /// Restituisce il numero di <see cref="T"/> che possono essere restituiti con il filtro applicato
        /// </summary>
        public int Count
        {
            get
            {
                return this.Lista.FindAll(this.Filtro).Count;
            }
        }

        #region Metodi pubblici
        /// <summary>
        /// Funzione che dice se l'oggetto è positivo o meno al filtro impostato.
        /// </summary>
        /// <param name="oggetto">Oggetto su cui testare il filtro</param>
        /// <returns>true se l'oggetto è positivo al filtro impostato</returns>
        public bool Visualizzabile(T oggetto)
        {
            OggettoVisualizzato<T> mockOggettoVisualizzato = new OggettoVisualizzato<T>(oggetto, false);
            return this.Filtro.Invoke(mockOggettoVisualizzato);
        }

        /// <summary>
        /// Imposta un filtro che cerca su tutti i campi. Si basa sulla funzione passata al costruttore
        /// </summary>
        /// <param name="stringaDaCercare">Stringa con il valore inserito</param>
        public void ImpostaFiltroTuttiParametri(string stringaDaCercare)
        {
            if (this._filtroTuttiCampi == null)
                return;
            if (stringaDaCercare.Length != 0)
                ImpostaFiltro(new Predicate<T>(t => this._filtroTuttiCampi.Invoke(t, stringaDaCercare)));
            else
                ImpostaFiltro(new Predicate<T>(t => true));
        }

        /// <summary>
        /// Imposta il nuovo filtro.
        /// N.B. NON verranno riproposti i clienti già dati con <see cref="Prossimo"/>, per vedere tutti gli oggetti utilizzare <see cref="Reset"/>
        /// </summary>
        /// <param name="filtro">Nuovo filtro che verrà applicato agli oggetti</param>
        /// <exception cref="ArgumentNullException">Se passato un filtro nullo</exception>
        public void ImpostaFiltro(Predicate<T> filtro)
        {
            if (filtro == null)
                throw new ArgumentNullException("Errore. Il filtro è nullo.");

            this.Filtro = new Predicate<OggettoVisualizzato<T>>(c => filtro.Invoke(c.Oggetto));

            var queryNonDevonoPiuEssereVisualizzati =
                (from coppia in this.Lista
                 where !filtro.Invoke(coppia.Oggetto)   // dove il filtro non è applicabile
                 select coppia
                 );

            foreach (OggettoVisualizzato<T> coppia in queryNonDevonoPiuEssereVisualizzati)
            {
                coppia.Visualizzato = false;
            }
        }

        /// <summary>
        /// Restituisce il prossimo <see cref="T"/> da visualizzare, <c>default(T)</c> se sono terminati i <see cref="T"/>
        /// </summary>
        /// <returns>Il <see cref="T"/>, <c>default(T)</c> se sono terminati</returns>
        public T Prossimo()
        {
            foreach (OggettoVisualizzato<T> oggetto in this.Lista.FindAll(this.Filtro))
            {
                if (!oggetto.Visualizzato)
                {
                    oggetto.Visualizzato = true;
                    return oggetto.Oggetto;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Dopo la chiamata a questa funzione verranno riproposti tutti gli oggetti
        /// </summary>
        public void Reset()
        {
            foreach (OggettoVisualizzato<T> oggetto in this.Lista)
            {
                oggetto.Visualizzato = false;
            }
        }
        #endregion
    }
}
