using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class ListaEmail : ICollection<Email>, IEnumerable<Email>
    {
        private List<Email> _email;

        /// <summary>
        /// Costruttore
        /// </summary>
        public ListaEmail(List<Email> email = null)
        {
            //Se argomento nullo da' lista vuota, altrimenti crea una copia della lista data
            _email = (email == null) ? new List<Email>() : new List<Email>(email);
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
            ((ICollection<Email>)_email).Add(item);
        }

        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear()
        {
            ((ICollection<Email>)_email).Clear();
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
            return ((ICollection<Email>)_email).Remove(item);
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
            get { return _email[i]; }
            set
            {
                _email[i] = value;
            }
        }
    }
}
