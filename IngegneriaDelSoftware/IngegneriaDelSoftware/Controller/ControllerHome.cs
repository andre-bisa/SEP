using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerHome {

        public void MostraAppuntamento() {

        }

        public void MostraClienti() {
            
        }

        public void MostraCalendario() {
            
        }

        public void MostraEmail() {
            
        }

        public void MostraFatture() {
            
        }

        public void MostraPreventivi() {
            
        }

        public void MostraVendite() {
            
        }

        public void MostraImpostazioni() {
            
        }

        public List<Appuntamento> AppuntamentiDiOggi() {
            return Calendario.GetInstance().AppuntamentiDaA(DateTime.Now, DateTime.Now.AddDays(1));
        }
    }
}
