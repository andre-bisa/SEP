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
            Assert.AreEqual(fattura.Calcola(), "96,0");
            fattura.Finalizza();
            var dati = new DatiFattura();
            Assert.Catch(() => fattura.DatiFatturaInterni = dati);
            Assert.Catch(() => fattura[1] = voce2);
            Assert.Catch(() => fattura.Add(voce1));
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
        [Test]
        public void TestEventiFattura() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new Fattura(2018, "2", cliente, vendita);
            var old = new Fattura(2018, "2", cliente, vendita);
            old.Finalizza();
            var voce1 = new VoceFattura("Corda", 30, 0.20f);
            var voce2 = new VoceFattura("Canapa", 20, 0.20f);
            fattura.OnModifica += (o, e) => {
                Assert.AreEqual(old, e.Vecchio);
                Assert.AreEqual(e.Nuovo[0], voce1);
                Assert.AreEqual(e.Nuovo[1], voce2);
                Assert.AreEqual(fattura, e.Nuovo);
            };
        }
        [Test]
        public void TestEventiVendita() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var old = new Vendita(1, cliente);
            var voce1 = new VoceVendita("Corda", 30);
            var voce2 = new VoceVendita("Canapa", 20);
            vendita.OnModifica += (o, e) => {
                Assert.AreEqual(old, e.Vecchio);
                Assert.AreEqual(e.Nuovo[0], voce1);
                Assert.AreEqual(e.Nuovo[1], voce2);
                Assert.AreEqual(vendita, e.Nuovo);
            };
        }
        [Test]
        public void TestEventiPreventivo() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var preventivo = new Preventivo(1, cliente, accettato: true);
            var old = new Preventivo(1, cliente, accettato: true);
            var voce1 = new VocePreventivo("Corda", 30);
            var voce2 = new VocePreventivo("Canapa", 20);
            preventivo.OnModifica += (o, e) => {
                Assert.AreEqual(old, e.Vecchio);
                Assert.AreEqual(e.Nuovo[0], voce1);
                Assert.AreEqual(e.Nuovo[1], voce2);
                Assert.AreEqual(preventivo, e.Nuovo);
            };
        }
        [Test]
        public void TestConversionePreventivoVendita() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var preventivo = new Preventivo(1, cliente, accettato: true);
            var voce1 = new VocePreventivo("Corda", 30);
            preventivo.Add(voce1);
            var vendita = Vendita.FromPreventivo(1, preventivo);
            Assert.AreEqual(voce1.ToVendita(), vendita[0]);
        }
        [Test]
        public void TestConversioneVenditaFattura() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita1 = new Vendita(1, cliente);
            var voce11 = new VoceVendita("Corda", 30, 0.20f);
            var voce12 = new VoceVendita("Canapa", 20, 0.20f);
            vendita1.Add(voce11, voce12);
            var vendita2 = new Vendita(2, cliente);
            var voce21 = new VoceVendita("Corda1", 30, 0.20f);
            var voce22 = new VoceVendita("Canapa1", 20, 0.20f);
            vendita2.Add(voce21, voce22);
            List<Vendita> vendite = new List<Vendita>();
            vendite.Add(vendita1);
            vendite.Add(vendita2);
            var fattura = Fattura.FromVendite(2018, "3", vendite);
            Assert.AreEqual(voce11.ToFattura(), fattura[0]);
            Assert.AreEqual(voce12.ToFattura(), fattura[1]);
            Assert.AreEqual(voce21.ToFattura(), fattura[2]);
            Assert.AreEqual(voce22.ToFattura(), fattura[3]);

        }
        [Test]
        public void TestMixedConversionePreventivoVendita() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var preventivo = new Preventivo(1, cliente, accettato: true);
            var voce1 = new VocePreventivo("Corda", 30);
            var voce2 = new VoceVendita("Canapa", 20);
            preventivo.Add(voce1);
            var vendita = Vendita.FromPreventivo(1, preventivo);
            vendita.Add(voce2);
            Assert.AreEqual(voce1.ToVendita(), vendita[0]);
            Assert.AreEqual(voce2, vendita[1]);
            Assert.AreEqual(2, vendita.Count);
        }
        [Test]
        public void TestMixedConversioneVenditaFattura() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita1 = new Vendita(1, cliente);
            var voce11 = new VoceVendita("Corda", 30, 0.20f);
            var voce12 = new VoceVendita("Canapa", 20, 0.20f);
            vendita1.Add(voce11, voce12);
            var vendita2 = new Vendita(2, cliente);
            var voce21 = new VoceVendita("Corda1", 30, 0.20f);
            var voce22 = new VoceVendita("Canapa1", 20, 0.20f);
            vendita2.Add(voce21, voce22);
            List<Vendita> vendite = new List<Vendita>();
            vendite.Add(vendita1);
            vendite.Add(vendita2);
            var fattura = Fattura.FromVendite(2018, "3", vendite);
            var voce31 = new VoceFattura("Canapa1", 20, 0.20f);
            fattura.Add(voce31);
            Assert.AreEqual(voce11.ToFattura(), fattura[0]);
            Assert.AreEqual(voce12.ToFattura(), fattura[1]);
            Assert.AreEqual(voce21.ToFattura(), fattura[2]);
            Assert.AreEqual(voce22.ToFattura(), fattura[3]);
            Assert.AreEqual(voce31, fattura[4]);

        }
        [Test]
        public void TestCostruttoreFattura() {
            var persona1 = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente1 = new Cliente(persona1, "1");
            var persona2 = new PersonaFisica("BBBBBBBBBB", "Via del Cane 12", "Sylvia", "Zbornak");
            var cliente2 = new Cliente(persona2, "2");
            var clientePot = new Cliente(persona1, "1", tipoCliente: EnumTipoCliente.Potenziale);
            var clienteEx = new Cliente(persona1, "1", tipoCliente: EnumTipoCliente.Ex);
            var vendita1 = new Vendita(1, cliente1);
            var vendita2 = new Vendita(1, cliente2);
            List<Vendita> vendite = new List<Vendita>();
            vendite.Add(vendita1);
            vendite.Add(vendita2);
            Assert.Catch(() => { var fattura = new Fattura(2018, "2", cliente1, vendite); });
            Assert.Catch(() => { var fattura = new Fattura(2018, "3", null, vendite); });
            Assert.Catch(() => { var fattura = new Fattura(2018, null, cliente1, vendite); });
            Assert.Catch(() => { var fattura = new Fattura(2018, "3", cliente1, venditeDiProvenienza: null); });
            Assert.Catch(() => { var fattura = new Fattura(1, "4", clientePot, vendite); });
            Assert.Catch(() => { var fattura = new Fattura(1, "5", null, vendite); });
            Assert.Catch(() => { var fattura = new Fattura(1, "6", clienteEx, vendite); });
            Assert.Catch(() => { var fattura = new Fattura(1, "6", clienteEx, vendite, sconto: -9); });
        }
        [Test]
        public void TestCostruttorePreventivo() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var clienteEx = new Cliente(persona, "1", tipoCliente: EnumTipoCliente.Ex);
            Assert.Catch(() => { var preventivo = new Preventivo(1, null); });
            Assert.Catch(() => { var preventivo = new Preventivo(1, clienteEx); });
        }
        [Test]
        public void TestCostruttoreVendita() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var clientePot = new Cliente(persona, "1", tipoCliente: EnumTipoCliente.Potenziale);
            var clienteEx = new Cliente(persona, "1", tipoCliente: EnumTipoCliente.Ex);
            Assert.Catch(() => { var vendita = new Vendita(1, clientePot); });
            Assert.Catch(() => { var vendita = new Vendita(1, null); });
            Assert.Catch(() => { var vendita = new Vendita(1, clienteEx); });
        }
    }
}
