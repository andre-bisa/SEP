using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model {
    public class Fattura : IEnumerable<VoceFattura>, ICollection<VoceFattura>, IObservable<Fattura> {
        public event EventHandler<ArgsModifica<Fattura>> OnModifica;
        private enum Stato { UNLOCKED, LOCKED };

        #region Campi privati
        private List<VoceFattura> _voci;
        private List<Vendita> _venditeDiProvenienza;
        private Stato _stato;
        private DatiFattura _datiFattura;
        #endregion

        #region Property
        /// <summary>
        /// Il cliente a cui la fattura è rivolta
        /// </summary>
        public Cliente Cliente {
            get {
                return this._datiFattura.Cliente;
            }
        }
        /// <summary>
        /// Le vendite di provenienza
        /// </summary>
        public List<Vendita> VenditeDiProvenienza {
            get {
                return new List<Vendita>(this._venditeDiProvenienza);
            }
        }
        /// <summary>
        /// Il numero della fattura
        /// </summary>
        public string Numero {
            get {
                return this._datiFattura.Numero;
            }
        }
        /// <summary>
        /// La data della fattura
        /// </summary>
        public DateTime Data {
            get {
                return this._datiFattura.Data;
            }
        }
        /// <summary>
        /// L'anno di emissione della fattura
        /// </summary>
        public int Anno {
            get {
                return this._datiFattura.Anno;
            }
        }
        /// <summary>
        /// Lo sconto della fattura.
        /// </summary>
        public float Sconto {
            get {
                return this._datiFattura.Sconto;
            }
        }
        /// <summary>
        /// Il numero delle voci
        /// </summary>
        public int Count {
            get {
                return ((ICollection<VoceFattura>)this._voci).Count;
            }
        }

        public bool IsReadOnly {
            get {
                return ((ICollection<VoceFattura>)this._voci).IsReadOnly;
            }
        }

        /// <summary>
        /// Dice se la fattura è finalizzata
        /// </summary>
        public bool IsFinalizzata
        {
            get
            {
                return (this._stato == Stato.LOCKED);
            }
        }
        /// <summary>
        /// La struttura dati interna
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public DatiFattura DatiFatturaInterni {
            set {
                if(this._stato == Stato.LOCKED) {
                    throw new InvalidOperationException("Non è possibilie modificare i dati se in stato di lock");
                }
                var old = this.Clone();
                this._datiFattura = value;
                this.OnModifica?.Invoke(this, new ArgsModifica<Fattura>(old, this));
            }
        }
        #endregion

        #region Costruttore
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datiFattura"></param>
        /// <param name="finalizzato">Se la fattura è in stato di lock o meno (finalizzato)</param>
        /// <param name="venditeDiProvenienza">Le vendite di provenienza</param>
        /// <param name="voci">Le voci della fattura.<para>Se posto a <c>null</c> una lista vuota viene inserita</para></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Fattura(DatiFattura datiFattura, List<Vendita> venditeDiProvenienza, List<VoceFattura> voci = null, bool finalizzato = false) {
            this._datiFattura = datiFattura;
            this._stato = finalizzato ? Stato.LOCKED : Stato.UNLOCKED;
        }
        /// <summary>
        /// Una nuova fattura
        /// </summary>
        /// <param name="anno">L'anno di emissione della fattura</param>
        /// <param name="numero">Il numero della fattura</param>
        /// <param name="cliente">Il cliente a cui la fattura è rivolta. Deve essere <see cref="EnumTipoCliente.Attivo"/> </param>
        /// <param name="venditeDiProvenienza">Le vendite di provenienza</param>
        /// <param name="data">La data della fattura.<para>Se posta a <c>null</c> è <see cref="DateTime.Now"/></para></param>
        /// <param name="sconto">Lo sconto della fattura.<para>Di default è 0</para></param>
        /// <param name="voci">Le voci della fattura.<para>Se posto a <c>null</c> una lista vuota viene inserita</para></param>
        /// <param name="finalizzato">Se la fattura è in stato di lock o meno (finalizzato)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Fattura(int anno, string numero, Cliente cliente, List<Vendita> venditeDiProvenienza,
             DateTime? data = null, float sconto = 0, List<VoceFattura> voci = null, bool finalizzato = false) 
            :this(new DatiFattura(anno, numero, cliente, data, sconto),venditeDiProvenienza, voci, finalizzato){
            if(venditeDiProvenienza == null) {
                throw new ArgumentNullException("La vendita di provenienza non può essere nulla");
            }
            if(venditeDiProvenienza.Count < 1) {
                throw new ArgumentException("La vendita di provenienza deve contenere almeno una vendita");
            }
            this._venditeDiProvenienza = new List<Vendita>(venditeDiProvenienza);
            this._voci = (voci == null) ? new List<VoceFattura>() : new List<VoceFattura>(voci);
        }
        /// <summary>
        /// Una nuova fattura
        /// </summary>
        /// <param name="anno">L'anno di emissione della fattura</param>
        /// <param name="numero">Il numero della fattura</param>
        /// <param name="cliente">Il cliente a cui la fattura è rivolta</param>
        /// <param name="venditaDiProvenienza">La vendita di provenienza</param>
        /// <param name="data">La data della fattura.<para>Se posta a <c>null</c> è <see cref="DateTime.Now"/></para></param>
        /// <param name="sconto">Lo sconto della fattura.<para>Di default è 0</para></param>
        /// <param name="voci">Le voci della fattura.<para>Se posto a <c>null</c> una lista vuota viene inserita</para></param>
        /// <param name="finalizzato">Se la fattura è in stato di lock o meno (finalizzato)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Fattura(int anno, string numero, Cliente cliente, Vendita venditaDiProvenienza,
             DateTime? data = null, float sconto = 0, List<VoceFattura> voci = null, bool finalizzato = false)
            :this(anno, numero, cliente, new List<Vendita>(new Vendita[] { venditaDiProvenienza }), data, sconto, voci, finalizzato) {
            //                                      ^ Don't hit me for this plz ^
        }
        #endregion

        #region Funzioni pubbliche
            /// <summary>
            /// Rende la fattura immodificabile
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
        public void Finalizza() {
            if(this._stato != Stato.LOCKED) {
                var old = this.Clone();
                this._stato = Stato.LOCKED;
                this.OnModifica?.Invoke(this, new ArgsModifica<Fattura>(old, this));
            } else {
                throw new InvalidOperationException("La fattura è già in stato di lock");
            }
        }
        /// <summary>
        /// Rende la fattura modificabile
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Definalizza() {
            if(this._stato != Stato.UNLOCKED) {
                var old = this.Clone();
                this._stato = Stato.UNLOCKED;
                this.OnModifica?.Invoke(this, new ArgsModifica<Fattura>(old, this));
            } else {
                throw new InvalidOperationException("La fattura è già in stato di unlock");
            }
        }

        /// <summary>
        /// Calcola il totale della fattura;
        /// </summary>
        /// <returns></returns>
        public virtual string Calcola() {
            return this._voci.Select((e) => { return e.ValoreTotale(); }).Sum().ToString();
        }

        /// <summary>
        /// Recupera la <see cref="VoceFattura"/> all'indice <c>i</c>.
        /// </summary>
        /// <param name="i">L'indice della <see cref="VoceFattura"/></param>
        /// <returns>La <see cref="VoceFattura"/> richiesta</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public VoceFattura this[int i] {
            get { return this._voci[i]; }
            set {
                if(this._stato != Stato.LOCKED) {
                    var old = this.Clone();
                    this._voci[i] = value;
                    this.OnModifica?.Invoke(this, new ArgsModifica<Fattura>(old, this));
                } else {
                    throw new InvalidOperationException("Non è possibile modificare una Fattura in stato di lock");
                }
            }
        }

        public override string ToString() {
            return String.Format("Fattura {0}\n{1}\\{2}\n{3}\n{4}\n{5}\n{6}",
                    this._stato,
                    this._datiFattura.Anno,
                    this._datiFattura.Numero,
                    this._datiFattura.Data.ToString(),
                    this._datiFattura.Cliente,
                    String.Join("\n", this._venditeDiProvenienza),
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
            var fattura = obj as Fattura;
            return fattura != null &&
                   Numero == fattura.Numero &&
                   Anno == fattura.Anno;
        }

        public override int GetHashCode()
        {
            var hashCode = -200852566;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Numero);
            hashCode = hashCode * -1521134295 + Anno.GetHashCode();
            return hashCode;
        }

        #region Iterator pattern implementation
        public IEnumerator<VoceFattura> GetEnumerator() {
            return ((IEnumerable<VoceFattura>)this._voci).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<VoceFattura>)this._voci).GetEnumerator();
        }
        #endregion

        #region Collection implementation
        /// <summary>
        /// Aggiunge una voce alla lista interna
        /// </summary>
        /// <param name="item">La voce</param>
        public void Add(VoceFattura item) {
            if(this._stato != Stato.LOCKED) {
                var old = this.Clone();
                ((ICollection<VoceFattura>)this._voci).Add(item);
                this.OnModifica?.Invoke(this, new ArgsModifica<Fattura>(old, this));
            } else {
                throw new InvalidOperationException("Non è possibile modificare una Fattura in stato di lock");
            }
        }
        /// <summary>
        /// Aggiunge una o più voci alla lista interna
        /// </summary>
        /// <param name="item">Le voci</param>
        public void Add(params VoceFattura[] item) {
            if(this._stato != Stato.LOCKED) {
                var old = this.Clone();
                this._voci.AddRange(item);
                this.OnModifica?.Invoke(this, new ArgsModifica<Fattura>(old, this));
            } else {
                throw new InvalidOperationException("Non è possibile modificare una Fattura in stato di lock");
            }
        }
        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear() {
            if(this._stato != Stato.LOCKED) {
                var old = this.Clone();
                ((ICollection<VoceFattura>)this._voci).Clear();
                this.OnModifica?.Invoke(this, new ArgsModifica<Fattura>(old, this));
            } else {
                throw new InvalidOperationException("Non è possibile modificare una Fattura in stato di lock");
            }
        }
        /// <summary>
        /// Verifica se la lista interna contiene o meno la voce
        /// </summary>
        /// <param name="item">Il valore da controllare</param>
        /// <returns></returns>
        public bool Contains(VoceFattura item) {
            return ((ICollection<VoceFattura>)this._voci).Contains(item);
        }

        public void CopyTo(VoceFattura[] array, int arrayIndex) {
            ((ICollection<VoceFattura>)this._voci).CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Rimuove una voce dalla lista
        /// </summary>
        /// <param name="item">L'elemento da rimuovere</param>
        /// <returns></returns>
        public bool Remove(VoceFattura item) {
            if(this._stato != Stato.LOCKED) {
                var old = this.Clone();
                bool result = ((ICollection<VoceFattura>)this._voci).Remove(item);
                this.OnModifica?.Invoke(this, new ArgsModifica<Fattura>(old, this));
                return result;
            } else {
                throw new InvalidOperationException("Non è possibile modificare una Fattura in stato di lock");
            }
        }
        #endregion

        #endregion

        #region Funzioni protected
        protected Fattura Clone() {
            return new Fattura(this._datiFattura, this._venditeDiProvenienza, this._voci, this._stato == Stato.LOCKED);
        }
        #endregion

        #region Struct interna

        public struct DatiFattura {
            public Cliente Cliente { get; private set; }
            public float Sconto { get; private set; }
            public string Numero { get; private set; }
            public DateTime Data { get; private set; }
            public int Anno { get; private set; }

            /// <summary>
            /// Una nuova fattura
            /// </summary>
            /// <param name="anno">L'anno di emissione della fattura</param>
            /// <param name="numero">Il numero della fattura</param>
            /// <param name="cliente">Il cliente a cui la fattura è rivolta</param>
            /// <param name="data">La data della fattura.<para>Se posta a <c>null</c> è <see cref="DateTime.Now"/></para></param>
            /// <param name="sconto">Lo sconto della fattura.<para>Di default è 0</para></param>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="InvalidOperationException"></exception>
            public DatiFattura(int anno, string numero, Cliente cliente, DateTime? data = null, float sconto = 0) {
                if(cliente == null) {
                    throw new ArgumentNullException("Il cliente non può essere nullo");
                }
                if(numero == null) {
                    throw new ArgumentNullException("Il numero non può essere nullo");
                }
                if(sconto < 0) {
                    throw new ArgumentException("Lo sconto non può assumere valori negativi");
                }
                if(cliente.TipoCliente != EnumTipoCliente.Attivo) {
                    throw new InvalidOperationException("Il cliente deve essere attivo per potere preformare questa operazione");
                }
                this.Cliente = cliente;
                this.Numero = numero;
                this.Data = data ?? DateTime.Now;
                this.Anno = anno;
                this.Sconto = sconto;
            }
            public DatiFattura(DatiFattura old, int? anno, string numero, Cliente cliente, DateTime? data = null, float? sconto = null)
                : this(anno ?? old.Anno, numero ?? old.Numero, cliente ?? old.Cliente, data ?? old.Data, sconto ?? old.Sconto ) { }

        }

        #endregion
    }
}
