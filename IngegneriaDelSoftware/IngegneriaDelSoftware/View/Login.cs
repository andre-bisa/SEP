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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using IngegneriaDelSoftware.Controller;
using MaterialSkin;
using IngegneriaDelSoftware.View;

namespace IngegneriaDelSoftware
{
    public partial class Login : MaterialForm
    {

        public Login()
        {
            InitializeComponent();
            materialLabelSettings.MouseEnter += (sender, args) =>
            {
                
            };

            this.DialogResult = DialogResult.Cancel;
            MaterialSkinManager.Instance.AddFormToManage(this);

            this.txtPassword.KeyDown += this.SubmitLogin;
            this.txtUsername.KeyDown += this.SubmitLogin;
        }

        private void SubmitLogin(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin.PerformClick();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool accesso = ControllerLogin.GetInstance().ControllaCredenziali(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (!accesso)
                    FormConfim.Show("Errore accesso", "Errore, username e/o password errati.", MessageBoxButtons.OK);
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            } catch (Persistenza.ExceptionPersistenza)
            {
                MessageBox.Show("Errore, connessione assente. Il programma termina", "Errore connessione DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void materialLabelSettings_Click(object sender, EventArgs e)
        {
            // Apertura delle impostazioni
        }
    }
}
