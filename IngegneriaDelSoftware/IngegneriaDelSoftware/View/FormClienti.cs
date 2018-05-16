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

        private MockControllerClienti _controller = new MockControllerClienti();

        private List<Cliente> _clienti;
        private int clienteDaCaricare = 0;

        private List<object> _clientiSelezionati = new List<object>();

        #region "Costruttori"
        public FormClienti()
        {
            InitializeComponent();
            this.txtSearchBar.KeyDown += (sender, e) => { if (e.KeyCode == System.Windows.Forms.Keys.Enter) RicercaTraClienti(); };

            _clienti = _controller.ListaClienti;
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
            if ( clienteDaCaricare >= _clienti.Count || _clienti[clienteDaCaricare] == null)
                return;

            PannelloCliente pannelloCliente = new PannelloCliente(_clienti[clienteDaCaricare], this.panelForm);
            pannelloCliente.Margin = new Padding(5, 3, 5, 3);
            pannelloCliente.ModificataSelezione += new EventHandler<ArgsPannelloCliente>(this.AbilitaDelete);
            this.flowClienti.Controls.Add(pannelloCliente);
            clienteDaCaricare++;
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
            MessageBox.Show("Elimina");
        }

        private void LblFilter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Filtra");
        }

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            OverlayCliente overlayCliente = new OverlayCliente(this.panelForm);
            overlayCliente.OverlayChiuso += this.ChiusoOverlayNuovoCliente;
            overlayCliente.Open();
        }

        private void ChiusoOverlayNuovoCliente(object sender, EventArgs e)
        {
            if (! (sender is OverlayCliente))
                return;
            OverlayCliente overlay = (OverlayCliente)sender;
            this._controller.AggiungiCliente(overlay.Cliente);
        }
        #endregion
    }

}
