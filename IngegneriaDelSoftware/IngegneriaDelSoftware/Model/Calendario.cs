using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class Calendario
    {
        private List<Appuntamento> _appuntamenti;

        /// <summary>
        /// Costruttore di Calendario
        /// </summary>
        public Calendario()
        {
            _appuntamenti = new List<Appuntamento>();
        }

        /// <summary>
        /// Permette di aggiungere un appuntamento al calendario
        /// </summary>
        /// <param name="appuntamento"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AggiungiAppuntamento(Appuntamento appuntamento)
        {
            if (appuntamento == null)
            {
                throw new ArgumentNullException();
            }

            _appuntamenti.Add(appuntamento);
        }

        /// <summary>
        /// Permette di rimuovere un appuntamento specifico
        /// </summary>
        /// <param name="appuntamento"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RimuoviAppuntamento(Appuntamento appuntamento)
        {
            if (appuntamento == null)
            {
                throw new ArgumentNullException();
            }

            _appuntamenti.Remove(appuntamento);
        }

        /// <summary>
        /// Ritorna la lista di appuntamenti rientranti in un range di date
        /// </summary>
        /// <param name="da"></param>
        /// <param name="a"></param>
        /// <returns>Lista di Appuntamenti</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public List<Appuntamento> AppuntamentiDaA(DateTime da, DateTime a)
        {
            if (da == null || a == null)
            {
                throw new ArgumentNullException();
            }
            //Se la data di partenza viene dopo quella d'arrivo
            if (da.CompareTo(a) > 0)
            {
                throw new ArgumentException();
            }

            List<Appuntamento> risultato = new List<Appuntamento>();

            foreach (Appuntamento appuntamento in this._appuntamenti){
                //Se l'appuntamento rientra nel range
                if(appuntamento.DataOra.CompareTo(da) >= 0 && appuntamento.DataOra.CompareTo(a) <= 0)
                {
                    risultato.Add(appuntamento);
                }
            }

            return risultato;
        }

        /// <summary>
        /// Ritorna la lista di appuntamenti correnti
        /// </summary>
        public List<Appuntamento> AppuntamentiCalendario
        {
            get { return this._appuntamenti; }
        }

        public override string ToString()
        {
            return String.Join("\n", this._appuntamenti);
        }
    }
}
