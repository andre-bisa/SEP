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
    public class CollezioneVendite : IEnumerable<Vendita>, ICollection<Vendita>
    {
        public event EventHandler<ArgsVendita> OnAggiunta;
        public event EventHandler<ArgsVendita> OnRimozione;
        public event EventHandler<ArgsModifica<Vendita>> OnModifica;

        private HashSet<Vendita> _vendite = new HashSet<Vendita>();

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(EnumTipoPersistenza.NONE);

        #region Singleton
        private static CollezioneVendite _listaFatture = null;
        /// <summary>
        /// Funzioen che dà un'istanza della <see cref="CollezioneFatture"/>
        /// </summary>
        /// <returns>La collezione riempita con tutti i clienti</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public static CollezioneVendite GetInstance()
        {
            if (_listaFatture == null)
                _listaFatture = new CollezioneVendite();
            return _listaFatture;
        }
        #endregion

        protected CollezioneVendite()
        {
            try
            {
                foreach (Vendita v in _persistenza.GetVenditaDAO().LeggiTutteVendite())
                {
                    _vendite.Add(v);
                    v.OnModifica += (o, e) => {
                        this.OnModifica?.Invoke(o, e);
                    };
                }
            } catch (Exception) { throw new ExceptionPersistenza(); }

            // TODO REMOVE! mock
            /*for (int i = 0; i < 100; i++)
            {
                Telefono[] telefoni = { new Telefono( "0510000"+i, "Nota "+i) };
                Email[] email = { new Email("indirizzo" + i + "@prova.com", "Nota" + i) };
                Referente[] referenti = { new Referente("Ref" + i, "Nota" + i), new Referente("Ref2" + i, "Nota2" + i) };
                _vendite.Add(new Vendita(new PersonaFisica("cf", "indirizzo" + i, "nome" + i, "cognome", "PIVA", telefoni, email), "ID" + i, referenti, EnumTipoVendita.Attivo, "Nota"+i));
            }*/
        }

        public int Count
        {
            get
            {
                return ((ICollection<Vendita>)_vendite).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<Vendita>)_vendite).IsReadOnly;
            }
        }

        /// <summary>
        /// Aggiunge un <see cref="Vendita"/> alla collezione
        /// </summary>
        /// <param name="item">Vendita da aggiungere alla collezione</param>
        /// <exception cref="ArgumentNullException">Se il <see cref="Vendita"/> è nullo</exception>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public void Add(Vendita item)
        {
            if (item == null)
                throw new ArgumentNullException("Errore. La vendita è nulla");

            if (!this._vendite.Contains(item))
            {
                if (_persistenza.GetVenditaDAO().Crea(item))
                {
                    ((ICollection<Vendita>)_vendite).Add(item);
                    item.OnModifica += (o, e) => {
                        this.OnModifica?.Invoke(o, e);
                    };
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

        public bool Contains(Vendita item)
        {
            return ((ICollection<Vendita>)_vendite).Contains(item);
        }

        public void CopyTo(Vendita[] array, int arrayIndex)
        {
            ((ICollection<Vendita>)_vendite).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Vendita> GetEnumerator()
        {
            return ((IEnumerable<Vendita>)_vendite).GetEnumerator();
        }

        /// <summary>
        /// Funzione che elimina un utente dalla collezione
        /// </summary>
        /// <param name="item">L'utente che si intende eliminare</param>
        /// <returns><c>true</c> o <c>false</c> a seconda se ci è riuscito oppure no</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public bool Remove(Vendita item)
        {
            bool rimosso = false;
            if (item != null)
            {
                if (_persistenza.GetVenditaDAO().Elimina(item.ID))
                {
                    rimosso = ((ICollection<Vendita>)_vendite).Remove(item);
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
            return ((IEnumerable<Vendita>)_vendite).GetEnumerator();
        }

        private void LanciaEvento(EventHandler<ArgsVendita> evento, Vendita vendita)
        {
            if (evento != null)
            {
                ArgsVendita args = new ArgsVendita(vendita);
                evento(this, args);
            }
        }

        public Vendita this[ulong id]
        {
            get
            {
                foreach (Vendita v in this._vendite)
                {
                    if (v.ID == id)
                        return v;
                }
                return null;
            }
        }

    }
}
