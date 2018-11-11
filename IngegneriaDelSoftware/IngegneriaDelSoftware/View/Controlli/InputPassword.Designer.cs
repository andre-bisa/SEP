namespace IngegneriaDelSoftware.View.Controlli
{
    partial class InputPassword
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
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBoxVisibilityPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisibilityPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Depth = 0;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Hint = "Password";
            this.txtPassword.Location = new System.Drawing.Point(0, 0);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // pictureBoxVisibilityPassword
            // 
            this.pictureBoxVisibilityPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxVisibilityPassword.BackgroundImage = global::IngegneriaDelSoftware.Properties.Resources.ic_visibility_black_18dp;
            this.pictureBoxVisibilityPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxVisibilityPassword.Location = new System.Drawing.Point(182, 0);
            this.pictureBoxVisibilityPassword.Name = "pictureBoxVisibilityPassword";
            this.pictureBoxVisibilityPassword.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxVisibilityPassword.TabIndex = 15;
            this.pictureBoxVisibilityPassword.TabStop = false;
            this.pictureBoxVisibilityPassword.Click += new System.EventHandler(this.pictureBoxVisibilityPassword_Click);
            // 
            // InputPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxVisibilityPassword);
            this.Controls.Add(this.txtPassword);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1000, 23);
            this.MinimumSize = new System.Drawing.Size(0, 23);
            this.Name = "InputPassword";
            this.Size = new System.Drawing.Size(200, 23);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisibilityPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private System.Windows.Forms.PictureBox pictureBoxVisibilityPassword;
    }
}
