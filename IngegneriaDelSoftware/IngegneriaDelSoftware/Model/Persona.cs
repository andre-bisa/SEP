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

}
