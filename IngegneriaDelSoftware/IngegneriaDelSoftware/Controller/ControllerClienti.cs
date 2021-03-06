﻿/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;

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


        #region Singleton
        private static ControllerClienti _instance = null;
        private ControllerClienti()
        {
            _clienti = Model.CollezioneClienti.GetInstance();
        }
        public static ControllerClienti GetInstance()
        {
            if (_instance == null)
                _instance = new ControllerClienti();
            return _instance;
        }
        #endregion

        /// <summary>
        /// Aggiunge una mail al cliente
        /// </summary>
        /// <param name="cliente">Cliente a cui aggiungere la mail</param>
        /// <param name="email">Email da aggiungere</param>
        /// <exception cref="ExceptionPersistenza">In caso di errori della persistenza</exception>
        public void AggiungiEmail(Cliente cliente, Email email)
        {
            cliente.Persona.Email.Add(email);
        }

        /// <summary>
        /// Aggiunge un telefono al cliente
        /// </summary>
        /// <param name="cliente">Cliente a cui aggiungere la mail</param>
        /// <param name="telefono">Telefono da aggiungere</param>
        /// <exception cref="ExceptionPersistenza">In caso di errori della persistenza</exception>
        public void AggiungiTelefono(Cliente cliente, Telefono telefono)
        {
            cliente.Persona.Telefoni.Add(telefono);
        }

        /// <summary>
        /// Aggiunge un referente al cliente
        /// </summary>
        /// <param name="cliente">Cliente a cui aggiungere la mail</param>
        /// <param name="referente">Referente da aggiungere</param>
        /// <exception cref="ExceptionPersistenza">In caso di errori della persistenza</exception>
        public void AggiungiReferente(Cliente cliente, Referente referente)
        {
            cliente.Referenti.Add(referente);
        }

        /// <summary>
        /// Aggiunge un cliente alla <see cref="CollezioneClienti"/>.
        /// </summary>
        /// <param name="cliente">I dati del <see cref="Cliente"/> da aggiungere</param>
        /// <param name="datiPersonaGenerica">I dati della <see cref="Persona"/> associati al <see cref="Cliente"/></param>
        /// <returns>Il <see cref="Cliente"/> appena inserito, <c>null</c> in caso di errori</returns>
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
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

            if (_clienti.Contains(risultato))
                return null;

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
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
        public void ModificaCliente(Cliente clienteDaModificare, DatiCliente nuoviDatiCliente, DatiPersona nuoviDatiPersona)
        {
            if (clienteDaModificare == null)
                throw new ArgumentNullException("Errore, il cliente è nullo.");

            //if (clienteDaModificare.Persona.TipoPersona == nuoviDatiPersona.TipoDatiPersona())
            //{
                clienteDaModificare.Persona.CambiaDatiPersona(nuoviDatiPersona);
            //}
            /*else
            {
                clienteDaModificare.CambiaPersona(nuoviDatiPersona);
            }*/
            
            clienteDaModificare.CambiaDatiCliente(nuoviDatiCliente);
        }

    } // class
}
