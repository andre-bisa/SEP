using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Model {
    public class CollezioneAppuntamenti: IEnumerable<Appuntamento>, ICollection<Appuntamento> {
        public event EventHandler<ArgsAppuntamento> OnAggiunta;
        public event EventHandler<ArgsAppuntamento> OnRimozione;
        public event EventHandler<ArgsModifica<Appuntamento>> OnModifica;

        private volatile HashSet<Appuntamento> _appuntamenti = new HashSet<Appuntamento>();

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(EnumTipoPersistenza.NONE);

        #region Singleton
        private static CollezioneAppuntamenti _listaAppuntamenti = null;
        /// <summary>
        /// Funzioen che dà un'istanza della <see cref="CollezioneFatture"/>
        /// </summary>
        /// <returns>La collezione riempita con tutti i clienti</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public static CollezioneAppuntamenti GetInstance() {
            if(_listaAppuntamenti == null)
                _listaAppuntamenti = new CollezioneAppuntamenti();
            return _listaAppuntamenti;
        }
        #endregion

        protected CollezioneAppuntamenti() {
            try {
                foreach(Appuntamento f in _persistenza.GetAppuntamentoDAO().LeggiTuttiAppuntamenti()) {
                    _appuntamenti.Add(f);
                    f.OnModifica += (o, e) => {
                        this.OnModifica?.Invoke(o, e);
                    };
                }
            } catch(Exception) { throw new ExceptionPersistenza(); }

        }

        public int Count {
            get {
                return ((ICollection<Appuntamento>)_appuntamenti).Count;
            }
        }

        public bool IsReadOnly {
            get {
                return ((ICollection<Appuntamento>)_appuntamenti).IsReadOnly;
            }
        }

        /// <summary>
        /// Aggiunge un <see cref="Appuntamento"/> alla collezione
        /// </summary>
        /// <param name="item">Fattura da aggiungere alla collezione</param>
        /// <exception cref="ArgumentNullException">Se il <see cref="Fattura"/> è nullo</exception>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public void Add(Appuntamento item) {
            if(item == null)
                throw new ArgumentNullException("Errore. La fattura è nulla");

            if(!this._appuntamenti.Contains(item)) {
                if(_persistenza.GetAppuntamentoDAO().Crea(item)) {
                    ((ICollection<Appuntamento>)_appuntamenti).Add(item);
                    item.OnModifica += (o, e) => {
                        this.OnModifica?.Invoke(o, e);
                    };
                    LanciaEvento(OnAggiunta, item);
                } else { // Se si sono verificati errori nella persistenza
                    throw new ExceptionPersistenza();
                }
            }
        }

        /// <summary>
        /// Funzione non supportata. Lancia SEMPRE eccezione
        /// </summary>
        /// <exception cref="InvalidOperationException">Viene lanciata SEMPRE!</exception>
        public void Clear() {
            throw new InvalidOperationException();
        }

        public bool Contains(Appuntamento item) {
            return ((ICollection<Appuntamento>)_appuntamenti).Contains(item);
        }

        public void CopyTo(Appuntamento[] array, int arrayIndex) {
            ((ICollection<Appuntamento>)_appuntamenti).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Appuntamento> GetEnumerator() {
            return ((IEnumerable<Appuntamento>)_appuntamenti).GetEnumerator();
        }

        /// <summary>
        /// Funzione che elimina un utente dalla collezione
        /// </summary>
        /// <param name="item">L'utente che si intende eliminare</param>
        /// <returns><c>true</c> o <c>false</c> a seconda se ci è riuscito oppure no</returns>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori nella persistenza</exception>
        public bool Remove(Appuntamento item) {
            bool rimosso = false;
            if(item != null) {
                if(_persistenza.GetAppuntamentoDAO().Elimina(item.ID)) {
                    rimosso = ((ICollection<Appuntamento>)_appuntamenti).Remove(item);
                    LanciaEvento(OnRimozione, item);
                } else { // Se ci sono errori nella persistenza
                    throw new ExceptionPersistenza();
                }
            }
            return rimosso;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<Appuntamento>)_appuntamenti).GetEnumerator();
        }

        private void LanciaEvento(EventHandler<ArgsAppuntamento> evento, Appuntamento fattura) {
            if(evento != null) {
                ArgsAppuntamento args = new ArgsAppuntamento(fattura);
                evento(this, args);
            }
        }

        public Appuntamento[] DaA(DateTime da, DateTime a) {
            return (from appuntamento in this._appuntamenti.AsParallel()
                    where appuntamento.DataOra > da && appuntamento.DataOra < a
                    select appuntamento).ToArray();
        }

        public Appuntamento this[string id] {
            get {
                foreach(Appuntamento f in this._appuntamenti) {
                    if(f.ID == id)
                        return f;
                }
                return null;
            }
        }
    }
}