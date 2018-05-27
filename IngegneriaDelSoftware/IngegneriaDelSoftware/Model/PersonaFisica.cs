using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Model
{
    public class PersonaFisica : Persona
    {
        #region Campi privati
        private DatiPersonaFisica _datiPersona;

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(EnumTipoPersistenza.MySQL);
        #endregion

        #region Proprietà
        public string Nome
        {
            get
            {
                return this._datiPersona.Nome;
            }
        }
        public string Cognome
        {
            get
            {
                return this._datiPersona.Cognome;
            }
        }
        public string PartitaIVA
        {
            get
            {
                return this._datiPersona.PartitaIVA;
            }
        }
        public override EnumTipoPersona TipoPersona
        {
            get
            {
                return this._datiPersona.TipoDatiPersona();
            }
        }

        public override string CodiceFiscale
        {
            get
            {
                return this._datiPersona.CodiceFiscale;
            }
        }

        public override string Indirizzo
        {
            get
            {
                return this._datiPersona.Indirizzo;
            }
        }

        public override CollezioneTelefoni Telefoni
        {
            get
            {
                return this._datiPersona.Telefoni;
            }
        }

        public override CollezioneEmail Email
        {
            get
            {
                return this._datiPersona.Email;
            }
        }
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
        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, string partitaIVA = "", IEnumerable<Telefono> telefoni = null, IEnumerable<Email> email = null)
        {
            this._datiPersona = new DatiPersonaFisica(codiceFiscale, indirizzo, nome, cognome, partitaIVA, telefoni, email);
        }

        public PersonaFisica(DatiPersonaFisica datiPersonaFisica)
        {
            this._datiPersona = datiPersonaFisica;
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

        /// <summary>
        /// Funzione che permette di cambiare i dati all'interno della persona
        /// </summary>
        /// <param name="datiPersona">Dati della nuova persona. DEVONO essere <see cref="DatiPersonaFisica"/></param>
        /// <exception cref="InvalidOperationException">Si verifica se NON si passano dei <see cref="DatiPersonaFisica"/></exception>
        public override void CambiaDatiPersona(DatiPersona datiPersona)
        {
            if (this._datiPersona.Equals(datiPersona))
                return;

            if (datiPersona.TipoDatiPersona() == EnumTipoPersona.Fisica)
            {
                Persona vecchio = this.Clone();
                this._datiPersona = (DatiPersonaFisica) datiPersona;
                if (! _persistenza.GetPersonaDAO().Aggiorna(vecchio, this))
                {
                    this._datiPersona = ((PersonaFisica)vecchio)._datiPersona; // Recupero i vecchi dati
                    throw new ExceptionPersistenza();
                }
                base.LanciaEvento(vecchio);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        protected override Persona Clone()
        {
            return new PersonaFisica(this._datiPersona);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            var hashCode = -1989808641;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(PersonaFisica fisica1, PersonaFisica fisica2)
        {
            return EqualityComparer<PersonaFisica>.Default.Equals(fisica1, fisica2);
        }

        public static bool operator !=(PersonaFisica fisica1, PersonaFisica fisica2)
        {
            return !(fisica1 == fisica2);
        }
    }

    public class DatiPersonaFisica : DatiPersona
    {
        #region Campi privati
        private string _codiceFiscale;
        private string _indirizzo;
        private CollezioneTelefoni _telefoni;
        private CollezioneEmail _email;
        private string _nome;
        private string _cognome;
        private string _partitaIVA;
        #endregion

        #region Proprietà
        public override string CodiceFiscale
        {
            get
            {
                return this._codiceFiscale;
            }
        }

        public override string Indirizzo
        {
            get
            {
                return this._indirizzo;
            }
        }

        public override CollezioneTelefoni Telefoni
        {
            get
            {
                return this._telefoni;
            }
        }

        public override CollezioneEmail Email
        {
            get
            {
                return this._email;
            }
        }

        public string Nome
        {
            get
            {
                return this._nome;
            }
        }

        public string Cognome
        {
            get
            {
                return this._cognome;
            }
        }

        public string PartitaIVA
        {
            get
            {
                return this._partitaIVA;
            }
        }

        #endregion

        #region Costruttori
        public DatiPersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, string partitaIVA = "", IEnumerable<Telefono> telefoni = null, IEnumerable<Email> email = null)
        {
            #region Controlli
            if (codiceFiscale == null)
                throw new ArgumentNullException();
            if (indirizzo == null)
                throw new ArgumentNullException();
            if (nome == null)
                throw new ArgumentNullException();
            if (cognome == null)
                throw new ArgumentNullException();
            if (partitaIVA == null)
                throw new ArgumentNullException();
            #endregion

            this._codiceFiscale = codiceFiscale;
            this._indirizzo = indirizzo;
            this._nome = nome;
            this._cognome = cognome;
            this._partitaIVA = partitaIVA;
            this._telefoni = new CollezioneTelefoni(telefoni);
            this._email = new CollezioneEmail(email);
        }
        #endregion

        public override EnumTipoPersona TipoDatiPersona()
        {
            return EnumTipoPersona.Fisica;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DatiPersonaFisica))
            {
                return false;
            }

            var fisica = (DatiPersonaFisica)obj;
            return CodiceFiscale == fisica.CodiceFiscale &&
                   Indirizzo == fisica.Indirizzo &&
                   Nome == fisica.Nome &&
                   Cognome == fisica.Cognome &&
                   PartitaIVA == fisica.PartitaIVA;
        }

        public override int GetHashCode()
        {
            var hashCode = 80561879;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CodiceFiscale);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Indirizzo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cognome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PartitaIVA);
            return hashCode;
        }

        public static bool operator ==(DatiPersonaFisica fisica1, DatiPersonaFisica fisica2)
        {
            return fisica1.Equals(fisica2);
        }

        public static bool operator !=(DatiPersonaFisica fisica1, DatiPersonaFisica fisica2)
        {
            return !(fisica1 == fisica2);
        }
    }

}
