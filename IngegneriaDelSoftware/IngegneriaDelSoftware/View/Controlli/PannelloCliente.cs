using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.View.Overlay;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.View.Controlli
{
    public partial class PannelloCliente : UserControl
    {
        public event EventHandler<ArgsPannelloCliente> DoppioClickCliente;
        public event EventHandler<ArgsPannelloCliente> ModificataSelezione;

        private Cliente _cliente;
        public Cliente Cliente {
            get
            {
                return this._cliente;
            }
            set
            {
                this._cliente = value;
                CaricaClienteSuForm();
            }
            }

        private bool _selected = false;
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if ( Selected )
                {
                    this.BackColor = System.Drawing.Color.LightCyan;
                } else {
                    this.BackColor = System.Drawing.SystemColors.Info;
                }
                LanciaEvento(ModificataSelezione);
            }
        }

        private Panel _panelContainer = null;

        #region "Costruttori"
        protected PannelloCliente()
        {
            InitializeComponent();

            lblDenominazione.MouseClick += this.MouseClickOnPanel;
            lblEmail.MouseClick += this.MouseClickOnPanel;
            lblIndirizzo.MouseClick += this.MouseClickOnPanel;
            lblReferenti.MouseClick += this.MouseClickOnPanel;
            lblTelefoni.MouseClick += this.MouseClickOnPanel;

            lblDenominazione.MouseDoubleClick += this.MouseClickOnPanel;
            lblEmail.MouseDoubleClick += this.MouseClickOnPanel;
            lblIndirizzo.MouseDoubleClick += this.MouseClickOnPanel;
            lblReferenti.MouseDoubleClick += this.MouseClickOnPanel;
            lblTelefoni.MouseDoubleClick += this.MouseClickOnPanel;
        }

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="cliente">Cliente che si intende visualizzare</param>
        public PannelloCliente(Cliente cliente) : this()
        {
            Cliente = cliente;
            Cliente.OnModifica += this.ClienteModificato;
        }

        public PannelloCliente(Cliente cliente, Panel panelContainer) : this(cliente)
        {
            _panelContainer = panelContainer;
            DoppioClickCliente += new EventHandler<ArgsPannelloCliente>(this.ApriOverlayCliente);
        }
        #endregion

        #region "Gestione eventi controlli"
        private void MouseClickOnPanel(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                DoubleClick_Panel();
                Click_Panel();      // Perchè lancia 2 eventi, uno per il click e l'altro per il doppio-click
            }
            else
            {
                Click_Panel();
            }
        }
        #endregion

        #region "Funzioni private"
        private void ClienteModificato(object sender, ArgsModifica<Cliente> e)
        {
            Cliente = e.Nuovo;
        }

        private void CaricaClienteSuForm()
        {
            lblIndirizzo.Text = Cliente.Persona.Indirizzo;
            if (Cliente.Persona.TipoPersona == EnumTipoPersona.Fisica)
            {
                PersonaFisica personaFisica = (PersonaFisica)Cliente.Persona;
                lblDenominazione.Text = personaFisica.Nome + " " + personaFisica.Cognome;
            }
            else
            {
                PersonaGiuridica personaGiuridica = (PersonaGiuridica)Cliente.Persona;
                lblDenominazione.Text = personaGiuridica.RagioneSociale;
            }

            lblReferenti.Text = "";
            foreach (Referente referente in Cliente.Referenti)
            {
                lblReferenti.Text += referente.Nome;
            }
        }

        /// <summary>
        /// Funzione di gestione quando si effettua il click sul panel
        /// </summary>
        private void Click_Panel()
        {
            Selected = !Selected;   // Nego la selezione
        }

        /// <summary>
        /// Funzione che lancia l'evento DoppioClickCliente
        /// </summary>
        private void DoubleClick_Panel()
        {
            LanciaEvento(DoppioClickCliente);
        }

        /// <summary>
        /// Funzione che permette di lanciare un evento
        /// </summary>
        /// <param name="evento">Evento da lanciare</param>
        private void LanciaEvento(EventHandler<ArgsPannelloCliente> evento)
        {
            if (evento != null)
            {
                ArgsPannelloCliente args = new ArgsPannelloCliente(Cliente, this);
                evento(this, args);
            }
        }

        private void ApriOverlayCliente(object sender, ArgsCliente e)
        {
            if (_panelContainer != null)
                new OverlayCliente(Cliente, _panelContainer).Open();
        }
        #endregion
    }

}
