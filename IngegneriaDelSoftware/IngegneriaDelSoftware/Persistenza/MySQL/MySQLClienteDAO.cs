using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLClienteDAO : IClienteDAO
    {
        public bool Aggiorna(Cliente clienteVecchio, DatiCliente datiCliente, DatiPersona datiPersona)
        {
            throw new NotImplementedException();
        }

        public void Crea(DatiCliente datiCliente, DatiPersona persona)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string IDCliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Leggi(string IDCliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> LeggiTuttiClienti()
        {
            throw new NotImplementedException();
        }
    }
}
