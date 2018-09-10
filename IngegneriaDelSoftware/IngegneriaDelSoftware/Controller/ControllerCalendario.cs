/*
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

using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerCalendario {

        private Calendario _calendario;

        public Calendario Calendario
        {
            get { return this._calendario; }
        }

        /// <summary>
        /// Costruttore di ControllerCalendario
        /// </summary>
        public ControllerCalendario()
        {
            this._calendario = Calendario.GetInstance();
        }

        /// <summary>
        /// Ritorna gli appuntamenti rientranti in un range di date specificato
        /// </summary>
        /// <param name="da">Data di partenza</param>
        /// <param name="a">Data di arrivo</param>
        /// <returns>Array di Appuntamenti</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public List<Appuntamento> GetAppuntamentiDaA(DateTime da, DateTime a) {

            if (da == null || a == null)
            {
                throw new ArgumentNullException();
            }
            //Se la data di partenza viene dopo quella d'arrivo
            if (da > a)
            {
                throw new ArgumentException();
            }

            return this._calendario.AppuntamentiDaA(da, a);
        }


        public Calendario GetAppuntamenti() {
            return this._calendario;
        }

        /// <summary>
        /// Aggiunge un certo appuntamento
        /// </summary>
        /// <param name="appuntamento"></param>
        public void AggiungiAppuntamento(Appuntamento appuntamento)
        {
            if(appuntamento == null)
            {
                throw new ArgumentNullException();
            }
            string id = (from cliente in CollezioneClienti.GetInstance()
             where cliente.Persona.Equals(appuntamento.ConChi)
             select cliente.IDCliente).FirstOrDefault();

            if (id == null)
            {
                throw new ArgumentNullException();
            }

            this._calendario.Add(appuntamento, id);
        }

        /// <summary>
        /// Rimuove un certo appuntamento
        /// </summary>
        /// <param name="appuntamento"></param>
        public void RimuoviAppuntamento(Appuntamento appuntamento)
        {
            if (appuntamento == null)
            {
                throw new ArgumentNullException();
            }

            this._calendario.Remove(appuntamento);
        }

        //TODO fix this;
        /// <summary>
        /// Recupera il prossimo intero dalla collezione
        /// </summary>
        /// <returns>prossimo ID</returns>
        public int GetNext() {
            // ordina in modo decrescente la collezione, seleziona solo l'id, 
            //prende solo il primo (o il default che è 0 per int) e ci aggiunge 1;
            return (from app in this._calendario
                    orderby app.IDAppuntamento descending
                    select app.IDAppuntamento
             ).FirstOrDefault() + 1;
        }

        // solo per comodità;
        public void AggiungiAppuntamento(DatiAppuntamento nuovoAppuntamento) {
            this.AggiungiAppuntamento(new Appuntamento(nuovoAppuntamento));
        }
    }
}
