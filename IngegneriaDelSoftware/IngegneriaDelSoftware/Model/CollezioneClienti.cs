using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class CollezioneClienti : IEnumerable<Cliente>, ICollection<Cliente>
    {
        public event EventHandler<ArgsCliente> OnAggiunta;
        public event EventHandler<ArgsCliente> OnRimozione;

        private HashSet<Cliente> _clienti = new HashSet<Cliente>();

        protected CollezioneClienti()
        {
            for (int i = 0; i < 100; i++)
            {
                _clienti.Add(new Cliente(new PersonaFisica("cf", "indirizzo" + i, "nome" + i, "cognome"), "ID" + i));
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

        public void Add(Cliente item)
        {
            if (item != null)
            {
                ((ICollection<Cliente>)_clienti).Add(item);
                LanciaEvento(OnAggiunta, item);
            }
        }

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

        public bool Remove(Cliente item)
        {
            bool rimosso = false;
            if (item != null)
            {
                rimosso = ((ICollection<Cliente>)_clienti).Remove(item);
                LanciaEvento(OnRimozione, item);
            }
            return rimosso;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Cliente>)_clienti).GetEnumerator();
        }

        #region Singleton
        private static CollezioneClienti _listaClienti = null;
        public static CollezioneClienti GetInstance()
        {
            if (_listaClienti == null)
                _listaClienti = new CollezioneClienti();
            return _listaClienti;
        }
        #endregion

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
