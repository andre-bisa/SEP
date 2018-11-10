using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.AdapterCalendario;

namespace IngegneriaDelSoftware.Model.AdapterCalendario
{
    public enum EnumAdapterCalendario
    {
        NONE,
        GoogleCalendar
    }

    public static class AdapterCalendarioStaticMethods
    {
        public static IAdapterCalendarioEsterno GetInstance(EnumAdapterCalendario enumerativo)
        {
            switch (enumerativo)
            {
                case EnumAdapterCalendario.GoogleCalendar:
                    return new AdapterGoogleCalendar(Impostazioni.GetInstance().FileSalvataggioTokenGoogleCalendar);
                case EnumAdapterCalendario.NONE:
                    return null;
                default:
                    return null;
            }
        }

        public static IAdapterCalendarioEsterno GetInstanceDaImpostazioni()
        {
            return GetInstance(Impostazioni.GetInstance().CalenadrioEsterno);
        }

    }

}
