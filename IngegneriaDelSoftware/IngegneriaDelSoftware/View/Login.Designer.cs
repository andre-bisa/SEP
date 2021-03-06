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

namespace IngegneriaDelSoftware
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MaterialSkin.Controls.MaterialLabel materialLabelPassword;
            MaterialSkin.Controls.MaterialLabel materialLabelUsername;
            this.BtnLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabelSettings = new MaterialSkin.Controls.MaterialLabel();
            this.txtPassword = new IngegneriaDelSoftware.View.Controlli.InputPassword();
            materialLabelPassword = new MaterialSkin.Controls.MaterialLabel();
            materialLabelUsername = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialLabelPassword
            // 
            materialLabelPassword.Depth = 0;
            materialLabelPassword.EnableAnimations = false;
            materialLabelPassword.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabelPassword.Image = global::IngegneriaDelSoftware.Properties.Resources.ic_fingerprint_black_24dp;
            materialLabelPassword.Location = new System.Drawing.Point(27, 133);
            materialLabelPassword.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabelPassword.Name = "materialLabelPassword";
            materialLabelPassword.Size = new System.Drawing.Size(36, 36);
            materialLabelPassword.TabIndex = 100;
            // 
            // materialLabelUsername
            // 
            materialLabelUsername.Depth = 0;
            materialLabelUsername.EnableAnimations = false;
            materialLabelUsername.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabelUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabelUsername.Image = global::IngegneriaDelSoftware.Properties.Resources.ic_account_box_black_24dp;
            materialLabelUsername.Location = new System.Drawing.Point(27, 81);
            materialLabelUsername.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabelUsername.Name = "materialLabelUsername";
            materialLabelUsername.Size = new System.Drawing.Size(36, 36);
            materialLabelUsername.TabIndex = 100;
            // 
            // BtnLogin
            // 
            this.BtnLogin.AutoSize = true;
            this.BtnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnLogin.Depth = 0;
            this.BtnLogin.Icon = null;
            this.BtnLogin.Location = new System.Drawing.Point(170, 193);
            this.BtnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Primary = true;
            this.BtnLogin.Size = new System.Drawing.Size(61, 36);
            this.BtnLogin.TabIndex = 2;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Depth = 0;
            this.txtUsername.Hint = "Username";
            this.txtUsername.Location = new System.Drawing.Point(82, 94);
            this.txtUsername.MaxLength = 30;
            this.txtUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.Size = new System.Drawing.Size(232, 23);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TabStop = false;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // materialLabelSettings
            // 
            this.materialLabelSettings.Depth = 0;
            this.materialLabelSettings.EnableAnimations = true;
            this.materialLabelSettings.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabelSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelSettings.Image = global::IngegneriaDelSoftware.Properties.Resources.ic_settings_black_24dp;
            this.materialLabelSettings.Location = new System.Drawing.Point(278, 193);
            this.materialLabelSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelSettings.Name = "materialLabelSettings";
            this.materialLabelSettings.Size = new System.Drawing.Size(36, 36);
            this.materialLabelSettings.TabIndex = 100;
            this.materialLabelSettings.Click += new System.EventHandler(this.materialLabelSettings_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.AbilitaVisionePassword = true;
            this.txtPassword.Location = new System.Drawing.Point(82, 145);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.MaximumSize = new System.Drawing.Size(1000, 23);
            this.txtPassword.MinimumSize = new System.Drawing.Size(0, 23);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(232, 23);
            this.txtPassword.TabIndex = 1;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.materialLabelSettings);
            this.Controls.Add(materialLabelPassword);
            this.Controls.Add(materialLabelUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.BtnLogin);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsername;
        private MaterialSkin.Controls.MaterialRaisedButton BtnLogin;
        private MaterialSkin.Controls.MaterialLabel materialLabelSettings;
        private View.Controlli.InputPassword txtPassword;
    }
}