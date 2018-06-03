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
using IngegneriaDelSoftware.Model.ArgsEvent;
using MaterialSkin.Controls;
using System.Text.RegularExpressions;

namespace IngegneriaDelSoftware.View
{
    public partial class FormInserisciEmail : MaterialForm
    {
        public event EventHandler<ArgsEmail> OnAggiunta;

        public FormInserisciEmail()
        {
            InitializeComponent();
        }

        private void BtnSalva_Click(object sender, EventArgs e)
        {
            Regex controlloEmail = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
            if (!controlloEmail.Match(txtEmail.Text.Trim()).Success)
            {
                FormConfim.Show("Errore email", "Errore, la e-mail inserita non è valida.", MessageBoxButtons.OK);
                return;
            }

            if (OnAggiunta != null)
            {
                ArgsEmail args = new ArgsEmail(new Model.Email(txtEmail.Text.Trim(), txtNota.Text.Trim()));
                OnAggiunta(this, args);
            }
            this.Close();
        }

        private void BtnCancella_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
