namespace IngegneriaDelSoftware.View {
    partial class GetPreventivoForm {
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
            this.PreventiviList = new MaterialSkin.Controls.MaterialListView();
            this.Cliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelezionaBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.AnnullaBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ClientiList
            // 
            this.PreventiviList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreventiviList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PreventiviList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Cliente,
            this.columnHeader1});
            this.PreventiviList.Depth = 0;
            this.PreventiviList.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.PreventiviList.FullRowSelect = true;
            this.PreventiviList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PreventiviList.Location = new System.Drawing.Point(12, 119);
            this.PreventiviList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.PreventiviList.MouseState = MaterialSkin.MouseState.OUT;
            this.PreventiviList.Name = "ClientiList";
            this.PreventiviList.OwnerDraw = true;
            this.PreventiviList.Size = new System.Drawing.Size(918, 304);
            this.PreventiviList.TabIndex = 0;
            this.PreventiviList.UseCompatibleStateImageBehavior = false;
            this.PreventiviList.View = System.Windows.Forms.View.Details;
            this.PreventiviList.SelectedIndexChanged += new System.EventHandler(this.ClientiList_SelectedIndexChanged);
            // 
            // Cliente
            // 
            this.Cliente.Text = "Vendita";
            this.Cliente.Width = 508;
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
            // columnHeader1
            // 
            this.columnHeader1.Text = "Cliente";
            this.columnHeader1.Width = 388;
            // 
            // GetVenditaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 483);
            this.Controls.Add(this.AnnullaBtn);
            this.Controls.Add(this.SelezionaBtn);
            this.Controls.Add(this.PreventiviList);
            this.Name = "GetVenditaForm";
            this.Text = "Seleziona le vendite desiderate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView PreventiviList;
        private MaterialSkin.Controls.MaterialRaisedButton SelezionaBtn;
        private MaterialSkin.Controls.MaterialFlatButton AnnullaBtn;
        private System.Windows.Forms.ColumnHeader Cliente;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}