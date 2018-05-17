using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model.ArgsEvent
{
    public class ArgsModifica<Tipo>
    {
        /// <summary>
        /// Il vecchio <see cref="Tipo"/>, <c>null</c> per inserire
        /// </summary>
        public Tipo Vecchio { get; private set; }
        /// <summary>
        /// Il nuovo <see cref="Tipo"/>, <c>null</c> per eliminare
        /// </summary>
        public Tipo Nuovo { get; private set; }

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="vecchio">Il vecchio <see cref="Tipo"/>, <c>null</c> per inserire</param>
        /// <param name="nuovo">Il nuovo <see cref="Tipo"/>, <c>null</c> per eliminare</param>
        public ArgsModifica (Tipo vecchio, Tipo nuovo)
        {
            Vecchio = vecchio;
            Nuovo = nuovo;
        }
    }
}
