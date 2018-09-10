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
    public class VocePreventivo: Voce {

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
        public VocePreventivo(string causale, decimal importo, string tipologia = null, int quantita = 1) : base(causale, importo, tipologia, quantita) {
        }
        #endregion

        /// <summary>
        /// Crea una nuova <see cref="VoceVendita"/> a partire da una <see cref="VocePreventivo"/>.
        /// <para>Il valore della provvigione è quello di default (<c>0</c>)</para>
        /// </summary>
        /// <param name="input"></param>
        public VoceVendita ToVendita() {
            return new VoceVendita(this.Causale, this.Importo,tipologia: this.Tipologia, quantita: this.Quantita);
        }
    }
}
