using IngegneriaDelSoftware.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IngegneriaDelSoftware.Model.Fattura;
using static IngegneriaDelSoftware.Model.Preventivo;
using static IngegneriaDelSoftware.Model.Vendita;

namespace IngegneriaDelSoftware.Test {
    [TestFixture]
    public class TestFatturazione {
        [Test]
        public void TestFattura() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new Fattura(2018, "2", cliente, vendita);
            var voce1 = new VoceFattura("Corda", 30, 0.20f);
            var voce2 = new VoceFattura("Canapa", 20, 0.20f);

            fattura.Add(voce1, voce2);
            Assert.AreEqual(fattura[0], voce1);
            Assert.AreEqual(fattura[1], voce2);
            Assert.AreEqual(fattura.Count, 2);
            fattura.Sort();
            Assert.AreEqual(fattura[0], voce2);
            Assert.AreEqual(fattura[1], voce1);
            fattura.Clear();
            fattura.Add(voce1);
            Assert.AreEqual(fattura.Count, 1);
            fattura.Add(voce1, voce2);
            Assert.AreEqual(fattura.Calcola(), "80");
            fattura.Finalizza();
            var dati = new DatiFattura();
            Assert.Catch(() => fattura.DatiFatturaInterni = dati);
            fattura.Definalizza();
            Assert.DoesNotThrow(() => fattura.DatiFatturaInterni = dati);
        }
        [Test]
        public void TestVendita() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var voce1 = new VoceVendita("Corda", 30);
            var voce2 = new VoceVendita("Canapa", 20);
            DatiVendita d = new DatiVendita(vendita.DatiVenditaInterni, iD: 8);
            vendita.Add(voce1, voce2);
            Assert.AreEqual(vendita[0], voce1);
            Assert.AreEqual(vendita[1], voce2);
            Assert.AreEqual(vendita.Count, 2);
            vendita.Sort();
            Assert.AreEqual(vendita[0], voce2);
            Assert.AreEqual(vendita[1], voce1);
            vendita.Clear();
            Assert.AreEqual(vendita.Count, 0);
            vendita.Add(voce1);
            vendita.Add(voce1, voce2);
            Assert.AreEqual(vendita.Totale(), 80);
        }
        [Test]
        public void TestPreventivo() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var preventivo = new Preventivo(1, cliente, accettato: true);
            var voce1 = new VocePreventivo("Corda", 30);
            var voce2 = new VocePreventivo("Canapa", 20);

            preventivo.Add(voce1, voce2);
            Assert.AreEqual(preventivo[0], voce1);
            Assert.AreEqual(preventivo[1], voce2);
            Assert.AreEqual(preventivo.Count, 2);
            preventivo.Sort();
            Assert.AreEqual(preventivo[0], voce2);
            Assert.AreEqual(preventivo[1], voce1);
            preventivo.Clear();
            Assert.AreEqual(preventivo.Count, 0);
            preventivo.Add(voce1);
            preventivo.Add(voce1, voce2);
            Assert.AreEqual(preventivo.Totale(), 80);

            Assert.AreEqual(preventivo.Accettato, true);
            preventivo.DatiPreventivoInterni = new DatiPreventivo(preventivo.DatiPreventivoInterni, accettato: false);
            Assert.AreEqual(preventivo.Accettato, false);
        }
    }
}
