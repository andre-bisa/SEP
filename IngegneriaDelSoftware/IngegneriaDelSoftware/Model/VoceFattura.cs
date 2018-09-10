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
        public VoceFattura(string causale, decimal importo, float IVA = 0, string tipologia = null, int quantita = 1) : base(causale, importo, String.IsNullOrEmpty(tipologia) ? "GENERICO" : tipologia, quantita) {
            this._iva = IVA;
        }
        #endregion

        #region Funzioni pubbliche
        public override string ToString() {
            return String.Format("{0}, {1}%", base.ToString(), this._iva*100);
        }

        public override bool Equals(object obj)
        {
            var fattura = obj as VoceFattura;
            return fattura != null &&
                   base.Equals(obj) &&
                   Iva == fattura.Iva;
        }

        public override decimal ValoreTotale() {
            return base.ValoreTotale() + base.ValoreTotale() * Convert.ToDecimal(this._iva);
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
