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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace IngegneriaDelSoftware.View
{
    public partial class FormConfim : MaterialForm
    {
        public string Titolo
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }
        public string Messaggio
        {
            get
            {
                return lblMessaggio.Text;
            }
            set
            {
                lblMessaggio.Text = value;
            }
        }

        #region "Costruttori"
        protected FormConfim()
        {
            InitializeComponent();
        }

        protected FormConfim(string titolo, string messaggio, MessageBoxButtons buttons) : this()
        {
            Titolo = titolo;
            Messaggio = messaggio;
            if(buttons == MessageBoxButtons.OKCancel) {
                //do nothing;
            }else if(buttons == MessageBoxButtons.OK) {
                this.btnAnnulla.Visible = false;
                this.btnConferma.Text = "Ok";
            }
        }
        #endregion

        #region "Metodi privati"
        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        /// <summary>
        /// Funzione che mostra una richiesta all'utente. Prende spunto dal MessageBox
        /// </summary>
        /// <param name="titolo">Titolo che verrà mostrato nella finestra</param>
        /// <param name="messaggio">Messaggio che si vuole chiedere all'utente</param>
        /// <returns></returns>
        public static DialogResult Show(string titolo, string messaggio, MessageBoxButtons buttons = MessageBoxButtons.OKCancel)
        {
            FormConfim formConfim = new FormConfim(titolo, messaggio, buttons);
            return formConfim.ShowDialog();
        }
    }
}
