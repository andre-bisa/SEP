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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public abstract class Persona : IObservable<Persona>
    {
        public event EventHandler<ArgsModifica<Persona>> OnModifica;

        public abstract EnumTipoPersona TipoPersona { get; }
        protected abstract Persona Clone();

        #region Proprietà
        public abstract string CodiceFiscale { get; }
        public abstract string Indirizzo { get; }
        public abstract CollezioneTelefoni Telefoni { get; }
        public abstract CollezioneEmail Email { get; }
        #endregion

        #region "Funzioni pubbliche"
        /// <summary>
        /// Restituisce il nome della persona da visualizzare
        /// </summary>
        /// <returns>La denominazione</returns>
        public abstract string getDenominazione();

        public abstract void CambiaDatiPersona(DatiPersona datiPersona);

        protected void LanciaEvento(Persona vecchio)
        {
            if (OnModifica != null)
            {
                ArgsModifica<Persona> args = new ArgsModifica<Persona>(vecchio, this);
                OnModifica(this, args);
            }
        }

        public override bool Equals(object obj)
        {
            var persona = obj as Persona;
            return persona != null &&
                   CodiceFiscale == persona.CodiceFiscale;
        }

        public override int GetHashCode()
        {
            return 542064849 + EqualityComparer<string>.Default.GetHashCode(CodiceFiscale);
        }
        #endregion

    }

    public abstract class DatiPersona
    {
        public abstract string CodiceFiscale { get; }
        public abstract string Indirizzo { get; }

        public abstract EnumTipoPersona TipoDatiPersona();

    }
}
