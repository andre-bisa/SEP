using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IPersonaDAO
    {
        bool Aggiorna(Persona vecchiaPersona, Persona nuovaPersona);

        bool InserisciEmail(Email email, Persona persona);

        bool RimuoviEmail(Email email, Persona persona);

        bool InserisciTelefono(Telefono telefono, Persona persona);

        bool RimuoviTelefono(Telefono telefono, Persona persona);

    }
}
