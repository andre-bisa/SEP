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
using IngegneriaDelSoftware.Graphics.Overlay;
using IngegneriaDelSoftware.Graphics.Controlli;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.Graphics
{
    public partial class FormClienti : MaterialForm
    {
        private const int NUMERO_CLIENTI_PER_PAGINA = 12;
        private const int NUMERO_PAGINE_CARICATE_INIZIALMENTE = 2;

        private List<object> _clienti = new List<object>();
        private int clienteDaCaricare = 0;

        private List<object> _clientiSelezionati = new List<object>();

        public FormClienti()
        {
            InitializeComponent();
            this.txtSearchBar.KeyDown += (sender, e) => { if (e.KeyCode == System.Windows.Forms.Keys.Enter) RicercaTraClienti(); };
            this.btnCaricaAltri.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CaricaListaClienti()
        {
            for (int i = 0; i < 100; i++)
                _clienti.Add(i);
        }

        /// <summary>
        /// 
        /// </summary>
        private void CaricaPaginaClienti()
        {
            for (int i = 0; i < NUMERO_CLIENTI_PER_PAGINA; i++)
            {
                CaricaClienteSullaForm();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void CaricaClienteSullaForm()
        {
            if ( clienteDaCaricare >= _clienti.Count || _clienti[clienteDaCaricare] == null)
                return;

            PannelloCliente pannelloCliente = new PannelloCliente(clienteDaCaricare);
            pannelloCliente.Margin = new Padding(5, 3, 5, 3);
            pannelloCliente.DoppioClickCliente += new EventHandler<ArgsCliente>(this.ApriOverlayCliente);
            pannelloCliente.ModificataSelezione += new EventHandler<ArgsCliente>(this.AbilitaDelete);
            this.flowClienti.Controls.Add(pannelloCliente);
            clienteDaCaricare++;
        }

        private void RicercaTraClienti()
        {
            // TODO gestire la ricerca dei clienti qui
            MessageBox.Show("Ricerca");
        }

        private void ApriOverlayCliente(object sender, ArgsCliente e)
        {
            OverlayCliente overlayCliente = new OverlayCliente(e.Cliente, this.panelForm);
            overlayCliente.Open();
        }

        private void AbilitaDelete(object sender, ArgsCliente e)
        {
            if (e == null || !(e.UserControl is PannelloCliente))
                return;

            PannelloCliente pannelloCliente = (PannelloCliente) e.UserControl;

            if (pannelloCliente.Selected)
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

        private void FormClienti_Shown(object sender, EventArgs e)
        {
            this.SuspendLayout();
            CaricaListaClienti();
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
            int cliente = 0;
            OverlayCliente overlayCliente = new OverlayCliente(cliente, this.panelForm);
            overlayCliente.Open();
            // TODO da gestire l'inserimento
        }
    }

}
