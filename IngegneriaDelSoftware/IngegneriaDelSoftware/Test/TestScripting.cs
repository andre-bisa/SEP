using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model;
using NUnit.Framework;
using ScriptInCSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Test {
    [TestFixture]
    class TestScripting {
        [Test]
        public void TestLoad(){
            Impostazioni impostazioni = Impostazioni.GetInstance();
            impostazioni.TipoPersistenza = Persistenza.EnumTipoPersistenza.NONE;

            ScriptProvider.create("Test", (""
                + "$ONORARI=( #SUM( @ONORARIO ) )\n"
                + "$TOTIMPO=( #SUM( @IMPONIBILI ) )\n"
                + "$NONIMPONIBILIA=( #SUM( @NONIMPONIBILI ) )\n"
                + "$IMPONIBILI=( $TOTIMPO / 2 )\n"
                + "$TOTALE=( $ONORARI + $IMPONIBILI )\n"
                + ".SET LABEL FOR $TOTALE AS \"Totale: \"\n"
                + ".SET LABEL FOR $IMPONIBILI AS \"Imponibile: \"\n"
                + ".SET $IMPONIBILI AS IMPORTANT\n"
                + ".SET $NONIMPONIBILI AS IMPORTANT\n"
                + ".SET $TOTALE AS IMPORTANT"
            + "").Split('\n'));
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new FatturaScripting(2018, "2", cliente, vendita);
            var voce1 = new VoceFattura("Corda", 30, 0f, "onorario");
            var voce2 = new VoceFattura("Canapa", 20, 0f, "onorario");
            var voce3 = new VoceFattura("Canapa", 20, 0f, "imponibili");
            var voce4 = new VoceFattura("Canapa", 20, 0f, "non imponibili");

            fattura.Add(voce1, voce2, voce3, voce4);
            Assert.AreEqual("Imponibile: 10\r\nTotale: 60\r\n", fattura.Calcola());
        }
        [Test]
        public void TestLoadNoVarName()
        {
            Impostazioni impostazioni = Impostazioni.GetInstance();
            impostazioni.TipoPersistenza = Persistenza.EnumTipoPersistenza.NONE;

            ScriptProvider.Drop("Test");

            ScriptProvider.create("Test", (""
                + "$GEN=( #SUM( @GENERICO ) )\n"
                + "$TOTALE=( $GEN )\n"
                + ".SET LABEL FOR $TOTALE AS \"Totale: \"\n"
                + ".SET LABEL FOR $GEN AS \"Generico: \"\n"
                + ".SET $GEN AS IMPORTANT\n"
                + ".SET $TOTALE AS IMPORTANT"
            + "").Split('\n'));
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new FatturaScripting(2018, "2", cliente, vendita);
            var voce1 = new VoceFattura("Corda", 30, 0f, "");
            var voce2 = new VoceFattura("Canapa", 20, 0f, "");
            var voce3 = new VoceFattura("Coltelli", 20, 0f, "");
            var voce4 = new VoceFattura("Cianuro", 20, 0f, "");

            fattura.Add(voce1, voce2, voce3, voce4);
            Assert.AreEqual("Generico: 90\r\nTotale: 90\r\n", fattura.Calcola());
        }
    }
}
