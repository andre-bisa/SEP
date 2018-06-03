using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model;
using NUnit.Framework;
using ScriptInCSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Test {
    [TestFixture]
    class TestScripting {
        [Test]
        public void TestLoad() {
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
            decimal imponibile = 10;
            decimal totale = 60;
            Assert.AreEqual("Imponibile: " + imponibile.ToString("C", CultureInfo.CurrentCulture) + "\r\nTotale: " + totale.ToString("C", CultureInfo.CurrentCulture) + "\r\n", fattura.Calcola());
        }
        [Test]
        public void TestLoadNoVarName() {
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
            decimal generico = 90;
            decimal totale = 90;
            Assert.AreEqual("Generico: " + generico.ToString("C", CultureInfo.CurrentCulture) + "\r\nTotale: " + totale.ToString("C", CultureInfo.CurrentCulture) + "\r\n", fattura.Calcola());
        }
        [Test]
        public void TestLoadReal1() {
            Impostazioni impostazioni = Impostazioni.GetInstance();
            impostazioni.TipoPersistenza = Persistenza.EnumTipoPersistenza.NONE;

            ScriptProvider.Drop("Test");

            ScriptProvider.create("Test", (""
                + "$ON=( #SUM( @ONORARIO ) )\n"
                + "$CPA=( $ON * 0,04 )\n"
                + "$IMPIVA=( $ON + $CPA )\n"
                + "$IVA=( $IMPIVA * 0,22 )\n"
                + "$TOTPAR=( $IMPIVA + $IVA )\n"
                + "$NON=( #SUM( @NONIMPONIBILI ) )\n"
                + "$TOTALE=( $TOTPAR + $NON )\n"
                + ".SET $ON AS IMPORTANT\n"
                + ".SET $CPA AS IMPORTANT\n"
                + ".SET $IMPIVA AS IMPORTANT\n"
                + ".SET $IVA AS IMPORTANT\n"
                + ".SET $TOTPAR AS IMPORTANT\n"
                + ".SET $NON AS IMPORTANT\n"
                + ".SET $TOTALE AS IMPORTANT\n"
                + ".SET LABEL FOR $ON AS \"Totale onorari \"\n"
                + ".SET LABEL FOR $CPA AS \"Cpa \"\n"
                + ".SET LABEL FOR $IMPIVA AS \"Imponibile iva \"\n"
                + ".SET LABEL FOR $IVA AS \"Iva \"\n"
                + ".SET LABEL FOR $TOTPAR AS \"Totale parziale \"\n"
                + ".SET LABEL FOR $NON AS \"Anticipazioni \"\n"
                + ".SET LABEL FOR $TOTALE AS \"Totale generale \""
            + "").Split('\n'));
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new FatturaScripting(2018, "2", cliente, vendita);
            var voce1 = new VoceFattura("Corda", 100, 0f, "onorario");
            var voce2 = new VoceFattura("Canapa", 16, 0f, "non imponibili");/*
            var voce3 = new VoceFattura("Coltelli", 20, 0f, "");
            var voce4 = new VoceFattura("Cianuro", 20, 0f, "");*/

            fattura.Add(voce1, voce2/*, voce3, voce4*/);
            decimal onorari = 100;
            decimal cpa = 4;
            decimal imponibileIva = 104;
            decimal iva = 22.88M;
            decimal totaleParziale = 126.88M;
            decimal anticipazioni = 16;
            decimal totaleGenerico = 142.88M;
            Assert.AreEqual("Totale onorari " + onorari.ToString("C", CultureInfo.CurrentCulture) + "\r\nCpa " + cpa.ToString("C", CultureInfo.CurrentCulture) + "\r\nImponibile iva " + imponibileIva.ToString("C", CultureInfo.CurrentCulture) + "\r\nIva " + iva.ToString("C", CultureInfo.CurrentCulture) + "\r\nTotale parziale " + totaleParziale.ToString("C", CultureInfo.CurrentCulture) + "\r\nAnticipazioni " + anticipazioni.ToString("C", CultureInfo.CurrentCulture) + "\r\nTotale generale " + totaleGenerico.ToString("C", CultureInfo.CurrentCulture) + "\r\n", fattura.Calcola());
        }
        [Test]
        public void TestLoadReal2() {
            Impostazioni impostazioni = Impostazioni.GetInstance();
            impostazioni.TipoPersistenza = Persistenza.EnumTipoPersistenza.NONE;

            ScriptProvider.Drop("Test");

            ScriptProvider.create("Test", (""
                + "$ON=( #SUM( @ONORARIO ) )\n"
                + "$CPA=( $ON * 0,04 )\n"
                + "$IMPIVA=( $ON + $CPA )\n"
                + "$IVA=( $IMPIVA * 0,22 )\n"
                + "$TOTPAR=( $IMPIVA + $IVA )\n"
                + "$NON=( #SUM( @NONIMPONIBILI ) )\n"
                + "$TOTALE=( $TOTPAR + $NON )\n"
                + ".SET $ON AS IMPORTANT\n"
                + ".SET $CPA AS IMPORTANT\n"
                + ".SET $IMPIVA AS IMPORTANT\n"
                + ".SET $IVA AS IMPORTANT\n"
                + ".SET $TOTPAR AS IMPORTANT\n"
                + ".SET $NON AS IMPORTANT\n"
                + ".SET $TOTALE AS IMPORTANT\n"
                + ".SET LABEL FOR $ON AS \"Totale onorari \"\n"
                + ".SET LABEL FOR $CPA AS \"Cpa \"\n"
                + ".SET LABEL FOR $IMPIVA AS \"Imponibile iva \"\n"
                + ".SET LABEL FOR $IVA AS \"Iva \"\n"
                + ".SET LABEL FOR $TOTPAR AS \"Totale parziale \"\n"
                + ".SET LABEL FOR $NON AS \"Anticipazioni \"\n"
                + ".SET LABEL FOR $TOTALE AS \"Totale generale \""
            + "").Split('\n'));
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new FatturaScripting(2018, "2", cliente, vendita);
            var voce1 = new VoceFattura("Corda", 320, 0f, "onorario");
            /*var voce2 = new VoceFattura("Canapa", 16, 0f, "non imponibili");/*
            var voce3 = new VoceFattura("Coltelli", 20, 0f, "");
            var voce4 = new VoceFattura("Cianuro", 20, 0f, "");*/

            fattura.Add(voce1/*, voce2/*, voce3, voce4*/);
            decimal onorari = 320;
            decimal cpa = 12.80M;
            decimal imponibileIva = 332.80M;
            decimal iva = 73.22M;
            decimal totaleParziale = 406.02M;
            decimal totaleGenerale = 406.02M;
            Assert.AreEqual("Totale onorari " + onorari.ToString("C", CultureInfo.CurrentCulture) + "\r\nCpa " + cpa.ToString("C", CultureInfo.CurrentCulture) + "\r\nImponibile iva " + imponibileIva.ToString("C", CultureInfo.CurrentCulture) + "\r\nIva " + iva.ToString("C", CultureInfo.CurrentCulture) + "\r\nTotale parziale " + totaleParziale.ToString("C", CultureInfo.CurrentCulture) + "\r\nTotale generale " + totaleGenerale.ToString("C", CultureInfo.CurrentCulture) + "\r\n", fattura.Calcola());
        }
    }
}
