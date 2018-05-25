using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;

//XXX check this one;
namespace IngegneriaDelSoftware.Model
{
    public class CollezionePreventivi : IEnumerable<Preventivo>, ICollection<Preventivo>
    {
        public event EventHandler<ArgsPreventivo> OnAggiunta;
        public event EventHandler<ArgsPreventivo> OnRimozione;

        private HashSet<Preventivo> _preventivi = new HashSet<Preventivo>();

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(EnumTipoPersistenza.MySQL);

        #region Singleton
        private static CollezionePreventivi _listaPreventivi = null;
        /// <summary>
        /// Funzioen che dà un'istanza della <see cref="CollezioneFatture"/>
        /// </summary>
        /// <returns>La collezione riempita con tutti i clienti</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public static CollezionePreventivi GetInstance()
        {
            if (_listaPreventivi == null)
                _listaPreventivi = new CollezionePreventivi();
            return _listaPreventivi;
        }
        #endregion

        protected CollezionePreventivi()
        {
            try
            {
                foreach (Preventivo p in _persistenza.GetPreventivoDAO().LeggiTuttiPreventivi())
                {
                    _preventivi.Add(p);
                }
            } catch (Exception) { throw new ExceptionPersistenza(); }

            // TODO REMOVE! mock
            /*for (int i = 0; i < 100; i++)
            {
                Telefono[] telefoni = { new Telefono( "0510000"+i, "Nota "+i) };
                Email[] email = { new Email("indirizzo" + i + "@prova.com", "Nota" + i) };
                Referente[] referenti = { new Referente("Ref" + i, "Nota" + i), new Referente("Ref2" + i, "Nota2" + i) };
                _preventivi.Add(new Preventivo(new PersonaFisica("cf", "indirizzo" + i, "nome" + i, "cognome", "PIVA", telefoni, email), "ID" + i, referenti, EnumTipoPreventivo.Attivo, "Nota"+i));
            }*/
        }

        public int Count
        {
            get
            {
                return ((ICollection<Preventivo>)_preventivi).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<Preventivo>)_preventivi).IsReadOnly;
            }
        }

        /// <summary>
        /// Aggiunge un <see cref="Preventivo"/> alla collezione
        /// </summary>
        /// <param name="item">Preventivo da aggiungere alla collezione</param>
        /// <exception cref="ArgumentNullException">Se il <see cref="Preventivo"/> è nullo</exception>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public void Add(Preventivo item)
        {
            if (item == null)
                throw new ArgumentNullException("Errore. Il preventivo è nullo");

            if (!this._preventivi.Contains(item))
            {
                if (_persistenza.GetPreventivoDAO().Crea(item))
                {
                    ((ICollection<Preventivo>)_preventivi).Add(item);
                    LanciaEvento(OnAggiunta, item);
                }
                else
                { // Se si sono verificati errori nella persistenza
                    throw new ExceptionPersistenza();
                }
            }
        }

        /// <summary>
        /// Funzione non supportata. Lancia SEMPRE eccezione
        /// </summary>
        /// <exception cref="InvalidOperationException">Viene lanciata SEMPRE!</exception>
        public void Clear()
        {
            throw new InvalidOperationException();
        }

        public bool Contains(Preventivo item)
        {
            return ((ICollection<Preventivo>)_preventivi).Contains(item);
        }

        public void CopyTo(Preventivo[] array, int arrayIndex)
        {
            ((ICollection<Preventivo>)_preventivi).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Preventivo> GetEnumerator()
        {
            return ((IEnumerable<Preventivo>)_preventivi).GetEnumerator();
        }

        /// <summary>
        /// Funzione che elimina un utente dalla collezione
        /// </summary>
        /// <param name="item">L'utente che si intende eliminare</param>
        /// <returns><c>true</c> o <c>false</c> a seconda se ci è riuscito oppure no</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public bool Remove(Preventivo item)
        {
            bool rimosso = false;
            if (item != null)
            {
                if (_persistenza.GetPreventivoDAO().Elimina(item.ID))
                {
                    rimosso = ((ICollection<Preventivo>)_preventivi).Remove(item);
                    LanciaEvento(OnRimozione, item);
                }
                else
                { // Se ci sono errori nella persistenza
                    throw new ExceptionPersistenza();
                }
            }
            return rimosso;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Preventivo>)_preventivi).GetEnumerator();
        }

        private void LanciaEvento(EventHandler<ArgsPreventivo> evento, Preventivo preventivo)
        {
            if (evento != null)
            {
                ArgsPreventivo args = new ArgsPreventivo(preventivo);
                evento(this, args);
            }
        }

        public Preventivo this[ulong id]
        {
            get
            {
                foreach (Preventivo p in this._preventivi)
                {
                    if (p.ID == id)
                        return p;
                }
                return null;
            }
        }

    }
}
