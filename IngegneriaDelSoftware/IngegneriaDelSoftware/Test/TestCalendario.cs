/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

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
            Impostazioni.GetInstance().CalenadrioEsterno = Model.AdapterCalendario.EnumAdapterCalendario.NONE;
            Impostazioni.GetInstance().TipoPersistenza = Persistenza.EnumTipoPersistenza.NONE;

            Persona p1 = new PersonaFisica("s", "Via x", "Mario", "Rossi");
            Persona p2 = new PersonaFisica("s", "Via x", "Mario", "Verdi");
            Persona p3 = new PersonaGiuridica("s", "Via x", "REgione Sociale", "Sede Illegale", "2");
            Persona p4 = new PersonaFisica("s", "Via x", "Filippo", "Bianchi");
            DatiAppuntamento datiAppuntamento1 = new DatiAppuntamento("1", p1, "Riunione", "Bologna", DateTime.Now);
            DatiAppuntamento datiAppuntamento2 = new DatiAppuntamento("2", p2, "Riunione", "Milano", new DateTime(2018, 4, 30, 12, 0, 0));
            DatiAppuntamento datiAppuntamento3 = new DatiAppuntamento("3", p3, "Riunione", "Roma", new DateTime(2100, 5, 30, 12, 0, 0));
            DatiAppuntamento datiAppuntamento4 = new DatiAppuntamento("4", p4, "Riunione", "Napoli", new DateTime(2018, 3, 21, 12, 0, 0));
            a1 = new Appuntamento(datiAppuntamento1);
            a2 = new Appuntamento(datiAppuntamento2);
            a3 = new Appuntamento(datiAppuntamento3);
            a4 = new Appuntamento(datiAppuntamento4);

            _calendario = new Calendario();

            _calendario = Calendario.GetInstance();

            _calendario.Add(a1);
            _calendario.Add(a2);
            _calendario.Add(a3);
            _calendario.Add(a4);
        }

        [Test]
        public void TestRimuoviCalendario()
        {
            Persona p2 = new PersonaFisica("s", "Via x", "Mario", "Verdi");
            DatiAppuntamento datiAppuntamento2 = new DatiAppuntamento("2", p2, "Riunione", "Milano", new DateTime(2018, 4, 30, 12, 0, 0));
            Appuntamento a2 = new Appuntamento(datiAppuntamento2);

            Assert.AreEqual(true, _calendario.Remove(a2));
        }

        [Test]
        public void TestAggiungiCalendario()
        {
            Persona p = new PersonaFisica("s", "Via x", "Mario", "Rossi");
            DatiAppuntamento datiAppuntamento2 = new DatiAppuntamento("1", p, "Chiacchierare", "Bologna", new DateTime(2018, 4, 30, 12, 0, 0));
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
