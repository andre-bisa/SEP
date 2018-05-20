using IngegneriaDelSoftware.Model.ArgsEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public class VoceFattura: Voce {

        #region Campi privati
        private float _iva;
        #endregion

        #region Proprty
        /// <summary>
        /// Il valore dell'iva da calcolare pe la voce
        /// </summary>
        public float Iva { get { return this._iva; } }
        #endregion

        #region Costruttore
        /// <summary>
        /// Crea una nuova voce inseribile in qualsiasi <see cref="VoceContainer"/>.
        /// </summary>
        /// <param name="causale">La causale della voce.</param>
        /// <param name="importo">L'importo della voce</param>
        /// <param name="tipologia">La tipologia della voce. Cioè un campo opzionale 
        /// riempibile dall'utente per raggruppare le voci in macro gruppi.
        /// <para>L'importo è sempre da intendersi singolo</para></param>
        /// <param name="quantita">La quantità di una voce</param>
        /// <param name="IVA">Il valore dell'iva da calcolare pe la voce</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public VoceFattura(string causale, decimal importo, float IVA = 0, string tipologia = null, int quantita = 1) : base(causale, importo, tipologia, quantita) {
            this._iva = IVA;
        }
        #endregion

        #region Funzioni pubbliche
        public override string ToString() {
            return String.Format("{0}\t{1}", base.ToString(), this._iva);
        }

        public override bool Equals(object obj)
        {
            var fattura = obj as VoceFattura;
            return fattura != null &&
                   base.Equals(obj) &&
                   Iva == fattura.Iva;
        }

        public override int GetHashCode()
        {
            var hashCode = 582580267;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Iva.GetHashCode();
            return hashCode;
        }
        #endregion

    }
}
