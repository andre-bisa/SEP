using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller
{
    public abstract class Visualizzatore<T>
    {
        protected List<OggettoVisualizzato<T>> Lista { get; } = new List<OggettoVisualizzato<T>>();

        protected Predicate<OggettoVisualizzato<T>> Filtro { get; private set; }

        protected Visualizzatore()
        {
            Filtro = new Predicate<OggettoVisualizzato<T>>(c => true); // di base accetta tutto
        }

        /// <summary>
        /// Restituisce il numero di <see cref="T"/> che possono essere restituiti con il filtro applicato
        /// </summary>
        public int Count
        {
            get
            {
                return this.Lista.FindAll(this.Filtro).Count;
            }
        }

        #region Metodi pubblici
        /// <summary>
        /// Imposta un filtro che cerca su tutti i campi di <see cref="T"/>
        /// </summary>
        /// <param name="stringaDaCercare">Stringa con il valore inserito</param>
        public abstract void FiltraSuTuttiICampi(string stringaDaCercare);

        /// <summary>
        /// Imposta il nuovo filtro per i <see cref="T"/>.
        /// N.B. NON verranno riproposti i clienti già dati con <see cref="Prossimo"/>, per vedere tutti gli oggetti utilizzare <see cref="Reset"/>
        /// </summary>
        /// <param name="filtro">Nuovo filtro che verrà applicato agli oggetti</param>
        /// <exception cref="ArgumentNullException">Se passato un filtro nullo</exception>
        public void ImpostaFiltro(Predicate<T> filtro)
        {
            if (filtro == null)
                throw new ArgumentNullException("Errore. Il filtro è nullo.");

            this.Filtro = new Predicate<OggettoVisualizzato<T>>(c => filtro.Invoke(c.Oggetto));

            var queryNonDevonoPiuEssereVisualizzati =
                (from coppia in this.Lista
                 where !filtro.Invoke(coppia.Oggetto)   // dove il filtro non è applicabile
                 select coppia
                 );

            foreach (OggettoVisualizzato<T> coppia in new List<OggettoVisualizzato<T>>(queryNonDevonoPiuEssereVisualizzati))
            {
                coppia.Visualizzato = false;
            }
        }

        /// <summary>
        /// Restituisce il prossimo oggetto da visualizzare
        /// </summary>
        /// <returns></returns>
        public T Prossimo()
        {
            foreach (OggettoVisualizzato<T> oggetto in this.Lista.FindAll(this.Filtro))
            {
                if (!oggetto.Visualizzato)
                {
                    oggetto.Visualizzato = true;
                    return oggetto.Oggetto;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Dopo la chiamata a questa funzione verranno riproposti tutti gli oggetti
        /// </summary>
        public void Reset()
        {
            foreach (OggettoVisualizzato<T> oggetto in this.Lista)
            {
                oggetto.Visualizzato = false;
            }
        }
        #endregion
    }
}
