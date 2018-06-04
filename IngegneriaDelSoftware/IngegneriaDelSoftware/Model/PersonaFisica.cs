/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

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
        private CollezioneTelefoni _telefoni;
        private CollezioneEmail _email;

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza);
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
            this._datiPersona = new DatiPersonaFisica(codiceFiscale, indirizzo, nome, cognome, partitaIVA);
            this._email = new CollezioneEmail(email);
            this._telefoni = new CollezioneTelefoni(telefoni);
            this.Email.OnAggiunta += (o, e) => { _persistenza.GetPersonaDAO().InserisciEmail(e.Email, this); LanciaEvento(this); };
            this.Email.OnRimozione += (o, e) => { _persistenza.GetPersonaDAO().RimuoviEmail(e.Email, this); LanciaEvento(this); };
            this.Telefoni.OnAggiunta += (o, e) => { _persistenza.GetPersonaDAO().InserisciTelefono(e.Telefono, this); LanciaEvento(this); };
            this.Telefoni.OnRimozione += (o, e) => { _persistenza.GetPersonaDAO().RimuoviTelefono(e.Telefono, this); LanciaEvento(this); };
        }

        public PersonaFisica(DatiPersonaFisica datiPersonaFisica)
        {
            this._datiPersona = datiPersonaFisica;
            this._email = new CollezioneEmail();
            this._telefoni = new CollezioneTelefoni();
            this.Email.OnAggiunta += (o, e) => { _persistenza.GetPersonaDAO().InserisciEmail(e.Email, this); LanciaEvento(this); };
            this.Email.OnRimozione += (o, e) => { _persistenza.GetPersonaDAO().RimuoviEmail(e.Email, this); LanciaEvento(this); };
            this.Telefoni.OnAggiunta += (o, e) => { _persistenza.GetPersonaDAO().InserisciTelefono(e.Telefono, this); LanciaEvento(this); };
            this.Telefoni.OnRimozione += (o, e) => { _persistenza.GetPersonaDAO().RimuoviTelefono(e.Telefono, this); LanciaEvento(this); };
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
        public DatiPersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, string partitaIVA = "")
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
