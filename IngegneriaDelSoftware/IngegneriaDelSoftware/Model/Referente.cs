using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class Referente
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
        /// 
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
            var referente = obj as Referente;
            return referente != null &&
                   Nome == referente.Nome;
        }

        public override int GetHashCode()
        {
            var hashCode = 557927457;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nota);
            return hashCode;
        }
    }
}
