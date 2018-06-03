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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public struct Email
    {
        /// <summary>
        /// L'indirizzo email
        /// </summary>
        public string Indirizzo { get; private set; }
        /// <summary>
        /// Una nota sull'indirizzo email. Can be <c>null</c>
        /// </summary>
        public string Nota { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indirizzo">L'indirizzo email</param>
        /// <param name="nota">La nota dell'indirizzo mail</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Email(string indirizzo, string nota = "")
        {
            if(indirizzo == null) {
                throw new ArgumentNullException(nameof(indirizzo));
            }
            Regex controlloEmail = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
            if (!controlloEmail.Match(indirizzo).Success)
            {
                throw new ArgumentException("L'e-mail inserita non è valida.");
            }
            Indirizzo = indirizzo;
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota));
            }
            Nota = nota;
        }

        #region ToString()
        public override string ToString()
        {
            return Indirizzo;
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (!(obj is Email))
            {
                return false;
            }

            var email = (Email)obj;
            return Indirizzo == email.Indirizzo;
        }

        public override int GetHashCode()
        {
            return 1205928949 + EqualityComparer<string>.Default.GetHashCode(Indirizzo);
        }
    }
}
