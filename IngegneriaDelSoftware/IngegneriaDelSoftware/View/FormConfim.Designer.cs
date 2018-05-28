namespace IngegneriaDelSoftware.View
{
    partial class FormConfim
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
            System.Windows.Forms.Panel panelMain;
            this.btnAnnulla = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnConferma = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblMessaggio = new MaterialSkin.Controls.MaterialLabel();
            panelMain = new System.Windows.Forms.Panel();
            panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panelMain.Controls.Add(this.btnAnnulla);
            panelMain.Controls.Add(this.btnConferma);
            panelMain.Controls.Add(this.lblMessaggio);
            panelMain.Location = new System.Drawing.Point(3, 64);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(495, 133);
            panelMain.TabIndex = 0;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.AutoSize = true;
            this.btnAnnulla.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAnnulla.Depth = 0;
            this.btnAnnulla.Icon = null;
            this.btnAnnulla.Location = new System.Drawing.Point(301, 88);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAnnulla.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Primary = false;
            this.btnAnnulla.Size = new System.Drawing.Size(83, 36);
            this.btnAnnulla.TabIndex = 2;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnConferma
            // 
            this.btnConferma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConferma.AutoSize = true;
            this.btnConferma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConferma.Depth = 0;
            this.btnConferma.Icon = null;
            this.btnConferma.Location = new System.Drawing.Point(391, 88);
            this.btnConferma.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConferma.Name = "btnConferma";
            this.btnConferma.Primary = true;
            this.btnConferma.Size = new System.Drawing.Size(94, 36);
            this.btnConferma.TabIndex = 1;
            this.btnConferma.Text = "Conferma";
            this.btnConferma.UseVisualStyleBackColor = true;
            this.btnConferma.Click += new System.EventHandler(this.btnConferma_Click);
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessaggio.Depth = 0;
            this.lblMessaggio.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblMessaggio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessaggio.Location = new System.Drawing.Point(2, 0);
            this.lblMessaggio.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(490, 82);
            this.lblMessaggio.TabIndex = 0;
            this.lblMessaggio.Text = "Messaggio";
            this.lblMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormConfim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 200);
            this.Controls.Add(panelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfim";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Titolo";
            this.TopMost = true;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblMessaggio;
        private MaterialSkin.Controls.MaterialFlatButton btnAnnulla;
        private MaterialSkin.Controls.MaterialRaisedButton btnConferma;
    }
}