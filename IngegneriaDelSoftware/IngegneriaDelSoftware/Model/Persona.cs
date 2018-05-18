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
        public event EventHandler<ArgsModifica<Persona>> OnModifica;

        public abstract EnumTipoPersona TipoPersona { get; }
        protected abstract Persona Clone();

        #region Campi privati
        private string _codiceFiscale;
        private string _indirizzo;
        private ListaTelefoni _telefoni;
        private ListaEmail _email;
        private string _ID;
        #endregion

        #region Proprietà
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
        public ListaTelefoni Telefoni
        {
            get
            {
                return this._telefoni;
            }
        }
        public ListaEmail Email
        {
            get
            {
                return _email;
            }
        }
        #endregion

        #region "Costruttori"
        /// <summary>
        /// Costruttore di default
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
            this._telefoni = new ListaTelefoni(telefoni);
            this._email = new ListaEmail(email);
        }

        protected Persona(Persona persona) : this(persona.CodiceFiscale, persona.Indirizzo, persona.Telefoni.ToList<Telefono>(), persona.Email.ToList<Email>())
        {}
        #endregion

        #region "Funzioni pubbliche"
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
