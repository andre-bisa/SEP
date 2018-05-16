namespace IngegneriaDelSoftware.View.Overlay
{
    partial class Overlay
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
            System.Windows.Forms.Panel panelLabelX;
            System.Windows.Forms.Panel panelFillDocked;
            System.Windows.Forms.Panel panelContent;
            System.Windows.Forms.Panel panelContainer;
            System.Windows.Forms.Panel panelTitle;
            this.lblClose = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblTitolo = new MaterialSkin.Controls.MaterialLabel();
            panelLabelX = new System.Windows.Forms.Panel();
            panelFillDocked = new System.Windows.Forms.Panel();
            panelContent = new System.Windows.Forms.Panel();
            panelContainer = new System.Windows.Forms.Panel();
            panelTitle = new System.Windows.Forms.Panel();
            panelLabelX.SuspendLayout();
            panelFillDocked.SuspendLayout();
            panelContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            panelContainer.SuspendLayout();
            panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLabelX
            // 
            panelLabelX.BackColor = System.Drawing.Color.Transparent;
            panelLabelX.Controls.Add(this.lblClose);
            panelLabelX.Dock = System.Windows.Forms.DockStyle.Right;
            panelLabelX.Location = new System.Drawing.Point(370, 0);
            panelLabelX.Margin = new System.Windows.Forms.Padding(0);
            panelLabelX.Name = "panelLabelX";
            panelLabelX.Size = new System.Drawing.Size(30, 30);
            panelLabelX.TabIndex = 0;
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Red;
            this.lblClose.Depth = 0;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClose.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblClose.Location = new System.Drawing.Point(0, 0);
            this.lblClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(30, 30);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.LblClose_Click);
            // 
            // panelFillDocked
            // 
            panelFillDocked.BackColor = System.Drawing.Color.Transparent;
            panelFillDocked.Controls.Add(panelContent);
            panelFillDocked.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFillDocked.Location = new System.Drawing.Point(0, 0);
            panelFillDocked.Name = "panelFillDocked";
            panelFillDocked.Size = new System.Drawing.Size(500, 500);
            panelFillDocked.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            panelContent.Controls.Add(this.tableLayoutPanel1);
            panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContent.Location = new System.Drawing.Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new System.Drawing.Size(500, 500);
            panelContent.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(panelContainer, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 500);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelContainer
            // 
            panelContainer.AutoScroll = true;
            panelContainer.BackColor = System.Drawing.Color.Transparent;
            panelContainer.Controls.Add(this.mainPanel);
            panelContainer.Controls.Add(panelTitle);
            panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContainer.Location = new System.Drawing.Point(50, 25);
            panelContainer.Margin = new System.Windows.Forms.Padding(0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new System.Drawing.Size(400, 450);
            panelContainer.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.LightYellow;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 30);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(400, 420);
            this.mainPanel.TabIndex = 2;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = System.Drawing.Color.White;
            panelTitle.Controls.Add(this.lblTitolo);
            panelTitle.Controls.Add(panelLabelX);
            panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            panelTitle.Location = new System.Drawing.Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new System.Drawing.Size(400, 30);
            panelTitle.TabIndex = 1;
            // 
            // lblTitolo
            // 
            this.lblTitolo.Depth = 0;
            this.lblTitolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitolo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTitolo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitolo.Location = new System.Drawing.Point(0, 0);
            this.lblTitolo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(370, 30);
            this.lblTitolo.TabIndex = 1;
            this.lblTitolo.Text = "Titolo";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(panelFillDocked);
            this.Name = "Overlay";
            this.Size = new System.Drawing.Size(500, 500);
            panelLabelX.ResumeLayout(false);
            panelFillDocked.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            panelContainer.ResumeLayout(false);
            panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblClose;
        private System.Windows.Forms.Panel mainPanel;
        private MaterialSkin.Controls.MaterialLabel lblTitolo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
