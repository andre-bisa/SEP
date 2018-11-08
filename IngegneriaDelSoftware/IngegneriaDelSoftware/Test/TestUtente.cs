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
    public class TestUtente
    {
        private DatiUtenteAzienda _duaz;
        private DatiUtenteAgente _duag;
        private DatiUtenteLiberoProfessionista _dulp;
        private UtenteAgente _uag;
        private UtenteAzienda _uaz;
        private UtenteLiberoProfessionista _ulp;

        public TestUtente()
        {
            Impostazioni.GetInstance().ModalitaTest = true;

            List<Telefono> t = new List<Telefono>();
            t.Add(new Telefono("051051051051", "Mio"));
            t.Add(new Telefono("333333333333"));


            List<Telefono> t2 = new List<Telefono>();
            t2.Add(new Telefono("1234567890", "Mio"));
            t2.Add(new Telefono("0123456789"));
            t2.Add(new Telefono("15642", "Prova"));
            t2.Add(new Telefono("7894561230"));


            this._duaz = new DatiUtenteAzienda("pippo", "01234567897", "pp1233ssassa", "Via x", new Email("pippo@gmail.com"), "REgione Sociale", "Sede Illegale", t);

            this._duag = new DatiUtenteAgente("pluto", "01234567897", "pp1233ssassa", "Via x", new Email("pluto@gmail.com", "Prova"), "Carlo", "Verdi", 0.5);

            this._dulp = new DatiUtenteLiberoProfessionista("paperino", "01234567897", "pp1233ssassa", "Via x", new Email("paperino@gmail.com"), "Nome", "Cognome", t2);

            this._uaz = new UtenteAzienda(this._duaz);
            this._uag = new UtenteAgente(this._duag);
            this._ulp = new UtenteLiberoProfessionista(this._dulp);
        }

        [Test]
        public void testUsernameUtente()
        {
            Assert.AreEqual( "pippo", this._uaz.Username);
            Assert.AreEqual("pluto", this._uag.Username);
            Assert.AreEqual("paperino", this._ulp.Username);
        }

        [Test]
        public void testTelefoniUtente()
        {
            Assert.AreEqual(2, _uaz.Telefoni.Count);
            Assert.AreEqual(0, _uag.Telefoni.Count);
            Assert.AreEqual(4, _ulp.Telefoni.Count);
        }

        [Test]
        public void testEmailUtente()
        {
            Email e = new Email("pippo@gmail.com");

            Assert.AreEqual(e, _uaz.Email);

            e = new Email("pluto@gmail.com", "Prova");

            Assert.AreEqual(e, _uag.Email);

            e = new Email("paperino@gmail.com");

            Assert.AreEqual(e, _ulp.Email);
        }
        
        [Test]
        public void testCampiUtenteAzienda()
        {
            Assert.AreEqual("REgione Sociale", _uaz.RagioneSociale);
            Assert.AreEqual("Sede Illegale", _uaz.SedeLegale);
        }

        [Test]
        public void testCampiUtenteAgente()
        {
            Assert.AreEqual("Carlo", _uag.Nome);
            Assert.AreEqual("Verdi", _uag.Cognome);
            Assert.AreEqual(0.5, _uag.ProvvigioneDefault);
        }

        [Test]
        public void testCampiUtenteLiberoProfessionista()
        {
            Assert.AreEqual("Nome", _ulp.Nome);
            Assert.AreEqual("Cognome", _ulp.Cognome);
        }
    }
}
