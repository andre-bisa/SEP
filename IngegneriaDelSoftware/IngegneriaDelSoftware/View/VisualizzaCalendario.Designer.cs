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

namespace IngegneriaDelSoftware.View
{
    partial class VisualizzaCalendario
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
            this.listCalendario = new MaterialSkin.Controls.MaterialListView();
            this.headerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerOra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerLuogo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerOggetto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerConChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimePickerDa = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerA = new System.Windows.Forms.DateTimePicker();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // listCalendario
            // 
            this.listCalendario.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listCalendario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listCalendario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listCalendario.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerID,
            this.headerData,
            this.headerOra,
            this.headerLuogo,
            this.headerOggetto,
            this.headerConChi});
            this.listCalendario.Depth = 0;
            this.listCalendario.Enabled = false;
            this.listCalendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listCalendario.FullRowSelect = true;
            this.listCalendario.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listCalendario.Location = new System.Drawing.Point(12, 133);
            this.listCalendario.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listCalendario.MouseState = MaterialSkin.MouseState.OUT;
            this.listCalendario.Name = "listCalendario";
            this.listCalendario.OwnerDraw = true;
            this.listCalendario.Size = new System.Drawing.Size(672, 278);
            this.listCalendario.TabIndex = 0;
            this.listCalendario.UseCompatibleStateImageBehavior = false;
            this.listCalendario.View = System.Windows.Forms.View.Details;
            this.listCalendario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListCalendario_KeyDown);
            // 
            // headerID
            // 
            this.headerID.Text = "ID";
            // 
            // headerData
            // 
            this.headerData.Text = "Data";
            this.headerData.Width = 109;
            // 
            // headerOra
            // 
            this.headerOra.Text = "Ora";
            this.headerOra.Width = 76;
            // 
            // headerLuogo
            // 
            this.headerLuogo.Text = "Luogo";
            this.headerLuogo.Width = 114;
            // 
            // headerOggetto
            // 
            this.headerOggetto.Text = "Oggetto";
            this.headerOggetto.Width = 165;
            // 
            // headerConChi
            // 
            this.headerConChi.Text = "Con chi";
            this.headerConChi.Width = 176;
            // 
            // dateTimePickerDa
            // 
            this.dateTimePickerDa.CustomFormat = "dd/mm/YYYY";
            this.dateTimePickerDa.Location = new System.Drawing.Point(68, 68);
            this.dateTimePickerDa.Name = "dateTimePickerDa";
            this.dateTimePickerDa.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDa.TabIndex = 1;
            // 
            // dateTimePickerA
            // 
            this.dateTimePickerA.Location = new System.Drawing.Point(68, 94);
            this.dateTimePickerA.Name = "dateTimePickerA";
            this.dateTimePickerA.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerA.TabIndex = 2;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(35, 68);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(27, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Da";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(35, 94);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(19, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "A";
            // 
            // VisualizzaCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 414);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dateTimePickerA);
            this.Controls.Add(this.dateTimePickerDa);
            this.Controls.Add(this.listCalendario);
            this.Name = "VisualizzaCalendario";
            this.Text = "VisualizzaCalendario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView listCalendario;
        private System.Windows.Forms.ColumnHeader headerData;
        private System.Windows.Forms.ColumnHeader headerLuogo;
        private System.Windows.Forms.ColumnHeader headerOggetto;
        private System.Windows.Forms.ColumnHeader headerConChi;
        private System.Windows.Forms.DateTimePicker dateTimePickerDa;
        private System.Windows.Forms.DateTimePicker dateTimePickerA;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ColumnHeader headerOra;
        private System.Windows.Forms.ColumnHeader headerID;
    }
}