using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.Graphics.Overlay;

namespace IngegneriaDelSoftware.Graphics.Overlay
{
    public partial class OverlayCliente : Overlay
    {
        private int _cliente;
        /// <summary>
        /// Cliente dell'overlay
        /// </summary>
        public int Cliente
        {
            get => _cliente;
            private set => _cliente = value;
        }

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="cliente">Cliente a cui si riferisce l'overlay</param>
        /// <param name="panelContainer">Pannello che conterrà l'overlay</param>
        public OverlayCliente(int cliente, Panel panelContainer) : base(panelContainer)
        {
            InitializeComponent();
            base.AddPanel(this.panel1);
            this.Titolo = "Cliente";

            Cliente = cliente;
        }

        private void CambiaRadioPersona(object sender, EventArgs e)
        {
            if ( this.radioFisica.Checked ) // Fisica selezionato
            {
                lblDenominazione.Visible = false;
                txtDenominazione.Visible = false;

                lblNome.Visible = true;
                lblCognome.Visible = true;
                txtNome.Visible = true;
                txtCognome.Visible = true;
            } else if ( this.radioGiuridica.Checked ) // Giuridica selezionato
            {
                lblDenominazione.Visible = true;
                txtDenominazione.Visible = true;

                lblNome.Visible = false;
                lblCognome.Visible = false;
                txtNome.Visible = false;
                txtCognome.Visible = false;
            }
        }
    }
}
