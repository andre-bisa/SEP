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

using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.AdapterCalendario;

namespace IngegneriaDelSoftware.Model
{
    public class Calendario : IEnumerable<Appuntamento>, ICollection<Appuntamento>
    {
        private HashSet<Appuntamento> _appuntamenti;
        private static Calendario _calendario;
        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza);
        public event EventHandler<ArgsAppuntamento> OnAggiunta;
        public event EventHandler<ArgsAppuntamento> OnRimozione;
        public event EventHandler<ArgsModifica<Appuntamento>> OnModifica;

        private readonly IAdapterCalendarioEsterno adapterCalendario = null;

        /// <summary>
        /// Costruttore di Calendario
        /// </summary>
        /// <exception cref="ExceptionPersistenza"></exception>
        public Calendario()
        {
            _appuntamenti = new HashSet<Appuntamento>();

            try
            {
                //Riempe preventivamente il calendario con appuntamenti presi da DB
                foreach (Appuntamento a in _persistenza.GetAppuntamentoDAO().LeggiTuttiAppuntamenti())
                {
                    _appuntamenti.Add(a);
                    /*a.OnModifica += (o, e) => {
                        this.OnModifica?.Invoke(o, e);
                    };*/
                }
            }
            catch (Exception)
            {
                throw new ExceptionPersistenza();
            }

            adapterCalendario = AdapterCalendarioStaticMethods.GetInstanceDaImpostazioni();

        }

        #region Singleton
        /// <summary>
        /// Funzione che dà un'istanza della classe <see cref="Calendario"/>
        /// </summary>
        /// <returns>Il calendario degli appuntamenti</returns>
        public static Calendario GetInstance()
        {
            if (_calendario == null)
                _calendario = new Calendario();
            return _calendario;
        }
        #endregion

        /// <summary>
        /// Ritorna la lista di appuntamenti rientranti in un range di date
        /// </summary>
        /// <param name="da"></param>
        /// <param name="a"></param>
        /// <returns>Lista di Appuntamenti</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public List<Appuntamento> AppuntamentiDaA(DateTime da, DateTime a)
        {
            if (da == null || a == null)
            {
                throw new ArgumentNullException();
            }
            //Se la data di partenza viene dopo quella d'arrivo
            if (da > a)
            {
                throw new ArgumentException();
            }

            List<Appuntamento> risultato = new List<Appuntamento>();

            foreach (Appuntamento appuntamento in this.AppuntamentiCalendario)
            {
                if (da <= appuntamento.DataOra && a >= appuntamento.DataOra) //Se l'appuntamento rientra nel range
                {
                    risultato.Add(appuntamento);
                }
            }

            return risultato;
        }

        /// <summary>
        /// Ritorna la lista di appuntamenti correnti
        /// </summary>
        public HashSet<Appuntamento> AppuntamentiCalendario
        {
            get {
                HashSet<Appuntamento> result = new HashSet<Appuntamento>(this._appuntamenti);
                this.adapterCalendario?.GetListaAppuntamenti().ToList().ForEach(app => result.Add(app));
                return result;
            }
        }

        public int Count
        {
            get { return ((ICollection<Appuntamento>)_appuntamenti).Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<Appuntamento>)_appuntamenti).IsReadOnly; }
        }

        public override string ToString()
        {
            return String.Join("\n", this._appuntamenti);
        }

        public IEnumerator<Appuntamento> GetEnumerator()
        {
            return this._appuntamenti.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._appuntamenti.GetEnumerator();
        }

        /// <summary>
        /// Permette di aggiungere un appuntamento al calendario
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(Appuntamento item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            ((ICollection<Appuntamento>)_appuntamenti).Add(item);
            item.OnModifica += (o, e) => {
                this.OnModifica?.Invoke(o, e);
            };

            if (OnAggiunta != null)
            {
                LanciaEvento(OnAggiunta, item);
            }
        }

        /// <summary>
        /// Svuota il calendario
        /// </summary>
        public void Clear()
        {
            ((ICollection<Appuntamento>)_appuntamenti).Clear();
        }

        /// <summary>
        /// Controlla se un appuntamento sta nel calendario
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Contains(Appuntamento item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return ((ICollection<Appuntamento>)_appuntamenti).Contains(item);
        }

        public void CopyTo(Appuntamento[] array, int arrayIndex)
        {
            ((ICollection<Appuntamento>)_appuntamenti).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Permette di rimuovere un appuntamento specifico
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Remove(Appuntamento item)
        {
            bool risultato = false;
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            risultato = ((ICollection<Appuntamento>)_appuntamenti).Remove(item);

            if (OnRimozione != null)
            {
                LanciaEvento(OnRimozione, item);
            }

            return risultato;
        }

        /// <summary>
        /// Indexer di <see cref="Calendario"/>, dà l'elemento con un certo id
        /// </summary>
        /// <param name="idAppuntamento">Identificativo dell'appuntamento</param>
        /// <returns></returns>
        public Appuntamento this[string idAppuntamento]
        {
            get
            {
                if (idAppuntamento == null)
                    return null;
                foreach (Appuntamento f in this._appuntamenti)
                {
                    if (f.IDAppuntamento == idAppuntamento)
                        return f;
                }
                return null;
            }
        }

        /// <summary>
        /// Lancia l'evento relativo ad un certo <see cref="Appuntamento"/>
        /// </summary>
        /// <param name="evento"></param>
        /// <param name="appuntamento"></param>
        private void LanciaEvento(EventHandler<ArgsAppuntamento> evento, Appuntamento appuntamento)
        {
            if (evento != null)
            {
                ArgsAppuntamento args = new ArgsAppuntamento(appuntamento);
                evento(this, args);
            }
        }
    }
}
