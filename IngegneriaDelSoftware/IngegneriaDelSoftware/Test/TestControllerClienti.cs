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

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Test
{
    [TestFixture]
    public class TestControllerClienti
    {
        private ControllerClienti _controllerClienti;

        public TestControllerClienti()
        {
            Impostazioni impostazioni = Impostazioni.GetInstance();
            impostazioni.TipoPersistenza = Persistenza.EnumTipoPersistenza.NONE;
            impostazioni.CalenadrioEsterno = Model.AdapterCalendario.EnumAdapterCalendario.NONE;

            this._controllerClienti = ControllerClienti.GetInstance();
        }

        [Test]
        public void TestAggiungiCliente()
        {
            DatiCliente d = new DatiCliente("ID1", EnumTipoCliente.Attivo);
            DatiPersona p = new DatiPersonaFisica("CF1", "Indirizzo", "Nome", "Cognome");

            Cliente c = this._controllerClienti.AggiungiCliente(d, p);

            Assert.NotNull(c);
            Assert.AreEqual(true, this._controllerClienti.CollezioneClienti.Contains(c));
        }

        [Test]
        public void TestRimuoviCliente()
        {
            // Aggiungo
            DatiCliente d = new DatiCliente("ID2", EnumTipoCliente.Attivo);
            DatiPersona p = new DatiPersonaFisica("CF2", "Indirizzo", "Nome", "Cognome");

            Cliente c = this._controllerClienti.AggiungiCliente(d, p);

            // Rimuovo
            this._controllerClienti.RimuoviCliente(c);
            Assert.AreEqual(false, this._controllerClienti.CollezioneClienti.Contains(c));
        }

        [Test]
        public void TestModificaClienteStessoTipoPersona()
        {
            // Aggiungo
            DatiCliente d = new DatiCliente("IDmodifica", EnumTipoCliente.Attivo);
            DatiPersona p = new DatiPersonaFisica("CF3", "Indirizzo", "Nome", "Cognome");

            Cliente c = this._controllerClienti.AggiungiCliente(d, p);

            Assert.NotNull(c);
            // Modifico
            DatiCliente d2 = new DatiCliente("ID4", EnumTipoCliente.Ex);
            DatiPersona p2 = new DatiPersonaFisica("CF4", "Indirizzo2", "Nome2", "Cognome2");

            this._controllerClienti.ModificaCliente(c, d2, p2);

            Assert.NotNull(c);
            Assert.AreEqual(true, this._controllerClienti.CollezioneClienti.Any(cli => cli.IDCliente == d2.IDCliente));
        }

        /*[Test]
        public void TestModificaClienteDiversoTipoPersona()
        {
            // Aggiungo
            DatiCliente d = new DatiCliente("ID", EnumTipoCliente.Attivo);
            DatiPersona p = new DatiPersonaFisica("CF", "Indirizzo", "Nome", "Cognome");

            Cliente c = this._controllerClienti.AggiungiCliente(d, p);

            // Modifico
            DatiCliente d2 = new DatiCliente("ID2", EnumTipoCliente.Ex);
            DatiPersona p2 = new DatiPersonaGiuridica("CF", "Indirizzo", "Ragione sociale", "Sede legale", "P.IVA");

            this._controllerClienti.ModificaCliente(c, d2, p2);

            Assert.AreEqual(true, this._controllerClienti.CollezioneClienti.Any(cli => cli.IDCliente == d2.IDCliente));
        }*/

    } // class
}
