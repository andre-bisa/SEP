using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public class PersonaGiuridica: Persona {
        private string _ragioneSociale;
        /// <summary>
        /// La ragione sociale
        /// <para>Il set causa il lancio dell'evento <see cref="Persona.ModificaPersona"/></para>
        /// </summary>
        public string RagioneSociale {
            get {
                return _ragioneSociale;
            }
            private set {
                if (_ragioneSociale != value)
                {
                    _ragioneSociale = value;
                    base.LanciaEvento(this);
                }
            }
        }
        private string _sedeLegale;
        /// <summary>
        /// La sede legale della persona
        /// <para>Il set causa il lancio dell'evento <see cref="Persona.ModificaPersona"/></para>
        /// </summary>
        public string SedeLegale {
            get {
                return _sedeLegale;
            }
            private set {
                if (_sedeLegale != value)
                {
                    _sedeLegale = value;
                    base.LanciaEvento(this);
                }
            }
        }
        private string _partitaIVA;
        /// <summary>
        /// La partita IVA della persona
        /// <para>Il set causa il lancio dell'evento <see cref="Persona.ModificaPersona"/></para>
        /// </summary>
        public string PartitaIVA {
            get {
                return _partitaIVA;
            }
            private set {
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
        public override EnumTipoPersona TipoPersona { get { return EnumTipoPersona.Giuridica; } }

        #region "Costruttori"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codiceFiscale">Il codice fiscale della persona</param>
        /// <param name="indirizzo">L'indirizzo della persona</param>
        /// <param name="ragioneSociale">La ragione sociale della persona</param>
        /// <param name="sedeLegale">La sede legale della persona</param>
        /// <param name="partitaIVA">La partita IVA della persona</param>
        /// <param name="telefoni">I numeri di telefono della persona</param>
        /// <param name="email">Gli indirizzi email della persona</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PersonaGiuridica(string codiceFiscale, string indirizzo, string ragioneSociale, string sedeLegale, string partitaIVA, List<Telefono> telefoni = null, List<Email> email = null) : base(codiceFiscale, indirizzo, telefoni, email) {
            if(ragioneSociale == null) {
                throw new ArgumentNullException(nameof(ragioneSociale));
            }
            RagioneSociale = ragioneSociale;
            if(sedeLegale == null) {
                throw new ArgumentNullException(nameof(sedeLegale));
            }
            SedeLegale = sedeLegale;
            if(partitaIVA == null) {
                throw new ArgumentNullException(nameof(partitaIVA));
            }
            PartitaIVA = partitaIVA;
        }

        protected PersonaGiuridica(PersonaGiuridica personaGiuridica) : base(personaGiuridica)
        {
            this._partitaIVA = personaGiuridica.PartitaIVA;
            this._ragioneSociale = personaGiuridica.RagioneSociale;
            this._sedeLegale = personaGiuridica.SedeLegale;
        }
        #endregion

        /// <summary>
        /// Restituisce il nome della persona da visualizzare
        /// </summary>
        /// <returns>La denominazione</returns>
        public override string getDenominazione() {
            return this.RagioneSociale;
        }

        protected override Persona Clone()
        {
            return new PersonaGiuridica(this);
        }
    }
}
