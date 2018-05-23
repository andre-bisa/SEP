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
