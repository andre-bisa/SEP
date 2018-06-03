using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerCalendario {

        private Calendario _calendario;

        public Calendario Calendario
        {
            get { return this._calendario; }
        }

        /// <summary>
        /// Costruttore di ControllerCalendario
        /// </summary>
        public ControllerCalendario()
        {
            this._calendario = Calendario.GetInstance();
        }

        /// <summary>
        /// Ritorna gli appuntamenti rientranti in un range di date specificato
        /// </summary>
        /// <param name="da">Data di partenza</param>
        /// <param name="a">Data di arrivo</param>
        /// <returns>Array di Appuntamenti</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public List<Appuntamento> GetAppuntamentiDaA(DateTime da, DateTime a) {

            if (da == null || a == null)
            {
                throw new ArgumentNullException();
            }
            //Se la data di partenza viene dopo quella d'arrivo
            if (da > a)
            {
                throw new ArgumentException();
            }

            return this._calendario.AppuntamentiDaA(da, a);
        }


        public Calendario GetAppuntamenti() {
            return this._calendario;
        }

        /// <summary>
        /// Aggiunge un certo appuntamento
        /// </summary>
        /// <param name="appuntamento"></param>
        public void AggiungiAppuntamento(Appuntamento appuntamento)
        {
            if(appuntamento == null)
            {
                throw new ArgumentNullException();
            }

            this._calendario.Add(appuntamento);
        }

        /// <summary>
        /// Rimuove un certo appuntamento
        /// </summary>
        /// <param name="appuntamento"></param>
        public void RimuoviAppuntamento(Appuntamento appuntamento)
        {
            if (appuntamento == null)
            {
                throw new ArgumentNullException();
            }

            this._calendario.Remove(appuntamento);
        }
    }
}
