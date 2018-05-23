using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class CollezioneEmailInviate : IEnumerable<MailInviata>, ICollection<MailInviata>
    {
        private List<MailInviata> _email = new List<MailInviata>();

        protected CollezioneEmailInviate()
        {
            for (int i = 0; i < 10; i++)
            {
                this._email.Add(new MailInviata(new DateTime(2018, 5, i+1), "Oggetto" + i, "Corpo", "mail@mail.com"));
            }
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
