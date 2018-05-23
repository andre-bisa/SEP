﻿using IngegneriaDelSoftware.Controller;
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
            ScriptProvider.create("Test", (""
                + "$ONORARI=( #SUM( @ONORARIO ) )\n"
                + "$TOTIMPO=( #SUM( @IMPONIBILI ) )\n"
                + "$IMPONIBILI=( $TOTIMPO / 2 )\n"
                + "$TOTALE=( $ONORARI + $IMPONIBILI )\n"
                + ".SET LABEL FOR $TOTALE AS \"Totale: \"\n"
                + ".SET LABEL FOR $IMPONIBILI AS \"Imponibile: \"\n"
                + ".SET $IMPONIBILI AS IMPORTANT\n"
                + ".SET $TOTALE AS IMPORTANT"
            + "").Split('\n'));
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new FatturaScripting(2018, "2", cliente, vendita);
            var voce1 = new VoceFattura("Corda", 30, 0.20f, "onorario");
            var voce2 = new VoceFattura("Canapa", 20, 0.20f, "onorario");
            var voce3 = new VoceFattura("Canapa", 20, 0.20f, "imponibili");

            fattura.Add(voce1, voce2, voce3);
            Assert.AreEqual("Imponibile: 10\nTotale: 60\n", fattura.Calcola());
        }
    }
}
