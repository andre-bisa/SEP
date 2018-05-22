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
        private readonly CollezioneClienti _clienti;
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

        /// <summary>
        /// Aggiunge un cliente alla <see cref="CollezioneClienti"/>.
        /// </summary>
        /// <param name="cliente">I dati del <see cref="Cliente"/> da aggiungere</param>
        /// <param name="datiPersonaGenerica">I dati della <see cref="Persona"/> associati al <see cref="Cliente"/></param>
        /// <returns>Il <see cref="Cliente"/> appena inserito, <c>null</c> in caso di errori</returns>
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
            if (cliente != null)
                this._clienti.Remove(cliente);
        }

        /// <summary>
        /// Modifica un cliente nella <see cref="CollezioneClienti"/>
        /// </summary>
        /// <param name="clienteDaModificare">Il <see cref="Cliente"/> da modificare</param>
        /// <param name="nuoviDatiCliente">I nuovi dati del <see cref="Cliente"/></param>
        /// <param name="nuoviDatiPersona">I nuovi dati della <see cref="Persona"/></param>
        /// <exception cref="ArgumentNullException">Se il <paramref name="clienteDaModificare"/> è nullo</exception>
        public void ModificaCliente(Cliente clienteDaModificare, DatiCliente nuoviDatiCliente, DatiPersona nuoviDatiPersona)
        {
            if (clienteDaModificare == null)
                throw new ArgumentNullException("Errore, il cliente è nullo.");

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

    } // class
}
