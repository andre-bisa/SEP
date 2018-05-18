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

        #region Campi privati
        private DatiCliente _datiCliente;
        #endregion

        #region Proprietà
        /// <summary>
        /// L'identificativo del cliente
        /// </summary>
        public string IDCliente {
            get
            {
                return _datiCliente.IDCliente;
            }
        }
        /// <summary>
        /// La persona collegata al cliente
        /// </summary>
        public Persona Persona {
            get
            {
                return _datiCliente.Persona;
            }
        }
        /// <summary>
        /// Le note legate all'utente
        /// </summary>
        public string Nota {
            get
            {
                return _datiCliente.Nota;
            }
        }
        /// <summary>
        /// L'enumerativo che determina il tipo di cliente
        /// </summary>
        public EnumTipoCliente TipoCliente
        {
            get
            {
                return this._datiCliente.TipoCliente;
            }
        }
        /// <summary>
        /// Restituisce una <see cref="ListaReferenti"/> che contiene l'elenco dei referenti
        /// </summary>
        public ListaReferenti Referenti
        {
            get
            {
                return _datiCliente.Referenti;
            }
        }
        #endregion

        #region "Costruttori"
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="persona">La persona dalla quale verrà creato il cliente</param>
        /// <param name="IDCliente">Codice del cliente</param>
        /// <param name="referenti">L'elenco dei referenti</param>
        /// <param name="tipoCliente">Tipo del cliente. Default: Ativo</param>
        /// <param name="nota">Nota del cliente. Default: ""</param>
        /// /// <exception cref="ArgumentNullException"></exception>
        public Cliente(Persona persona, string IDCliente, List<Referente> referenti = null, EnumTipoCliente tipoCliente = EnumTipoCliente.Attivo, string nota = "")
        {
            #region Controlli
            if(IDCliente == null)
            {
                 throw new ArgumentNullException(nameof(IDCliente));
            }
            if(persona == null)
            {
                 throw new ArgumentNullException(nameof(persona));
            }
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota));
            }
            #endregion
            this._datiCliente = new DatiCliente(persona, IDCliente, tipoCliente, referenti, nota);
            persona.OnModifica += this.PersonaModificata;
        }

        public Cliente(DatiCliente cliente) : this(cliente.Persona, cliente.IDCliente, cliente.Referenti.ToList<Referente>(), cliente.TipoCliente, cliente.Nota)
        {}
        #endregion

        #region "Funzioni pubbliche"

        /// <summary>
        /// Funzione che permette di impostare i nuovi <see cref="DatiCliente"/>
        /// </summary>
        /// <param name="nuoviDati">Nuovi dati del cliente</param>
        public void CambiaDatiCliente(DatiCliente nuoviDati)
        {
            if (_datiCliente != nuoviDati)
            {
                Cliente vecchioCliente = this.Clone();
                this._datiCliente = nuoviDati;
                LanciaEvento(vecchioCliente);
            }
        }

        /// <summary>
        /// Funzione che permette di promuovere il Cliente. Ci sono alcuni vincoli:
        /// Un cliente Attivo non può diventare Potenziale
        /// Un cliente Potenziale non può diventare Ex e viceversa
        /// </summary>
        /// <param name="nuovoTipoCliente">Nuovo tipo che si intende impostare</param>
        /// <exception cref="ArgumentException">In caso di errori dello stato</exception>
        public void PromuoviCliente(EnumTipoCliente nuovoTipoCliente)
        {
            if (TipoCliente == nuovoTipoCliente)
            {
                return;
            }

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

            DatiCliente nuoviDati = new DatiCliente(this.Persona, this.IDCliente, nuovoTipoCliente, this.Referenti.ToList<Referente>(), this.Nota);
            CambiaDatiCliente(nuoviDati);
        }

        public override bool Equals(object obj)
        {
            if (obj is DatiCliente)
            {
                return ((DatiCliente)obj).IDCliente == this.IDCliente; // Se è di tipo DatiCliente posso dire che è uguale se il codice è uguale
            }
            var cliente = obj as Cliente;
            return cliente != null &&
                   IDCliente == cliente.IDCliente;
        }

        public override int GetHashCode()
        {
            var hashCode = 2011232026;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IDCliente);
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
            Cliente clienteVecchio = new Cliente(p.Vecchio, this.IDCliente, this.Referenti.ToList<Referente>(), this.TipoCliente, this.Nota);
            LanciaEvento(clienteVecchio);
        }

        protected Cliente Clone()
        {
            return new Cliente(this._datiCliente);
        }
        #endregion
    }

    public struct DatiCliente
    {
        public string IDCliente { get; private set; }
        public Persona Persona { get; private set; }
        public string Nota { get; private set; }
        public ListaReferenti Referenti { get; private set; }
        public EnumTipoCliente TipoCliente { get; private set; }

        #region Costruttori
        public DatiCliente(Persona persona, string IDCliente, EnumTipoCliente tipoCliente, List<Referente> referenti = null, string nota = "")
        {
            #region Controlli
            if (persona == null)
                throw new ArgumentNullException(nameof(persona));
            if (IDCliente == null)
                throw new ArgumentNullException(nameof(IDCliente));
            if (nota == null)
                throw new ArgumentNullException(nameof(nota));
            #endregion

            this.IDCliente = IDCliente;
            this.TipoCliente = tipoCliente;
            this.Persona = persona;
            this.Referenti = new ListaReferenti(referenti); // La gestione del null la fa la ListaReferenti
            this.Nota = nota;
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            if (!(obj is DatiCliente))
            {
                return false;
            }

            var cliente = (DatiCliente)obj;
            return IDCliente == cliente.IDCliente &&
                   EqualityComparer<Persona>.Default.Equals(Persona, cliente.Persona) &&
                   Nota == cliente.Nota &&
                   EqualityComparer<ListaReferenti>.Default.Equals(Referenti, cliente.Referenti) &&
                   TipoCliente == cliente.TipoCliente;
        }

        public override int GetHashCode()
        {
            var hashCode = 919071402;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IDCliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<Persona>.Default.GetHashCode(Persona);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nota);
            hashCode = hashCode * -1521134295 + EqualityComparer<ListaReferenti>.Default.GetHashCode(Referenti);
            hashCode = hashCode * -1521134295 + TipoCliente.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DatiCliente cliente1, DatiCliente cliente2)
        {
            return cliente1.Equals(cliente2);
        }

        public static bool operator !=(DatiCliente cliente1, DatiCliente cliente2)
        {
            return !(cliente1 == cliente2);
        }
        #endregion

    }

}
