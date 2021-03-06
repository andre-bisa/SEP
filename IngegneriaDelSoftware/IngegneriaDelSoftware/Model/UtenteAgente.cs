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
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class UtenteAgente : Utente
    {
        public override event EventHandler<ArgsModifica<Utente>> OnModifica;
        private DatiUtenteAgente _datiUtenteAgente;

        #region Costruttore
        public UtenteAgente(DatiUtenteAgente datiUtenteAgente)
        {
            _datiUtenteAgente = datiUtenteAgente;
        }
        #endregion

        #region Properties
        public string Nome
        {
            get { return _datiUtenteAgente.Nome; }
        }
        public string Cognome
        {
            get { return _datiUtenteAgente.Cognome; }
        }
        public double ProvvigioneDefault
        {
            get { return _datiUtenteAgente.ProvigioneDefault; }
        }
        public override string Username
        {
            get { return _datiUtenteAgente.Username; }
        }
        public override string PartitaIva
        {
            get { return _datiUtenteAgente.PartitaIva; }
        }
        public override string CodiceFiscale
        {
            get { return _datiUtenteAgente.CodiceFiscale; }
        }
        public override string Indirizzo
        {
            get { return _datiUtenteAgente.Indirizzo; }
        }
        public override CollezioneTelefoni Telefoni
        {
            get { return _datiUtenteAgente.Telefoni; }
        }
        public override Email Email
        {
            get { return _datiUtenteAgente.Email; }
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return String.Format("{0} \nNome: {1} \nCognome: {2} \nProvvigione di Default: {3}", base.ToString(), Nome, Cognome, ProvvigioneDefault);
        }
        #endregion
    }

    public class DatiUtenteAgente : DatiUtente
    {
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public double ProvigioneDefault { get; private set; }

        /// <summary>
        /// Costruttore di Dati di UtenteAgente
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="provigioneDefault">La percentuale default di provvigione espressa con un numero da 0 a 1 (es. 100% = 1, 50% = 0,5)/param>
        /// <exception cref="ArgumentNullException"></exception>
        public DatiUtenteAgente(string username, string pIva, string cf, string indirizzo, Email email, string nome, string cognome, double provigioneDefault, List<Telefono> telefoni = null)
            : base(username, pIva, cf, indirizzo, email, telefoni)
        {
            if (nome == null || cognome == null)
            {
                throw new ArgumentNullException();
            }
            if (provigioneDefault < 0 || provigioneDefault > 1)
            {
                throw new ArgumentException();
            }

            Nome = nome;
            Cognome = cognome;
            ProvigioneDefault = provigioneDefault;
        }
    }
}
