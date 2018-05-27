using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerLogin {
        public bool VerificaCredenziali(string username, SecureString password) {
            // libera la stringa;
            password.Dispose();
            return true;
        }
    }
}
