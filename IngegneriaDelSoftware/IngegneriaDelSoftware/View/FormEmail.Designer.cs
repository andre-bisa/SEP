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
            System.Windows.Forms.Panel panelSchedeClienteGenerico;
            System.Windows.Forms.Panel panelSearchBar;
            System.Windows.Forms.Panel panelSearchBarIcon;
            System.Windows.Forms.TabPage tabMailInviate;
            System.Windows.Forms.Panel panelMailInviate;
            MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
            this.btnAnnulla = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnInvia = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtCorpo = new System.Windows.Forms.TextBox();
            this.txtOggetto = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.flowClienti = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearchBar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.ListaData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListaOggetto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListaDestinatario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListaCorpo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelForm = new System.Windows.Forms.Panel();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabInviaMail = new System.Windows.Forms.TabPage();
            panelInviaMail = new System.Windows.Forms.Panel();
            panelInvioMailPrincipale = new System.Windows.Forms.Panel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            panelSchedeClienteGenerico = new System.Windows.Forms.Panel();
            panelSearchBar = new System.Windows.Forms.Panel();
            panelSearchBarIcon = new System.Windows.Forms.Panel();
            tabMailInviate = new System.Windows.Forms.TabPage();
            panelMailInviate = new System.Windows.Forms.Panel();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            materialTabControl1.SuspendLayout();
            tabInviaMail.SuspendLayout();
            panelInviaMail.SuspendLayout();
            panelInvioMailPrincipale.SuspendLayout();
            panelSchedeClienteGenerico.SuspendLayout();
            this.panel1.SuspendLayout();
            panelSearchBar.SuspendLayout();
            panelSearchBarIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            panelInviaMail.Controls.Add(panelInvioMailPrincipale);
            panelInviaMail.Controls.Add(panelSchedeClienteGenerico);
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
            this.btnAnnulla.Primary = false;
            this.btnAnnulla.Size = new System.Drawing.Size(83, 36);
            this.btnAnnulla.TabIndex = 5;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
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
            this.txtCorpo.Size = new System.Drawing.Size(494, 137);
            this.txtCorpo.TabIndex = 3;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel2.Location = new System.Drawing.Point(18, 82);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(50, 19);
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
            this.txtOggetto.Size = new System.Drawing.Size(495, 23);
            this.txtOggetto.TabIndex = 1;
            this.txtOggetto.TabStop = false;
            this.txtOggetto.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel1.Location = new System.Drawing.Point(18, 17);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(62, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Oggetto";
            // 
            // panelSchedeClienteGenerico
            // 
            panelSchedeClienteGenerico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            panelSchedeClienteGenerico.Controls.Add(this.flowClienti);
            panelSchedeClienteGenerico.Controls.Add(this.panel1);
            panelSchedeClienteGenerico.Location = new System.Drawing.Point(4, 3);
            panelSchedeClienteGenerico.Name = "panelSchedeClienteGenerico";
            panelSchedeClienteGenerico.Size = new System.Drawing.Size(230, 289);
            panelSchedeClienteGenerico.TabIndex = 1;
            // 
            // flowClienti
            // 
            this.flowClienti.AutoScroll = true;
            this.flowClienti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowClienti.Location = new System.Drawing.Point(0, 36);
            this.flowClienti.Name = "flowClienti";
            this.flowClienti.Size = new System.Drawing.Size(230, 253);
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
            panelMailInviate.Controls.Add(this.materialListView1);
            panelMailInviate.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMailInviate.Location = new System.Drawing.Point(3, 3);
            panelMailInviate.Name = "panelMailInviate";
            panelMailInviate.Size = new System.Drawing.Size(778, 295);
            panelMailInviate.TabIndex = 0;
            // 
            // materialListView1
            // 
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListaData,
            this.ListaOggetto,
            this.ListaDestinatario,
            this.ListaCorpo});
            this.materialListView1.Depth = 0;
            this.materialListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.materialListView1.FullRowSelect = true;
            this.materialListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.materialListView1.Location = new System.Drawing.Point(0, 0);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.Size = new System.Drawing.Size(778, 295);
            this.materialListView1.TabIndex = 0;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
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
            panelSchedeClienteGenerico.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            panelSearchBar.ResumeLayout(false);
            panelSearchBarIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            tabMailInviate.ResumeLayout(false);
            panelMailInviate.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelForm;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private System.Windows.Forms.ColumnHeader ListaData;
        private System.Windows.Forms.ColumnHeader ListaOggetto;
        private System.Windows.Forms.ColumnHeader ListaDestinatario;
        private System.Windows.Forms.ColumnHeader ListaCorpo;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSearchBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowClienti;
        private MaterialSkin.Controls.MaterialFlatButton btnAnnulla;
        private MaterialSkin.Controls.MaterialRaisedButton btnInvia;
        private System.Windows.Forms.TextBox txtCorpo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtOggetto;
    }
}