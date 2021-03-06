﻿/*
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
    public class CollezioneEmail : ICollection<Email>, IEnumerable<Email>
    {
        public event EventHandler<ArgsEmail> OnAggiunta;
        public event EventHandler<ArgsEmail> OnRimozione;

        //Set poiche' non ha senso aggiungere due o piu' email uguali
        private HashSet<Email> _email;

        /// <summary>
        /// Costruttore
        /// </summary>
        public CollezioneEmail(IEnumerable<Email> email = null)
        {
            //Se argomento nullo da' lista vuota, altrimenti crea una copia della lista data
            _email = (email == null) ? new HashSet<Email>() : new HashSet<Email>(email);
        }

        public int Count
        {
            get { return ((ICollection<Email>)_email).Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<Email>)_email).IsReadOnly; }
        }

        /// <summary>
        /// Aggiunge un email alla lista
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(Email item)
        {
            if (_email.Contains(item))
                return;

            ((ICollection<Email>)_email).Add(item);
            if (OnAggiunta != null)
            {
                ArgsEmail args = new ArgsEmail(item);
                OnAggiunta(this, args);
            }
        }

        /// <summary>
        /// Funzione non utilizzabile. Lancia SEMPRE eccezione
        /// </summary>
        /// <exception cref="InvalidOperationException">Viene lanciata SEMPRE</exception>
        public void Clear()
        {
            throw new InvalidOperationException("Errore. Operazione non valida. Non è possibile svuotare questa collezione.");
        }

        /// <summary>
        /// Ricerca un email nella lista
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public bool Contains(Email item)
        {
            return ((ICollection<Email>)_email).Contains(item);
        }

        public void CopyTo(Email[] array, int arrayIndex)
        {
            ((ICollection<Email>)_email).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Email> GetEnumerator()
        {
            return ((ICollection<Email>)_email).GetEnumerator();
        }

        /// <summary>
        /// Rimuove un dato email nella lista
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Remove(Email item)
        { 
            bool risultato = ((ICollection<Email>)_email).Remove(item);
            if (OnRimozione != null)
            {
                ArgsEmail args = new ArgsEmail(item);
                OnRimozione(this, args);
            }
            return risultato;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<Email>)_email).GetEnumerator();
        }

        /// <summary>
        /// Accede all'i-esimo elemento della lista
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Email this[int i]
        {
            get { return _email.ElementAt<Email>(i); }
        }

        public override string ToString()
        {
            return String.Join(",", this._email);
        }
    }
}
