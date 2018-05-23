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
using IngegneriaDelSoftware.View.Controlli;
using IngegneriaDelSoftware.Controller;

namespace IngegneriaDelSoftware.View.Overlay
{
    public partial class OverlayCliente : Overlay
    {
        /// <summary>
        /// Cliente dell'overlay
        /// </summary>
        public Cliente Cliente { get; private set; }
        private ControllerClienti _controller;

        private Impostazioni _impostazioni = new Impostazioni();

        #region "Costruttori"
        /// <summary>
        /// Costruttore da usare per la creazione di un overlay vuoto. Utile per l'inserimento di un cliente.
        /// </summary>
        /// <param name="controller">Il controller dei clienti a cui dovrà fare riferimento la view (serve a chiedere di inserire/modificare/eliminare i clienti)</param>
        /// <param name="panelContainer">Pannello che conterrà l'overlay</param>
        /// <param name="cliente">Cliente a cui si riferisce l'overlay</param>
        public OverlayCliente(ControllerClienti controller, Panel panelContainer, Cliente cliente = null) : base(panelContainer)
        {
            InitializeComponent();
            base.AddPanel(this.panel1);
            btnSalva.Click += this.BottoneSalva;

            this.Titolo = "Cliente";

            this._controller = controller;
            if (cliente != null)
            {
                Cliente = cliente;
                CaricaClienteSuForm();
            }
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
            DatiPersona datiPersona;
            EnumTipoCliente tipoCliente = EnumTipoCliente.Attivo;
            DatiCliente datiCliente;
            List<Referente> listaReferenti = null;
            string nota = txtNote.Text;

            if (radioFisica.Checked)
            {
                datiPersona = new DatiPersonaFisica(txtCodiceFiscale.Text, txtIndirizzo.Text, txtNome.Text, txtCognome.Text, txtPartitaIVA.Text);
            }
            else // Giuridica
            {
                datiPersona = new DatiPersonaGiuridica(txtCodiceFiscale.Text, txtIndirizzo.Text, txtDenominazione.Text, "Sede legale", txtPartitaIVA.Text);
            }

            if (checkEx.Checked)
                tipoCliente = EnumTipoCliente.Ex;
            else if (checkPotenziale.Checked)
                tipoCliente = EnumTipoCliente.Potenziale;

            datiCliente = new DatiCliente(txtCodice.Text, tipoCliente, listaReferenti, nota);
            
            if (Cliente == null) // devo creare un cliente
            {
                Cliente = this._controller.AggiungiCliente(datiCliente, datiPersona);
            }
            else
            {
                this._controller.ModificaCliente(Cliente, datiCliente, datiPersona);
            }

            this.Close(); // Chiudo l'overlay
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
            txtNote.Text = Cliente.Nota;

            // Carico Email
            foreach (Email email in Cliente.Persona.Email)
            {
                string[] rows = { email.Indirizzo, email.Nota };
                ListViewItem item = new ListViewItem(rows);
                listEmail.Items.Add(item);
            }

            // Carico Telefoni
            foreach (Telefono tel in Cliente.Persona.Telefoni)
            {
                string[] rows = { tel.Numero, tel.Nota };
                ListViewItem item = new ListViewItem(rows);
                listTelefoni.Items.Add(item);
            }

            // Carico Referenti
            foreach (Referente referente in Cliente.Referenti)
            {
                string[] rows = { referente.Nome, referente.Nota };
                ListViewItem item = new ListViewItem(rows);
                listReferenti.Items.Add(item);
            }

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
                checkPotenziale.Checked = true;

            // Disattivo scelte non valide
            switch (Cliente.TipoCliente)
            {
                case EnumTipoCliente.Attivo:
                    checkEx.Enabled = true;
                    checkPotenziale.Enabled = false;
                    break;
                case EnumTipoCliente.Ex:
                    checkPotenziale.Enabled = false;
                    checkEx.Enabled = true;
                    break;
                case EnumTipoCliente.Potenziale:
                    checkEx.Enabled = false;
                    checkPotenziale.Enabled = true;
                    break;
            }

            // Colore di sfondo
            base.ColoreSfondo = this._impostazioni.ColoreCliente(Cliente.TipoCliente);
        }
        #endregion

        private void checkPotenziale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPotenziale.Checked)
            {
                checkEx.Enabled = false;
                checkEx.Checked = false;
            }
            else
            {
                checkEx.Enabled = true;
            }
        }

        private void checkEx_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEx.Checked)
            {
                checkPotenziale.Enabled = false;
                checkPotenziale.Checked = false;
            }
            else
            {
                checkPotenziale.Enabled = true;
            }
        }
    }
}
