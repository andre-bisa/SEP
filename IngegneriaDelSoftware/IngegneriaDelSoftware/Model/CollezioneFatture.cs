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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;

//XXX check this one;
namespace IngegneriaDelSoftware.Model
{
    public class CollezioneFatture : IEnumerable<Fattura>, ICollection<Fattura>
    {
        public event EventHandler<ArgsFattura> OnAggiunta;
        public event EventHandler<ArgsFattura> OnRimozione;
        public event EventHandler<ArgsModifica<Fattura>> OnModifica;

        private volatile HashSet<Fattura> _fatture = new HashSet<Fattura>();

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza);

        #region Singleton
        private static CollezioneFatture _listaFatture = null;
        /// <summary>
        /// Funzioen che dà un'istanza della <see cref="CollezioneFatture"/>
        /// </summary>
        /// <returns>La collezione riempita con tutti i clienti</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public static CollezioneFatture GetInstance()
        {
            if (_listaFatture == null)
                _listaFatture = new CollezioneFatture();
            return _listaFatture;
        }
        #endregion

        protected CollezioneFatture()
        {
            try
            {
                foreach (Fattura f in _persistenza.GetFatturaDAO().LeggiTutteFatture())
                {
                    _fatture.Add(f);
                    f.OnModifica += (o, e) => {
                        Persistenza.PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza)
                            .GetFatturaDAO()
                                .Aggiorna(e.Vecchio, e.Nuovo);
                        this.OnModifica?.Invoke(o, e);
                    };
                }
            } catch (Exception) { throw new ExceptionPersistenza(); }
            
        }

        public int Count
        {
            get
            {
                return ((ICollection<Fattura>)_fatture).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<Fattura>)_fatture).IsReadOnly;
            }
        }

        /// <summary>
        /// Aggiunge un <see cref="Fattura"/> alla collezione
        /// </summary>
        /// <param name="item">Fattura da aggiungere alla collezione</param>
        /// <exception cref="ArgumentNullException">Se il <see cref="Fattura"/> è nullo</exception>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public void Add(Fattura item)
        {
            if (item == null)
                throw new ArgumentNullException("Errore. La fattura è nulla");

            if (!this._fatture.Contains(item))
            {
                if (_persistenza.GetFatturaDAO().Crea(item))
                {
                    ((ICollection<Fattura>)_fatture).Add(item);
                    item.OnModifica += (o, e) => {
                        Persistenza.PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza)
                            .GetFatturaDAO()
                                .Aggiorna(e.Vecchio, e.Nuovo);
                        this.OnModifica?.Invoke(o, e);
                    };
                    LanciaEvento(OnAggiunta, item);
                }
                else
                { // Se si sono verificati errori nella persistenza
                    throw new ExceptionPersistenza();
                }
            }else {
                throw new ArgumentException("L'id era già presente: sceglierne un altro");
            }
        }

        /// <summary>
        /// Funzione non supportata. Lancia SEMPRE eccezione
        /// </summary>
        /// <exception cref="InvalidOperationException">Viene lanciata SEMPRE!</exception>
        public void Clear()
        {
            throw new InvalidOperationException();
        }

        public bool Contains(Fattura item)
        {
            return ((ICollection<Fattura>)_fatture).Contains(item);
        }

        public void CopyTo(Fattura[] array, int arrayIndex)
        {
            ((ICollection<Fattura>)_fatture).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Fattura> GetEnumerator()
        {
            return ((IEnumerable<Fattura>)_fatture).GetEnumerator();
        }

        /// <summary>
        /// Funzione che elimina un utente dalla collezione
        /// </summary>
        /// <param name="item">L'utente che si intende eliminare</param>
        /// <returns><c>true</c> o <c>false</c> a seconda se ci è riuscito oppure no</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public bool Remove(Fattura item)
        {
            bool rimosso = false;
            if (item != null)
            {
                if (_persistenza.GetFatturaDAO().Elimina(item.Numero, item.Anno))
                {
                    rimosso = ((ICollection<Fattura>)_fatture).Remove(item);
                    LanciaEvento(OnRimozione, item);
                }
                else
                { // Se ci sono errori nella persistenza
                    throw new ExceptionPersistenza();
                }
            }
            return rimosso;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Fattura>)_fatture).GetEnumerator();
        }

        private void LanciaEvento(EventHandler<ArgsFattura> evento, Fattura fattura)
        {
            if (evento != null)
            {
                ArgsFattura args = new ArgsFattura(fattura);
                evento(this, args);
            }
        }

        public Fattura this[string numero, int anno]
        {
            get
            {
                foreach (Fattura f in this._fatture)
                {
                    if (f.Numero == numero && f.Anno == anno)
                        return f;
                }
                return null;
            }
        }

    }
}
