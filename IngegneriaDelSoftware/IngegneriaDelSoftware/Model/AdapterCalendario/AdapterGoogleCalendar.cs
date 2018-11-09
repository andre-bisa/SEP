using IngegneriaDelSoftware.Model.AdapterGoogleCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Globalization;

namespace IngegneriaDelSoftware.Model.AdapterCalendario
{
    public class AdapterGoogleCalendar : IAdapterCalendarioEsterno
    {
        private static readonly string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        private static readonly string ApplicationName = "Google Calendar API .NET SEP";

        private CalendarService Servizio
        {
            get;
        }

        public AdapterGoogleCalendar()
        {
            UserCredential credential;
            using (FileStream stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
            }

            Servizio = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            /*string elencoCalendari = "";

            foreach (CalendarListEntry calendario in Servizio.CalendarList.List().Execute().Items)
            {
                elencoCalendari += calendario.Summary + ", ";
            }

            System.Windows.Forms.MessageBox.Show(elencoCalendari);*/
        }

        public ICollection<Appuntamento> GetListaAppuntamenti()
        {
            LinkedList<Appuntamento> result = new LinkedList<Appuntamento>();

            var richiesta = Servizio.Events.List("primary");
            richiesta.TimeMin = DateTime.Now;
            richiesta.ShowDeleted = false;
            richiesta.SingleEvents = true;
            richiesta.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            foreach (Event evento in richiesta.Execute().Items)
            {
                DateTime data = evento.Start.DateTime ?? DateTime.Parse(evento.Start.Date);
                result.AddLast(new Appuntamento(evento.Id, null, evento.Summary ?? "", evento.Location ?? "", data));
            }
            
            return result;
        }
    }
}
