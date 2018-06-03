using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class UtenteAzienda : Utente
    {
        public override event EventHandler<ArgsModifica<Utente>> OnModifica;
        private DatiUtenteAzienda _datiUtenteAzienda;

        #region Costruttore
        public UtenteAzienda(DatiUtenteAzienda datiUtenteAzienda)
        {
            _datiUtenteAzienda = datiUtenteAzienda;
        }
        #endregion

        #region Properties
        public string RagioneSociale
        {
            get { return _datiUtenteAzienda.RagioneSociale; }
        }
        public string SedeLegale
        {
            get { return _datiUtenteAzienda.SedeLegale; }
        }

        public override string Username
        {
            get { return _datiUtenteAzienda.Username; }
        }
        public override string PartitaIva
        {
            get { return _datiUtenteAzienda.PartitaIva; }
        }
        public override string CodiceFiscale
        {
            get { return _datiUtenteAzienda.CodiceFiscale; }
        }
        public override string Indirizzo
        {
            get { return _datiUtenteAzienda.Indirizzo; }
        }
        public override CollezioneTelefoni Telefoni
        {
            get { return _datiUtenteAzienda.Telefoni; }
        }
        public override Email Email
        {
            get { return _datiUtenteAzienda.Email; }
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return  String.Format("{0} \nRagione sociale: {1} \nSedeLegale: {2}", base.ToString(), RagioneSociale, SedeLegale);
        }
        #endregion
    }

    public class DatiUtenteAzienda : DatiUtente
    {
        public string RagioneSociale { get; private set; }
        public string SedeLegale { get; private set; }
        
        /// <summary>
        /// Costruttore di Dati Utente di tipo Azienda
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pIva"></param>
        /// <param name="cf"></param>
        /// <param name="indirizzo"></param>
        /// <param name="email"></param>
        /// <param name="ragioneSociale"></param>
        /// <param name="sedeLegale"></param>
        /// <param name="telefoni"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DatiUtenteAzienda(string username, string pIva, string cf, string indirizzo, Email email, string ragioneSociale, string sedeLegale, List<Telefono> telefoni = null)
            : base(username, pIva, cf, indirizzo, email, telefoni)
        {
            if (ragioneSociale == null || sedeLegale == null)
            {
                throw new ArgumentNullException();
            }

            RagioneSociale = ragioneSociale;
            SedeLegale = sedeLegale;
        }
    }
}
