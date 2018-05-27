using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerCalendario {
        public Appuntamento[] GetAppuntamentiDaA(DateTime da, DateTime a) {
            return CollezioneAppuntamenti.GetInstance().DaA(da, a);
        }
        public List<Appuntamento> GetAppuntamenti() {
            return CollezioneAppuntamenti.GetInstance().ToList();
        }
    }
}
