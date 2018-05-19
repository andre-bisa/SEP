using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public struct Telefono
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
        /// <param name="nota">La nota del telefono</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Telefono(string numero, string nota = "")
        {
            if (numero == null)
            {
                throw new ArgumentNullException(nameof(numero));
            }
            Numero = numero;
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota));
            }
            Nota = nota;
        }

        #region ToString()
        public override string ToString()
        {
            return String.Format("Numero: {0} \nNota: {1}", Numero, Nota);
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (!(obj is Telefono))
            {
                return false;
            }

            var telefono = (Telefono)obj;
            return Numero == telefono.Numero;
        }

        public override int GetHashCode()
        {
            return -1449941195 + EqualityComparer<string>.Default.GetHashCode(Numero);
        }
    }
}
