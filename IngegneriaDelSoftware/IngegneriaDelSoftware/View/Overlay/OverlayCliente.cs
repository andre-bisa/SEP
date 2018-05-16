using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.View.Overlay;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.View.Controlli;

namespace IngegneriaDelSoftware.View.Overlay
{
    public partial class OverlayCliente : Overlay
    {
        /// <summary>
        /// Cliente dell'overlay
        /// </summary>
        public Cliente Cliente { get; private set; }

        #region "Costruttori"
        /// <summary>
        /// Costruttore da usare per la creazione di un overlay vuoto. Utile per l'inserimento di un cliente.
        /// </summary>
        /// <param name="panelContainer">Pannello che conterrà l'overlay</param>
        public OverlayCliente (Panel panelContainer) : base(panelContainer)
        {
            InitializeComponent();
            base.AddPanel(this.panel1);
            this.Titolo = "Cliente";
        }

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="cliente">Cliente a cui si riferisce l'overlay</param>
        /// <param name="panelContainer">Pannello che conterrà l'overlay</param>
        public OverlayCliente(Cliente cliente, Panel panelContainer) : this(panelContainer)
        {
            Cliente = cliente;
            CaricaClienteSuForm();
        }
        #endregion

        #region "Gestione eventi controlli"
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

        private void BottoneSalva(object sender, EventArgs e)
        {
            Persona persona;
            EnumTipoCliente tipoCliente = EnumTipoCliente.Attivo;

            if (radioFisica.Checked)
            {
                persona = new PersonaFisica(txtCodiceFiscale.Text, txtIndirizzo.Text, txtNome.Text, txtCognome.Text, txtPartitaIVA.Text);
            }
            else // Giuridica
            {
                persona = new PersonaGiuridica(txtCodiceFiscale.Text, txtIndirizzo.Text, txtDenominazione.Text, txtIndirizzo.Text, txtPartitaIVA.Text);
            }

            if (checkEx.Checked)
                tipoCliente = EnumTipoCliente.Ex;
            else if (checkPotenziale.Checked)
                tipoCliente = EnumTipoCliente.Potenziale;

            if (Cliente != null)
            {
                Cliente.IDCliente = txtCodice.Text;
                Cliente.Persona = persona;
                Cliente.CambiaTipoCliente(tipoCliente);
            }
            else
            {
                Cliente = new Cliente(persona, txtCodice.Text, tipoCliente);
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Funzioni private"
        private void CaricaClienteSuForm()
        {
            txtCodice.Text = Cliente.IDCliente;
            txtCodiceFiscale.Text = Cliente.Persona.CodiceFiscale;
            txtIndirizzo.Text = Cliente.Persona.Indirizzo;
            if (Cliente.Persona.TipoPersona == EnumTipoPersona.Fisica)
            {
                PersonaFisica personaFisica = (PersonaFisica) Cliente.Persona;
                txtNome.Text = personaFisica.Nome;
                txtCognome.Text = personaFisica.Cognome;
                txtPartitaIVA.Text = personaFisica.PartitaIVA;

                radioFisica.Checked = true;
            }
            else
            {
                PersonaGiuridica personaGiuridica = (PersonaGiuridica) Cliente.Persona;
                txtDenominazione.Text = personaGiuridica.RagioneSociale;
                txtPartitaIVA.Text = personaGiuridica.PartitaIVA;

                radioGiuridica.Checked = true;
            }
            if (Cliente.TipoCliente == EnumTipoCliente.Ex)
                checkEx.Checked = true;
            else if (Cliente.TipoCliente == EnumTipoCliente.Potenziale)
                checkEx.Checked = true;
        }
        #endregion

    }
}
