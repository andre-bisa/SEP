using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public struct Email
    {
        /// <summary>
        /// L'indirizzo email
        /// </summary>
        public string Indirizzo { get; private set; }
        /// <summary>
        /// Una nota sull'indirizzo email. Can be <c>null</c>
        /// </summary>
        public string Nota { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indirizzo">L'indirizzo email</param>
        /// <param name="nota">La nota dell'indirizzo mail</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Email(string indirizzo, string nota = "")
        {
            if(indirizzo == null) {
                throw new ArgumentNullException(nameof(indirizzo));
            }
            Indirizzo = indirizzo;
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota));
            }
            Nota = nota;
        }

        #region ToString()
        public override string ToString()
        {
            return Indirizzo;
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (!(obj is Email))
            {
                return false;
            }

            var email = (Email)obj;
            return Indirizzo == email.Indirizzo;
        }

        public override int GetHashCode()
        {
            return 1205928949 + EqualityComparer<string>.Default.GetHashCode(Indirizzo);
        }
    }
}
