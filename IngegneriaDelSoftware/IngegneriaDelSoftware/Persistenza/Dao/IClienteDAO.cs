using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IClienteDAO
    {
        bool Crea(Cliente cliente);

        bool Aggiorna(Cliente clienteVecchio, Cliente clienteNuovo);

        bool Elimina(string IDCliente);

        List<Cliente> LeggiTuttiClienti();

    }
}
