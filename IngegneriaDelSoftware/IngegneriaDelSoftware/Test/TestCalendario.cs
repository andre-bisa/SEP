using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Test
{
    public class TestCalendario
    {

        public TestCalendario()
        {
            Appuntamento a1 = new Appuntamento("Bologna", new PersonaFisica("s", "Via x", "Mario", "Rossi"), "Riunione", DateTime.Now);
            Appuntamento a2 = new Appuntamento("Bologna", new PersonaFisica("s", "Via x", "Mario", "Verdi"), "Riunione", new DateTime(2018, 5, 30, 12, 0, 0));
            Appuntamento a3 = new Appuntamento("Roma", new PersonaFisica("s", "Via x", "Carlo", "Rossi"), "Riunione", new DateTime(2018, 4, 30, 12, 0, 0));
            Appuntamento a4 = new Appuntamento("Milano", new PersonaFisica("s", "Via x", "Filippo", "Bianchi"), "Riunione", new DateTime(2018, 3, 21, 12, 0, 0));
            Appuntamento a5 = new Appuntamento("Napoli", new PersonaFisica("s", "Via x", "Fabrizio", "Rossi"), "Riunione", new DateTime(2018, 4, 30, 12, 0, 0));

            Calendario calendario = new Calendario();

            calendario.AggiungiAppuntamento(a1);
            calendario.AggiungiAppuntamento(a2);
            calendario.AggiungiAppuntamento(a3);
            calendario.AggiungiAppuntamento(a4);
            calendario.AggiungiAppuntamento(a5);

            List<Appuntamento> appuntamenti = calendario.AppuntamentiDaA(new DateTime(2018, 3, 1, 0, 0, 0), DateTime.Now);

            foreach (Appuntamento a in appuntamenti)
            {
                Console.WriteLine(a.ToString());
            }
        }

    }
}
