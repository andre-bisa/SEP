using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsMailInviata : EventArgs
    {
        public MailInviata MailInviata { get; private set; }

        public ArgsMailInviata(MailInviata mail)
        {
            MailInviata = mail;
        }
    }
}
