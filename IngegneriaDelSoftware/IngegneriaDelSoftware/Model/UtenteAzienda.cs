using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class UtenteAzienda : Utente, IObservable<UtenteAzienda>
    {
        private string _ragioneSociale, _sedeLegale;
        public event EventHandler<ArgsModifica<UtenteAzienda>> OnModifica;

        #region Costruttore
        /// <summary>
        /// Costruttore di un Utente di tipologia Azienda
        /// </summary>
        /// <param name="ragioneSociale"></param>
        /// <param name="sedeLegale"></param>
        public UtenteAzienda(string ragioneSociale, string sedeLegale)
        {
            _ragioneSociale = ragioneSociale ?? throw new ArgumentNullException(nameof(ragioneSociale));
            _sedeLegale = sedeLegale ?? throw new ArgumentNullException(nameof(sedeLegale));
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
    }
}
