using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class MailInviata
    {
        public int ID { get; private set; }
        public DateTime Data { get; private set; }
        public string Oggetto { get; private set; }
        public string Corpo { get; private set; }
        public string Email { get; private set; }

        public MailInviata(int iD, DateTime data, string oggetto, string corpo, string email)
        {
            ID = iD;
            Data = data;
            Oggetto = oggetto;
            Corpo = corpo;
            Email = email;
        }

        #region Equals
        public override bool Equals(object obj)
        {
            var inviata = obj as MailInviata;
            return inviata != null &&
                   ID == inviata.ID;
        }

        public override int GetHashCode()
        {
            return 1213502048 + ID.GetHashCode();
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
