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

using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public class PersonaGiuridica: Persona {

        #region Campi privati
        private DatiPersonaGiuridica _datiPersona;
        private CollezioneTelefoni _telefoni;
        private CollezioneEmail _email;

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza);
        #endregion

        #region Proprietà
        /// <summary>
        /// La ragione sociale
        /// <para>Il set causa il lancio dell'evento <see cref="Persona.ModificaPersona"/></para>
        /// </summary>
        public string RagioneSociale {
            get {
                return this._datiPersona.RagioneSociale;
            }
        }
        
        /// <summary>
        /// La sede legale della persona
        /// <para>Il set causa il lancio dell'evento <see cref="Persona.ModificaPersona"/></para>
        /// </summary>
        public string SedeLegale {
            get {
                return this._datiPersona.SedeLegale;
            }
        }
        
        /// <summary>
        /// La partita IVA della persona
        /// <para>Il set causa il lancio dell'evento <see cref="Persona.ModificaPersona"/></para>
        /// </summary>
        public string PartitaIVA {
            get {
                return this._datiPersona.PartitaIVA;
            }
        }
        /// <summary>
        /// Il tipo di persona
        /// </summary>
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
        /// <param name="codiceFiscale">Il codice fiscale della persona</param>
        /// <param name="indirizzo">L'indirizzo della persona</param>
        /// <param name="ragioneSociale">La ragione sociale della persona</param>
        /// <param name="sedeLegale">La sede legale della persona</param>
        /// <param name="partitaIVA">La partita IVA della persona</param>
        /// <param name="telefoni">I numeri di telefono della persona</param>
        /// <param name="email">Gli indirizzi email della persona</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PersonaGiuridica(string codiceFiscale, string indirizzo, string ragioneSociale, string sedeLegale, string partitaIVA, IEnumerable<Telefono> telefoni = null, IEnumerable<Email> email = null) {
            this._datiPersona = new DatiPersonaGiuridica(codiceFiscale, indirizzo, ragioneSociale, sedeLegale, partitaIVA);
            this._email = new CollezioneEmail(email);
            this._telefoni = new CollezioneTelefoni(telefoni);
            this.Email.OnAggiunta += (o, e) => { _persistenza.GetPersonaDAO().InserisciEmail(e.Email, this); LanciaEvento(this); };
            this.Email.OnRimozione += (o, e) => { _persistenza.GetPersonaDAO().RimuoviEmail(e.Email, this); LanciaEvento(this); };
            this.Telefoni.OnAggiunta += (o, e) => { _persistenza.GetPersonaDAO().InserisciTelefono(e.Telefono, this); LanciaEvento(this); };
            this.Telefoni.OnRimozione += (o, e) => { _persistenza.GetPersonaDAO().RimuoviTelefono(e.Telefono, this); LanciaEvento(this); };
        }

        public PersonaGiuridica(DatiPersonaGiuridica datiPersonaGiuridica)
        {
            this._datiPersona = datiPersonaGiuridica;
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
        public override string getDenominazione() {
            return this.RagioneSociale;
        }

        public override void CambiaDatiPersona(DatiPersona datiPersona)
        {
            if (this._datiPersona.Equals(datiPersona))
                return;

            if (datiPersona.TipoDatiPersona() == EnumTipoPersona.Giuridica)
            {
                Persona vecchio = this.Clone();
                this._datiPersona = (DatiPersonaGiuridica)datiPersona;

                if (! _persistenza.GetPersonaDAO().Aggiorna(vecchio, this))
                {
                    this._datiPersona = ((PersonaGiuridica)vecchio)._datiPersona; // Recupero i vecchi dati
                    throw new ExceptionPersistenza();
                }
                base.LanciaEvento(vecchio);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected override Persona Clone()
        {
            return new PersonaGiuridica(this._datiPersona);
        }

        public override int GetHashCode()
        {
            var hashCode = -1989808641;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            return hashCode;
        }
    }

    public class DatiPersonaGiuridica : DatiPersona
    {

        #region Campi privati
        private string _codiceFiscale;
        private string _indirizzo;
        private string _ragioneSociale;
        private string _sedeLegale;
        private string _partitaIVA;
        #endregion

        #region Proprietà
        public override string CodiceFiscale
        {
            get
            {
                return _codiceFiscale;
            }
        }
        /// <summary>
        /// L'indirizzo della persona
        /// <para>Il set causa il lancio dell'evento <see cref="ModificaPersona"/></para>
        /// </summary>
        public override string Indirizzo
        {
            get
            {
                return _indirizzo;
            }
        }

        public string RagioneSociale
        {
            get
            {
                return this._ragioneSociale;
            }
        }

        public string SedeLegale
        {
            get
            {
                return _sedeLegale;
            }
        }

        public string PartitaIVA
        {
            get
            {
                return _partitaIVA;
            }
        }
        #endregion

        #region Costruttori
        public DatiPersonaGiuridica(string codiceFiscale, string indirizzo, string ragioneSociale, string sedeLegale, string partitaIVA)
        {
            #region Controlli
            if (codiceFiscale == null)
                throw new ArgumentNullException();
            if (indirizzo == null)
                throw new ArgumentNullException();
            if (ragioneSociale == null)
                throw new ArgumentNullException();
            if (sedeLegale == null)
                throw new ArgumentNullException();
            if (partitaIVA == null)
                throw new ArgumentNullException();
            #endregion

            this._codiceFiscale = codiceFiscale;
            this._indirizzo = indirizzo;
            this._ragioneSociale = ragioneSociale;
            this._sedeLegale = sedeLegale;
            this._partitaIVA = partitaIVA;
        }
        #endregion

        public override EnumTipoPersona TipoDatiPersona()
        {
            return EnumTipoPersona.Giuridica;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DatiPersonaGiuridica))
            {
                return false;
            }

            var giuridica = (DatiPersonaGiuridica)obj;
            return CodiceFiscale == giuridica.CodiceFiscale &&
                   Indirizzo == giuridica.Indirizzo &&
                   RagioneSociale == giuridica.RagioneSociale &&
                   SedeLegale == giuridica.SedeLegale &&
                   PartitaIVA == giuridica.PartitaIVA;
        }

        public override int GetHashCode()
        {
            var hashCode = -559532584;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CodiceFiscale);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Indirizzo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RagioneSociale);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SedeLegale);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PartitaIVA);
            return hashCode;
        }

        public static bool operator ==(DatiPersonaGiuridica giuridica1, DatiPersonaGiuridica giuridica2)
        {
            return giuridica1.Equals(giuridica2);
        }

        public static bool operator !=(DatiPersonaGiuridica giuridica1, DatiPersonaGiuridica giuridica2)
        {
            return !(giuridica1 == giuridica2);
        }
    }
}
