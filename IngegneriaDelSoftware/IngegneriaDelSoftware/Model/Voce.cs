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
    public abstract class Voce: IComparable<Voce> {

        #region Campi privati
        private string _causale;
        private decimal _importo;
        private string _tipologia;
        private int _quantita;
        #endregion

        #region Property
        /// <summary>
        /// La causale della voce.
        /// </summary>
        public string Causale { get { return this._causale; } }
        /// <summary>
        /// L'importo della voce
        /// </summary>
        public decimal Importo { get { return this._importo; } }
        /// <summary>
        /// La tipologia della voce. Cioè un campo opzionale riempibile dall'utente per raggruppare le voci in macro gruppi.
        /// <para>L'importo è sempre da intendersi singolo</para>
        /// </summary>
        public string Tipologia { get { return this._tipologia; } }
        /// <summary>
        /// La quantità di una voce
        /// </summary>
        public int Quantita { get { return this._quantita; } }
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
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Voce(string causale, decimal importo, string tipologia = null, int quantita = 1) {
            if(causale == null) {
                throw new ArgumentNullException("La causale non può essere nulla");
            }
            if(quantita < 0) {
                throw new ArgumentException("La quantità non può essere negativa");
            }
            if(tipologia == null) {
                tipologia = ""; //La tipologia può essere nulla;
            }
            this._causale = causale;
            this._importo = importo;
            this._tipologia = tipologia;
            this._quantita = quantita;
        }
        #endregion

        #region Funzioni pubbliche
        /// <summary>
        /// Calcola e restituisce l'effettivo valore della voce effettuando <c><see cref="Quantita"/> * <see cref="Importo"/></c>
        /// </summary>
        /// <returns>Il valore totale della voce</returns>
        public virtual decimal ValoreTotale() {
            return this._quantita * this._importo;
        }

        public override string ToString() {
            return string.Format("Tipo: \"{1}\", {0}, Quantità: {2}, {3:C2}", this._causale, this._tipologia, this._quantita, this._importo);
        }

        public virtual int CompareTo(Voce other) {
            return this._importo.CompareTo(other.Importo);
        }

        public override bool Equals(object obj)
        {
            var voce = obj as Voce;
            return voce != null &&
                   Causale == voce.Causale &&
                   Importo == voce.Importo &&
                   Tipologia == voce.Tipologia &&
                   Quantita == voce.Quantita;
        }

        public override int GetHashCode()
        {
            var hashCode = 87959449;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Causale);
            hashCode = hashCode * -1521134295 + Importo.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tipologia);
            hashCode = hashCode * -1521134295 + Quantita.GetHashCode();
            return hashCode;
        }

        #endregion
    }
}
