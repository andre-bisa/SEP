using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.AdapterGoogleCalendar
{
    public interface IAdapterCalendarioEsterno
    {
        ICollection<Appuntamento> GetListaAppuntamenti();
    }
}
