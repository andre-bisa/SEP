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

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsModifica<Tipo>
    {
        /// <summary>
        /// Il vecchio <see cref="Tipo"/>
        /// </summary>
        public Tipo Vecchio { get; private set; }
        /// <summary>
        /// Il nuovo <see cref="Tipo"/>, <c>null</c> per eliminare
        /// </summary>
        public Tipo Nuovo { get; private set; }

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="vecchio">Il vecchio <see cref="Tipo"/>, <c>null</c> per inserire</param>
        /// <param name="nuovo">Il nuovo <see cref="Tipo"/>, <c>null</c> per eliminare</param>
        public ArgsModifica (Tipo vecchio, Tipo nuovo)
        {
            Vecchio = vecchio;
            Nuovo = nuovo;
        }
    }
}
