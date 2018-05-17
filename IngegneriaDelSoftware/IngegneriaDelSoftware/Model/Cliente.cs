using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class Cliente : IObservable<Cliente>
    {
        public event EventHandler<ArgsModifica<Cliente>> OnModifica;

        private string _idCliente;
        public string IDCliente {
            get
            {
                return _idCliente;
            }
            set
            {
                if (_idCliente != value)
                {
                    Cliente vecchioCliente = this.Clone();
                    _idCliente = value;
                    LanciaEvento(vecchioCliente);
                }
            }
        }
        private Persona _persona;
        public Persona Persona {
            get
            {
                return _persona;
            }
            set
            {
                if (_persona != value)
                {
                    Cliente vecchioCliente = this.Clone();
                    _persona = value;
                    LanciaEvento(vecchioCliente);
                }
            }
        }
        private string _nota;

        

        public string Nota {
            get
            {
                return _nota;
            }
            set
            {
                if (_nota != value)
                {
                    Cliente vecchioCliente = this.Clone();
                    _nota = value;
                    LanciaEvento(vecchioCliente);
                }
            }
        }
        public EnumTipoCliente TipoCliente { get; private set; }
        public List<Referente> Referenti { get; private set; } = new List<Referente>();

        #region "Costruttori"
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="persona">La persona dalla quale verrà creato il cliente</param>
        /// <param name="IDCliente">Codice del cliente</param>
        /// <param name="tipoCliente">Tipo del cliente</param>
        /// /// <exception cref="ArgumentNullException"></exception>
        public Cliente(Persona persona, string IDCliente, EnumTipoCliente tipoCliente)
        {
            if(IDCliente == null) {
                 throw new ArgumentNullException(nameof(IDCliente));
            }
            this._idCliente = IDCliente;
            
            if(persona == null) {
                 throw new ArgumentNullException(nameof(persona));
            }
            //TODO check this one;
            _persona = persona;
            //Persona.ModificaPersona += this.PersonaModificata; // Se ci sono modifiche dico che il cliente è stato modificato
            _persona.OnModifica += this.PersonaModificata;
            TipoCliente = tipoCliente;
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="persona">La persona dalla quale verrà creato il cliente</param>
        /// <param name="IDCliente">Codice del cliente</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Cliente (Persona persona, string IDCliente) : this(persona, IDCliente, EnumTipoCliente.Attivo)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="persona">La persona dalla quale verrà creato il cliente</param>
        /// <param name="IDCliente">Codice del cliente</param>
        /// <param name="nota">Eventuali note</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Cliente (Persona persona, string IDCliente, string nota) : this(persona, IDCliente)
        {
            
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="persona">La persona dalla quale verrà creato il cliente</param>
        /// <param name="IDCliente">Codice del cliente</param>
        /// <param name="tipoCliente">Tipo del cliente</param>
        /// <param name="nota">Eventuali note</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Cliente (Persona persona, string IDCliente, EnumTipoCliente tipoCliente, string nota) : this(persona, IDCliente, tipoCliente)
        {
            if(nota == null) {
                throw new ArgumentNullException(nameof(nota));
            }
            this._nota = nota;
        }

        protected Cliente(Cliente cliente) : this(cliente.Persona, cliente.IDCliente, cliente.TipoCliente)
        {
            this._nota = cliente.Nota;
            this.Referenti = new List<Referente>(cliente.Referenti);
        }
        #endregion

        #region "Funzioni Referenti"
        /// <summary>
        /// Aggiunge un referente alla lista interna dei referenti
        /// </summary>
        /// <param name="referente">Il referente da aggiungere</param>
        /// <exception cref="ArgumentNullException">Se referente è nullo</exception>
        public void AggiungiReferente(Referente referente)
        {
            if(referente != null) {
                this.Referenti.Add(referente);
            } else {
                throw new ArgumentNullException(nameof(referente));
            }
        }
        /// <summary>
        /// Rimuove il referente dalla lista interna dei referenti
        /// </summary>
        /// <param name="referente">Il referente da rimuovere</param>
        /// <exception cref="ArgumentNullException">Se referente è nullo</exception>
        public void RimuoviReferente(Referente referente)
        {
            if(referente != null) {
                this.Referenti.Remove(referente);
            } else {
                throw new ArgumentNullException(nameof(referente));
            }
        }
        #endregion

        #region "Funzioni pubbliche"
        /// <summary>
        /// Funzione che permette di promuovere il Cliente. Ci sono alcuni vincoli:
        /// Un cliente Attivo non può diventare Potenziale
        /// Un cliente Potenziale non può diventare Ex e viceversa
        /// </summary>
        /// <param name="nuovoTipoCliente">Nuovo tipo che si intende impostare</param>
        /// <exception cref="ArgumentException">In caso di errori dello stato</exception>
        public void CambiaTipoCliente(EnumTipoCliente nuovoTipoCliente)
        {
            if (TipoCliente == nuovoTipoCliente)
            {
                return;
            }

            Cliente vecchioCliente = this.Clone();

            if (TipoCliente == EnumTipoCliente.Attivo && nuovoTipoCliente == EnumTipoCliente.Potenziale)
            { 
                throw new ArgumentException();
            }

            if (TipoCliente == EnumTipoCliente.Potenziale && nuovoTipoCliente == EnumTipoCliente.Ex)
            {
                throw new ArgumentException();
            }

            if (TipoCliente == EnumTipoCliente.Ex && nuovoTipoCliente == EnumTipoCliente.Potenziale)
            {
                throw new ArgumentException();
            }

            TipoCliente = nuovoTipoCliente;
            LanciaEvento(vecchioCliente);
        }

        public override bool Equals(object obj)
        {
            var cliente = obj as Cliente;
            return cliente != null &&
                   IDCliente == cliente.IDCliente;
        }

        public override int GetHashCode()
        {
            var hashCode = 2011232026;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IDCliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<Persona>.Default.GetHashCode(Persona);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nota);
            hashCode = hashCode * -1521134295 + TipoCliente.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Referente>>.Default.GetHashCode(Referenti);
            return hashCode;
        }
        #endregion

        #region "Funzioni private"
        protected void LanciaEvento(Cliente vecchioCliente)
        {
            //ModificaCliente?.Invoke(this, new ArgsModificaCliente(this));
            if(OnModifica != null)
            {
                ArgsModifica<Cliente> args = new ArgsModifica<Cliente>(vecchioCliente, this);
                OnModifica(this, args);
            }
            
        }

        private void PersonaModificata(object sender, ArgsModifica<Persona> p)
        {
            Cliente clienteVecchio = new Cliente(p.Vecchio, this.IDCliente, this.TipoCliente);
            clienteVecchio.Nota = this.Nota;
            clienteVecchio.Referenti = this.Referenti;
            LanciaEvento(clienteVecchio);
        }

        protected Cliente Clone()
        {
            return new Cliente(this);
        }

        #endregion
    }
}
