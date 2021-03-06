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
    public abstract class Utente : IObservable<Utente>
    {
        public abstract event EventHandler<ArgsModifica<Utente>> OnModifica;

        #region Properties
        public abstract string Username { get; }
        public abstract string PartitaIva { get; }
        public abstract string CodiceFiscale { get; }
        public abstract string Indirizzo { get; }
        public abstract CollezioneTelefoni Telefoni { get; }
        public abstract Email Email { get; }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return String.Format("Username: {0} \nPartita Iva: {1} \nCodice Fiscale: {2}" +
                " \nIndirizzo: {3}  \nTelefoni: {4} \nEmail: {5}", Username, PartitaIva, CodiceFiscale,
                Indirizzo, Telefoni.ToString(), Email.ToString());
        }
        #endregion
    }

    //Abstract class per avere ereditarieta' con gli altri tipi di utente
    public abstract class DatiUtente
    {
        public string Username { get; private set; }
        public string PartitaIva { get; private set; }
        public string CodiceFiscale { get; private set; }
        public string Indirizzo { get; private set; }
        public CollezioneTelefoni Telefoni { get; private set; }
        public Email Email { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pIva"></param>
        /// <param name="cf"></param>
        /// <param name="indirizzo"></param>
        /// <param name="email"></param>
        /// <param name="telefoni"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DatiUtente(string username, string pIva, string cf, string indirizzo, Email email, List<Telefono> telefoni = null)
        {
            #region Controlli
            if(username == null)
            {
                throw new ArgumentNullException();
            }
            if (pIva == null)
            {
                throw new ArgumentNullException();
            }
            if (cf == null)
            {
                throw new ArgumentNullException();
            }
            if (indirizzo == null)
            {
                throw new ArgumentNullException();
            }
            #endregion

            Username = username;
            PartitaIva = pIva;
            CodiceFiscale = cf;
            Indirizzo = indirizzo;
            Email = email;
            //Se argomento nullo da' lista vuota, altrimenti crea una copia della lista data
            Telefoni = new CollezioneTelefoni(telefoni);
        }
    }
}
