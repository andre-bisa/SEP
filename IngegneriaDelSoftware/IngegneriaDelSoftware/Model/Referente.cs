using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class Referente
    {
        public string Nome { get; private set; }
        public string Nota { get; private set; }

        public Referente(string nome)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }

        public Referente(string nome, string nota) : this(nome)
        {
            Nota = nota ?? throw new ArgumentNullException(nameof(nota));
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
