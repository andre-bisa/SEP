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

        private CollezioneEmailInviate _emailInviate = CollezioneEmailInviate.GetInstance();

        #region "Costruttore"
        public FormEmail()
        {
            InitializeComponent();
            this.visualizzatoreClienti.FiltroCliente = new Predicate<Cliente>(c => c.Persona.Email.Count > 0);

            this.btnInvia.Click += (o, e) => { InviaMail(); };

            this._controllerInviaMail.CollezioneEmailInviate.OnAggiunta += (o, email) => 
            {
                string[] row = { email.MailInviata.Data.ToString(), email.MailInviata.Oggetto, email.MailInviata.Email, email.MailInviata.Corpo };
                ListViewItem item = new ListViewItem(row);
                this.listMailInviate.Items.Add(item);
            };
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
            CaricaEmailNellaLista();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InviaMail()
        {
            List<Cliente> clientiSelezionati = this.visualizzatoreClienti.ClientiSelezionati;
            if (clientiSelezionati.Count == 0)
            {
                FormConfim.Show("Errore", "Seleziona almeno un destinatario!", MessageBoxButtons.OK);
                return;
            }

            btnInvia.Enabled = false;

            bool mandate = this._controllerInviaMail.InviaMail(txtOggetto.Text.Trim(), txtCorpo.Text, clientiSelezionati);
            if (mandate)
                FormConfim.Show("Mail inviate", "Mail inviate con successo.", MessageBoxButtons.OK);
            else
                FormConfim.Show("Errore", "Errore invio email." + Environment.NewLine + "Consulta le MailInviate per vedere tutte le mail inviate.", MessageBoxButtons.OK);

            btnInvia.Enabled = true;
        }
    }

}
