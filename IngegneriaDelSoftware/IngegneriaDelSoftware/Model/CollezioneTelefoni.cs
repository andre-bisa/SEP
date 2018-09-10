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
 
 using IngegneriaDelSoftware.Model.ArgsEvent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class CollezioneTelefoni : ICollection<Telefono>, IEnumerable<Telefono>
    {
        public event EventHandler<ArgsTelefono> OnAggiunta;
        public event EventHandler<ArgsTelefono> OnRimozione;

        //Set poiche' non ha senso aggiungere due o piu' numeri uguali
        private HashSet<Telefono> _telefoni;

        /// <summary>
        /// Costruttore
        /// </summary>
        public CollezioneTelefoni(IEnumerable<Telefono> telefoni = null)
        {
            //Se argomento nullo da' lista vuota, altrimenti crea una copia della lista data
            _telefoni = (telefoni == null) ? new HashSet<Telefono>() : new HashSet<Telefono>(telefoni);
        }

        public int Count
        {
            get { return ((ICollection<Telefono>)_telefoni).Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<Telefono>)_telefoni).IsReadOnly; }
        }

        /// <summary>
        /// Aggiunge un telefono alla lista
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(Telefono item)
        {
            if (_telefoni.Contains(item))
                return;

            ((ICollection<Telefono>)_telefoni).Add(item);
            if (OnAggiunta != null)
            {
                ArgsTelefono args = new ArgsTelefono(item);
                OnAggiunta(this, args);
            }
        }

        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear()
        {
            ((ICollection<Telefono>)_telefoni).Clear();
        }

        /// <summary>
        /// Ricerca un telefono nella lista
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public bool Contains(Telefono item)
        {
            return ((ICollection<Telefono>)_telefoni).Contains(item);
        }

        public void CopyTo(Telefono[] array, int arrayIndex)
        {
            ((ICollection<Telefono>)_telefoni).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Telefono> GetEnumerator()
        {
            return ((ICollection<Telefono>)_telefoni).GetEnumerator();
        }

        /// <summary>
        /// Rimuove un dato telefono nella lista
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Remove(Telefono item)
        {
            bool risultato = ((ICollection<Telefono>)_telefoni).Remove(item);
            if (OnRimozione != null)
            {
                ArgsTelefono args = new ArgsTelefono(item);
                OnRimozione(this, args);
            }
            return risultato;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<Telefono>)_telefoni).GetEnumerator();
        }

        /// <summary>
        /// Accede all'i-esimo elemento della lista
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Telefono this[int i]
        {
            get { return _telefoni.ElementAt<Telefono>(i); }
        }

        public override string ToString()
        {
            return String.Join(",", this._telefoni);
        }
    }
}
