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

namespace IngegneriaDelSoftware.View
{
    partial class FormInserisciReferente
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
            MaterialSkin.Controls.MaterialLabel materialLabel1;
            MaterialSkin.Controls.MaterialLabel materialLabel2;
            this.txtNome = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.BtnSalva = new MaterialSkin.Controls.MaterialRaisedButton();
            this.BtnCancella = new MaterialSkin.Controls.MaterialFlatButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel1.Location = new System.Drawing.Point(12, 72);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(114, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Nome referente";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel2.Location = new System.Drawing.Point(265, 72);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(42, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Nota";
            // 
            // txtNome
            // 
            this.txtNome.Depth = 0;
            this.txtNome.Hint = "";
            this.txtNome.Location = new System.Drawing.Point(25, 94);
            this.txtNome.MaxLength = 32767;
            this.txtNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNome.Name = "txtNome";
            this.txtNome.PasswordChar = '\0';
            this.txtNome.SelectedText = "";
            this.txtNome.SelectionLength = 0;
            this.txtNome.SelectionStart = 0;
            this.txtNome.Size = new System.Drawing.Size(200, 23);
            this.txtNome.TabIndex = 1;
            this.txtNome.TabStop = false;
            this.txtNome.UseSystemPasswordChar = false;
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(279, 97);
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(250, 100);
            this.txtNota.TabIndex = 3;
            // 
            // BtnSalva
            // 
            this.BtnSalva.AutoSize = true;
            this.BtnSalva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnSalva.Depth = 0;
            this.BtnSalva.Icon = null;
            this.BtnSalva.Location = new System.Drawing.Point(61, 202);
            this.BtnSalva.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnSalva.Name = "BtnSalva";
            this.BtnSalva.Primary = true;
            this.BtnSalva.Size = new System.Drawing.Size(64, 36);
            this.BtnSalva.TabIndex = 4;
            this.BtnSalva.Text = "Salva";
            this.BtnSalva.UseVisualStyleBackColor = true;
            this.BtnSalva.Click += new System.EventHandler(this.BtnSalva_Click);
            // 
            // BtnCancella
            // 
            this.BtnCancella.AutoSize = true;
            this.BtnCancella.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCancella.Depth = 0;
            this.BtnCancella.Icon = null;
            this.BtnCancella.Location = new System.Drawing.Point(145, 202);
            this.BtnCancella.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnCancella.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnCancella.Name = "BtnCancella";
            this.BtnCancella.Primary = true;
            this.BtnCancella.Size = new System.Drawing.Size(90, 36);
            this.BtnCancella.TabIndex = 5;
            this.BtnCancella.Text = "Cancella";
            this.BtnCancella.UseVisualStyleBackColor = true;
            this.BtnCancella.Click += new System.EventHandler(this.BtnCancella_Click);
            // 
            // FormInserisciReferente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 250);
            this.Controls.Add(this.BtnCancella);
            this.Controls.Add(this.BtnSalva);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(materialLabel2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(materialLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInserisciReferente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.Text = "Inserisci Referente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtNome;
        private System.Windows.Forms.TextBox txtNota;
        private MaterialSkin.Controls.MaterialRaisedButton BtnSalva;
        private MaterialSkin.Controls.MaterialFlatButton BtnCancella;
    }
}