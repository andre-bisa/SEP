using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Model
{
    public class Cliente : IObservable<Cliente>
    {
        public event EventHandler<ArgsModifica<Cliente>> OnModifica;

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(EnumTipoPersistenza.MySQL);

        #region Campi privati
        private DatiCliente _datiCliente;
        private Persona _persona;
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
                return _persona;
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
        /// Restituisce una <see cref="CollezioneReferenti"/> che contiene l'elenco dei referenti
        /// </summary>
        public CollezioneReferenti Referenti
        {
            get
            {
                return _datiCliente.Referenti;
            }
        }

        /// <summary>
        /// Restituisce il nome del cliente indistintamente tra PersonaFisica o PersonaGiuridica
        /// </summary>
        public string Denominazione
        {
            get
            {
                return this.Persona.getDenominazione();
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
        public Cliente(Persona persona, string IDCliente, IEnumerable<Referente> referenti = null, EnumTipoCliente tipoCliente = EnumTipoCliente.Attivo, string nota = "")
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
            this._datiCliente = new DatiCliente(IDCliente, tipoCliente, referenti, nota);
            _persona = persona;
            persona.OnModifica += this.PersonaModificata;
        }

        public Cliente(DatiCliente cliente, Persona persona) : this(persona, cliente.IDCliente, cliente.Referenti, cliente.TipoCliente, cliente.Nota)
        {}
        #endregion

        #region "Funzioni pubbliche"

        /// <summary>
        /// Funzione che permette di impostare i nuovi <see cref="DatiCliente"/>
        /// </summary>
        /// <param name="nuoviDati">Nuovi dati del cliente</param>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori con la persistenza</exception>
        public void CambiaDatiCliente(DatiCliente nuoviDati)
        {
            if (_datiCliente != nuoviDati)
            {
                Cliente vecchioCliente = this.Clone();
                this._datiCliente = nuoviDati;

                if (! _persistenza.GetClienteDAO().Aggiorna(vecchioCliente, this))
                { // se ci sono errori con la persistenza
                    this._datiCliente = vecchioCliente._datiCliente; // recupero i dati utente che avevo prima
                    throw new ExceptionPersistenza();
                }
                LanciaEvento(vecchioCliente);
            }
        }

        /*public void CambiaPersona(DatiPersona datiPersona)
        {
            switch (datiPersona.TipoDatiPersona())
            {
                case EnumTipoPersona.Fisica:
                    this.CambiaPersona(new PersonaFisica((DatiPersonaFisica)datiPersona));
                    break;

                case EnumTipoPersona.Giuridica:
                    this.CambiaPersona(new PersonaGiuridica((DatiPersonaGiuridica)datiPersona));
                    break;
            }
        }

        public void CambiaPersona(Persona persona)
        {
            if (_persona != persona)
            {
                Cliente vecchioCliente = this.Clone();
                if (! _persistenza.GetPersonaDAO().CambiaPersona(vecchioCliente, persona))
                {
                    throw new ExceptionPersistenza();
                }
                this._persona = persona;
                persona.OnModifica += this.PersonaModificata;
                LanciaEvento(vecchioCliente);
            }
        }*/

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

            DatiCliente nuoviDati = new DatiCliente(this.IDCliente, nuovoTipoCliente, this.Referenti, this.Nota);
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
            Cliente clienteVecchio = this.Clone();
            this._persona = p.Nuovo;
            LanciaEvento(clienteVecchio);
        }

        protected Cliente Clone()
        {
            return new Cliente(this._datiCliente, this._persona);
        }
        #endregion
    }

    public struct DatiCliente
    {
        public string IDCliente { get; private set; }
        public string Nota { get; private set; }
        public CollezioneReferenti Referenti { get; private set; }
        public EnumTipoCliente TipoCliente { get; private set; }

        #region Costruttori
        public DatiCliente(string IDCliente, EnumTipoCliente tipoCliente, IEnumerable<Referente> referenti = null, string nota = "")
        {
            #region Controlli
            if (IDCliente == null)
                throw new ArgumentNullException(nameof(IDCliente));
            if (nota == null)
                throw new ArgumentNullException(nameof(nota));
            #endregion

            this.IDCliente = IDCliente;
            this.TipoCliente = tipoCliente;
            this.Referenti = new CollezioneReferenti(referenti); // La gestione del null la fa la ListaReferenti
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
                   Nota == cliente.Nota &&
                   TipoCliente == cliente.TipoCliente;
        }

        public override int GetHashCode()
        {
            var hashCode = -358072698;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IDCliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nota);
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
