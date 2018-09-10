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

            /*if (IDUtente > 0)
            {
                // Carico DB
                CollezioneClienti.GetInstance();
                CollezioneEmailInviate.GetInstance();
                CollezionePreventivi.GetInstance();
                CollezioneVendite.GetInstance();
                CollezioneFatture.GetInstance();
            }*/

            return (IDUtente >= 0);
        }

    }
}
