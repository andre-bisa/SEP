using IngegneriaDelSoftware.Model.ArgsEvent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public class Preventivo: IEnumerable<VocePreventivo>, ICollection<VocePreventivo>, IObservable<Preventivo> {
        public event EventHandler<ArgsModifica<Preventivo>> OnModifica;

        #region Campi privati
        private DatiPreventivo _datiPreventivo;
        #endregion

        #region Property
        /// <summary>
        /// Le voci contenute nel preventivo
        /// </summary>
        public List<VocePreventivo> Voci {
            get {
                return new List<VocePreventivo>(this._datiPreventivo.Voci);
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
                return ((ICollection<VocePreventivo>)this._datiPreventivo.Voci).Count;
            }
        }

        public bool IsReadOnly {
            get {
                return ((ICollection<VocePreventivo>)this._datiPreventivo.Voci).IsReadOnly;
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
                this._datiPreventivo = value;
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
        public Preventivo(DatiPreventivo datiPreventivo) {
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
            :this(new DatiPreventivo(id, cliente, data, accettato, voci)){
            
        }
        #endregion

        #region Funzioni Pubbliche

        /// <summary>
        /// Calcola il valore della vendita
        /// </summary>
        /// <returns>il valore della vendita</returns>
        public decimal Totale() {
            return this._datiPreventivo.Voci.Select((e) => { return e.ValoreTotale(); }).Sum();
        }

        /// <summary>
        /// Recupera la <see cref="VocePreventivo"/> all'indice <c>i</c>.
        /// </summary>
        /// <param name="i">L'indice della <see cref="VocePreventivo"/></param>
        /// <returns>La <see cref="VocePreventivo"/> richiesta</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public VocePreventivo this[int i] {
            get { return this._datiPreventivo.Voci[i]; }
            set { this._datiPreventivo.Voci[i] = value; }
        }

        public override string ToString() {
            return String.Format("Vendita {0}\t{1}\t{2}\n{3}",
                    this._datiPreventivo.Data,
                    this._datiPreventivo.Cliente,
                    this._datiPreventivo.Accettato,
                    String.Join("\n", this._datiPreventivo.Voci)
                );
        }
        /// <summary>
        /// Ordina la lista interna
        /// </summary>
        public void Sort() {
            this._datiPreventivo.Voci.Sort();
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
            ((ICollection<VocePreventivo>)this._datiPreventivo.Voci).Add(item);
        }
        /// <summary>
        /// Aggiunge una o più voci alla lista interna
        /// </summary>
        /// <param name="item">Le voci</param>
        public void Add(params VocePreventivo[] item) {
            this._datiPreventivo.Voci.AddRange(item);
        }
        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear() {
            ((ICollection<VocePreventivo>)this._datiPreventivo.Voci).Clear();
        }
        /// <summary>
        /// Verifica se la lista interna contiene o meno la voce
        /// </summary>
        /// <param name="item">Il valore da controllare</param>
        /// <returns></returns>
        public bool Contains(VocePreventivo item) {
            return ((ICollection<VocePreventivo>)this._datiPreventivo.Voci).Contains(item);
        }

        public void CopyTo(VocePreventivo[] array, int arrayIndex) {
            ((ICollection<VocePreventivo>)this._datiPreventivo.Voci).CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Rimuove una voce dalla lista
        /// </summary>
        /// <param name="item">L'elemento da rimuovere</param>
        /// <returns></returns>
        public bool Remove(VocePreventivo item) {
            return ((ICollection<VocePreventivo>)this._datiPreventivo.Voci).Remove(item);
        }
        #endregion

        #region Iterator pattern implementation
        public IEnumerator<VocePreventivo> GetEnumerator() {
            return ((IEnumerable<VocePreventivo>)this._datiPreventivo.Voci).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<VocePreventivo>)this._datiPreventivo.Voci).GetEnumerator();
        }
        #endregion

        #endregion

        #region Struct dati
        public struct DatiPreventivo {
            public List<VocePreventivo> Voci { get; private set; }
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
            /// <param name="voci">Le voci contenute nel preventivo<para>se <c>null</c> viene inizializzato a lista vuota</para></param>
            /// <param name="iD">L'id del preventivo</param>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="InvalidOperationException"></exception>
            public DatiPreventivo(ulong iD, Cliente cliente, DateTime? data = null, bool accettato = false, List<VocePreventivo> voci = null) {
                if(cliente == null) {
                    throw new ArgumentNullException("Cliente non può essere nullo");
                }
                if(voci != null && voci.Count < 1) {
                    throw new ArgumentException("La lista voci deve contenere almeno un elemento");
                }
                if(cliente.TipoCliente == EnumTipoCliente.Ex) {
                    throw new InvalidOperationException("Il cliente deve essere attivo per potere preformare questa operazione");
                }
                this.Cliente = cliente;
                this.Voci = (voci == null) ? new List<VocePreventivo>() : new List<VocePreventivo>(voci);
                this.Accettato = accettato;
                this.Data = data ?? DateTime.Now;
                this.ID = iD;
            }

        }
        #endregion

        #region Tests
        public static bool Test() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var preventivo = new Preventivo(1, cliente);
            var voce1 = new VocePreventivo("Corda", 30);
            var voce2 = new VocePreventivo("Canapa", 20);

            preventivo.Add(voce1, voce2);
            if(!preventivo[0].Equals(voce1)) {
                return false;
            }
            if(!preventivo[1].Equals(voce2)) {
                return false;
            }
            if(preventivo.Count != 2) {
                return false;
            }
            preventivo.Sort();
            if(!preventivo[0].Equals(voce2)) {
                return false;
            }
            if(!preventivo[1].Equals(voce1)) {
                return false;
            }
            preventivo.Clear();
            preventivo.Add(voce1);
            if(preventivo.Count != 1) {
                return false;
            }
            preventivo.Add(voce1, voce2);
            if(preventivo.Totale() != 80) {
                return false;
            }
            if(preventivo.Accettato) {
                return false;
            }/*
            preventivo.Accettato = true;
            if(!preventivo.Accettato) {
                return false;
            }*/
            return true;
        }

        #endregion
    }
}
