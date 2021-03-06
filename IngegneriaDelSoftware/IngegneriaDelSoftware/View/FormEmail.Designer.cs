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

using IngegneriaDelSoftware.Model;
using System;

namespace IngegneriaDelSoftware.View
{
    partial class FormEmail
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
            MaterialSkin.Controls.MaterialTabControl materialTabControl1;
            System.Windows.Forms.TabPage tabInviaMail;
            System.Windows.Forms.Panel panelInviaMail;
            System.Windows.Forms.Panel panelInvioMailPrincipale;
            MaterialSkin.Controls.MaterialLabel materialLabel2;
            MaterialSkin.Controls.MaterialLabel materialLabel1;
            System.Windows.Forms.TabPage tabMailInviate;
            System.Windows.Forms.Panel panelMailInviate;
            MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
            this.btnAnnulla = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnInvia = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtCorpo = new System.Windows.Forms.TextBox();
            this.txtOggetto = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.listMailInviate = new MaterialSkin.Controls.MaterialListView();
            this.ListaData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListaOggetto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListaDestinatario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListaCorpo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelForm = new System.Windows.Forms.Panel();
            this.visualizzatoreClienti = new IngegneriaDelSoftware.View.Controlli.VisualizzatoreColonnaClienti();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabInviaMail = new System.Windows.Forms.TabPage();
            panelInviaMail = new System.Windows.Forms.Panel();
            panelInvioMailPrincipale = new System.Windows.Forms.Panel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            tabMailInviate = new System.Windows.Forms.TabPage();
            panelMailInviate = new System.Windows.Forms.Panel();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            materialTabControl1.SuspendLayout();
            tabInviaMail.SuspendLayout();
            panelInviaMail.SuspendLayout();
            panelInvioMailPrincipale.SuspendLayout();
            tabMailInviate.SuspendLayout();
            panelMailInviate.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            materialTabControl1.Controls.Add(tabInviaMail);
            materialTabControl1.Controls.Add(tabMailInviate);
            materialTabControl1.Depth = 0;
            materialTabControl1.Location = new System.Drawing.Point(3, 52);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new System.Drawing.Size(792, 327);
            materialTabControl1.TabIndex = 0;
            // 
            // tabInviaMail
            // 
            tabInviaMail.BackColor = System.Drawing.Color.White;
            tabInviaMail.Controls.Add(panelInviaMail);
            tabInviaMail.Location = new System.Drawing.Point(4, 22);
            tabInviaMail.Name = "tabInviaMail";
            tabInviaMail.Padding = new System.Windows.Forms.Padding(3);
            tabInviaMail.Size = new System.Drawing.Size(784, 301);
            tabInviaMail.TabIndex = 0;
            tabInviaMail.Text = "Invia mail";
            // 
            // panelInviaMail
            // 
            panelInviaMail.Controls.Add(this.visualizzatoreClienti);
            panelInviaMail.Controls.Add(panelInvioMailPrincipale);
            panelInviaMail.Controls.Add(this.materialDivider1);
            panelInviaMail.Dock = System.Windows.Forms.DockStyle.Fill;
            panelInviaMail.Location = new System.Drawing.Point(3, 3);
            panelInviaMail.Name = "panelInviaMail";
            panelInviaMail.Size = new System.Drawing.Size(778, 295);
            panelInviaMail.TabIndex = 0;
            // 
            // panelInvioMailPrincipale
            // 
            panelInvioMailPrincipale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panelInvioMailPrincipale.Controls.Add(this.btnAnnulla);
            panelInvioMailPrincipale.Controls.Add(this.btnInvia);
            panelInvioMailPrincipale.Controls.Add(this.txtCorpo);
            panelInvioMailPrincipale.Controls.Add(materialLabel2);
            panelInvioMailPrincipale.Controls.Add(this.txtOggetto);
            panelInvioMailPrincipale.Controls.Add(materialLabel1);
            panelInvioMailPrincipale.Location = new System.Drawing.Point(250, 3);
            panelInvioMailPrincipale.Name = "panelInvioMailPrincipale";
            panelInvioMailPrincipale.Size = new System.Drawing.Size(530, 289);
            panelInvioMailPrincipale.TabIndex = 2;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.AutoSize = true;
            this.btnAnnulla.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAnnulla.Depth = 0;
            this.btnAnnulla.Icon = null;
            this.btnAnnulla.Location = new System.Drawing.Point(246, 250);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAnnulla.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Primary = true;
            this.btnAnnulla.Size = new System.Drawing.Size(83, 36);
            this.btnAnnulla.TabIndex = 5;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnInvia
            // 
            this.btnInvia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvia.AutoSize = true;
            this.btnInvia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInvia.Depth = 0;
            this.btnInvia.Icon = null;
            this.btnInvia.Location = new System.Drawing.Point(171, 250);
            this.btnInvia.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnInvia.Name = "btnInvia";
            this.btnInvia.Primary = true;
            this.btnInvia.Size = new System.Drawing.Size(56, 36);
            this.btnInvia.TabIndex = 4;
            this.btnInvia.Text = "Invia";
            this.btnInvia.UseVisualStyleBackColor = true;
            // 
            // txtCorpo
            // 
            this.txtCorpo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorpo.Location = new System.Drawing.Point(31, 104);
            this.txtCorpo.Multiline = true;
            this.txtCorpo.Name = "txtCorpo";
            this.txtCorpo.Size = new System.Drawing.Size(478, 137);
            this.txtCorpo.TabIndex = 3;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel2.Location = new System.Drawing.Point(18, 82);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(50, 18);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Corpo";
            // 
            // txtOggetto
            // 
            this.txtOggetto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOggetto.Depth = 0;
            this.txtOggetto.Hint = "Oggetto";
            this.txtOggetto.Location = new System.Drawing.Point(30, 39);
            this.txtOggetto.MaxLength = 32767;
            this.txtOggetto.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtOggetto.Name = "txtOggetto";
            this.txtOggetto.PasswordChar = '\0';
            this.txtOggetto.SelectedText = "";
            this.txtOggetto.SelectionLength = 0;
            this.txtOggetto.SelectionStart = 0;
            this.txtOggetto.Size = new System.Drawing.Size(479, 23);
            this.txtOggetto.TabIndex = 1;
            this.txtOggetto.TabStop = false;
            this.txtOggetto.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel1.Location = new System.Drawing.Point(18, 17);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(61, 18);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Oggetto";
            // 
            // materialDivider1
            // 
            this.materialDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(240, 3);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(3, 289);
            this.materialDivider1.TabIndex = 0;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // tabMailInviate
            // 
            tabMailInviate.Controls.Add(panelMailInviate);
            tabMailInviate.Location = new System.Drawing.Point(4, 22);
            tabMailInviate.Name = "tabMailInviate";
            tabMailInviate.Padding = new System.Windows.Forms.Padding(3);
            tabMailInviate.Size = new System.Drawing.Size(784, 301);
            tabMailInviate.TabIndex = 1;
            tabMailInviate.Text = "Mail inviate";
            tabMailInviate.UseVisualStyleBackColor = true;
            // 
            // panelMailInviate
            // 
            panelMailInviate.Controls.Add(this.listMailInviate);
            panelMailInviate.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMailInviate.Location = new System.Drawing.Point(3, 3);
            panelMailInviate.Name = "panelMailInviate";
            panelMailInviate.Size = new System.Drawing.Size(778, 295);
            panelMailInviate.TabIndex = 0;
            // 
            // listMailInviate
            // 
            this.listMailInviate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listMailInviate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListaData,
            this.ListaOggetto,
            this.ListaDestinatario,
            this.ListaCorpo});
            this.listMailInviate.Depth = 0;
            this.listMailInviate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMailInviate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listMailInviate.FullRowSelect = true;
            this.listMailInviate.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listMailInviate.Location = new System.Drawing.Point(0, 0);
            this.listMailInviate.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listMailInviate.MouseState = MaterialSkin.MouseState.OUT;
            this.listMailInviate.Name = "listMailInviate";
            this.listMailInviate.OwnerDraw = true;
            this.listMailInviate.Size = new System.Drawing.Size(778, 295);
            this.listMailInviate.TabIndex = 0;
            this.listMailInviate.UseCompatibleStateImageBehavior = false;
            this.listMailInviate.View = System.Windows.Forms.View.Details;
            // 
            // ListaData
            // 
            this.ListaData.Text = "Data invio";
            this.ListaData.Width = 157;
            // 
            // ListaOggetto
            // 
            this.ListaOggetto.Text = "Oggetto";
            this.ListaOggetto.Width = 198;
            // 
            // ListaDestinatario
            // 
            this.ListaDestinatario.Text = "Destinatario";
            this.ListaDestinatario.Width = 186;
            // 
            // ListaCorpo
            // 
            this.ListaCorpo.Text = "Corpo";
            this.ListaCorpo.Width = 198;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            materialTabSelector1.BaseTabControl = materialTabControl1;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Location = new System.Drawing.Point(0, 0);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new System.Drawing.Size(802, 51);
            materialTabSelector1.TabIndex = 1;
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForm.AutoScroll = true;
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(materialTabSelector1);
            this.panelForm.Controls.Add(materialTabControl1);
            this.panelForm.Location = new System.Drawing.Point(0, 64);
            this.panelForm.Margin = new System.Windows.Forms.Padding(0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(798, 382);
            this.panelForm.TabIndex = 1;
            // 
            // visualizzatoreClienti
            // 
            this.visualizzatoreClienti.FiltroCliente = null;
            this.visualizzatoreClienti.Location = new System.Drawing.Point(3, 2);
            this.visualizzatoreClienti.Name = "visualizzatoreClienti";
            this.visualizzatoreClienti.PannelloForm = this.panelForm;
            this.visualizzatoreClienti.Size = new System.Drawing.Size(231, 290);
            this.visualizzatoreClienti.TabIndex = 2;
            // 
            // FormEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelForm);
            this.Name = "FormEmail";
            this.Text = "Email";
            this.Load += new System.EventHandler(this.FormEmail_Load);
            materialTabControl1.ResumeLayout(false);
            tabInviaMail.ResumeLayout(false);
            panelInviaMail.ResumeLayout(false);
            panelInvioMailPrincipale.ResumeLayout(false);
            panelInvioMailPrincipale.PerformLayout();
            tabMailInviate.ResumeLayout(false);
            panelMailInviate.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelForm;
        private MaterialSkin.Controls.MaterialListView listMailInviate;
        private System.Windows.Forms.ColumnHeader ListaData;
        private System.Windows.Forms.ColumnHeader ListaOggetto;
        private System.Windows.Forms.ColumnHeader ListaDestinatario;
        private System.Windows.Forms.ColumnHeader ListaCorpo;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialFlatButton btnAnnulla;
        private MaterialSkin.Controls.MaterialRaisedButton btnInvia;
        private System.Windows.Forms.TextBox txtCorpo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtOggetto;
        private Controlli.VisualizzatoreColonnaClienti visualizzatoreClienti;
    }
}