using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Model
{
    public class Appuntamento : IObservable<Appuntamento>
    {
        public event EventHandler<ArgsModifica<Appuntamento>> OnModifica;

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza);
        private DatiAppuntamento _datiAppuntamento;

        #region Costruttori
        /// <summary>
        /// Costruttore di Appuntamento con struct
        /// </summary>
        /// <param name="datiAppuntamento"></param>
        public Appuntamento(DatiAppuntamento datiAppuntamento)
        {
            _datiAppuntamento = datiAppuntamento;
        }

        /// <summary>
        /// Costruttore di Appuntamento
        /// </summary>
        /// <param name="conChi"></param>
        /// <param name="oggetto"></param>
        /// <param name="luogo"></param>
        /// <param name="dataOra"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Appuntamento(int idAppuntamento, Persona conChi, string note, string luogo, DateTime dataOra)
        {
            if (idAppuntamento < 0 || conChi == null || note == null || dataOra == null || luogo == null)
            {
                throw new ArgumentNullException();
            }

            this._datiAppuntamento = new DatiAppuntamento(idAppuntamento, conChi, note, luogo, dataOra);
        }
        #endregion

        #region Properties
        public string Note
        {
            get { return _datiAppuntamento.Note; }
        }

        public Persona ConChi
        {
            get { return _datiAppuntamento.ConChi; }
        }

        public string Luogo
        {
            get { return _datiAppuntamento.Luogo; }
        }

        public DateTime DataOra
        {
            get { return _datiAppuntamento.DataOra; }
        }
        public int IDAppuntamento
        {
            get { return _datiAppuntamento.IDAppuntamento; }
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5}", IDAppuntamento, DataOra.ToShortDateString(), DataOra.ToShortTimeString(), Luogo, Note, ConChi.getDenominazione());
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            var appuntamento = obj as Appuntamento;
            return appuntamento != null &&
                   IDAppuntamento == appuntamento.IDAppuntamento;
        }

        public override int GetHashCode()
        {
            var hashCode = -1334492624;
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(IDAppuntamento);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Note);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Luogo);
            hashCode = hashCode * -1521134295 + DataOra.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Appuntamento appuntamento1, Appuntamento appuntamento2)
        {
            return EqualityComparer<Appuntamento>.Default.Equals(appuntamento1, appuntamento2);
        }

        public static bool operator !=(Appuntamento appuntamento1, Appuntamento appuntamento2)
        {
            return !(appuntamento1 == appuntamento2);
        }

        #endregion

        protected void LanciaEvento(Appuntamento vecchioAppuntamento)
        {
            if (OnModifica != null)
            {
                ArgsModifica<Appuntamento> args = new ArgsModifica<Appuntamento>(vecchioAppuntamento, this);
                OnModifica(this, args);
            }

        }

        public void cambiaDatiAppuntamento(DatiAppuntamento nuoviDati)
        {
            if (this._datiAppuntamento != nuoviDati)
            {
                Appuntamento vecchioAppuntamento = this.Clone();
                this._datiAppuntamento = nuoviDati;

                if (!_persistenza.GetAppuntamentoDAO().Aggiorna(vecchioAppuntamento, this))
                { // se ci sono errori con la persistenza
                    this._datiAppuntamento = vecchioAppuntamento._datiAppuntamento; // recupero i dati utente che avevo prima
                    throw new ExceptionPersistenza();
                }
                LanciaEvento(vecchioAppuntamento);
            }
        }

        #region Clone()
        protected Appuntamento Clone()
        {
            return new Appuntamento(this._datiAppuntamento);
        }
        #endregion

    }

    #region Struct interna
    public struct DatiAppuntamento
    {
        public Persona ConChi { get; private set; }
        public string Note { get; private set; }
        public string Luogo { get; private set; }
        public DateTime DataOra { get; private set; }
        public int IDAppuntamento { get; private set; }

        #region Costruttore
        /// <summary>
        /// Costruttore dei DatiAppuntamento
        /// </summary>
        /// <param name="luogo">Luogo dove si tiene l'appuntamento</param>
        /// <param name="conChi">Con chi viene tenuto l'appuntamento</param>
        /// <param name="note">Il motivo dell'appuntamento o una nota semplificativa</param>
        /// <param name="dataOra">Data e ora dell'appuntamento</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DatiAppuntamento(int idAppuntamento, Persona conChi, string note, string luogo, DateTime dataOra)
        {
            if (idAppuntamento < 0 || conChi == null || note == null || dataOra == null || luogo == null)
            {
                throw new ArgumentNullException();
            }

            IDAppuntamento = idAppuntamento;
            ConChi = conChi;
            Note = note;
            DataOra = dataOra;
            Luogo = luogo;
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            var datiAppuntamento = (DatiAppuntamento) obj;
            return IDAppuntamento == datiAppuntamento.IDAppuntamento &&
                   ConChi == datiAppuntamento.ConChi && Note == datiAppuntamento.Note
                   && datiAppuntamento.Luogo == Luogo && datiAppuntamento.DataOra == DataOra;

        }

        public override int GetHashCode()
        {
            var hashCode = -1334492624;
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(IDAppuntamento);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Note);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Luogo);
            hashCode = hashCode * -1521134295 + DataOra.GetHashCode();
            return hashCode;
        }
        
        public static bool operator == (DatiAppuntamento datiAppuntamento1, DatiAppuntamento datiAppuntamento2)
        {
            return EqualityComparer<DatiAppuntamento>.Default.Equals(datiAppuntamento1, datiAppuntamento2);
        }

        public static bool operator != (DatiAppuntamento datiAppuntamento1, DatiAppuntamento datiAppuntamento2)
        {
            return !(datiAppuntamento1 == datiAppuntamento2);
        }
        #endregion
    }
    #endregion
}
