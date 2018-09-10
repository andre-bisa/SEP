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
    public class MailInviata
    {
        public DateTime Data { get; private set; }
        public string Oggetto { get; private set; }
        public string Corpo { get; private set; }
        public string Email { get; private set; }

        #region Costruttori
        public MailInviata(DateTime data, string oggetto, string corpo, string email)
        {
            Data = data;
            Oggetto = oggetto;
            Corpo = corpo;
            Email = email;
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            var inviata = obj as MailInviata;
            return inviata != null &&
                   Data == inviata.Data &&
                   Oggetto == inviata.Oggetto &&
                   Corpo == inviata.Corpo &&
                   Email == inviata.Email;
        }

        public override int GetHashCode()
        {
            var hashCode = -574234898;
            hashCode = hashCode * -1521134295 + Data.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Oggetto);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Corpo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }

        public static bool operator ==(MailInviata inviata1, MailInviata inviata2)
        {
            return EqualityComparer<MailInviata>.Default.Equals(inviata1, inviata2);
        }

        public static bool operator !=(MailInviata inviata1, MailInviata inviata2)
        {
            return !(inviata1 == inviata2);
        }

        #endregion
    }

}
