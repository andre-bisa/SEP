using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class Appuntamento : IObservable<Appuntamento>
    {
        public event EventHandler<ArgsModifica<Appuntamento>> OnModifica;
        private Persona _conChi;
        private string _oggetto;
        private string _luogo;
        private DateTime _dataOra;

        #region Costruttore
        /// <summary>
        /// Costruttore di Appuntamento
        /// </summary>
        /// <param name="luogo">Luogo dove si tiene l'appuntamento</param>
        /// <param name="conChi">Con chi viene tenuto l'appuntamento</param>
        /// <param name="oggetto">Il motivo dell'appuntamento o una nota semplificativa</param>
        /// <param name="dataOra">Data e ora dell'appuntamento</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Appuntamento(string luogo, Persona conChi, string oggetto, DateTime dataOra)
        {
            if (conChi == null || oggetto == null || dataOra == null || luogo == null)
            {
                throw new ArgumentNullException();
            }

            _conChi = conChi;
            _oggetto = oggetto;
            _dataOra = dataOra;
            _luogo = luogo;
        }
        #endregion

        #region Getters and Setters
        public string Oggetto
        {
            get { return _oggetto; }
            set { this._oggetto = value; }
        }

        public Persona ConChi
        {
            get { return _conChi; }
            set { this._conChi = value; }
        }

        public string Luogo
        {
            get { return _luogo; }
            set { this._luogo = value; }
        }

        public DateTime DataOra
        {
            get { return _dataOra; }
            set { this._dataOra = value; }
        }
        #endregion

        public override string ToString()
        {
            return String.Format("Data e ora: {0} \nLuogo: {1} \nCon chi: {2} \nOggetto: {3}", DataOra.ToString(), Luogo, ConChi.getDenominazione(), Oggetto);
        }
    }
}
