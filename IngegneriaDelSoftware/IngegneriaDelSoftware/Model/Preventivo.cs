using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public class Preventivo: IEnumerable<VocePreventivo>, ICollection<VocePreventivo> {

        #region Campi privati
        private List<VocePreventivo> _voci;
        private bool _accettato;
        private Cliente _cliente;
        private DateTime _data;
        #endregion

        #region Property
        /// <summary>
        /// Le voci contenute nel preventivo
        /// </summary>
        public List<VocePreventivo> Voci {
            get {
                return _voci;
            }
        }
        /// <summary>
        /// Se il preventivo è accettato o meno.
        /// </summary>
        public bool Accettato {
            get {
                return _accettato;
            }

            set {
                this._accettato = value;
            }
        }
        /// <summary>
        /// Il cliente a cui è proposto il preventivo
        /// </summary>
        public Cliente Cliente {
            get {
                return _cliente;
            }

            set {
                if(value == null) {
                    throw new ArgumentNullException("Client enon può essere nullo");
                }
                this._cliente = value;
            }
        }
        /// <summary>
        /// La data del preventivo
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
        #endregion

        #region Costruttore
        /// <summary>
        /// Crea un nuovo preventivo.
        /// </summary>
        /// <param name="cliente">Il cliente a cui è proposto il preventivo</param>
        /// <param name="data">La data del preventivo<para>Se <c>null</c> è la data corrente</para></param>
        /// <param name="accettato">Se il preventivo è accettato o meno. <c>false</c> di default</param>
        /// <param name="voci">Le voci contenute nel preventivo<para>se <c>null</c> viene inizializzato a lista vuota</para></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Preventivo(Cliente cliente, DateTime? data = null, bool accettato = false, List<VocePreventivo> voci = null) {
            if(cliente == null) {
                throw new ArgumentNullException("Cliente non può essere nullo");
            }
            if(voci != null && voci.Count < 1) {
                throw new ArgumentException("La lista voci deve contenere almeno un elemento");
            }
            this._voci = voci ?? new List<VocePreventivo>();
            this._accettato = accettato;
            this._cliente = cliente;
            this._data = data ?? DateTime.Now;
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
            set { this._voci[i] = value; }
        }

        public override string ToString() {
            return String.Format("Vendita {0}\t{1}\t{2}\n{3}",
                    this._data,
                    this._cliente,
                    this._accettato,
                    String.Join("\n", this._voci)
                );
        }
        /// <summary>
        /// Ordina la lista interna
        /// </summary>
        public void Sort() {
            this._voci.Sort();
        }

        #region Collection implementation
        /// <summary>
        /// Aggiunge una voce alla lista interna
        /// </summary>
        /// <param name="item">La voce</param>
        public void Add(VocePreventivo item) {
            ((ICollection<VocePreventivo>)this._voci).Add(item);
        }
        /// <summary>
        /// Aggiunge una o più voci alla lista interna
        /// </summary>
        /// <param name="item">Le voci</param>
        public void Add(params VocePreventivo[] item) {
            this._voci.AddRange(item);
        }
        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear() {
            ((ICollection<VocePreventivo>)this._voci).Clear();
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
            return ((ICollection<VocePreventivo>)this._voci).Remove(item);
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

        #region Tests
        public static bool Test() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var preventivo = new Preventivo(cliente);
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
            }
            preventivo.Accettato = true;
            if(!preventivo.Accettato) {
                return false;
            }
            return true;
        }

        #endregion
    }
}
