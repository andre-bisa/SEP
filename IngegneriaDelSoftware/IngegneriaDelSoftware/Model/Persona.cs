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

        public List<Telefono> Telefoni { get; } = new List<Telefono>();
        public List<Email> Email { get; } = new List<Email>();

        #region "Costruttori"
        protected Persona(string codiceFiscale, string indirizzo)
        {
            CodiceFiscale = codiceFiscale ?? throw new ArgumentNullException(nameof(codiceFiscale));
            Indirizzo = indirizzo ?? throw new ArgumentNullException(nameof(indirizzo));
        }

        protected Persona(string codiceFiscale, string indirizzo, List<Telefono> telefoni, List<Email> email) : this(codiceFiscale, indirizzo)
        {
            if (telefoni != null)
                foreach (Telefono tel in telefoni)
                {
                    this.Telefoni.Add(tel);
                }

            if (email != null)
                foreach (Email mail in email)
                {
                    this.Email.Add(mail);
                }
        }

        protected Persona(string codiceFiscale, string indirizzo, List<Telefono> telefoni) : this(codiceFiscale, indirizzo, telefoni, null)
        {
        }

        protected Persona(string codiceFiscale, string indirizzo, List<Email> email) : this(codiceFiscale, indirizzo, null, email)
        {
        }

        #endregion

        #region "Funzioni Telefono"
        public void AggiungiTelefono (Telefono telefono)
        {
            if (telefono != null)
                this.Telefoni.Add(telefono);
        }

        public void RimuoviTelefono (Telefono telefono)
        {
            if (telefono != null)
                this.Telefoni.Remove(telefono);
        }
        #endregion

        #region "Funzioni Email"
        public void AggiungiEmail(Email email)
        {
            if (email != null)
                this.Email.Add(email);
        }

        public void RimuoviEmail(Email email)
        {
            if (email != null)
                this.Email.Remove(email);
        }
        #endregion

        #region "Funzioni pubbliche"
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

    public class PersonaFisica : Persona
    {
        private string _nome;
        public string Nome {
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
        public string Cognome {
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
        public string PartitaIVA {
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

        public override EnumTipoPersona TipoPersona { get { return EnumTipoPersona.Fisica; } }

        #region "Costruttori"
        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome) : this(codiceFiscale, indirizzo, nome, cognome, null, null, null)
        {
        }

        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, List<Telefono> telefoni, List<Email> email) : this(codiceFiscale, indirizzo, nome, cognome, null, telefoni, email)
        {
        }

        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, string partitaIVA) : this(codiceFiscale, indirizzo, nome, cognome, partitaIVA, null, null)
        {
        }

        public PersonaFisica(string codiceFiscale, string indirizzo, string nome, string cognome, string partitaIVA, List<Telefono> telefoni, List<Email> email) : base(codiceFiscale, indirizzo, telefoni, email)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cognome = cognome ?? throw new ArgumentNullException(nameof(cognome));
            PartitaIVA = partitaIVA; // can be null
        }
        #endregion

        public override string getDenominazione()
        {
            return this.Nome + " " + this.Cognome;
        }
    }

    public class PersonaGiuridica : Persona
    {
        private string _ragioneSociale;
        public string RagioneSociale {
            get
            {
                return _ragioneSociale;
            }
            private set
            {
                _ragioneSociale = value;
                base.LanciaEvento();
            }
        }
        private string _sedeLegale;
        public string SedeLegale {
            get
            {
                return _sedeLegale;
            }
            private set
            {
                _sedeLegale = value;
                base.LanciaEvento();
            }
        }
        private string _partitaIVA;
        public string PartitaIVA {
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

        public override EnumTipoPersona TipoPersona { get { return EnumTipoPersona.Giuridica; } }

        #region "Costruttori"
        public PersonaGiuridica(string codiceFiscale, string indirizzo, string ragioneSociale, string sedeLegale, string partitaIVA) : this(codiceFiscale, indirizzo, ragioneSociale, sedeLegale, partitaIVA, null, null)
        {
        }

        public PersonaGiuridica(string codiceFiscale, string indirizzo, string ragioneSociale, string sedeLegale, string partitaIVA, List<Telefono> telefoni, List<Email> email) : base(codiceFiscale, indirizzo, telefoni, email)
        {
            RagioneSociale = ragioneSociale ?? throw new ArgumentNullException(nameof(ragioneSociale));
            SedeLegale = sedeLegale ?? throw new ArgumentNullException(nameof(sedeLegale));
            PartitaIVA = partitaIVA ?? throw new ArgumentNullException(nameof(partitaIVA));
        }
        #endregion

        public override string getDenominazione()
        {
            return this.RagioneSociale;
        }
    }

}
