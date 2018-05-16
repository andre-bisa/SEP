using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class Telefono
    {
        /// <summary>
        /// Il numero di telefono
        /// </summary>
        public string Numero { get; private set; }
        /// <summary>
        /// Una nota sul numero. Can be <c>null</c>.
        /// </summary>
        public string Nota { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero">Il numero di telefono</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Telefono(string numero)
        {
            if(numero == null) {
                throw new ArgumentNullException(nameof(numero));
            }
            Numero = numero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero">Il numero di telefono</param>
        /// <param name="nota">Una nota sul numero</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Telefono(string numero, string nota) : this(numero)
        {
            if(nota == null) {
                throw new ArgumentNullException(nameof(nota));
            }
            Nota = nota;
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
