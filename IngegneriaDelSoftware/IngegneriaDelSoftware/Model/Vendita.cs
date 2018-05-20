using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model {
    /// <summary>
    /// <example>this._voci.AddRange(this._datiVendita.PreventivoDiProvenienza.Cast<VoceVendita>());</example>
    /// </summary>
    public class Vendita: IEnumerable<VoceVendita>, ICollection<VoceVendita>, IObservable<Vendita> {
        public event EventHandler<ArgsModifica<Vendita>> OnModifica;

        #region Campi privati
        private DatiVendita _datiVendita;
        private List<VoceVendita> _voci;
        #endregion

        #region Property
        /// <summary>
        /// Il cliente a cui sono riferite le voci
        /// </summary>
        public List<VoceVendita> Voci {
            get {
                return new List<VoceVendita>(this._voci);
            }
        }
        /// <summary>
        /// Le voci nella vendita.
        /// </summary>
        public Cliente Cliente {
            get {
                return this._datiVendita.Cliente;
            }
        }
        /// <summary>
        /// La data della vendita.
        /// </summary>
        public DateTime Data {
            get {
                return this._datiVendita.Data;
            }
        }
        /// <summary>
        /// Il preventivo da cui la fattura proviene
        /// <para>Can be <c>null</c></para>
        /// </summary>
        public Preventivo PreventivoDiProvenienza {
            get {
                return this._datiVendita.PreventivoDiProvenienza;
            }
        }
        /// <summary>
        /// Il numero delle voci
        /// </summary>
        public int Count {
            get {
                return ((ICollection<VoceVendita>)this._voci).Count;
            }
        }

        public bool IsReadOnly {
            get {
                return ((ICollection<VoceVendita>)this._voci).IsReadOnly;
            }
        }

        public ulong ID {
            get
            {
                return this._datiVendita.ID;
            }
        }
        /// <summary>
        /// La struttura dati interna
        /// </summary>
        public DatiVendita DatiVenditaInterni {
            get {
                return _datiVendita;
            }

            set {
                var old = this.Clone();
                this._datiVendita = value;
                this.OnModifica?.Invoke(this, new ArgsModifica<Vendita>(old, this));
            }
        }
        #endregion

        #region Costruttore
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datiVendita"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Vendita(DatiVendita datiVendita, List<VoceVendita> voci = null) {
            this._datiVendita = datiVendita;
            this._voci = (voci == null) ? new List<VoceVendita>() : new List<VoceVendita>(voci);
        }
        /// <summary>
        /// Una nuova vendita.
        /// </summary>
        /// <param name="cliente">Il cliente a cui sono riferite le voci. Deve essere <see cref="EnumTipoCliente.Attivo"/>/param>
        /// <param name="data">La data della vendita.<para>Se <c>null</c> è la data corrente</para></param>
        /// <param name="voci">Le voci nella vendita. Deve contenere almeno un valore.<para>Se <c>null</c> è una lista vuota</para></param>
        /// <param name="preventivoDiProvenienza">Il preventivo da cui la fattura proviene.<para>Se <c>null</c> non viene inserito</para></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Vendita(ulong iD, Cliente cliente, DateTime? data = null, List<VoceVendita> voci = null, Preventivo preventivoDiProvenienza = null)
            : this(new DatiVendita(iD, cliente, data, preventivoDiProvenienza), voci) {
        }

        #endregion

        #region Funzioni Pubbliche
        /// <summary>
        /// Recupera la <see cref="VoceVendita"/> all'indice <c>i</c>.
        /// </summary>
        /// <param name="i">L'indice della <see cref="VoceVendita"/></param>
        /// <returns>La <see cref="VoceVendita"/> richiesta</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public VoceVendita this[int i] {
            get { return this._voci[i]; }
            set {
                var old = this.Clone();
                this._voci[i] = value;
                this.OnModifica?.Invoke(this, new ArgsModifica<Vendita>(old, this));
            }
        }
        /// <summary>
        /// Calcola il valore della vendita
        /// </summary>
        /// <returns>il valore della vendita</returns>
        public decimal Totale() {
            return this._voci.Select((e) => { return e.ValoreTotale(); }).Sum();
        }

        public override string ToString() {
            return String.Format("Vendita {0}\t{1}\n{2}",
                    this._datiVendita.Data,
                    this._datiVendita.Cliente,
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
            var vendita = obj as Vendita;
            return vendita != null &&
                   ID == vendita.ID;
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
        public void Add(VoceVendita item) {
            var old = this.Clone();
            ((ICollection<VoceVendita>)this._voci).Add(item);
            this.OnModifica?.Invoke(this, new ArgsModifica<Vendita>(old, this));
        }
        /// <summary>
        /// Aggiunge una o più voci alla lista interna
        /// </summary>
        /// <param name="item">Le voci</param>
        public void Add(params VoceVendita[] item) {
            var old = this.Clone();
            this._voci.AddRange(item);
            this.OnModifica?.Invoke(this, new ArgsModifica<Vendita>(old, this));
        }
        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear() {
            var old = this.Clone();
            ((ICollection<VoceVendita>)this._voci).Clear();
            this.OnModifica?.Invoke(this, new ArgsModifica<Vendita>(old, this));
        }
        /// <summary>
        /// Verifica se la lista interna contiene o meno la voce
        /// </summary>
        /// <param name="item">Il valore da controllare</param>
        /// <returns></returns>
        public bool Contains(VoceVendita item) {
            return ((ICollection<VoceVendita>)this._voci).Contains(item);
        }

        public void CopyTo(VoceVendita[] array, int arrayIndex) {
            ((ICollection<VoceVendita>)this._voci).CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Rimuove una voce dalla lista
        /// </summary>
        /// <param name="item">L'elemento da rimuovere</param>
        /// <returns></returns>
        public bool Remove(VoceVendita item) {
            var old = this.Clone();
            bool result = ((ICollection<VoceVendita>)this._voci).Remove(item);
            this.OnModifica?.Invoke(this, new ArgsModifica<Vendita>(old, this));
            return result;
        }
        #endregion

        #region Iterator pattern implementation
        public IEnumerator<VoceVendita> GetEnumerator() {
            return ((IEnumerable<VoceVendita>)this._voci).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<VoceVendita>)this._voci).GetEnumerator();
        }
        #endregion

        #endregion

        #region Funzioni protected
        protected Vendita Clone() {
            return new Vendita(this._datiVendita, this._voci);
        }
        #endregion

        #region Statics
        /// <summary>
        /// Crea una nuova vendita da un preventivo riversando la lista delle <see cref="VocePreventivo"/> in quella di
        /// <see cref="VoceVendita"/> interna della nuova <see cref="Vendita"/>.
        /// </summary>
        /// <param name="iD">L'id della vendita</param>
        /// <param name="input">Il preventivo d'ingresso</param>
        /// <param name="data">La data della vendita <para><see cref="DateTime.Now"/> di default</para></param>
        /// <returns></returns>
        public static Vendita FromPreventivo(ulong iD, Preventivo input, DateTime? data = null) {
            return new Vendita(iD, input.Cliente, data ?? DateTime.Now, input.Voci.Cast<VoceVendita>().ToList<VoceVendita>(), input);
        }
        #endregion

        #region Struct dati
        public struct DatiVendita {
            /// <summary>
            /// Una nuova vendita.
            /// </summary>
            /// <param name="cliente">Il cliente a cui sono riferite le voci. Deve essere <see cref="EnumTipoCliente.Attivo"/></param>
            /// <param name="data">La data della vendita.<para>Se <c>null</c> è la data corrente</para></param>
            /// <param name="preventivoDiProvenienza">Il preventivo da cui la fattura proviene.<para>Se <c>null</c> non viene inserito</para></param>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="InvalidOperationException"></exception>
            public DatiVendita(ulong iD, Cliente cliente, DateTime? data = null, Preventivo preventivoDiProvenienza = null) : this() {
                if(cliente == null) {
                    throw new ArgumentNullException("Il cliente non può essere nullo");
                }
                if(cliente.TipoCliente != EnumTipoCliente.Attivo) {
                    throw new InvalidOperationException("Il cliente deve essere attivo per potere preformare questa operazione");
                }
                if(preventivoDiProvenienza != null && preventivoDiProvenienza.Accettato) {
                    throw new ArgumentException("Il preventivo deve essere accettato");
                }
                this.Cliente = cliente;
                this.Data = data ?? DateTime.Now;
                this.PreventivoDiProvenienza = preventivoDiProvenienza;
                this.ID = iD;
            }
            public DatiVendita(DatiVendita old, ulong? iD = null, Cliente cliente = null, DateTime? data = null, Preventivo preventivoDiProvenienza = null)
                : this(iD ?? old.ID, cliente ?? old.Cliente, data ?? old.Data, preventivoDiProvenienza ?? old.PreventivoDiProvenienza) { }



            public Cliente Cliente { get; private set; }
            public DateTime Data { get; private set; }
            public Preventivo PreventivoDiProvenienza { get; private set; }
            public ulong ID { get; private set; }

        }
        #endregion
    }
}
