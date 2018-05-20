using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Controller
{
    public class ControllerClienti
    {
        private CollezioneClienti _clienti;
        public CollezioneClienti CollezioneClienti
        {
            get
            {
                return _clienti;
            }
        }

        public ControllerClienti()
        {
            _clienti = Model.CollezioneClienti.GetInstance();
        }

        public Cliente AggiungiCliente(DatiCliente cliente, DatiPersona datiPersonaGenerica)
        {
            Persona persona;

            if (datiPersonaGenerica.TipoDatiPersona() == EnumTipoPersona.Fisica)
            { 
                DatiPersonaFisica datiPersona = (DatiPersonaFisica)datiPersonaGenerica;
                persona = new PersonaFisica(datiPersona);
            }
            else
            {
                DatiPersonaGiuridica datiPersona = (DatiPersonaGiuridica)datiPersonaGenerica;
                persona = new PersonaGiuridica(datiPersona);
            }

            Cliente risultato = new Cliente(cliente, persona);
            if (risultato != null)
                this._clienti.Add(risultato);
            return risultato;
        }

        public void RimuoviCliente(Cliente cliente)
        {
            this._clienti.Remove(cliente);
        }

        public void ModificaCliente(Cliente clienteDaModificare, DatiCliente nuoviDatiCliente, DatiPersona nuoviDatiPersona)
        {

            if (clienteDaModificare.Persona.TipoPersona == nuoviDatiPersona.TipoDatiPersona())
            {
                clienteDaModificare.Persona.CambiaDatiPersona(nuoviDatiPersona);
            }
            else
            {
                clienteDaModificare.CambiaPersona(nuoviDatiPersona);
            }
            
            clienteDaModificare.CambiaDatiCliente(nuoviDatiCliente);
            
        }

    }
}
