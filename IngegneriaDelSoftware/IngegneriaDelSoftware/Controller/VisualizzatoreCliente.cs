using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Controller
{
    public class VisualizzatoreCliente
    {
        // Il bool serve per sapere se il cliente è stato mostrato oppure no
        private List<CoppiaClienteVisualizzato> _lista = new List<CoppiaClienteVisualizzato>();

        private Predicate<CoppiaClienteVisualizzato> _filtro;

        public VisualizzatoreCliente(CollezioneClienti collezioneClienti)
        {
            _filtro = new Predicate<CoppiaClienteVisualizzato>(c => true); // di base accetta tutto

            collezioneClienti.OnAggiunta += this.NuovoCliente;
            collezioneClienti.OnRimozione += this.RimossoCliente;

            foreach (Cliente c in collezioneClienti)
            {
                _lista.Add(new CoppiaClienteVisualizzato(c, false));
            }
        }

        #region Gestione eventi
        private void RimossoCliente(object sender, ArgsCliente e)
        {
            this._lista.Remove(this._lista.Find(c => c.Cliente.Equals(e.Cliente)));
        }

        private void NuovoCliente(object sender, ArgsCliente e)
        {
            this._lista.Add(new CoppiaClienteVisualizzato(e.Cliente, false));
        }
        #endregion

        #region Metodi pubblici
        /// <summary>
        /// Imposta un filtro che cerca su tutti i campi di <see cref="Cliente"/>
        /// </summary>
        /// <param name="stringaDaCercare">Stringa con il valore inserito</param>
        public void FiltraSuTuttiICampi(string stringaDaCercare)
        {
            _filtro = new Predicate<CoppiaClienteVisualizzato>(c => c.Cliente.IDCliente.Contains(stringaDaCercare)
            || c.Cliente.Persona.getDenominazione().Contains(stringaDaCercare) || c.Cliente.Referenti.Any(r => r.Nome.Contains(stringaDaCercare)));
        }

        /// <summary>
        /// Imposta il nuovo filtro per i clienti.
        /// N.B. NON verranno riproposti i clienti già dati con <see cref="ProssimoCliente"/>, per vedere tutti i clienti utilizzare <see cref="Reset"/>
        /// </summary>
        /// <param name="filtro">Nuovo filtro che verrà applicato ai clienti</param>
        /// <exception cref="ArgumentNullException">Se passato un filtro nullo</exception>
        public void ImpostaFiltro(Predicate<Cliente> filtro)
        {
            if (filtro == null)
                throw new ArgumentNullException("Errore. Il filtro è nullo.");

            this._filtro = new Predicate<CoppiaClienteVisualizzato>(c => filtro.Invoke(c.Cliente));

            var queryClientiCheNonDevonoPiuEssereVisualizzati =
                (from coppia in this._lista
                 where !filtro.Invoke(coppia.Cliente)   // dove il filtro non è applicabile
                 select coppia
                 );

            foreach (CoppiaClienteVisualizzato coppia in new List<CoppiaClienteVisualizzato>(queryClientiCheNonDevonoPiuEssereVisualizzati))
            {
                coppia.Visualizzato = false;
            }
        }

        /// <summary>
        /// Restituisce il prossimo cliente da visualizzare
        /// </summary>
        /// <returns></returns>
        public Cliente ProssimoCliente()
        {
            foreach (CoppiaClienteVisualizzato cliente in this._lista.FindAll(this._filtro))
            {
                if (! cliente.Visualizzato)
                {
                    cliente.Visualizzato = true;
                    return cliente.Cliente;
                }
            }
            return null;
        }

        /// <summary>
        /// Dopo la chiamata a questa funzione verranno riproposti tutti i clienti
        /// </summary>
        public void Reset()
        {
            foreach (CoppiaClienteVisualizzato cliente in this._lista)
            {
                cliente.Visualizzato = false;
            }
        }
        

    }

    class CoppiaClienteVisualizzato
    {
        public Cliente Cliente { get; }
        public bool Visualizzato { get; set; }

        public CoppiaClienteVisualizzato(Cliente cliente, bool visualizzato)
        {
            this.Cliente = cliente;
            this.Visualizzato = visualizzato;
        }
    }

}
