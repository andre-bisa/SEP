using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public class Vendita: IEnumerable<VoceVendita>, ICollection<VoceVendita> {

        #region Campi privati
        private List<VoceVendita> _voci;
        private Cliente _cliente;
        private DateTime _data;
        private Preventivo _preventivoDiProvenienza;
        private UInt64 _ID;
        #endregion

        #region Property
        /// <summary>
        /// Il cliente a cui sono riferite le voci
        /// </summary>
        public List<VoceVendita> Voci {
            get {
                return new List<VoceVendita>(_voci);
            }
        }
        /// <summary>
        /// Le voci nella vendita.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public Cliente Cliente {
            get {
                return _cliente;
            }

            set {
                if(value == null) {
                    throw new ArgumentNullException("Il cliente non può essere nullo");
                }
                this._cliente = value;
            }
        }
        /// <summary>
        /// La data della vendita.
        /// </summary>
        public DateTime Data {
            get {
                return _data;
            }

            set {
                this._data = value;
            }
        }
        /// <summary>
        /// Il preventivo da cui la fattura proviene
        /// <para>Can be <c>null</c></para>
        /// </summary>
        public Preventivo PreventivoDiProvenienza {
            get {
                return _preventivoDiProvenienza;
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

        public UInt64 ID {
            get
            {
                return _ID;
            }
        }
        #endregion

        #region Costruttore
        /// <summary>
        /// Una nuova vendita.
        /// </summary>
        /// <param name="cliente">Il cliente a cui sono riferite le voci</param>
        /// <param name="data">La data della vendita.<para>Se <c>null</c> è la data corrente</para></param>
        /// <param name="voci">Le voci nella vendita. Deve contenere almeno un valore.<para>Se <c>null</c> è una lista vuota</para></param>
        /// <param name="preventivoDiProvenienza">Il preventivo da cui la fattura proviene.<para>Se <c>null</c> non viene inserito</para></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Vendita(Cliente cliente, DateTime? data = null, List<VoceVendita> voci = null, Preventivo preventivoDiProvenienza = null) {
            if(cliente == null) {
                throw new ArgumentNullException("Il cliente non può essere nullo");
            }
            if(voci != null && voci.Count < 1) {
                throw new ArgumentException("Le voci devono essere almeno una");
            }
            this._cliente = cliente;
            this._voci = (voci == null) ? new List<VoceVendita>() : new List<VoceVendita>(voci);
            this._preventivoDiProvenienza = preventivoDiProvenienza;
            this._data = data ?? DateTime.Now;
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
            set { this._voci[i] = value; }
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
                    this._data,
                    this._cliente,
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
            ((ICollection<VoceVendita>)this._voci).Add(item);
        }
        /// <summary>
        /// Aggiunge una o più voci alla lista interna
        /// </summary>
        /// <param name="item">Le voci</param>
        public void Add(params VoceVendita[] item) {
            this._voci.AddRange(item);
        }
        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear() {
            ((ICollection<VoceVendita>)this._voci).Clear();
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
            return ((ICollection<VoceVendita>)this._voci).Remove(item);
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

        #region Tests
        public static bool Test() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(cliente);
            var voce1 = new VoceVendita("Corda", 30);
            var voce2 = new VoceVendita("Canapa", 20);

            vendita.Add(voce1, voce2);
            if(!vendita[0].Equals(voce1)) {
                return false;
            }
            if(!vendita[1].Equals(voce2)) {
                return false;
            }
            if(vendita.Count != 2) {
                return false;
            }
            vendita.Sort();
            if(!vendita[0].Equals(voce2)) {
                return false;
            }
            if(!vendita[1].Equals(voce1)) {
                return false;
            }
            vendita.Clear();
            vendita.Add(voce1);
            if(vendita.Count != 1) {
                return false;
            }
            vendita.Add(voce1, voce2);
            if(vendita.Totale() != 80) {
                return false;
            }
            return true;
        }

        #endregion

    }
}
