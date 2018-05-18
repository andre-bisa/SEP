using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public abstract class Persona : IObservable<Persona>
    {
        //public event EventHandler<ArgsModificaPersona> ModificaPersona;
        public event EventHandler<ArgsModifica<Persona>> OnModifica;

        public abstract EnumTipoPersona TipoPersona { get; }

        protected abstract Persona Clone();

        private string _codiceFiscale;
        /// <summary>
        /// Il codice fiscale della persona
        /// <para>Il set causa il lancio dell'evento <see cref="ModificaPersona"/></para>
        /// </summary>
        public string CodiceFiscale {
            get
            {
                return _codiceFiscale;
            }
            set
            {
                if (_codiceFiscale != value)
                {
                    Persona vecchiaPersona = this.Clone();
                    _codiceFiscale = value;
                    LanciaEvento(vecchiaPersona);
                }
            }
        }
        private string _indirizzo;
        /// <summary>
        /// L'indirizzo della persona
        /// <para>Il set causa il lancio dell'evento <see cref="ModificaPersona"/></para>
        /// </summary>
        public string Indirizzo {
            get
            {
                return _indirizzo;
            }
            set
            {
                if (_indirizzo != value)
                {
                    Persona vecchiaPersona = this.Clone();
                    _indirizzo = value;
                    LanciaEvento(vecchiaPersona);
                }
            }
        }

        //XXX ha senso che siano pubbliche?;

        private List<Telefono> _telefoni;
        public List<Telefono> Telefoni
        {
            get
            {
                return new List<Telefono>(_telefoni);
            }
        }

        private List<Email> _email;
        public List<Email> Email
        {
            get
            {
                return new List<Email>(_email);
            }
        }

        #region "Costruttori"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale della persona</param>
        /// <param name="indirizzo">L'indirizzo della persona</param>
        /// <param name="telefoni">I telefoni della persona. Default: lista vuota</param>
        /// <param name="email">Gli indirizzi email della persona. Default: lista vuota</param>
        /// <exception cref="ArgumentNullException">/exception>
        protected Persona(string codiceFiscale, string indirizzo, List<Telefono> telefoni = null, List<Email> email = null)
        {

            if (codiceFiscale == null)
            {
                throw new ArgumentNullException(nameof(codiceFiscale));
            }
            _codiceFiscale = codiceFiscale;
            if (indirizzo == null)
            {
                throw new ArgumentNullException(nameof(indirizzo));
            }
            _indirizzo = indirizzo;

            this._telefoni = (telefoni == null) ? new List<Telefono>() : new List<Telefono>(telefoni);

            this._email = (email == null) ? new List<Email>() : new List<Email>(email);
        }

        protected Persona(Persona persona) : this(persona.CodiceFiscale, persona.Indirizzo, persona.Telefoni, persona.Email)
        {
        }

        #endregion

        #region "Funzioni Telefono"
        /// <summary>
        /// Aggiunge un numero di telefono alla lista interna
        /// </summary>
        /// <param name="telefono">Il telefono da aggiungere</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AggiungiTelefono (Telefono telefono)
        {
            if(telefono != null) {
                this.Telefoni.Add(telefono);
            } else {
                throw new ArgumentNullException(nameof(telefono));
            }
        }
        /// <summary>
        /// Rimuove un numero di telefono alla lista interna
        /// </summary>
        /// <param name="telefono">Il telefono da rimuovere</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RimuoviTelefono (Telefono telefono)
        {
            if(telefono != null) {
                this.Telefoni.Remove(telefono);
            } else {
                throw new ArgumentNullException(nameof(telefono));
            }
        }
        #endregion

        #region "Funzioni Email"
        /// <summary>
        /// Aggiunge un indirizzo email dalla lista interna
        /// </summary>
        /// <param name="email">L'indirizzo da aggiungere</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AggiungiEmail(Email email)
        {
            if(email != null) {
                this.Email.Add(email);
            } else {
                throw new ArgumentNullException(nameof(email));
            }
        }
        /// <summary>
        /// Rimuove un indirizzo email dalla lista interna
        /// </summary>
        /// <param name="email">L'indirizzo da rimuovere</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RimuoviEmail(Email email)
        {
            if(email != null) {
                this.Email.Remove(email);
            } else {
                throw new ArgumentNullException(nameof(email));
            }
        }
        #endregion

        #region "Funzioni pubbliche"
        //XXX è giusto?
        /// <summary>
        /// Restituisce il nome della persona da visualizzare
        /// </summary>
        /// <returns>La denominazione</returns>
        public abstract string getDenominazione();
        #endregion

        #region "Funzioni private"
        protected void LanciaEvento(Persona vecchiaPersona)
        {
            if (OnModifica != null)
            {
                ArgsModifica<Persona> args = new ArgsModifica<Persona>(vecchiaPersona, this);
                OnModifica(this, args);
            }
        }
        #endregion

    }

}
