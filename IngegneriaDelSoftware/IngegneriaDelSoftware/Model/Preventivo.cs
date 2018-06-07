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

using IngegneriaDelSoftware.Model.ArgsEvent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public class Preventivo: IEnumerable<VocePreventivo>, ICollection<VocePreventivo>, IObservable<Preventivo>{
        public event EventHandler<ArgsModifica<Preventivo>> OnModifica;

        #region Campi privati
        private DatiPreventivo _datiPreventivo;
        private List<VocePreventivo> _voci;
        #endregion

        #region Property
        /// <summary>
        /// Le voci contenute nel preventivo
        /// </summary>
        public List<VocePreventivo> Voci {
            get {
                return new List<VocePreventivo>(this._voci);
            }
        }
        /// <summary>
        /// Se il preventivo è accettato o meno.
        /// </summary>
        public bool Accettato {
            get {
                return this._datiPreventivo.Accettato;
            }
        }
        /// <summary>
        /// Il cliente a cui è proposto il preventivo
        /// </summary>
        public Cliente Cliente {
            get {
                return this._datiPreventivo.Cliente;
            }
        }
        /// <summary>
        /// La data del preventivo
        /// </summary>
        public DateTime Data {
            get {
                return this._datiPreventivo.Data;
            }
        }
        /// <summary>
        /// Il numero delle voci
        /// </summary>
        public int Count {
            get {
                return ((ICollection<VocePreventivo>)this._voci).Count;
            }
        }

        public bool IsReadOnly {
            get {
                return ((ICollection<VocePreventivo>)this._voci).IsReadOnly;
            }
        }

        public ulong ID
        {
            get
            {
                return this._datiPreventivo.ID;
            }
        }
        /// <summary>
        /// La struttura dati interna
        /// </summary>
        public DatiPreventivo DatiPreventivoInterni {
            get {
                return _datiPreventivo;
            }

            set {
                var old = this.Clone();
                this._datiPreventivo = value;
                this.OnModifica?.Invoke(this, new ArgsModifica<Preventivo>(old, this));
            }
        }

        
        #endregion

        #region Costruttore
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datiPreventivo"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Preventivo(DatiPreventivo datiPreventivo, List<VocePreventivo> voci) {
            this._voci = (voci == null) ? new List<VocePreventivo>() : new List<VocePreventivo>(voci);
            this._datiPreventivo = datiPreventivo;
        }
        /// <summary>
        /// Crea un nuovo preventivo.
        /// </summary>
        /// <param name="cliente">Il cliente a cui è proposto il preventivo. Non può essere <see cref="EnumTipoCliente.Ex"/></param>
        /// <param name="data">La data del preventivo<para>Se <c>null</c> è la data corrente</para></param>
        /// <param name="accettato">Se il preventivo è accettato o meno. <c>false</c> di default</param>
        /// <param name="voci">Le voci contenute nel preventivo<para>se <c>null</c> viene inizializzato a lista vuota</para></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Preventivo(ulong id, Cliente cliente, DateTime? data = null, bool accettato = false, List<VocePreventivo> voci = null)
            :this(new DatiPreventivo(id, cliente, data, accettato), voci) {
            
        }
        #endregion

        #region Funzioni Pubbliche

        /// <summary>
        /// Calcola il valore della vendita
        /// </summary>
        /// <returns>il valore della vendita</returns>
        public decimal Totale() {
            return this._voci.Select((e) => { return e.ValoreTotale(); }).Sum();
        }

        /// <summary>
        /// Recupera la <see cref="VocePreventivo"/> all'indice <c>i</c>.
        /// </summary>
        /// <param name="i">L'indice della <see cref="VocePreventivo"/></param>
        /// <returns>La <see cref="VocePreventivo"/> richiesta</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public VocePreventivo this[int i] {
            get { return this._voci[i]; }
            set {
                var old = this.Clone();
                this._voci[i] = value;
                this.OnModifica?.Invoke(this, new ArgsModifica<Preventivo>(old, this));
            }
        }

        public override string ToString() {
            return String.Format("{0}, {1}, {2}, {3}",
                    this._datiPreventivo.Data,
                    this._datiPreventivo.Cliente,
                    this._datiPreventivo.Accettato,
                    String.Join("\n", this._voci)
                );
        }
        /// <summary>
        /// Ordina la lista interna
        /// </summary>
        public void Sort() {
            this._voci.Sort();
        }

        public override bool Equals(object obj)
        {
            var preventivo = obj as Preventivo;
            return preventivo != null &&
                   ID == preventivo.ID;
        }

        public override int GetHashCode()
        {
            return 1213502048 + ID.GetHashCode();
        }

        #region Collection implementation
        /// <summary>
        /// Aggiunge una voce alla lista interna
        /// </summary>
        /// <param name="item">La voce</param>
        public void Add(VocePreventivo item) {
            var old = this.Clone();
            ((ICollection<VocePreventivo>)this._voci).Add(item);
            this.OnModifica?.Invoke(this, new ArgsModifica<Preventivo>(old, this));
        }
        /// <summary>
        /// Aggiunge una o più voci alla lista interna
        /// </summary>
        /// <param name="item">Le voci</param>
        public void Add(params VocePreventivo[] item) {
            var old = this.Clone();
            this._voci.AddRange(item);
            this.OnModifica?.Invoke(this, new ArgsModifica<Preventivo>(old, this));
        }
        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear() {
            var old = this.Clone();
            ((ICollection<VocePreventivo>)this._voci).Clear();
            this.OnModifica?.Invoke(this, new ArgsModifica<Preventivo>(old, this));
        }
        /// <summary>
        /// Verifica se la lista interna contiene o meno la voce
        /// </summary>
        /// <param name="item">Il valore da controllare</param>
        /// <returns></returns>
        public bool Contains(VocePreventivo item) {
            return ((ICollection<VocePreventivo>)this._voci).Contains(item);
        }

        public void CopyTo(VocePreventivo[] array, int arrayIndex) {
            ((ICollection<VocePreventivo>)this._voci).CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Rimuove una voce dalla lista
        /// </summary>
        /// <param name="item">L'elemento da rimuovere</param>
        /// <returns></returns>
        public bool Remove(VocePreventivo item) {
            var old = this.Clone();
            bool result = ((ICollection<VocePreventivo>)this._voci).Remove(item);
            this.OnModifica?.Invoke(this, new ArgsModifica<Preventivo>(old, this));
            return result;
        }
        #endregion

        #region Iterator pattern implementation
        public IEnumerator<VocePreventivo> GetEnumerator() {
            return ((IEnumerable<VocePreventivo>)this._voci).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<VocePreventivo>)this._voci).GetEnumerator();
        }
        #endregion

        #endregion

        #region Funzioni protected
        protected Preventivo Clone() {
            return new Preventivo(this._datiPreventivo, this._voci);
        }
        #endregion

        #region Struct dati
        public struct DatiPreventivo {
            public bool Accettato { get; private set; }
            public Cliente Cliente { get; private set; }
            public DateTime Data { get; private set; }
            public ulong ID { get; private set; }
            /// <summary>
            /// Crea un nuovo preventivo.
            /// </summary>
            /// <param name="cliente">Il cliente a cui è proposto il preventivo. Non può essere <see cref="EnumTipoCliente.Ex"/></param>
            /// <param name="data">La data del preventivo<para>Se <c>null</c> è la data corrente</para></param>
            /// <param name="accettato">Se il preventivo è accettato o meno. <c>false</c> di default</param>
            /// <param name="iD">L'id del preventivo</param>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="InvalidOperationException"></exception>
            public DatiPreventivo(ulong iD, Cliente cliente, DateTime? data = null, bool accettato = false) {
                if(cliente == null) {
                    throw new ArgumentNullException("Cliente non può essere nullo");
                }
                if(cliente.TipoCliente == EnumTipoCliente.Ex) {
                    throw new InvalidOperationException("Il cliente deve essere attivo per potere preformare questa operazione");
                }
                this.Cliente = cliente;
                this.Accettato = accettato;
                this.Data = data ?? DateTime.Now;
                this.ID = iD;
            }
            public DatiPreventivo(DatiPreventivo old, ulong? iD = null, Cliente cliente = null, DateTime? data = null, bool? accettato = false) 
                : this(iD ?? old.ID, cliente ?? old.Cliente, data ?? old.Data, accettato ?? old.Accettato) { }

        }
        #endregion
    }
}
