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
using IngegneriaDelSoftware.View.Overlay;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Controller;

namespace IngegneriaDelSoftware.View.Controlli
{
    public partial class SchedaCliente : UserControl
    {
        /// <summary>
        /// Evento lanciato quando si fa click sulla freccia di apertura.
        /// </summary>
        public event EventHandler<ArgsSchedaCliente> AperturaCliente;
        /// <summary>
        /// Evento lanciato quando cambia la selezione della casella di controllo.
        /// </summary>
        public event EventHandler<ArgsSchedaCliente> ModificataSelezione;

        #region Campi privati
        private Panel _panelContainer;
        private ControllerClienti _controller = ControllerClienti.GetInstance();

        private Cliente _cliente;
        private bool _selected = false;
        private Impostazioni _impostazioni = Impostazioni.GetInstance();
        #endregion

        /// <summary>
        /// Il cliente cui la scheda fa riferimento.
        /// </summary>
        public Cliente Cliente
        {
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

        /// <summary>
        /// Dice se la scheda è selezionata.
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (Selected)
                {
                    this.BackColor = Color.LightBlue;
                    this.checkScheda.CheckState = CheckState.Checked;
                }
                else
                {
                    this.BackColor = _impostazioni.ColoreCliente(Cliente.TipoCliente);
                    this.checkScheda.CheckState = CheckState.Unchecked;
                }
                LanciaEvento(ModificataSelezione);
            }
        }

        #region "Costruttori"
        protected SchedaCliente()
        {
            InitializeComponent();
            this.checkScheda.CheckedChanged += this.CambiaSelezione;

            this.MouseClick += this.CambiaSelezione;
            lblDenominazione.MouseClick += this.CambiaSelezione;
            lblEmail.MouseClick += this.CambiaSelezione;
            lblIndirizzo.MouseClick += this.CambiaSelezione;

            this.MouseDoubleClick += this.CambiaSelezione;
            lblDenominazione.MouseDoubleClick += this.CambiaSelezione;
            lblEmail.MouseDoubleClick += this.CambiaSelezione;
            lblIndirizzo.MouseDoubleClick += this.CambiaSelezione;

            this.Size = new System.Drawing.Size(200, SchedaCliente.AltezzaSchedaClienti());
        }
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="controller">Controller che verrà usato per modifiche/inserimenti/eliminazioni dei clienti</param>
        /// <param name="cliente">Cliente da visualizzare</param>
        /// <param name="panelContainer">Pannello che conterrà l'overlay a seguito della pressione del pulsante di espansione</param>
        /// <exception cref="ArgumentNullException">Se vengono passati dei null</exception>
        public SchedaCliente(Cliente cliente, Panel panelContainer = null, bool selected = false) : this()
        {
            #region Controlli
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            #endregion

            _panelContainer = panelContainer;
            Cliente = cliente;
            Cliente.OnModifica += this.ClienteModificato;
            AperturaCliente += new EventHandler<ArgsSchedaCliente>(this.ApriOverlayCliente);

            Selected = selected;
            checkScheda.Checked = selected;
        }
        #endregion

        #region "Gestione eventi controlli"
        private void CambiaSelezione(object sender, EventArgs e)
        {
            if (sender is MaterialSkin.Controls.MaterialCheckBox)
            {
                if (((MaterialSkin.Controls.MaterialCheckBox)sender).Checked == Selected)
                    return;
            }
            Selected = !Selected;
            return;
            if (sender is CheckBox)
                Selected = checkScheda.Checked;
            else
                checkScheda.Checked = !Selected;
        }

        private void LblEspandi_Click(object sender, EventArgs e)
        {
            LanciaEvento(AperturaCliente);
        }
        #endregion

        #region "Funzioni private"
        /// <summary>
        /// Funzione che permette di lanciare un evento
        /// </summary>
        /// <param name="evento">Evento che si vuole lanciare</param>
        private void LanciaEvento(EventHandler<ArgsSchedaCliente> evento)
        {
            if (evento != null)
            {
                ArgsSchedaCliente args = new ArgsSchedaCliente(Cliente, this);
                evento(this, args);
            }
        }

        private void ClienteModificato(object sender, ArgsModifica<Cliente> e)
        {
            Cliente = e.Nuovo;
        }
        #endregion

        #region "Gestione eventi propri"
        private void ApriOverlayCliente(object sender, ArgsCliente e)
        {
            if (_panelContainer != null)
                new OverlayCliente(_panelContainer, Cliente).Open();
        }

        private void CaricaClienteSuForm()
        {
            lblIndirizzo.Text = Cliente.Persona.Indirizzo;
            lblEmail.Text = Cliente.Persona.Email.ToString();
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

            this.BackColor = _impostazioni.ColoreCliente(Cliente.TipoCliente);
        }
        #endregion

        #region "Funzione statiche"

        public static int AltezzaSchedaClienti()
        {
            return 150;
        }
        #endregion

    }
}
