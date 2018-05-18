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
                return new List<Vendita>(this._datiFattura.VenditeDiProvenienza);
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
                return ((ICollection<VoceFattura>)this._datiFattura.Voci).Count;
            }
        }

        public bool IsReadOnly {
            get {
                return ((ICollection<VoceFattura>)this._datiFattura.Voci).IsReadOnly;
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
            get {
                return _datiFattura;
            }

            set {
                if(this._stato == Stato.LOCKED) {
                    throw new InvalidOperationException("Non è possibilie modificare i dati se in stato di lock");
                }
                this._datiFattura = value;
            }
        }
        #endregion

        #region Costruttore
        public Fattura(DatiFattura datiFattura, bool finalizzato = false) {
            this._datiFattura = datiFattura;
            this._stato = finalizzato ? Stato.LOCKED : Stato.UNLOCKED;
        }
        /// <summary>
        /// Una nuova fattura
        /// </summary>
        /// <param name="anno">L'anno di emissione della fattura</param>
        /// <param name="numero">Il numero della fattura</param>
        /// <param name="cliente">Il cliente a cui la fattura è rivolta</param>
        /// <param name="venditeDiProvenienza">Le vendite di provenienza</param>
        /// <param name="data">La data della fattura.<para>Se posta a <c>null</c> è <see cref="DateTime.Now"/></para></param>
        /// <param name="sconto">Lo sconto della fattura.<para>Di default è 0</para></param>
        /// <param name="voci">Le voci della fattura.<para>Se posto a <c>null</c> una lista vuota viene inserita</para></param>
        /// <param name="finalizzato">Se la fattura è in stato di lock o meno (finalizzato)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Fattura(int anno, string numero, Cliente cliente, List<Vendita> venditeDiProvenienza,
             DateTime? data = null, float sconto = 0, List<VoceFattura> voci = null, bool finalizzato = false) 
            :this(new DatiFattura(anno, numero, cliente, venditeDiProvenienza, data, sconto, voci, finalizzato)){
            
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
                this._stato = Stato.LOCKED;
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
                this._stato = Stato.UNLOCKED;
            } else {
                throw new InvalidOperationException("La fattura è già in stato di unlock");
            }
        }

        /// <summary>
        /// Calcola il totale della fattura;
        /// </summary>
        /// <returns></returns>
        public virtual string Calcola() {
            return this._datiFattura.Voci.Select((e) => { return e.ValoreTotale(); }).Sum().ToString();
        }

        /// <summary>
        /// Recupera la <see cref="VoceFattura"/> all'indice <c>i</c>.
        /// </summary>
        /// <param name="i">L'indice della <see cref="VoceFattura"/></param>
        /// <returns>La <see cref="VoceFattura"/> richiesta</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public VoceFattura this[int i] {
            get { return this._datiFattura.Voci[i]; }
            set {
                if(this._stato != Stato.LOCKED) {
                    this._datiFattura.Voci[i] = value;
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
                    String.Join("\n", this._datiFattura.VenditeDiProvenienza),
                    String.Join("\n", this._datiFattura.Voci)
                );
        }
        /// <summary>
        /// Ordina la lista interna
        /// </summary>
        public void Sort() {
            this._datiFattura.Voci.Sort();
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
            return ((IEnumerable<VoceFattura>)this._datiFattura.Voci).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<VoceFattura>)this._datiFattura.Voci).GetEnumerator();
        }
        #endregion

        #region Collection implementation
        /// <summary>
        /// Aggiunge una voce alla lista interna
        /// </summary>
        /// <param name="item">La voce</param>
        public void Add(VoceFattura item) {
            ((ICollection<VoceFattura>)this._datiFattura.Voci).Add(item);
        }
        /// <summary>
        /// Aggiunge una o più voci alla lista interna
        /// </summary>
        /// <param name="item">Le voci</param>
        public void Add(params VoceFattura[] item) {
            this._datiFattura.Voci.AddRange(item);
        }
        /// <summary>
        /// Svuota la lista
        /// </summary>
        public void Clear() {
            ((ICollection<VoceFattura>)this._datiFattura.Voci).Clear();
        }
        /// <summary>
        /// Verifica se la lista interna contiene o meno la voce
        /// </summary>
        /// <param name="item">Il valore da controllare</param>
        /// <returns></returns>
        public bool Contains(VoceFattura item) {
            return ((ICollection<VoceFattura>)this._datiFattura.Voci).Contains(item);
        }

        public void CopyTo(VoceFattura[] array, int arrayIndex) {
            ((ICollection<VoceFattura>)this._datiFattura.Voci).CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Rimuove una voce dalla lista
        /// </summary>
        /// <param name="item">L'elemento da rimuovere</param>
        /// <returns></returns>
        public bool Remove(VoceFattura item) {
            return ((ICollection<VoceFattura>)this._datiFattura.Voci).Remove(item);
        }
        #endregion

        #endregion

        #region Struct interna

        public struct DatiFattura {
            public List<VoceFattura> Voci { get; private set; }
            public Cliente Cliente { get; private set; }
            public List<Vendita> VenditeDiProvenienza { get; private set; }
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
            /// <param name="venditeDiProvenienza">Le vendite di provenienza</param>
            /// <param name="data">La data della fattura.<para>Se posta a <c>null</c> è <see cref="DateTime.Now"/></para></param>
            /// <param name="sconto">Lo sconto della fattura.<para>Di default è 0</para></param>
            /// <param name="voci">Le voci della fattura.<para>Se posto a <c>null</c> una lista vuota viene inserita</para></param>
            /// <param name="finalizzato">Se la fattura è in stato di lock o meno (finalizzato)</param>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="ArgumentException"></exception>
            public DatiFattura(int anno, string numero, Cliente cliente, List<Vendita> venditeDiProvenienza,
             DateTime? data = null, float sconto = 0, List<VoceFattura> voci = null, bool finalizzato = false) {
                if(cliente == null) {
                    throw new ArgumentNullException("Il cliente non può essere nullo");
                }
                if(venditeDiProvenienza == null) {
                    throw new ArgumentNullException("La vendita di provenienza non può essere nulla");
                }
                if(numero == null) {
                    throw new ArgumentNullException("Il numero non può essere nullo");
                }
                if(sconto < 0) {
                    throw new ArgumentException("Lo sconto non può assumere valori negativi");
                }
                if(venditeDiProvenienza.Count < 1) {
                    throw new ArgumentException("La vendita di provenienza deve contenere almeno una vendita");
                }
                this.Voci = (voci == null) ? new List<VoceFattura>() : new List<VoceFattura>(voci);
                this.Cliente = cliente;
                this.VenditeDiProvenienza = new List<Vendita>(venditeDiProvenienza);
                this.Numero = numero;
                this.Data = data ?? DateTime.Now;
                this.Anno = anno;
                this.Sconto = sconto;
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
            public DatiFattura(int anno, string numero, Cliente cliente, Vendita venditaDiProvenienza,
                 DateTime? data = null, float sconto = 0, List<VoceFattura> voci = null, bool finalizzato = false)
            :this(anno, numero, cliente, new List<Vendita>(new Vendita[] { venditaDiProvenienza }), data, sconto, voci, finalizzato) {
                //                                      ^ Don't hit me for this plz ^
            }

        }

        #endregion

        #region Tests
        public static bool Test() {
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new Fattura(2018, "2", cliente, vendita);
            var voce1 = new VoceFattura("Corda", 30, 0.20f);
            var voce2 = new VoceFattura("Canapa", 20, 0.20f);

            fattura.Add(voce1, voce2);
            if(!fattura[0].Equals(voce1)) {
                return false;
            }
            if(!fattura[1].Equals(voce2)) {
                return false;
            }
            if(fattura.Count != 2) {
                return false;
            }
            fattura.Sort();
            if(!fattura[0].Equals(voce2)) {
                return false;
            }
            if(!fattura[1].Equals(voce1)) {
                return false;
            }
            fattura.Clear();
            fattura.Add(voce1);
            if(fattura.Count != 1) {
                return false;
            }
            fattura.Add(voce1, voce2);
            if(!fattura.Calcola().Equals("80")) {
                return false;
            }
            fattura.Finalizza();
            var dati = new DatiFattura();
            try {
                fattura.DatiFatturaInterni = dati;
                return false;
            }catch(InvalidOperationException e) {
                e.ToString();
            }
            fattura.Definalizza();
            try {
                fattura.DatiFatturaInterni = dati;
            } catch(InvalidOperationException e) {
                return false;
            }
            return true;
        }

        #endregion

    }
}
