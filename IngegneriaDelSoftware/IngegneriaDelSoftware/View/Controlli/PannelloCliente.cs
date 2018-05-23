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
using IngegneriaDelSoftware.Controller;

namespace IngegneriaDelSoftware.View.Controlli
{
    public partial class PannelloCliente : UserControl
    {
        public event EventHandler<ArgsPannelloCliente> DoppioClickCliente;
        public event EventHandler<ArgsPannelloCliente> ModificataSelezione;

        #region Campi privati
        private Panel _panelContainer;
        private ControllerClienti _controller;

        private Cliente _cliente;
        private bool _selected = false;
        #endregion

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
        /// Costruttore
        /// </summary>
        /// <param name="controller">Controller che verrà usato per modifiche/inserimenti/eliminazioni dei clienti</param>
        /// <param name="cliente">Cliente da visualizzare</param>
        /// <param name="panelContainer">Pannello che conterrà l'overlay a seguito della pressione del pulsante di espansione</param>
        /// <exception cref="ArgumentNullException">Se vengono passati dei null</exception>
        public PannelloCliente(ControllerClienti controller, Cliente cliente, Panel panelContainer) : this()
        {
            #region Controlli
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            #endregion

            Cliente = cliente;
            _panelContainer = panelContainer;
            _controller = controller;

            DoppioClickCliente += new EventHandler<ArgsPannelloCliente>(this.ApriOverlayCliente);
            Cliente.OnModifica += this.ClienteModificato;
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
            CaricaClienteSuForm();
        }

        private void CaricaClienteSuForm()
        {
            lblIndirizzo.Text = Cliente.Persona.Indirizzo;
            lblDenominazione.Text = Cliente.Persona.getDenominazione();
            lblEmail.Text = Cliente.Persona.Email.ToString();
            lblTelefoni.Text = Cliente.Persona.Telefoni.ToString();
            lblReferenti.Text = Cliente.Referenti.ToString();

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
                new OverlayCliente(_controller, _panelContainer, Cliente).Open();
        }
        #endregion
    }

}
