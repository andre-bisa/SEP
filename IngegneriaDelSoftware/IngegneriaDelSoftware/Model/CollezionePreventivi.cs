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
    public class CollezionePreventivi : IEnumerable<Preventivo>, ICollection<Preventivo>
    {
        public event EventHandler<ArgsPreventivo> OnAggiunta;
        public event EventHandler<ArgsPreventivo> OnRimozione;
        public event EventHandler<ArgsModifica<Preventivo>> OnModifica;

        private HashSet<Preventivo> _preventivi = new HashSet<Preventivo>();

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza);

        #region Singleton
        private static CollezionePreventivi _listaPreventivi = null;
        /// <summary>
        /// Funzioen che dà un'istanza della <see cref="CollezioneFatture"/>
        /// </summary>
        /// <returns>La collezione riempita con tutti i clienti</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public static CollezionePreventivi GetInstance()
        {
            if (_listaPreventivi == null)
                _listaPreventivi = new CollezionePreventivi();
            return _listaPreventivi;
        }
        #endregion

        protected CollezionePreventivi()
        {
            try
            {
                foreach (Preventivo p in _persistenza.GetPreventivoDAO().LeggiTuttiPreventivi())
                {
                    _preventivi.Add(p);
                    p.OnModifica += (o, e) => {
                        Persistenza.PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza)
                            .GetPreventivoDAO()
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
                return ((ICollection<Preventivo>)_preventivi).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<Preventivo>)_preventivi).IsReadOnly;
            }
        }

        public Preventivo Get(ulong IDPreventivo)
        {
            foreach (Preventivo p in this._preventivi)
            {
                if (p.ID == IDPreventivo)
                    return p;
            }
            return null;
        }

        /// <summary>
        /// Aggiunge un <see cref="Preventivo"/> alla collezione
        /// </summary>
        /// <param name="item">Preventivo da aggiungere alla collezione</param>
        /// <exception cref="ArgumentNullException">Se il <see cref="Preventivo"/> è nullo</exception>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public void Add(Preventivo item)
        {
            if (item == null)
                throw new ArgumentNullException("Errore. Il preventivo è nullo");

            if (!this._preventivi.Contains(item))
            {
                if (_persistenza.GetPreventivoDAO().Crea(item))
                {
                    ((ICollection<Preventivo>)_preventivi).Add(item);
                    item.OnModifica += (o, e) => {
                        Persistenza.PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza)
                            .GetPreventivoDAO()
                                .Aggiorna(e.Vecchio, e.Nuovo);
                        this.OnModifica?.Invoke(o, e);
                    };
                    LanciaEvento(OnAggiunta, item);
                }
                else
                { // Se si sono verificati errori nella persistenza
                    throw new ExceptionPersistenza();
                }
            } else {
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

        public bool Contains(Preventivo item)
        {
            return ((ICollection<Preventivo>)_preventivi).Contains(item);
        }

        public void CopyTo(Preventivo[] array, int arrayIndex)
        {
            ((ICollection<Preventivo>)_preventivi).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Preventivo> GetEnumerator()
        {
            return ((IEnumerable<Preventivo>)_preventivi).GetEnumerator();
        }

        /// <summary>
        /// Funzione che elimina un utente dalla collezione
        /// </summary>
        /// <param name="item">L'utente che si intende eliminare</param>
        /// <returns><c>true</c> o <c>false</c> a seconda se ci è riuscito oppure no</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public bool Remove(Preventivo item)
        {
            bool rimosso = false;
            if (item != null)
            {
                if (_persistenza.GetPreventivoDAO().Elimina(item.ID))
                {
                    rimosso = ((ICollection<Preventivo>)_preventivi).Remove(item);
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
            return ((IEnumerable<Preventivo>)_preventivi).GetEnumerator();
        }

        private void LanciaEvento(EventHandler<ArgsPreventivo> evento, Preventivo preventivo)
        {
            if (evento != null)
            {
                ArgsPreventivo args = new ArgsPreventivo(preventivo);
                evento(this, args);
            }
        }

        public Preventivo this[ulong id]
        {
            get
            {
                foreach (Preventivo p in this._preventivi)
                {
                    if (p.ID == id)
                        return p;
                }
                return null;
            }
        }

    }
}
