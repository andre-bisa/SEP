using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public struct Referente
    {
        /// <summary>
        /// Il nome del referente
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Una nota sul referente
        /// </summary>
        public string Nota { get; private set; }

        /// <summary>
        /// Il referente e' una classe di comodo del cliente
        /// </summary>
        /// <param name="nome">Il nome del referente</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Referente(string nome, string nota = "")
        {
            if(nome == null) {
                throw new ArgumentNullException(nameof(nome)); ;
            }
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota));
            }

            Nome = nome;
            Nota = nota;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Referente))
            {
                return false;
            }

            var referente = (Referente)obj;
            return Nome == referente.Nome;
        }

        public override int GetHashCode()
        {
            return 285249808 + EqualityComparer<string>.Default.GetHashCode(Nome);
        }
    }
}
