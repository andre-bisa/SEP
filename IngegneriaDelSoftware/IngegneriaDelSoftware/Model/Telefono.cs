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

namespace IngegneriaDelSoftware.Model
{
    public struct Telefono
    {
        /// <summary>
        /// Il numero di telefono
        /// </summary>
        public string Numero { get; private set; }
        /// <summary>
        /// Una nota sul numero. Can be <c>null</c>.
        /// </summary>
        public string Nota { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero">Il numero di telefono</param>
        /// <param name="nota">La nota del telefono</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Telefono(string numero, string nota = "")
        {
            if (numero == null)
            {
                throw new ArgumentNullException(nameof(numero));
            }
            Numero = numero;
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota));
            }
            Nota = nota;
        }

        #region ToString()
        public override string ToString()
        {
            return Numero;
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (!(obj is Telefono))
            {
                return false;
            }

            var telefono = (Telefono)obj;
            return Numero == telefono.Numero;
        }

        public override int GetHashCode()
        {
            return -1449941195 + EqualityComparer<string>.Default.GetHashCode(Numero);
        }

    }
}
