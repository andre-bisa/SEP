namespace IngegneriaDelSoftware.View.Controlli
{
    partial class VisualizzatoreColonnaClienti
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
            System.Windows.Forms.Panel panelSchedeClienteGenerico;
            System.Windows.Forms.Panel panelSearchBar;
            System.Windows.Forms.Panel panelSearchBarIcon;
            this.flowClienti = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearchBar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            panelSchedeClienteGenerico = new System.Windows.Forms.Panel();
            panelSearchBar = new System.Windows.Forms.Panel();
            panelSearchBarIcon = new System.Windows.Forms.Panel();
            panelSchedeClienteGenerico.SuspendLayout();
            this.panel1.SuspendLayout();
            panelSearchBar.SuspendLayout();
            panelSearchBarIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSchedeClienteGenerico
            // 
            panelSchedeClienteGenerico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panelSchedeClienteGenerico.Controls.Add(this.flowClienti);
            panelSchedeClienteGenerico.Controls.Add(this.panel1);
            panelSchedeClienteGenerico.Location = new System.Drawing.Point(0, 0);
            panelSchedeClienteGenerico.Name = "panelSchedeClienteGenerico";
            panelSchedeClienteGenerico.Size = new System.Drawing.Size(230, 300);
            panelSchedeClienteGenerico.TabIndex = 2;
            // 
            // flowClienti
            // 
            this.flowClienti.AutoScroll = true;
            this.flowClienti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowClienti.Location = new System.Drawing.Point(0, 36);
            this.flowClienti.Name = "flowClienti";
            this.flowClienti.Size = new System.Drawing.Size(230, 264);
            this.flowClienti.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(panelSearchBar);
            this.panel1.Controls.Add(panelSearchBarIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 36);
            this.panel1.TabIndex = 0;
            // 
            // panelSearchBar
            // 
            panelSearchBar.Controls.Add(this.txtSearchBar);
            panelSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSearchBar.Location = new System.Drawing.Point(0, 0);
            panelSearchBar.Name = "panelSearchBar";
            panelSearchBar.Size = new System.Drawing.Size(194, 36);
            panelSearchBar.TabIndex = 1;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Depth = 0;
            this.txtSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchBar.Hint = "Search";
            this.txtSearchBar.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBar.MaxLength = 32767;
            this.txtSearchBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.PasswordChar = '\0';
            this.txtSearchBar.SelectedText = "";
            this.txtSearchBar.SelectionLength = 0;
            this.txtSearchBar.SelectionStart = 0;
            this.txtSearchBar.Size = new System.Drawing.Size(194, 23);
            this.txtSearchBar.TabIndex = 0;
            this.txtSearchBar.TabStop = false;
            this.txtSearchBar.UseSystemPasswordChar = false;
            // 
            // panelSearchBarIcon
            // 
            panelSearchBarIcon.Controls.Add(this.pictureBox1);
            panelSearchBarIcon.Dock = System.Windows.Forms.DockStyle.Right;
            panelSearchBarIcon.Location = new System.Drawing.Point(194, 0);
            panelSearchBarIcon.Name = "panelSearchBarIcon";
            panelSearchBarIcon.Size = new System.Drawing.Size(36, 36);
            panelSearchBarIcon.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::IngegneriaDelSoftware.Properties.Resources.ic_search_black_24dp;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.SearchPicture_Click);
            // 
            // VisualizzatoreColonnaClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(panelSchedeClienteGenerico);
            this.Name = "VisualizzatoreColonnaClienti";
            this.Size = new System.Drawing.Size(230, 300);
            this.Load += new System.EventHandler(this.OnLoad);
            panelSchedeClienteGenerico.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            panelSearchBar.ResumeLayout(false);
            panelSearchBarIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowClienti;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSearchBar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
