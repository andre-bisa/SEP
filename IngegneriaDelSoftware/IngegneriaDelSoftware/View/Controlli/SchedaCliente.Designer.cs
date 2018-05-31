namespace IngegneriaDelSoftware.View.Controlli
{
    partial class SchedaCliente
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
            this.checkScheda = new MaterialSkin.Controls.MaterialCheckBox();
            this.lblDenominazione = new MaterialSkin.Controls.MaterialLabel();
            this.lblIndirizzo = new MaterialSkin.Controls.MaterialLabel();
            this.lblEmail = new MaterialSkin.Controls.MaterialLabel();
            this.lblEspandi = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblEspandi)).BeginInit();
            this.SuspendLayout();
            // 
            // checkScheda
            // 
            this.checkScheda.AutoSize = true;
            this.checkScheda.Depth = 0;
            this.checkScheda.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkScheda.Location = new System.Drawing.Point(0, 60);
            this.checkScheda.Margin = new System.Windows.Forms.Padding(0);
            this.checkScheda.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkScheda.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkScheda.Name = "checkScheda";
            this.checkScheda.Ripple = true;
            this.checkScheda.Size = new System.Drawing.Size(26, 30);
            this.checkScheda.TabIndex = 0;
            this.checkScheda.UseVisualStyleBackColor = true;
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.AutoEllipsis = true;
            this.lblDenominazione.Depth = 0;
            this.lblDenominazione.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDenominazione.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDenominazione.Location = new System.Drawing.Point(3, 6);
            this.lblDenominazione.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(194, 25);
            this.lblDenominazione.TabIndex = 1;
            this.lblDenominazione.Text = "Denominazione";
            this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndirizzo
            // 
            this.lblIndirizzo.AutoEllipsis = true;
            this.lblIndirizzo.Depth = 0;
            this.lblIndirizzo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblIndirizzo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblIndirizzo.Location = new System.Drawing.Point(-4, 31);
            this.lblIndirizzo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblIndirizzo.Name = "lblIndirizzo";
            this.lblIndirizzo.Size = new System.Drawing.Size(194, 25);
            this.lblIndirizzo.TabIndex = 2;
            this.lblIndirizzo.Text = "Indirizzo";
            this.lblIndirizzo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoEllipsis = true;
            this.lblEmail.Depth = 0;
            this.lblEmail.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEmail.Location = new System.Drawing.Point(3, 90);
            this.lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(194, 25);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEspandi
            // 
            this.lblEspandi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEspandi.Image = global::IngegneriaDelSoftware.Properties.Resources.ic_aspect_ratio_black_48dp;
            this.lblEspandi.Location = new System.Drawing.Point(161, 111);
            this.lblEspandi.Name = "lblEspandi";
            this.lblEspandi.Size = new System.Drawing.Size(36, 36);
            this.lblEspandi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblEspandi.TabIndex = 4;
            this.lblEspandi.TabStop = false;
            this.lblEspandi.Click += new System.EventHandler(this.LblEspandi_Click);
            // 
            // SchedaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lblEspandi);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblIndirizzo);
            this.Controls.Add(this.lblDenominazione);
            this.Controls.Add(this.checkScheda);
            this.Name = "SchedaCliente";
            this.Size = new System.Drawing.Size(200, 150);
            ((System.ComponentModel.ISupportInitialize)(this.lblEspandi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckBox checkScheda;
        private MaterialSkin.Controls.MaterialLabel lblDenominazione;
        private MaterialSkin.Controls.MaterialLabel lblIndirizzo;
        private MaterialSkin.Controls.MaterialLabel lblEmail;
        private System.Windows.Forms.PictureBox lblEspandi;
    }
}
