using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private Dictionary<string, Tuple<Cliente, PannelloCliente>> _clienti = new Dictionary<string, Tuple<Cliente, PannelloCliente>>();

        private List<Cliente> _clientiSelezionati = new List<Cliente>();

        #region "Costruttori"
        protected FormClienti()
        {
            InitializeComponent();
            this.txtSearchBar.KeyDown += (sender, e) => { if (e.KeyCode == System.Windows.Forms.Keys.Enter) RicercaTraClienti(); };
        }

        public FormClienti(ControllerClienti controller): this()
        {
            this._visualizzatoreCliente = new VisualizzatoreCliente(controller.CollezioneClienti);
            this._controller = controller;

            foreach (Cliente c in _controller.CollezioneClienti)
            {
                c.OnModifica += this.AggiornaDizionarioPerModificaCliente;
                _clienti.Add(c.IDCliente, new Tuple<Cliente, PannelloCliente>(c, null));
            }

            _controller.RimossoCliente += this.RimossoCliente;
        }
        #endregion


        #region "Carica clienti"
        /// <summary>
        /// Funzione che visualizza nella form una pagina di clienti
        /// </summary>
        private void CaricaPaginaClienti()
        {
            for (int i = 0; i < NUMERO_CLIENTI_PER_PAGINA; i++)
            {
                CaricaClienteSullaForm();
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
            this._clienti[clienteDaCaricare.IDCliente] = new Tuple<Cliente, PannelloCliente>(clienteDaCaricare, pannelloCliente);
        }

        private void RimossoCliente(object sender, ArgsCliente e)
        {
            if (e.Cliente == null)
                return;

            PannelloCliente pannelloDaRimuovere = this._clienti[e.Cliente.IDCliente].Item2;
            this._clienti.Remove(e.Cliente.IDCliente);
            this._clientiSelezionati.Remove(e.Cliente);
            if (pannelloDaRimuovere != null)
            {
                this.flowClienti.Controls.Remove(pannelloDaRimuovere);
                CaricaClienteSullaForm();
            }
        }

        private void AggiornaDizionarioPerModificaCliente(object sender, ArgsModifica<Cliente> e)
        {
            if (e.Nuovo.GetHashCode() != e.Vecchio.GetHashCode())
            {
                PannelloCliente pannello = this._clienti[e.Vecchio.IDCliente].Item2;
                this._clienti.Remove(e.Vecchio.IDCliente);
                this._clienti.Add(e.Nuovo.IDCliente, new Tuple<Cliente, PannelloCliente>(e.Nuovo, pannello));
            }
        }

        #endregion

        /// <summary>
        /// Funzione che effettua il filtraggio dei clienti
        /// </summary>
        private void RicercaTraClienti()
        {
            // TODO gestire la ricerca dei clienti qui
            MessageBox.Show("Ricerca");
        }

        #region "Gestione eventi pannello cliente"
        private void AbilitaDelete(object sender, ArgsPannelloCliente e)
        {
            if (e == null)
                return;

            if (e.PannelloCliente.Selected)
            {
                _clientiSelezionati.Add(e.Cliente);
                lblElimina.Enabled = true;
            }
            else
            {
                _clientiSelezionati.Remove(e.Cliente);
                if (_clientiSelezionati.Count == 0)
                    lblElimina.Enabled = false;
            }
        }
        #endregion

        #region "Gestione eventi form"
        private void FormClienti_Shown(object sender, EventArgs e)
        {
            this.SuspendLayout();
            // Mostro solo il numero di clienti impostato
            for (int i = 0; i < NUMERO_PAGINE_CARICATE_INIZIALMENTE; i++)
            {
                CaricaPaginaClienti();
            }
            this.ResumeLayout();
        }

        private void BtnCaricaAltri_Click(object sender, EventArgs e)
        {
            CaricaPaginaClienti();
        }

        private void LblIconSearchBar_Click(object sender, EventArgs e)
        {
            RicercaTraClienti();
        }

        private void LblElimina_Click(object sender, EventArgs e)
        {
            if (FormConfim.Show("Eliminare clienti?", "Confermi l'eliminazione dei clienti?") == DialogResult.OK)
            {
                List<Cliente> clientiDaEliminare = new List<Cliente>(_clientiSelezionati);
                foreach (Cliente c in clientiDaEliminare)
                {
                    this._controller.RimuoviCliente(c);
                }
            }
            MessageBox.Show("Eliminati");
            lblElimina.Enabled = false;
        }

        private void LblFilter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Filtra");
        }

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            OverlayCliente overlayCliente = new OverlayCliente(_controller, this.panelForm);
            overlayCliente.OverlayChiuso += this.ChiusoOverlayNuovoCliente;
            overlayCliente.Open();
        }

        private void ChiusoOverlayNuovoCliente(object sender, EventArgs e)
        {
            if (! (sender is OverlayCliente))
                return;
            OverlayCliente overlay = (OverlayCliente)sender;
            if (overlay.Cliente != null)
                this._clienti.Add(overlay.Cliente.IDCliente, new Tuple<Cliente, PannelloCliente>(overlay.Cliente, null));
        }
        #endregion
    }

}
