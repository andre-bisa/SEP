using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public abstract class Persona
    {
        public event EventHandler<ArgsModificaPersona> ModificaPersona;

        public abstract EnumTipoPersona TipoPersona { get; }

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
                _codiceFiscale = value;
                LanciaEvento();
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
                _indirizzo = value;
                LanciaEvento();
            }
        }

        //XXX ha senso che siano pubbliche?;

        public List<Telefono> Telefoni { get; } = new List<Telefono>();
        public List<Email> Email { get; } = new List<Email>();

        #region "Costruttori"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale della persona</param>
        /// <param name="indirizzo">L'indirizzo della persona</param>
        /// <exception cref="ArgumentNullException">/exception>
        protected Persona(string codiceFiscale, string indirizzo)
        {
            if(codiceFiscale == null) {
                throw new ArgumentNullException(nameof(codiceFiscale));
            }
            CodiceFiscale = codiceFiscale;
            if(indirizzo == null) {
                throw new ArgumentNullException(nameof(indirizzo));
            }
            Indirizzo = indirizzo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale della persona</param>
        /// <param name="indirizzo">L'indirizzo della persona</param>
        /// <param name="telefoni">I telefoni della persona</param>
        /// <param name="email">Gli indirizzi email della persona</param>
        /// <exception cref="ArgumentNullException">/exception>
        protected Persona(string codiceFiscale, string indirizzo, List<Telefono> telefoni, List<Email> email) : this(codiceFiscale, indirizzo)
        {
            //N.B. il lancio delle eccezioni è evitato perchè si vuole rituilizzare questo codice negli altri due costruttori più sotto;
            if(telefoni != null) {
                foreach(Telefono tel in telefoni) {
                    this.Telefoni.Add(tel);
                }
            }

            if(email != null) {
                foreach(Email mail in email) {
                    this.Email.Add(mail);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale della persona</param>
        /// <param name="indirizzo">L'indirizzo della persona</param>
        /// <param name="telefoni">I telefoni della persona</param>
        /// <exception cref="ArgumentNullException">/exception>
        protected Persona(string codiceFiscale, string indirizzo, List<Telefono> telefoni) : this(codiceFiscale, indirizzo, telefoni, null)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale della persona</param>
        /// <param name="indirizzo">L'indirizzo della persona</param>
        /// <param name="email">Gli indirizzi email della persona</param>
        /// <exception cref="ArgumentNullException">/exception>
        protected Persona(string codiceFiscale, string indirizzo, List<Email> email) : this(codiceFiscale, indirizzo, null, email)
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
        protected void LanciaEvento()
        {
            if (ModificaPersona != null)
            {
                ArgsModificaPersona args = new ArgsModificaPersona(this);
                ModificaPersona(this, args);
            }
        }
        #endregion

    }

}
