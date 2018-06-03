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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Model
{
    public class CollezioneEmailInviate : IEnumerable<MailInviata>, ICollection<MailInviata>
    {
        public event EventHandler<ArgsMailInviata> OnAggiunta;

        private List<MailInviata> _email = new List<MailInviata>();

        protected CollezioneEmailInviate()
        {
            foreach (MailInviata mail in PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza).GetMailInviataDAO().GetListaMailInviate())
            {
                this._email.Add(mail);
            }
            // Mock
            /*
            for (int i = 0; i < 10; i++)
            {
                this._email.Add(new MailInviata(new DateTime(2018, 5, i+1), "Oggetto" + i, "Corpo", "mail@mail.com"));
            }
            */
        }

        #region Singleton
        private static CollezioneEmailInviate _listaEmailInviate = null;
        public static CollezioneEmailInviate GetInstance()
        {
            if (_listaEmailInviate == null)
                _listaEmailInviate = new CollezioneEmailInviate();
            return _listaEmailInviate;
        }
        #endregion

        public int Count => ((ICollection<MailInviata>)_email).Count;

        public bool IsReadOnly => ((ICollection<MailInviata>)_email).IsReadOnly;

        public IEnumerator<MailInviata> GetEnumerator()
        {
            return ((IEnumerable<MailInviata>)_email).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<MailInviata>)_email).GetEnumerator();
        }

        public void Add(MailInviata item)
        {
            ((ICollection<MailInviata>)_email).Add(item);

            if (OnAggiunta != null)
            {
                ArgsMailInviata args = new ArgsMailInviata(item);
                OnAggiunta(this, args);
            }
        }

        public void Clear()
        {
            ((ICollection<MailInviata>)_email).Clear();
        }

        public bool Contains(MailInviata item)
        {
            return ((ICollection<MailInviata>)_email).Contains(item);
        }

        public void CopyTo(MailInviata[] array, int arrayIndex)
        {
            ((ICollection<MailInviata>)_email).CopyTo(array, arrayIndex);
        }

        public bool Remove(MailInviata item)
        {
            return ((ICollection<MailInviata>)_email).Remove(item);
        }

        public override string ToString()
        {
            return String.Join(",", this._email);
        }

    }
}
