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
        private Calendario _calendario;
        private Appuntamento a1, a2, a3, a4;

        public TestCalendario()
        {
            Persona p1 = new PersonaFisica("s", "Via x", "Mario", "Rossi");
            Persona p2 = new PersonaFisica("s", "Via x", "Mario", "Verdi");
            Persona p3 = new PersonaGiuridica("s", "Via x", "REgione Sociale", "Sede Illegale", "2");
            Persona p4 = new PersonaFisica("s", "Via x", "Filippo", "Bianchi");
            DatiAppuntamento datiAppuntamento1 = new DatiAppuntamento(p1, "Riunione", "Bologna", DateTime.Now);
            DatiAppuntamento datiAppuntamento2 = new DatiAppuntamento(p2, "Riunione", "Milano", new DateTime(2018, 4, 30, 12, 0, 0));
            DatiAppuntamento datiAppuntamento3 = new DatiAppuntamento(p3, "Riunione", "Roma", new DateTime(2100, 5, 30, 12, 0, 0));
            DatiAppuntamento datiAppuntamento4 = new DatiAppuntamento(p4, "Riunione", "Napoli", new DateTime(2018, 3, 21, 12, 0, 0));
            a1 = new Appuntamento(datiAppuntamento1);
            a2 = new Appuntamento(datiAppuntamento2);
            a3 = new Appuntamento(datiAppuntamento3);
            a4 = new Appuntamento(datiAppuntamento4);

            _calendario = new Calendario();

            _calendario.Add(a1);
            _calendario.Add(a2);
            _calendario.Add(a3);
            _calendario.Add(a4);
        }

        [Test]
        public void TestRimuoviCalendario()
        {
            Persona p2 = new PersonaFisica("s", "Via x", "Mario", "Verdi");
            DatiAppuntamento datiAppuntamento2 = new DatiAppuntamento(p2, "Riunione", "Milano", new DateTime(2018, 4, 30, 12, 0, 0));
            Appuntamento a2 = new Appuntamento(datiAppuntamento2);

            Assert.AreEqual(true, _calendario.Remove(a2));
        }

        [Test]
        public void TestAggiungiCalendario()
        {
            Persona p = new PersonaFisica("s", "Via x", "Mario", "Rossi");
            DatiAppuntamento datiAppuntamento2 = new DatiAppuntamento(p, "Chiacchierare", "Bologna", new DateTime(2018, 4, 30, 12, 0, 0));
            Appuntamento a2 = new Appuntamento(datiAppuntamento2);

            this._calendario.Add(a2);

            Assert.AreEqual(true, _calendario.Contains(a2));
        }

        [Test]
        public void TestCalendarioDaA()
        {
            List<Appuntamento> appuntamenti = _calendario.AppuntamentiDaA(new DateTime(2018, 3, 1, 0, 0, 0), DateTime.Now);

            Assert.AreEqual(true, appuntamenti.Contains(a1));
            Assert.AreEqual(true, appuntamenti.Contains(a2));
            Assert.AreEqual(false, appuntamenti.Contains(a3));
            Assert.AreEqual(true, appuntamenti.Contains(a4));
        }


    }
}
