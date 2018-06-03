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
using IngegneriaDelSoftware.Model.ArgsEvent;
using System.Drawing;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Model
{
    public class Impostazioni
    {

        #region Singleton
        protected Impostazioni() { }

        private static Impostazioni _instance = null;
        public static Impostazioni GetInstance()
        {
            if (_instance == null)
                _instance = new Impostazioni();
            return _instance;
        }
        #endregion

        #region Colori clienti
        public Color ColoreClienteAttivo { get; set; } = Color.LightYellow;
        public Color ColoreClienteEx { get; set; } = Color.LightSalmon;
        public Color ColoreClientePotenziale { get; set; } = Color.LightGreen;

        public Color ColoreCliente(EnumTipoCliente tipoCliente)
        {
            switch (tipoCliente)
            {
                case EnumTipoCliente.Attivo:
                default:
                    return this.ColoreClienteAttivo;
                case EnumTipoCliente.Ex:
                    return this.ColoreClienteEx;
                case EnumTipoCliente.Potenziale:
                    return this.ColoreClientePotenziale;
            }
        }
        #endregion

        #region Database
        public EnumTipoPersistenza TipoPersistenza { get; set; }
        #endregion

        #region Dati pubblici
        public int IDUtente { get; internal set; }
        public Utente UtenteLoggato { get; internal set; }
        public string Email { get; private set; } = "andreabisacchi@gmail.com";
        public string PasswordEmail { get; private set; } = "PASSWORD-QUI-PASSWORD-QUI";
        #endregion

    }
}
