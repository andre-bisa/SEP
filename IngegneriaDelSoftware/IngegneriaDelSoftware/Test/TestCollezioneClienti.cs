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
    public class TestCollezioneClienti
    {
        private CollezioneClienti _collezioneClienti;

        public TestCollezioneClienti()
        {
            Impostazioni.GetInstance().ModalitaTest = true;

            List<Telefono> telefoni = new List<Telefono>();
            List<Email> email = new List<Email>();
            List<Referente> referenti = new List<Referente>();
            for (int i = 0; i < 10; i++)
            {
                referenti.Add(new Referente("Nome " + i, "Nota " + i));
            }
            for (int i = 0; i < 10; i++)
            {
                telefoni.Add(new Telefono("051051051" + i, "Nota " + i));
                email.Add(new Email("indirizzo" + i + "@gmail.com", "Nota " + i));
            }
            Persona p1 = new PersonaFisica("CF", "Indirizzo", "Nome", "Cognome", "P.IVA", null, null);
            Persona p2 = new PersonaFisica("CF2", "Indirizzo2", "Nome2", "Cognome2", "", telefoni, email);
            Persona p3 = new PersonaGiuridica("CF", "Indirizzo", "Ragione sociale1", "Sede legale1", "P.IVA", null, null);
            Persona p4 = new PersonaGiuridica("CF2", "Indirizzo2", "Ragione sociale2", "Sede legale2", "P.IVA2", telefoni, email);

            Cliente c1 = new Cliente(p1, "ID1", null, EnumTipoCliente.Attivo, "Nota1");
            Cliente c2 = new Cliente(p2, "ID2", referenti, EnumTipoCliente.Attivo, "Nota2");
            Cliente c3 = new Cliente(p3, "ID3", referenti, EnumTipoCliente.Ex, "Nota3");
            Cliente c4 = new Cliente(p4, "ID4", null, EnumTipoCliente.Potenziale, "Nota4");

            _collezioneClienti = CollezioneClienti.GetInstance();

            _collezioneClienti.Add(c1);
            _collezioneClienti.Add(c2);
            _collezioneClienti.Add(c3);
            _collezioneClienti.Add(c4);
        }

        [Test]
        public void TestRimuoviCollezioneClienti()
        {
            Persona p1 = new PersonaFisica("CF", "Indirizzo", "Nome", "Cognome", "P.IVA", null, null);
            Cliente c1 = new Cliente(p1, "ID1", null, EnumTipoCliente.Attivo, "Nota1");

            Assert.AreEqual(true, _collezioneClienti.Remove(c1));
        }

        [Test]
        public void TestAggiungiCollezioneClienti()
        {
            Persona p = new PersonaFisica("s", "Via x", "Mario", "Rossi");
            Cliente c = new Cliente(p, "ID");

            this._collezioneClienti.Add(c);

            Assert.AreEqual(true, _collezioneClienti.Contains(c));
        }

    }
}
