﻿using System;
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

        private Cliente _cliente;
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

        private bool _selected = false;
        /// <summary>
        /// Dice se la scheda è selezionata.
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            private set
            {
                _selected = value;
                if (Selected)
                {
                    this.BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    this.BackColor = System.Drawing.SystemColors.Info;
                }
                LanciaEvento(ModificataSelezione);
            }
        }

        private Panel _panelContainer = null;

        #region "Costruttori"
        /// <summary>
        /// Costruttore base
        /// </summary>
        /// <param name="cliente">Cliente</param>
        public SchedaCliente(Cliente cliente)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(200, SchedaCliente.AltezzaSchedaClienti());

            Cliente = cliente;
            Cliente.ModificaCliente += this.ClienteModificato;
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="panelContainer">Pannello che conterrà l'overlay a seguito della pressione del pulsante di espansione</param>
        public SchedaCliente(Cliente cliente, Panel panelContainer) : this(cliente)
        {
            _panelContainer = panelContainer;
            AperturaCliente += new EventHandler<ArgsSchedaCliente>(this.ApriOverlayCliente);
        }
        #endregion

        #region "Gestione eventi controlli"
        private void CheckScheda_CheckedChanged(object sender, EventArgs e)
        {
            Selected = !Selected;
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

        private void ClienteModificato(object sender, ArgsModificaCliente e)
        {
            Cliente = e.Cliente;
        }
        #endregion

        #region "Gestione eventi propri"
        private void ApriOverlayCliente(object sender, ArgsCliente e)
        {
            if (_panelContainer != null)
                new OverlayCliente(Cliente, _panelContainer).Open();
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