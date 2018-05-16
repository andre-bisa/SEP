using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class Email
    {
        public string Indirizzo { get; private set; }
        public string Nota { get; private set; }

        public Email(string indirizzo)
        {
            Indirizzo = indirizzo ?? throw new ArgumentNullException(nameof(indirizzo));
        }

        public Email(string indirizzo, string nota) : this(indirizzo)
        {
            Nota = nota ?? throw new ArgumentNullException(nameof(nota));
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
