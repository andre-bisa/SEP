namespace IngegneriaDelSoftware.View {
    partial class GetClienteForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ClientiList = new MaterialSkin.Controls.MaterialListView();
            this.SelezionaBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.AnnullaBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.Cliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ClientiList
            // 
            this.ClientiList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientiList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientiList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Cliente,
            this.CF});
            this.ClientiList.Depth = 0;
            this.ClientiList.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.ClientiList.FullRowSelect = true;
            this.ClientiList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ClientiList.Location = new System.Drawing.Point(12, 119);
            this.ClientiList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ClientiList.MouseState = MaterialSkin.MouseState.OUT;
            this.ClientiList.Name = "ClientiList";
            this.ClientiList.OwnerDraw = true;
            this.ClientiList.Size = new System.Drawing.Size(918, 304);
            this.ClientiList.TabIndex = 0;
            this.ClientiList.UseCompatibleStateImageBehavior = false;
            this.ClientiList.View = System.Windows.Forms.View.Details;
            this.ClientiList.SelectedIndexChanged += new System.EventHandler(this.ClientiList_SelectedIndexChanged);
            // 
            // SelezionaBtn
            // 
            this.SelezionaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelezionaBtn.AutoSize = true;
            this.SelezionaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelezionaBtn.Depth = 0;
            this.SelezionaBtn.Icon = null;
            this.SelezionaBtn.Location = new System.Drawing.Point(837, 432);
            this.SelezionaBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SelezionaBtn.Name = "SelezionaBtn";
            this.SelezionaBtn.Primary = true;
            this.SelezionaBtn.Size = new System.Drawing.Size(93, 36);
            this.SelezionaBtn.TabIndex = 1;
            this.SelezionaBtn.Text = "Seleziona";
            this.SelezionaBtn.UseVisualStyleBackColor = true;
            this.SelezionaBtn.Click += new System.EventHandler(this.SelezionaBtn_Click);
            // 
            // AnnullaBtn
            // 
            this.AnnullaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AnnullaBtn.AutoSize = true;
            this.AnnullaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AnnullaBtn.Depth = 0;
            this.AnnullaBtn.Icon = null;
            this.AnnullaBtn.Location = new System.Drawing.Point(747, 432);
            this.AnnullaBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AnnullaBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AnnullaBtn.Name = "AnnullaBtn";
            this.AnnullaBtn.Primary = false;
            this.AnnullaBtn.Size = new System.Drawing.Size(83, 36);
            this.AnnullaBtn.TabIndex = 2;
            this.AnnullaBtn.Text = "Annulla";
            this.AnnullaBtn.UseVisualStyleBackColor = true;
            this.AnnullaBtn.Click += new System.EventHandler(this.AnnullaBtn_Click);
            // 
            // Cliente
            // 
            this.Cliente.Text = "Cliente";
            this.Cliente.Width = 430;
            // 
            // CF
            // 
            this.CF.Text = "Codice Fiscale";
            this.CF.Width = 308;
            // 
            // GetClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 483);
            this.Controls.Add(this.AnnullaBtn);
            this.Controls.Add(this.SelezionaBtn);
            this.Controls.Add(this.ClientiList);
            this.Name = "GetClienteForm";
            this.Text = "Seleziona il cliente desiderato";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView ClientiList;
        private MaterialSkin.Controls.MaterialRaisedButton SelezionaBtn;
        private MaterialSkin.Controls.MaterialFlatButton AnnullaBtn;
        private System.Windows.Forms.ColumnHeader Cliente;
        private System.Windows.Forms.ColumnHeader CF;
    }
}