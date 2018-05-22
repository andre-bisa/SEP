using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface ClienteDAO
    {
        void Crea(DatiCliente datiCliente, DatiPersona persona);

        Cliente Leggi(string IDCliente);

        bool Aggiorna(Cliente clienteVecchio, DatiCliente datiCliente, DatiPersona datiPersona);

        bool Elimina(string IDCliente);

        List<Cliente> LeggiTuttiClienti();

    }
}
