using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public class VoceVendita: Voce {

        #region Campi privati
        private float _provvigione;
        #endregion

        #region Property
        /// <summary>
        /// La provvigione sulla fattura.
        /// </summary>
        public float Provvigione { get { return this._provvigione; } }
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
        /// <param name="provvigione">La provvigione sulla fattura. Di default vale <c>0</c></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public VoceVendita(string causale, decimal importo, float provvigione = 0, string tipologia = null, int quantita = 1) : base(causale, importo, tipologia, quantita) {
            this._provvigione = provvigione;
        }
        #endregion

        #region Funzioni Pubbliche
        public override string ToString() {
            return String.Format("{0}\t{1}", base.ToString(), this._provvigione);
        }
        #endregion

    }
}
