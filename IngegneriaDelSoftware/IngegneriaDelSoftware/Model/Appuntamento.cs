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
        private DatiAppuntamento _datiAppuntamento;

        #region Costruttore
        /// <summary>
        /// Costruttore di Appuntamento
        /// </summary>
        /// <param name="datiAppuntamento"></param>
        public Appuntamento(DatiAppuntamento datiAppuntamento)
        {
            _datiAppuntamento = datiAppuntamento;
        }
        #endregion

        #region Properties
        public string Oggetto
        {
            get { return _datiAppuntamento.Oggetto; }
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
        #endregion

        #region ToString()
        public override string ToString()
        {
            return String.Format("Data e ora: {0} \nLuogo: {1} \nCon chi: {2} \nOggetto: {3}", DataOra.ToString(), Luogo, ConChi.getDenominazione(), Oggetto);
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            var appuntamento = obj as Appuntamento;
            return appuntamento != null &&
                   Oggetto == appuntamento.Oggetto &&
                   Luogo == appuntamento.Luogo &&
                   DataOra == appuntamento.DataOra;
        }

        public override int GetHashCode()
        {
            var hashCode = -1334492624;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Oggetto);
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

    }

    #region Struct interna
    public struct DatiAppuntamento
    {
        public Persona ConChi { get; private set; }
        public string Oggetto { get; private set; }
        public string Luogo { get; private set; }
        public DateTime DataOra { get; private set; }

        #region Costruttore
        /// <summary>
        /// Costruttore dei DatiAppuntamento
        /// </summary>
        /// <param name="luogo">Luogo dove si tiene l'appuntamento</param>
        /// <param name="conChi">Con chi viene tenuto l'appuntamento</param>
        /// <param name="oggetto">Il motivo dell'appuntamento o una nota semplificativa</param>
        /// <param name="dataOra">Data e ora dell'appuntamento</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DatiAppuntamento(Persona conChi, string oggetto, string luogo, DateTime dataOra)
        {
            if (conChi == null || oggetto == null || dataOra == null || luogo == null)
            {
                throw new ArgumentNullException();
            }

            ConChi = conChi;
            Oggetto = oggetto;
            DataOra = dataOra;
            Luogo = luogo;
        }
        #endregion
    }
    #endregion
}
