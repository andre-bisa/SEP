/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

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
        private ControllerClienti _controller = ControllerClienti.GetInstance();

        private Cliente _cliente;
        private bool _selected = false;
        private Impostazioni _impostazioni = Impostazioni.GetInstance();
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
                    this.BackColor = System.Drawing.Color.LightBlue;
                } else {
                    this.BackColor = _impostazioni.ColoreCliente(Cliente.TipoCliente);
                }
                LanciaEvento(ModificataSelezione);
            }
        }


        #region "Costruttori"
        private PannelloCliente()
        {
            InitializeComponent();

            this.MouseClick += this.MouseClickOnPanel;
            lblDenominazione.MouseClick += this.MouseClickOnPanel;
            lblEmail.MouseClick += this.MouseClickOnPanel;
            lblIndirizzo.MouseClick += this.MouseClickOnPanel;
            lblReferenti.MouseClick += this.MouseClickOnPanel;
            lblTelefoni.MouseClick += this.MouseClickOnPanel;

            this.MouseDoubleClick += this.MouseClickOnPanel;
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
        public PannelloCliente(Cliente cliente, Panel panelContainer) : this()
        {
            #region Controlli
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            #endregion

            Cliente = cliente;
            _panelContainer = panelContainer;

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

            this.BackColor = _impostazioni.ColoreCliente(Cliente.TipoCliente);
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
                new OverlayCliente(_panelContainer, Cliente).Open();
        }
        #endregion
    }

}
