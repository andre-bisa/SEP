using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLPersonaDAO : IPersonaDAO
    {
        public bool Aggiorna(Persona personaVecchia, DatiPersona datiPersona)
        {
            throw new NotImplementedException();
        }

        public void Crea(DatiPersona persona)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string CF)
        {
            throw new NotImplementedException();
        }

        public Persona Leggi(string CF)
        {
            throw new NotImplementedException();
        }
    }
}
