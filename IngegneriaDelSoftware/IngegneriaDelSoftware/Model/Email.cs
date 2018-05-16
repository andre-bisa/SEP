using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class Email
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
        /// <exception cref="ArgumentNullException"></exception>
        public Email(string indirizzo)
        {
            if(indirizzo == null) {
                throw new ArgumentNullException(nameof(indirizzo));
            }
            Indirizzo = indirizzo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indirizzo">L'indirizzo email</param>
        /// <param name="nota">Una nota sull'indirizzo</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Email(string indirizzo, string nota) : this(indirizzo)
        {
            if(nota == null) {
                throw new ArgumentNullException(nameof(nota));
            }
            Nota = nota;
        }

        public override bool Equals(object obj)
        {
            var email = obj as Email;
            return email != null &&
                   Indirizzo == email.Indirizzo;
        }

        public override int GetHashCode()
        {
            var hashCode = 1478606598;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Indirizzo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nota);
            return hashCode;
        }
    }
}
