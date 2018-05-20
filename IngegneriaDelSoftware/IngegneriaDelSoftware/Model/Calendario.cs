using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class Calendario : IEnumerable<Appuntamento>, ICollection<Appuntamento>
    {
        private List<Appuntamento> _appuntamenti;

        /// <summary>
        /// Costruttore di Calendario
        /// </summary>
        public Calendario()
        {
            _appuntamenti = new List<Appuntamento>();
        }

        /// <summary>
        /// Ritorna la lista di appuntamenti rientranti in un range di date
        /// </summary>
        /// <param name="da"></param>
        /// <param name="a"></param>
        /// <returns>Lista di Appuntamenti</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public List<Appuntamento> AppuntamentiDaA(DateTime da, DateTime a)
        {
            if (da == null || a == null)
            {
                throw new ArgumentNullException();
            }
            //Se la data di partenza viene dopo quella d'arrivo
            if (da > a)
            {
                throw new ArgumentException();
            }

            List<Appuntamento> risultato = new List<Appuntamento>();

            foreach (Appuntamento appuntamento in this._appuntamenti) {
                if (da <= appuntamento.DataOra && a >= appuntamento.DataOra) //Se l'appuntamento rientra nel range
                {
                    risultato.Add(appuntamento);
                }
            }

            return risultato;
        }

        /// <summary>
        /// Ritorna la lista di appuntamenti correnti
        /// </summary>
        public List<Appuntamento> AppuntamentiCalendario
        {
            get { return this._appuntamenti; }
        }

        public int Count
        {
            get { return ((ICollection<Appuntamento>)_appuntamenti).Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<Appuntamento>)_appuntamenti).IsReadOnly; }
        }

        public override string ToString()
        {
            return String.Join("\n", this._appuntamenti);
        }

        public IEnumerator<Appuntamento> GetEnumerator()
        {
            return this._appuntamenti.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._appuntamenti.GetEnumerator();
        }

        /// <summary>
        /// Permette di aggiungere un appuntamento al calendario
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(Appuntamento item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            ((ICollection<Appuntamento>)_appuntamenti).Add(item);
        }

        /// <summary>
        /// Svuota il calendario
        /// </summary>
        public void Clear()
        {
            ((ICollection<Appuntamento>)_appuntamenti).Clear();
        }

        /// <summary>
        /// Controlla se un appuntamento sta nel calendario
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Contains(Appuntamento item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return ((ICollection<Appuntamento>)_appuntamenti).Contains(item);
        }

        public void CopyTo(Appuntamento[] array, int arrayIndex)
        {
            ((ICollection<Appuntamento>)_appuntamenti).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Permette di rimuovere un appuntamento specifico
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Remove(Appuntamento item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return ((ICollection<Appuntamento>)_appuntamenti).Remove(item);
        }
    }
}
