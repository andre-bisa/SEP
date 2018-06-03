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
