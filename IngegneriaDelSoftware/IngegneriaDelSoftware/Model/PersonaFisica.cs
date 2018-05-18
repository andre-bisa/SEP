using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class PersonaFisica : Persona
    {
        #region Campi privati
        private string _nome;
        private string _cognome;
        private string _partitaIVA;
        #endregion

        #region Proprietà
        /// <summary>
        /// Il nome della persona
        /// <para>Il set causa il lancio dell'evento <see cref="Persona.ModificaPersona"/></para>
        /// </summary>
        public string Nome
        {
            get
            {
                return _nome;
            }
            private set
            {
                if (_nome != value)
                {
                    _nome = value;
                    base.LanciaEvento(this);
                }
            }
        }
        /// <summary>
        /// Il cognome della persona
        /// <para>Il set causa il lancio dell'evento <see cref="Persona.ModificaPersona"/></para>
        /// </summary>
        public string Cognome
        {
            get
            {
                return _cognome;
            }
            private set
            {
                if (_cognome != value)
                {
                    _cognome = value;
                    base.LanciaEvento(this);
                }
            }
        }
        /// <summary>
        /// La partita IVA della persona. Can be <c>null</c>.
        /// <para>Il set causa il lancio dell'evento <see cref="Persona.ModificaPersona"/></para>
        /// </summary>
        public string PartitaIVA
        {
            get
            {
                return _partitaIVA;
            }
            private set
            {
                if (_partitaIVA != value)
                {
                    _partitaIVA = value;
                    base.LanciaEvento(this);
                }
            }
        }
        /// <summary>
        /// Il tipo di persona
        /// </summary>
        public override EnumTipoPersona TipoPersona { get { return EnumTipoPersona.Fisica; } }
        #endregion

        #region "Costruttori"
        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale</param>
        /// <param name="indirizzo">L'indirizzo</param>
        /// <param name="nome">Il nome proprio della persona fisica</param>
        /// <param name="cognome">Il cognome della persona fisica</param>
        /// <param name="partitaIVA">La partita IVA (can be <c>null</c>)</param>
        /// <param name="telefoni">I numeri di telefono della persona</param>
        /// <param name="email">Le email della persona</param>
        /// <seealso cref="Persona"/>
        /// <exception cref="ArgumentNullException"></exception>
        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, string partitaIVA = null, List<Telefono> telefoni = null, List<Email> email = null) : base(codiceFiscale, indirizzo, telefoni, email)
        {
            if (nome == null) {
                 throw new ArgumentNullException(nameof(nome));
            }
            _nome = nome;
            if(cognome == null) {
                throw new ArgumentNullException(nameof(cognome));
            }
            _cognome = cognome; 
            _partitaIVA = partitaIVA; // can be null
        }

        protected PersonaFisica(PersonaFisica personaFisica) : base(personaFisica)
        {
            this._nome = personaFisica.Nome;
            this._cognome = personaFisica.Cognome;
            this._partitaIVA = personaFisica.PartitaIVA;
        }
        #endregion

        /// <summary>
        /// Restituisce il nome della persona da visualizzare
        /// </summary>
        /// <returns>La denominazione</returns>
        public override string getDenominazione()
        {
            return this.Nome + " " + this.Cognome;
        }

        protected override Persona Clone()
        {
            return new PersonaFisica(this);
        }

    }
}
