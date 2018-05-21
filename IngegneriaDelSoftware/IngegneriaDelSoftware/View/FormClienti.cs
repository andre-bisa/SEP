using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MaterialSkin.Controls;
using IngegneriaDelSoftware.View.Overlay;
using IngegneriaDelSoftware.View.Controlli;
using System.Windows.Forms;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Controller;

namespace IngegneriaDelSoftware.View
{
    public partial class FormClienti : MaterialForm
    {
        private const int NUMERO_CLIENTI_PER_PAGINA = 12;
        private const int NUMERO_PAGINE_CARICATE_INIZIALMENTE = 2;

        private ControllerClienti _controller;
        private VisualizzatoreCliente _visualizzatoreCliente;

        private List<TriplaCliente> _clientiCaricati = new List<TriplaCliente>();

        private int quantiClientiCaricare = NUMERO_CLIENTI_PER_PAGINA * NUMERO_PAGINE_CARICATE_INIZIALMENTE;

        #region "Costruttori"
        protected FormClienti()
        {
            InitializeComponent();
            this.txtSearchBar.KeyDown += (sender, e) => 
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    RicercaTraClienti();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
        }

        public FormClienti(ControllerClienti controller): this()
        {
            this._visualizzatoreCliente = new VisualizzatoreCliente(controller.CollezioneClienti);
            this._controller = controller;

            _controller.CollezioneClienti.OnRimozione += this.RimossoCliente;
        }
        #endregion

        #region "Carica clienti"
        private void CaricaClientiMancanti()
        {
            bool caricatoQualcosa = false;
            for (int i = this._clientiCaricati.Count; i < this.quantiClientiCaricare; i++)
            {
                CaricaClienteSullaForm();
                caricatoQualcosa = true;
            }
            if (caricatoQualcosa)
            {

            }
        }

        /// <summary>
        /// Funzione che aggiunge sulla form un cliente
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void CaricaClienteSullaForm()
        {
            Cliente clienteDaCaricare = _visualizzatoreCliente.ProssimoCliente();

            if (clienteDaCaricare == null) // Sono già mostrati tutti i clienti
                return;

            PannelloCliente pannelloCliente = new PannelloCliente(_controller, clienteDaCaricare, this.panelForm);
            pannelloCliente.Margin = new Padding(5, 3, 5, 3);
            pannelloCliente.ModificataSelezione += new EventHandler<ArgsPannelloCliente>(this.AbilitaDelete);
            this.flowClienti.Controls.Add(pannelloCliente);
            this._clientiCaricati.Add(new TriplaCliente(clienteDaCaricare, pannelloCliente, false));
        }

        private void RimossoCliente(object sender, ArgsCliente e)
        {
            if (e.Cliente == null)
                return;

            PannelloCliente pannelloDaRimuovere = this._clientiCaricati.Find(c => e.Cliente.Equals(c.Cliente)).PannelloCliente;
            if (pannelloDaRimuovere != null)
            {
                this.flowClienti.Controls.Remove(pannelloDaRimuovere);
                CaricaClientiMancanti();
            }
        }

        #endregion

        /// <summary>
        /// Funzione che effettua il filtraggio dei clienti
        /// </summary>
        private void RicercaTraClienti()
        {
            Predicate<Cliente> filtro;

            if (txtSearchBar.Text.Trim() == "")
            {
                filtro = new Predicate<Cliente>(c => true);
            }
            else
            {
                filtro = new Predicate<Cliente>(c => c.Persona.getDenominazione().Contains(txtSearchBar.Text.Trim()));
            }

            this._visualizzatoreCliente.ImpostaFiltro(filtro);

            var queryTriplaClientiDaRimuovere =
                (from tripla in this._clientiCaricati
                 where !filtro.Invoke(tripla.Cliente)    // dove il filtro non è applicabile
                 select tripla
                 );

            foreach (TriplaCliente tripla in new List<TriplaCliente>(queryTriplaClientiDaRimuovere))
            {
                this.flowClienti.Controls.Remove(tripla.PannelloCliente);
                this._clientiCaricati.Remove(tripla);
            }

            CaricaClientiMancanti();
        }

        #region "Gestione eventi pannello cliente"
        private void AbilitaDelete(object sender, ArgsPannelloCliente e)
        {
            if (e == null)
                return;
            TriplaCliente tripla = _clientiCaricati.Find(t => t.Cliente.Equals(e.Cliente));

            if (e.PannelloCliente.Selected)
            {
                tripla.Selezionato = true;
                lblElimina.Enabled = true;
            }
            else
            {
                tripla.Selezionato = false;
                if (_clientiCaricati.Sum(t => (t.Selezionato) ? 1 : 0 ) == 0)
                    lblElimina.Enabled = false;
            }
        }
        #endregion

        #region "Gestione eventi form"
        private void FormClienti_Shown(object sender, EventArgs e)
        {
            // Carica i clienti per arrivare al numero iniziale
            CaricaClientiMancanti();
        }

        private void BtnCaricaAltri_Click(object sender, EventArgs e)
        {
            this.quantiClientiCaricare += NUMERO_CLIENTI_PER_PAGINA;
            CaricaClientiMancanti();
        }

        private void LblIconSearchBar_Click(object sender, EventArgs e)
        {
            RicercaTraClienti();
        }

        private void LblElimina_Click(object sender, EventArgs e)
        {
            if (FormConfim.Show("Eliminare clienti?", "Confermi l'eliminazione dei clienti?") == DialogResult.OK)
            {
                foreach (Cliente c in this._clientiCaricati.FindAll(t => t.Selezionato).Select(t => t.Cliente))
                {
                    this._controller.RimuoviCliente(c);
                }
            }
            MessageBox.Show("Eliminati con successo");
            lblElimina.Enabled = false;
        }

        private void LblOrdina_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ordina");
        }

        private void MaterialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            OverlayCliente overlayCliente = new OverlayCliente(_controller, this.panelForm);
            overlayCliente.Open();
        }
        #endregion
    }

    class TriplaCliente
    {
        public Cliente Cliente { get; }
        public PannelloCliente PannelloCliente { get; set; }
        public bool Selezionato { get; set; }

        public TriplaCliente (Cliente cliente, PannelloCliente pannello, bool selezionato)
        {
            this.Cliente = cliente;
            this.PannelloCliente = pannello;
            this.Selezionato = selezionato;
        }

    }

}
