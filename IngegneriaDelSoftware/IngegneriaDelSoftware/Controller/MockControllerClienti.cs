using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Controller
{
    public class MockControllerClienti
    {
        public event EventHandler<ArgsCliente> RimossoCliente;

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

        public Cliente AggiungiCliente(DatiCliente cliente)
        {
            Cliente risultato = new Cliente(cliente);
            if (risultato != null)
                this._clienti.Add(risultato);
            return risultato;
        }

        public void RimuoviCliente(Cliente cliente)
        {
            this._clienti.Remove(cliente);
            if (RimossoCliente != null)
            {
                RimossoCliente(this, new ArgsCliente(cliente));
            }
        }

        public void RimuoviCliente(DatiCliente cliente)
        {
            Cliente daRimuovere = this._clienti.Find(c => c.IDCliente.Equals(cliente));
            if (daRimuovere != null)
                this._clienti.Remove(daRimuovere);
        }

        public void ModificaCliente(Cliente clienteDaModificare, DatiCliente nuoviDatiCliente)
        {
            clienteDaModificare.CambiaDatiCliente(nuoviDatiCliente);
        }

    }
}
