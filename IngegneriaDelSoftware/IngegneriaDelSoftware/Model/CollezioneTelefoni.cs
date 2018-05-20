﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class CollezioneTelefoni : ICollection<Telefono>, IEnumerable<Telefono>
    {
        //Set poiche' non ha senso aggiungere due o piu' numeri uguali
        private HashSet<Telefono> _telefoni;

        /// <summary>
        /// Costruttore
        /// </summary>
        public CollezioneTelefoni(List<Telefono> telefoni = null)
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
            ((ICollection<Telefono>)_telefoni).Add(item);
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
            return ((ICollection<Telefono>)_telefoni).Remove(item);
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
            return String.Join("\n", this._telefoni);
        }
    }
}
