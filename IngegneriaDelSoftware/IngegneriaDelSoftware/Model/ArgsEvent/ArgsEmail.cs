using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsEmail : EventArgs
    {
        public Email Email { get; private set; }

        public ArgsEmail(Email email)
        {
            this.Email = email;
        }
    }
}
