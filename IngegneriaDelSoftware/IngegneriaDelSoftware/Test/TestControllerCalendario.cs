﻿/*
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

using IngegneriaDelSoftware.Controller;
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
    public class TestControllerCalendario
    {
        private ControllerCalendario _controllerCalendario;

        public TestControllerCalendario()
        {
            Impostazioni impostazioni = Impostazioni.GetInstance();
            impostazioni.CalenadrioEsterno = Model.AdapterCalendario.EnumAdapterCalendario.NONE;
            impostazioni.TipoPersistenza = Persistenza.EnumTipoPersistenza.NONE;

            this._controllerCalendario = new ControllerCalendario();
        }

        [Test]
        public void TestControllerAggiungiAppuntamento()
        {
            Persona p = new PersonaGiuridica("cf", "indirizzo", "ragione sociale", "sede legale", "000011111");
            DatiAppuntamento d = new DatiAppuntamento("1", p, "note a caso", "Ovunque", DateTime.Now);

            Appuntamento a = new Appuntamento(d);

            this._controllerCalendario.AggiungiAppuntamento(a);

            Assert.AreEqual(true, this._controllerCalendario.Calendario.Contains(a));
        }

        [Test]
        public void TestControllerRimuoviAppuntamento()
        {
            Persona p = new PersonaGiuridica("cf", "indirizzo", "ragione sociale", "sede legale", "000011111");
            DatiAppuntamento d = new DatiAppuntamento("1", p, "note a caso", "Ovunque", DateTime.Now);

            Appuntamento a = new Appuntamento(d);

            this._controllerCalendario.AggiungiAppuntamento(a);
            this._controllerCalendario.RimuoviAppuntamento(a);

            Assert.AreEqual(false, this._controllerCalendario.Calendario.Contains(a));
        }

        [Test]
        public void TestControllerGetAppuntamentiDaA()
        {
            Persona p = new PersonaGiuridica("cf", "indirizzo", "ragione sociale", "sede legale", "000011111");
            DatiAppuntamento d1 = new DatiAppuntamento("1", p, "note a caso", "Ovunque", DateTime.Now);
            DatiAppuntamento d2 = new DatiAppuntamento("2", p, "note a caso", "Ovunque", new DateTime(1999, 12, 31, 23, 59, 59));
            DatiAppuntamento d3 = new DatiAppuntamento("3", p, "note a caso", "Ovunque", new DateTime(9999, 12, 31, 23, 59, 59));

            Appuntamento a1 = new Appuntamento(d1);
            Appuntamento a2 = new Appuntamento(d2);
            Appuntamento a3 = new Appuntamento(d3);

            this._controllerCalendario.AggiungiAppuntamento(a1);
            this._controllerCalendario.AggiungiAppuntamento(a2);
            this._controllerCalendario.AggiungiAppuntamento(a3);

            Assert.AreEqual(true, this._controllerCalendario.GetAppuntamentiDaA(new DateTime(1950, 12, 31, 23, 59, 59), new DateTime(2020, 1, 1, 1, 1, 1)).Contains(a2));
            Assert.AreEqual(true, this._controllerCalendario.GetAppuntamentiDaA(new DateTime(1950, 12, 31, 23, 59, 59), new DateTime(2020, 1, 1, 1, 1, 1)).Contains(a1));
            Assert.AreEqual(false, this._controllerCalendario.GetAppuntamentiDaA(new DateTime(1950, 12, 31, 23, 59, 59), new DateTime(2020, 1, 1, 1, 1, 1)).Contains(a3));
        }
    }
}
