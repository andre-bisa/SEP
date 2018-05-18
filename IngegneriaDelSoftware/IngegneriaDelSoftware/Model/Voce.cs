using IngegneriaDelSoftware.Model.ArgsEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public abstract class Voce: IComparable<Voce>, IObservable<Voce> {
        public abstract event EventHandler<ArgsModifica<Voce>> OnModifica;

        #region Campi privati
        private string _causale;
        private decimal _importo;
        private string _tipologia;
        private int _quantita;
        #endregion

        #region Property
        /// <summary>
        /// La causale della voce.
        /// </summary>
        public string Causale { get { return this._causale; } }
        /// <summary>
        /// L'importo della voce
        /// </summary>
        public decimal Importo { get { return this._importo; } }
        /// <summary>
        /// La tipologia della voce. Cioè un campo opzionale riempibile dall'utente per raggruppare le voci in macro gruppi.
        /// <para>L'importo è sempre da intendersi singolo</para>
        /// </summary>
        public string Tipologia { get { return this._tipologia; } }
        /// <summary>
        /// La quantità di una voce
        /// </summary>
        public int Quantita { get { return this._quantita; } }
        #endregion

        #region Costruttore
        /// <summary>
        /// Crea una nuova voce inseribile in qualsiasi <see cref="VoceContainer"/>.
        /// </summary>
        /// <param name="causale">La causale della voce.</param>
        /// <param name="importo">L'importo della voce</param>
        /// <param name="tipologia">La tipologia della voce. Cioè un campo opzionale 
        /// riempibile dall'utente per raggruppare le voci in macro gruppi.
        /// <para>L'importo è sempre da intendersi singolo</para></param>
        /// <param name="quantita">La quantità di una voce</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Voce(string causale, decimal importo, string tipologia = null, int quantita = 1) {
            if(causale == null) {
                throw new ArgumentNullException("La causale non può essere nulla");
            }
            if(quantita < 0) {
                throw new ArgumentException("La quantità non può essere negativa");
            }
            if(tipologia == null) {
                tipologia = ""; //La tipologia può essere nulla;
            }
            this._causale = causale;
            this._importo = importo;
            this._tipologia = tipologia;
            this._quantita = quantita;
        }
        #endregion

        #region Funzioni pubbliche
        /// <summary>
        /// Calcola e restituisce l'effettivo valore della voce effettuando <c><see cref="Quantita"/> * <see cref="Importo"/></c>
        /// </summary>
        /// <returns>Il valore totale della voce</returns>
        public virtual decimal ValoreTotale() {
            return this._quantita * this._importo;
        }

        public override string ToString() {
            return String.Format("{0}\t{1}\t{2}\t{3}", this._causale, this._tipologia, this._quantita, this._importo);
        }

        public virtual int CompareTo(Voce other) {
            return this._importo.CompareTo(other.Importo);
        }

        public override bool Equals(object obj)
        {
            var voce = obj as Voce;
            return voce != null &&
                   Causale == voce.Causale &&
                   Importo == voce.Importo &&
                   Tipologia == voce.Tipologia &&
                   Quantita == voce.Quantita;
        }

        public override int GetHashCode()
        {
            var hashCode = 87959449;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Causale);
            hashCode = hashCode * -1521134295 + Importo.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tipologia);
            hashCode = hashCode * -1521134295 + Quantita.GetHashCode();
            return hashCode;
        }

        #endregion
    }
}
