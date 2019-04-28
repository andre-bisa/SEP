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

using IngegneriaDelSoftware.Model;
using System;

namespace IngegneriaDelSoftware.View
{
    partial class FormAppuntamenti
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
            MaterialSkin.Controls.MaterialLabel materialLabel3;
            MaterialSkin.Controls.MaterialLabel materialLabel4;
            this.txtLuogoAppuntamento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.dataAppuntamento = new System.Windows.Forms.DateTimePicker();
            this.txtNoteAppuntamento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnAggiungi = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.visualizzatoreClienti = new IngegneriaDelSoftware.View.Controlli.VisualizzatoreColonnaClienti();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.BackColor = System.Drawing.Color.Transparent;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel1.Location = new System.Drawing.Point(280, 20);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(212, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Creazione di un appuntamento";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.BackColor = System.Drawing.Color.Transparent;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel2.Location = new System.Drawing.Point(280, 146);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(51, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Luogo";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.BackColor = System.Drawing.Color.Transparent;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel3.Location = new System.Drawing.Point(280, 82);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new System.Drawing.Size(78, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "Data e ora";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.BackColor = System.Drawing.Color.Transparent;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel4.Location = new System.Drawing.Point(280, 211);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new System.Drawing.Size(42, 19);
            materialLabel4.TabIndex = 6;
            materialLabel4.Text = "Note";
            // 
            // txtLuogoAppuntamento
            // 
            this.txtLuogoAppuntamento.BackColor = System.Drawing.Color.White;
            this.txtLuogoAppuntamento.Depth = 0;
            this.txtLuogoAppuntamento.Hint = "Luogo";
            this.txtLuogoAppuntamento.Location = new System.Drawing.Point(428, 142);
            this.txtLuogoAppuntamento.MaxLength = 32767;
            this.txtLuogoAppuntamento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLuogoAppuntamento.Name = "txtLuogoAppuntamento";
            this.txtLuogoAppuntamento.PasswordChar = '\0';
            this.txtLuogoAppuntamento.SelectedText = "";
            this.txtLuogoAppuntamento.SelectionLength = 0;
            this.txtLuogoAppuntamento.SelectionStart = 0;
            this.txtLuogoAppuntamento.Size = new System.Drawing.Size(183, 23);
            this.txtLuogoAppuntamento.TabIndex = 2;
            this.txtLuogoAppuntamento.TabStop = false;
            this.txtLuogoAppuntamento.UseSystemPasswordChar = false;
            // 
            // dataAppuntamento
            // 
            this.dataAppuntamento.CustomFormat = "dd/MM/yyyy H:mm";
            this.dataAppuntamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataAppuntamento.Location = new System.Drawing.Point(428, 82);
            this.dataAppuntamento.Name = "dataAppuntamento";
            this.dataAppuntamento.Size = new System.Drawing.Size(183, 20);
            this.dataAppuntamento.TabIndex = 1;
            // 
            // txtNoteAppuntamento
            // 
            this.txtNoteAppuntamento.BackColor = System.Drawing.Color.White;
            this.txtNoteAppuntamento.Depth = 0;
            this.txtNoteAppuntamento.Hint = "Note";
            this.txtNoteAppuntamento.Location = new System.Drawing.Point(428, 207);
            this.txtNoteAppuntamento.MaxLength = 32767;
            this.txtNoteAppuntamento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNoteAppuntamento.Name = "txtNoteAppuntamento";
            this.txtNoteAppuntamento.PasswordChar = '\0';
            this.txtNoteAppuntamento.SelectedText = "";
            this.txtNoteAppuntamento.SelectionLength = 0;
            this.txtNoteAppuntamento.SelectionStart = 0;
            this.txtNoteAppuntamento.Size = new System.Drawing.Size(183, 23);
            this.txtNoteAppuntamento.TabIndex = 3;
            this.txtNoteAppuntamento.TabStop = false;
            this.txtNoteAppuntamento.UseSystemPasswordChar = false;
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.AnimateIcon = true;
            this.btnAggiungi.AnimateShowHideButton = true;
            this.btnAggiungi.Depth = 0;
            this.btnAggiungi.Icon = global::IngegneriaDelSoftware.Properties.Resources.ic_save_black_48dp;
            this.btnAggiungi.Location = new System.Drawing.Point(577, 314);
            this.btnAggiungi.Mini = false;
            this.btnAggiungi.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(56, 56);
            this.btnAggiungi.TabIndex = 4;
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(246, 3);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(3, 377);
            this.materialDivider1.TabIndex = 10;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.visualizzatoreClienti);
            this.mainPanel.Controls.Add(this.btnAggiungi);
            this.mainPanel.Controls.Add(this.materialDivider1);
            this.mainPanel.Controls.Add(this.txtNoteAppuntamento);
            this.mainPanel.Controls.Add(materialLabel1);
            this.mainPanel.Controls.Add(materialLabel4);
            this.mainPanel.Controls.Add(materialLabel2);
            this.mainPanel.Controls.Add(this.dataAppuntamento);
            this.mainPanel.Controls.Add(this.txtLuogoAppuntamento);
            this.mainPanel.Controls.Add(materialLabel3);
            this.mainPanel.Location = new System.Drawing.Point(5, 68);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(641, 377);
            this.mainPanel.TabIndex = 12;
            // 
            // visualizzatoreClienti
            // 
            this.visualizzatoreClienti.FiltroCliente = null;
            this.visualizzatoreClienti.Location = new System.Drawing.Point(0, 0);
            this.visualizzatoreClienti.Margin = new System.Windows.Forms.Padding(0);
            this.visualizzatoreClienti.Name = "visualizzatoreClienti";
            this.visualizzatoreClienti.PannelloForm = this.mainPanel;
            this.visualizzatoreClienti.Size = new System.Drawing.Size(240, 374);
            this.visualizzatoreClienti.TabIndex = 11;
            // 
            // FormAppuntamenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "FormAppuntamenti";
            this.Text = "Inserimento appuntamenti";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLuogoAppuntamento;
        private System.Windows.Forms.DateTimePicker dataAppuntamento;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNoteAppuntamento;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnAggiungi;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Panel mainPanel;
        private Controlli.VisualizzatoreColonnaClienti visualizzatoreClienti;
    }
}