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
}
