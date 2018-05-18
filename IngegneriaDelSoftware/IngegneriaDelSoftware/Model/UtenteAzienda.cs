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
        private string _ragioneSociale, _sedeLegale;

        #region Costruttore
        /// <summary>
        /// Costruttore di un Utente di tipologia Azienda
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pIva"></param>
        /// <param name="cF"></param>
        /// <param name="indirizzo"></param>
        /// <param name="telefoni"></param>
        /// <param name="email"></param>
        /// <param name="ragioneSociale"></param>
        /// <param name="sedeLegale"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UtenteAzienda(string username, string pIva, string cF, string indirizzo, List<Telefono> telefoni, Telefono email, string ragioneSociale, string sedeLegale)
            : base(username, pIva, cF, indirizzo, telefoni, email)
        {
            if (ragioneSociale == null)
            {
                throw new ArgumentNullException();
            }
            if (sedeLegale == null)
            {
                throw new ArgumentNullException();
            }

            _ragioneSociale = ragioneSociale;
            _sedeLegale = sedeLegale;
        }
        #endregion

        #region Getters e setters
        public string RagioneSociale
        {
            get { return _ragioneSociale; }
            set { _ragioneSociale = value; }
        }
        public string SedeLegale
        {
            get { return _sedeLegale; }
            set { _sedeLegale = value; }
        }
        #endregion

        public override string ToString()
        {
            return String.Format("Ragione sociale: {0} \nSedeLegale: {1}", RagioneSociale, SedeLegale);
        }
    }
}
