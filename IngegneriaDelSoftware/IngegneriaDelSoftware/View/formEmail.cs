﻿/*
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
using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model.ArgsEvent;
using System.Threading;

namespace IngegneriaDelSoftware.View
{
    public partial class FormEmail : MaterialForm
    {
        private ControllerInviaMail _controllerInviaMail = ControllerInviaMail.GetInstance();

        private ControllerClienti _controllerClienti = ControllerClienti.GetInstance();
        private VisualizzatoreCliente _visualizzatore;

        private List<ClienteMostrato<SchedaCliente>> _clientiCaricati = new List<ClienteMostrato<SchedaCliente>>();
        private int quantiClientiMostrare;

        private List<Cliente> _clientiACuiMandare = new List<Cliente>();

        private CollezioneEmailInviate _emailInviate = CollezioneEmailInviate.GetInstance();

        #region "Costruttore"
        public FormEmail()
        {
            InitializeComponent();

            this.btnInvia.Click += (o, e) => { InviaMail(); };

            flowClienti.Scroll += (s, e) => HandleScroll();
            flowClienti.MouseWheel += (s, e) => HandleScroll();
            txtSearchBar.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    RicercaTraClienti();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };

            // Funzione che permette di effettuare la ricerca per tutti i campi
            var ricercaTuttiParametri = new Func<Cliente, string, bool>((cliente, stringa) =>
            {
                return cliente.IDCliente.ToLower().Contains(stringa.ToLower()) || cliente.Persona.Indirizzo.ToLower().Contains(stringa.ToLower()) || cliente.Denominazione.ToLower().Contains(stringa.ToLower()) || cliente.Referenti.Any(referente => referente.Nome.ToLower().Contains(stringa.ToLower()));
            });
            this._visualizzatore = new VisualizzatoreCliente(ricercaTuttiParametri);

            this._controllerClienti.CollezioneClienti.OnRimozione += this.RimossoCliente;
            this._controllerClienti.CollezioneClienti.OnAggiunta += (o, e) => { CaricaClientiMancanti(); };

            this._controllerInviaMail.CollezioneEmailInviate.OnAggiunta += (o, email) => 
            {
                string[] row = { email.MailInviata.Data.ToString(), email.MailInviata.Oggetto, email.MailInviata.Email, email.MailInviata.Corpo };
                ListViewItem item = new ListViewItem(row);
                this.listMailInviate.Items.Add(item);
            };
        }
        #endregion

        #region "Carica schede cliente"
        /// <summary>
        /// Funzione che mostra le schede dei clienti nella form
        /// </summary>
        private void CaricaSchedaCliente()
        {
            Cliente clienteDaMostrare;

            do // Non mostro i clienti che non hanno indirizzi Email
            {
                clienteDaMostrare = _visualizzatore.ProssimoCliente();
            } while (clienteDaMostrare != null && clienteDaMostrare.Persona.Email.Count == 0);

            if (clienteDaMostrare == null)
                return;

            SchedaCliente schedaCliente = new SchedaCliente(clienteDaMostrare, this.panelForm);
            schedaCliente.ModificataSelezione += ModificataSelezione;
            this.flowClienti.Controls.Add(schedaCliente);
            this._clientiCaricati.Add(new ClienteMostrato<SchedaCliente>(clienteDaMostrare, schedaCliente, false));

        }

        private void ModificataSelezione(object sender, ArgsSchedaCliente e)
        {
            if (e.SchedaCliente.Selected)
            {
                this._clientiACuiMandare.Add(e.Cliente);
            }
            else
            {
                if (this._clientiACuiMandare.Contains(e.Cliente))
                    this._clientiACuiMandare.Remove(e.Cliente);
            }
        }

        /// <summary>
        /// Funzione che permette di visualizzare un certo numero di clienti nella form
        /// </summary>
        /// <param name="quanti">Quanti clienti mostrare</param>
        private void RiempiSchedeClienti(int quanti)
        {
            this.quantiClientiMostrare += quanti;
            CaricaClientiMancanti();
        }

        private void CaricaClientiMancanti()
        {
            for (int i = this._clientiCaricati.Count; i < this.quantiClientiMostrare; i++)
            {
                CaricaSchedaCliente();
            }
        }
        #endregion

        #region Carica email in lista
        private void CaricaEmailNellaLista()
        {
            foreach (MailInviata email in this._emailInviate)
            {
                string[] row = { email.Data.ToString(), email.Oggetto, email.Email, email.Corpo };
                ListViewItem item = new ListViewItem(row);
                this.listMailInviate.Items.Add(item);
            }
        }
        #endregion

        private void FormEmail_Load(object sender, EventArgs e)
        {
            // Carico il numero di clienti che possono essere visti in base alle dimensioni dello schermo
            RiempiSchedeClienti(Screen.FromControl(this).Bounds.Height / SchedaCliente.AltezzaSchedaClienti() + 1);
            CaricaEmailNellaLista();
        }

        /// <summary>
        /// Funzione che permette di caricare i clienti solo quando si sta visualizzando l'ultimo cliente
        /// </summary>
        private void HandleScroll()
        {
            // if (sto visualizzando l'ultimo cliente) => ne carico un altro
            if (flowClienti.VerticalScroll.Value >= flowClienti.VerticalScroll.Maximum - flowClienti.VerticalScroll.LargeChange - SchedaCliente.AltezzaSchedaClienti())
                RiempiSchedeClienti(1);
        }

        private void RimossoCliente(object sender, ArgsCliente e)
        {
            if (e.Cliente == null)
                return;

            ClienteMostrato<SchedaCliente> cliente = this._clientiCaricati.Find(c => e.Cliente == c.Cliente);

            if (cliente == null) // Se non è stato mostrato
                return;

            SchedaCliente schedaDaRimuovere = this._clientiCaricati.Find(c => e.Cliente.Equals(c.Cliente)).DoveMostrato;
            if (schedaDaRimuovere != null)
            {
                this.flowClienti.Controls.Remove(schedaDaRimuovere);
                this._clientiCaricati.Remove(cliente);
                CaricaSchedaCliente();
            }
        }

        private void RicercaTraClienti()
        {
            this._visualizzatore.ImpostaFiltroTuttiParametri(txtSearchBar.Text.Trim());

            var queryClientiDaRimuovere =
                (from tripla in this._clientiCaricati
                 where !this._visualizzatore.Visualizzabile(tripla.Cliente)    // dove i clienti non devono essere visualizzati
                 select tripla
                 );

            foreach (ClienteMostrato<SchedaCliente> cliente in new List<ClienteMostrato<SchedaCliente>>(queryClientiDaRimuovere))
            {
                this.flowClienti.Controls.Remove(cliente.DoveMostrato);
                this._clientiCaricati.Remove(cliente);
            }

            CaricaClientiMancanti();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            RicercaTraClienti();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InviaMail()
        {
            if (_clientiACuiMandare.Count == 0)
            {
                FormConfim.Show("Errore", "Seleziona almeno un destinatario!", MessageBoxButtons.OK);
                return;
            }

            btnInvia.Enabled = false;

            bool mandate = this._controllerInviaMail.InviaMail(txtOggetto.Text.Trim(), txtCorpo.Text, this._clientiACuiMandare);
            if (mandate)
                FormConfim.Show("Mail inviate", "Mail inviate con successo.", MessageBoxButtons.OK);
            else
                FormConfim.Show("Errore", "Errore invio email." + Environment.NewLine + "Consulta le MailInviate per vedere tutte le mail inviate.", MessageBoxButtons.OK);

            btnInvia.Enabled = true;
        }
    }

}
