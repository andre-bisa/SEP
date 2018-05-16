using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class PersonaFisica : Persona
    {
        private string _nome;
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
                _nome = value;
                base.LanciaEvento();
            }
        }
        private string _cognome;
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
                _cognome = value;
                base.LanciaEvento();
            }
        }
        private string _partitaIVA;
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
                _partitaIVA = value;
                base.LanciaEvento();
            }
        }

        /// <summary>
        /// Il tipo di persona
        /// </summary>
        public override EnumTipoPersona TipoPersona { get { return EnumTipoPersona.Fisica; } }

        #region "Costruttori"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale</param>
        /// <param name="indirizzo">L'indirizzo</param>
        /// <param name="nome">Il nome proprio della persona fisica</param>
        /// <param name="cognome">Il cognome della persona fisica</param>
        /// <seealso cref="Persona"/>
        /// <exception cref="ArgumentNullException"></exception>
        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome) : this(codiceFiscale, indirizzo, nome, cognome, null, null, null)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale</param>
        /// <param name="indirizzo">L'indirizzo</param>
        /// <param name="nome">Il nome proprio della persona fisica</param>
        /// <param name="cognome">Il cognome della persona fisica</param>
        /// <param name="telefoni">I numeri di telefono della persona</param>
        /// <param name="email">Le email della persona</param>
        /// <seealso cref="Persona"/>
        /// <exception cref="ArgumentNullException"></exception>
        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, List<Telefono> telefoni, List<Email> email) : this(codiceFiscale, indirizzo, nome, cognome, null, telefoni, email)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale</param>
        /// <param name="indirizzo">L'indirizzo</param>
        /// <param name="nome">Il nome proprio della persona fisica</param>
        /// <param name="cognome">Il cognome della persona fisica</param>
        /// <param name="partitaIVA">La partita IVA (can be <c>null</c>)</param>
        /// <seealso cref="Persona"/>
        /// <exception cref="ArgumentNullException"></exception>
        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, string partitaIVA) : this(codiceFiscale, indirizzo, nome, cognome, partitaIVA, null, null)
        {
        }
        /// <summary>
        /// 
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
        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, string partitaIVA, List<Telefono> telefoni, List<Email> email) : base(codiceFiscale, indirizzo, telefoni, email)
        {
            if (nome == null) {
                 throw new ArgumentNullException(nameof(nome));
            }
            Nome = nome;
            if(cognome == null) {
                throw new ArgumentNullException(nameof(cognome));
            }
            Cognome = cognome; 
            PartitaIVA = partitaIVA; // can be null
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
    }
}
