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
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class CollezioneReferenti : ICollection<Referente>, IEnumerable<Referente>
    {
        public event EventHandler<ArgsReferente> OnAggiunta;
        public event EventHandler<ArgsReferente> OnRimozione;

        //Set poiche' non ha senso aggiungere due o piu' referenti uguali
        private HashSet<Referente> _referenti;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="referenti">Referenti iniziali</param>
        public CollezioneReferenti(IEnumerable<Referente> referenti = null)
        {
            //Se argomento nullo dà lista vuota, altrimenti crea una copia della lista data
            _referenti = (referenti == null) ? new HashSet<Referente>() : new HashSet<Referente>(referenti);
        }

        public int Count
        {
            get { return ((ICollection<Referente>)_referenti).Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<Referente>)_referenti).IsReadOnly; }
        }

        /// <summary>
        /// Aggiunge un referente alla lista
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(Referente item)
        {
            if (_referenti.Contains(item))
                return;

            ((ICollection<Referente>)_referenti).Add(item);
            if (OnAggiunta != null)
            {
                ArgsReferente args = new ArgsReferente(item);
                OnAggiunta(this, args);
            }
        }

        /// <summary>
        /// Funzione non supportata!
        /// </summary>
        public void Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Ricerca un referente nella lista
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public bool Contains(Referente item)
        {
            return ((ICollection<Referente>)_referenti).Contains(item);
        }

        public void CopyTo(Referente[] array, int arrayIndex)
        {
            ((ICollection<Referente>)_referenti).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Referente> GetEnumerator()
        {
            return ((ICollection<Referente>)_referenti).GetEnumerator();
        }

        /// <summary>
        /// Rimuove un dato referente nella lista
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Remove(Referente item)
        {
            bool risultato = ((ICollection<Referente>)_referenti).Remove(item);
            if (OnRimozione != null)
            {
                ArgsReferente args = new ArgsReferente(item);
                OnRimozione(this, args);
            }
            return risultato;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<Referente>)_referenti).GetEnumerator();
        }

        /// <summary>
        /// Accede all'i-esimo elemento della lista
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Referente this[int i]
        {
            get { return _referenti.ElementAt<Referente>(i); }
        }

        public override string ToString()
        {
            return String.Join(",", this._referenti);
        }
    }
}
