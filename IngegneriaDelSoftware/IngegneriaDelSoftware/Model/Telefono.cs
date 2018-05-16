using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class Telefono
    {
        public string Numero { get; private set; }
        public string Nota { get; private set; }

        public Telefono(string numero)
        {
            Numero = numero ?? throw new ArgumentNullException(nameof(numero));
        }

        public Telefono(string numero, string nota) : this(numero)
        {
            Nota = nota ?? throw new ArgumentNullException(nameof(nota));
        }

        public override bool Equals(object obj)
        {
            var telefono = obj as Telefono;
            return telefono != null &&
                   Numero == telefono.Numero;
        }

        public override int GetHashCode()
        {
            var hashCode = -1177263546;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Numero);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nota);
            return hashCode;
        }
    }
}
