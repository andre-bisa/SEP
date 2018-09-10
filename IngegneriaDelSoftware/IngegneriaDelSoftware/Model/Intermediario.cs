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
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class Intermediario : IObservable<Intermediario>
    {
        public event EventHandler<ArgsModifica<Intermediario>> OnModifica;

        private Persona _persona;
        /// <summary>
        /// Persona riferita all'intermediario
        /// </summary>
        public Persona Persona
        {
            get
            {
                return _persona;
            }
            private set
            {
                _persona = value;
            }
        }

        /// <summary>
        /// Identificativo intermediario
        /// </summary>
        public string ID { get; private set; }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="persona">Persona riferita all'intermediario</param>
        /// <param name="ID">Identificativo intermediario</param>
        /// <exception cref="ArgumentNullException">Se vengono passati dei valori <c>null</c></exception>
        public Intermediario(Persona persona, string ID)
        {
            if (persona == null)
                throw new ArgumentNullException(nameof(persona));
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));
            this.ID = ID;
            Persona = persona;
        }
    }
}
