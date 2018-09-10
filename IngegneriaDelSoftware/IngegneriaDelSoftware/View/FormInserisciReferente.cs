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

namespace IngegneriaDelSoftware.View
{
    public partial class FormInserisciReferente : MaterialForm
    {
        public event EventHandler<ArgsReferente> OnAggiunta;

        public FormInserisciReferente()
        {
            InitializeComponent();
        }

        private void BtnSalva_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim().Length == 0)
                return;

            if (OnAggiunta != null)
            {
                ArgsReferente args = new ArgsReferente(new Model.Referente(txtNome.Text.Trim(), txtNota.Text.Trim()));
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
