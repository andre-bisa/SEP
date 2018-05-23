using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller
{
    public class OggettoVisualizzato<T>
    {
        public T Oggetto { get; }
        public bool Visualizzato { get; set; }

        public OggettoVisualizzato(T oggetto, bool visualizzato)
        {
            this.Oggetto = oggetto;
            this.Visualizzato = visualizzato;
        }
    }
}
