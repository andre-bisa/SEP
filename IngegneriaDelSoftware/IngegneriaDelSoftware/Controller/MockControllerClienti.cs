using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Controller
{
    public class MockControllerClienti
    {
        private List<Cliente> _clienti = new List<Cliente>();
        public List<Cliente> ListaClienti
        {
            get
            {
                return new List<Cliente>(_clienti);
            }
        }

        public MockControllerClienti()
        {
            for (int i = 0; i < 100; i++)
            {
                Cliente cliente = new Cliente(new PersonaFisica("Codice fiscale", "indirizzo" + i, "nome" + i, "cognome"), "ID" + i);
                _clienti.Add(cliente);
            }
        }

        public void AggiungiCliente(Cliente cliente)
        {
            if (cliente != null)
                this._clienti.Add(cliente);
        }
    }
}
