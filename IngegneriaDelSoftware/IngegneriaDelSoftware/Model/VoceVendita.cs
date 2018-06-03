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
            return String.Format("{0}, {1}%", base.ToString(), this._provvigione*100);
        }

        public override decimal ValoreTotale() {
            return base.ValoreTotale() + base.ValoreTotale() * Convert.ToDecimal(this._provvigione);
        }

        /// <summary>
        /// Crea una nuova <see cref="VoceFattura"/> a partire da una <see cref="VoceVendita"/>.
        /// <para>Il valore dell'iva è quello di default (<c>0</c>)</para>
        /// </summary>
        /// <param name="input"></param>
        public  VoceFattura ToFattura() {
            return new VoceFattura(this.Causale, this.Importo, tipologia: this.Tipologia, quantita: this.Quantita);
        }
        #endregion
    }
}
