using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class PersonaGiuridica : Persona
    {
        private string _ragioneSociale;
        public string RagioneSociale
        {
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
        public string SedeLegale
        {
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
