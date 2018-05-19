using IngegneriaDelSoftware.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Test
{
    [TestFixture]
    public class TestCalendario
    {

        public TestCalendario()
        {
            Persona p1 = new PersonaFisica("s", "Via x", "Mario", "Rossi");
            Persona p2 = new PersonaFisica("s", "Via x", "Mario", "Verdi");
            Persona p3 = new PersonaGiuridica("s", "Via x", "REgione Sociale", "Sede Illegale", "2");
            Persona p4 = new PersonaFisica("s", "Via x", "Filippo", "Bianchi");
            DatiAppuntamento datiAppuntamento1 = new DatiAppuntamento(p1, "Riunione", "Bologna", DateTime.Now);
            DatiAppuntamento datiAppuntamento2 = new DatiAppuntamento(p2, "Riunione", "Milano", new DateTime(2018, 4, 30, 12, 0, 0));
            DatiAppuntamento datiAppuntamento3 = new DatiAppuntamento(p2, "Riunione", "Roma", new DateTime(2018, 4, 30, 12, 0, 0));
            DatiAppuntamento datiAppuntamento4 = new DatiAppuntamento(p2, "Riunione", "Napoli", new DateTime(2018, 3, 21, 12, 0, 0));
            Appuntamento a1 = new Appuntamento(datiAppuntamento1);
            Appuntamento a2 = new Appuntamento(datiAppuntamento2);
            Appuntamento a3 = new Appuntamento(datiAppuntamento3);
            Appuntamento a4 = new Appuntamento(datiAppuntamento4);



            Calendario calendario = new Calendario();

            calendario.Add(a1);
            calendario.Add(a2);
            calendario.Add(a3);
            calendario.Add(a4);

            List<Appuntamento> appuntamenti = calendario.AppuntamentiDaA(new DateTime(2018, 3, 1, 0, 0, 0), DateTime.Now);

            foreach (Appuntamento a in appuntamenti)
            {
                Console.WriteLine(a.ToString());
            }
        }

        [Test]
        public void Test()
        {

        }

    }
}
