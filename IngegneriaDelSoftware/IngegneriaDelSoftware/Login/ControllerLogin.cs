using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Controller
{
    public class ControllerLogin
    {

        private Impostazioni _impostazioni = Impostazioni.GetInstance();


        #region Singleton
        protected ControllerLogin()
        {
            // Impostazioni iniziali che dovranno essere recuperate da file
            _impostazioni.TipoPersistenza = Persistenza.EnumTipoPersistenza.MySQL;
        }
        private static ControllerLogin _instance = null;
        public static ControllerLogin GetInstance()
        {
            if (_instance == null)
                _instance = new ControllerLogin();
            return _instance;
        }
        #endregion

        /// <summary>
        /// Funzione che esegue il login e che carica la finestra Home
        /// </summary>
        /// <param name="username">Username dell'utente</param>
        /// <param name="password">Password dell'utente</param>
        /// <returns></returns>
        public bool ControllaCredenziali(string username, string password)
        {
            int IDUtente = PersistenzaFactory.OttieniDAO(_impostazioni.TipoPersistenza).GetUtenteDAO().Accesso(username, password);
            _impostazioni.UtenteLoggato = null; // Da settare
            _impostazioni.IDUtente = IDUtente;

            return (IDUtente >= 0);
        }

    }
}
