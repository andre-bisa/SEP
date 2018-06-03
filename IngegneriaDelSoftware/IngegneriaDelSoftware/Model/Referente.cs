/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

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

        public override string ToString()
        {
            return Nome;
        }
    }
}
