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
