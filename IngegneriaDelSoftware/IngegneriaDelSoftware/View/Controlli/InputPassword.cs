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

namespace IngegneriaDelSoftware.View.Controlli
{
    public partial class InputPassword : UserControl
    {

        public new String Text => txtPassword.Text;

        private bool _abilitaVisionePassword = true;
        /// <summary>
        /// Consente di abilitare la visualizzazione in chiaro della password tramite apposito bottone (immagine)
        /// </summary>
        public bool AbilitaVisionePassword
        {
            get
            {
                return this._abilitaVisionePassword;
            }
            set
            {
                this._abilitaVisionePassword = value;
                this.pictureBoxVisibilityPassword.Visible = AbilitaVisionePassword;
                if (!this._abilitaVisionePassword)
                { // se disabilito la visione
                    this.txtPassword.UseSystemPasswordChar = true; // Rimetto gli asterischi
                    this.pictureBoxVisibilityPassword.BackgroundImage = Properties.Resources.ic_visibility_black_18dp; // Rimetto l'immagine giusta
                }

            }
        }

        public InputPassword()
        {
            InitializeComponent();
            txtPassword.KeyDown += (s, e) => this.OnKeyDown(e);

            AbilitaVisionePassword = true;
        }

        private void pictureBoxVisibilityPassword_Click(object sender, EventArgs e)
        {
            if (!AbilitaVisionePassword)
                return;

            this.txtPassword.UseSystemPasswordChar = !this.txtPassword.UseSystemPasswordChar;
            if (this.txtPassword.UseSystemPasswordChar)
                this.pictureBoxVisibilityPassword.BackgroundImage = Properties.Resources.ic_visibility_black_18dp;
            else
                this.pictureBoxVisibilityPassword.BackgroundImage = Properties.Resources.ic_visibility_off_black_18dp;
        }
    }
}
