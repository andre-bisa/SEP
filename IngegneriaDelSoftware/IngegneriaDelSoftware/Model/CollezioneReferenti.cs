using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class CollezioneReferenti : ICollection<Referente>, IEnumerable<Referente>
    {
        //Set poiche' non ha senso aggiungere due o piu' referenti uguali
        private HashSet<Referente> _referenti;

        /// <summary>
        /// Costruttore
        /// </summary>
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
            ((ICollection<Referente>)_referenti).Add(item);
        }

        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear()
        {
            ((ICollection<Referente>)_referenti).Clear();
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
            return ((ICollection<Referente>)_referenti).Remove(item);
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
