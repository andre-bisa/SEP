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

namespace IngegneriaDelSoftware.View.Controlli
{
    partial class PannelloCliente
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDenominazione = new MaterialSkin.Controls.MaterialLabel();
            this.lblIndirizzo = new MaterialSkin.Controls.MaterialLabel();
            this.lblReferenti = new MaterialSkin.Controls.MaterialLabel();
            this.lblTelefoni = new MaterialSkin.Controls.MaterialLabel();
            this.lblEmail = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDenominazione.AutoEllipsis = true;
            this.lblDenominazione.Depth = 0;
            this.lblDenominazione.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDenominazione.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDenominazione.Location = new System.Drawing.Point(3, 6);
            this.lblDenominazione.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(242, 25);
            this.lblDenominazione.TabIndex = 0;
            this.lblDenominazione.Text = "Denominazione";
            this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndirizzo
            // 
            this.lblIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIndirizzo.AutoEllipsis = true;
            this.lblIndirizzo.Depth = 0;
            this.lblIndirizzo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblIndirizzo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblIndirizzo.Location = new System.Drawing.Point(3, 31);
            this.lblIndirizzo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblIndirizzo.Name = "lblIndirizzo";
            this.lblIndirizzo.Size = new System.Drawing.Size(242, 25);
            this.lblIndirizzo.TabIndex = 1;
            this.lblIndirizzo.Text = "Indirizzo";
            this.lblIndirizzo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReferenti
            // 
            this.lblReferenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferenti.AutoEllipsis = true;
            this.lblReferenti.Depth = 0;
            this.lblReferenti.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblReferenti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReferenti.Location = new System.Drawing.Point(3, 56);
            this.lblReferenti.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblReferenti.Name = "lblReferenti";
            this.lblReferenti.Size = new System.Drawing.Size(242, 25);
            this.lblReferenti.TabIndex = 2;
            this.lblReferenti.Text = "Referenti";
            this.lblReferenti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTelefoni
            // 
            this.lblTelefoni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelefoni.AutoEllipsis = true;
            this.lblTelefoni.Depth = 0;
            this.lblTelefoni.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTelefoni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTelefoni.Location = new System.Drawing.Point(3, 81);
            this.lblTelefoni.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTelefoni.Name = "lblTelefoni";
            this.lblTelefoni.Size = new System.Drawing.Size(242, 25);
            this.lblTelefoni.TabIndex = 3;
            this.lblTelefoni.Text = "Telefoni";
            this.lblTelefoni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.AutoEllipsis = true;
            this.lblEmail.Depth = 0;
            this.lblEmail.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEmail.Location = new System.Drawing.Point(2, 106);
            this.lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(242, 25);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PannelloCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTelefoni);
            this.Controls.Add(this.lblReferenti);
            this.Controls.Add(this.lblIndirizzo);
            this.Controls.Add(this.lblDenominazione);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PannelloCliente";
            this.Size = new System.Drawing.Size(248, 148);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblDenominazione;
        private MaterialSkin.Controls.MaterialLabel lblIndirizzo;
        private MaterialSkin.Controls.MaterialLabel lblReferenti;
        private MaterialSkin.Controls.MaterialLabel lblTelefoni;
        private MaterialSkin.Controls.MaterialLabel lblEmail;
    }
}
