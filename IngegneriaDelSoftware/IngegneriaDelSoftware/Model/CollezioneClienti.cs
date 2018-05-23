using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Model
{
    public class CollezioneClienti : IEnumerable<Cliente>, ICollection<Cliente>
    {
        public event EventHandler<ArgsCliente> OnAggiunta;
        public event EventHandler<ArgsCliente> OnRimozione;

        private HashSet<Cliente> _clienti = new HashSet<Cliente>();

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(EnumTipoPersistenza.MySQL);

        #region Singleton
        private static CollezioneClienti _listaClienti = null;
        /// <summary>
        /// Funzioen che dà un'istanza della <see cref="CollezioneClienti"/>
        /// </summary>
        /// <returns>La collezione riempita con tutti i clienti</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public static CollezioneClienti GetInstance()
        {
            if (_listaClienti == null)
                _listaClienti = new CollezioneClienti();
            return _listaClienti;
        }
        #endregion

        protected CollezioneClienti()
        {
            try
            {
                foreach (Cliente c in _persistenza.GetClienteDAO().LeggiTuttiClienti())
                {
                    _clienti.Add(c);
                }
            } catch (Exception) { throw new ExceptionPersistenza(); }

            // TODO REMOVE! mock
            for (int i = 0; i < 100; i++)
            {
                Telefono[] telefoni = { new Telefono( "0510000"+i, "Nota "+i) };
                Email[] email = { new Email("indirizzo" + i + "@prova.com", "Nota" + i) };
                Referente[] referenti = { new Referente("Ref" + i, "Nota" + i), new Referente("Ref2" + i, "Nota2" + i) };
                _clienti.Add(new Cliente(new PersonaFisica("cf", "indirizzo" + i, "nome" + i, "cognome", "PIVA", telefoni, email), "ID" + i, referenti, EnumTipoCliente.Attivo, "Nota"+i));
            }
        }

        public int Count
        {
            get
            {
                return ((ICollection<Cliente>)_clienti).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<Cliente>)_clienti).IsReadOnly;
            }
        }

        /// <summary>
        /// Aggiunge un <see cref="Cliente"/> alla collezione
        /// </summary>
        /// <param name="item">Cliente da aggiungere alla collezione</param>
        /// <exception cref="ArgumentNullException">Se il <see cref="Cliente"/> è nullo</exception>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public void Add(Cliente item)
        {
            if (item == null)
                throw new ArgumentNullException("Errore. Il cliente è nullo");

            if (!this._clienti.Contains(item))
            {
                if (_persistenza.GetClienteDAO().Crea(item))
                {
                    ((ICollection<Cliente>)_clienti).Add(item);
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

        public bool Contains(Cliente item)
        {
            return ((ICollection<Cliente>)_clienti).Contains(item);
        }

        public void CopyTo(Cliente[] array, int arrayIndex)
        {
            ((ICollection<Cliente>)_clienti).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Cliente> GetEnumerator()
        {
            return ((IEnumerable<Cliente>)_clienti).GetEnumerator();
        }

        /// <summary>
        /// Funzione che elimina un utente dalla collezione
        /// </summary>
        /// <param name="item">L'utente che si intende eliminare</param>
        /// <returns><c>true</c> o <c>false</c> a seconda se ci è riuscito oppure no</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public bool Remove(Cliente item)
        {
            bool rimosso = false;
            if (item != null)
            {
                if (_persistenza.GetClienteDAO().Elimina(item.IDCliente))
                {
                    rimosso = ((ICollection<Cliente>)_clienti).Remove(item);
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
            return ((IEnumerable<Cliente>)_clienti).GetEnumerator();
        }

        private void LanciaEvento(EventHandler<ArgsCliente> evento, Cliente cliente)
        {
            if (evento != null)
            {
                ArgsCliente args = new ArgsCliente(cliente);
                evento(this, args);
            }
        }

        public Cliente this[string id]
        {
            get
            {
                foreach (Cliente c in this._clienti)
                {
                    if (c.IDCliente == id)
                        return c;
                }
                return null;
            }
        }

    }
}
