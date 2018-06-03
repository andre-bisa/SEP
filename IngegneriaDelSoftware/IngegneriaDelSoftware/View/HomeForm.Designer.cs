namespace IngegneriaDelSoftware.View {
    partial class HomeForm {
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
            this.backGroundPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.venditeBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.preventiviBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.calendarioBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.fattureBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.emailBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.clientiBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.appuntamentoBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.syncBtn = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.AppunamentiList = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backGroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backGroundPanel
            // 
            this.backGroundPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backGroundPanel.BackColor = System.Drawing.Color.White;
            this.backGroundPanel.Controls.Add(this.splitContainer1);
            this.backGroundPanel.Location = new System.Drawing.Point(12, 66);
            this.backGroundPanel.Name = "backGroundPanel";
            this.backGroundPanel.Size = new System.Drawing.Size(688, 369);
            this.backGroundPanel.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.venditeBtn);
            this.splitContainer1.Panel1.Controls.Add(this.preventiviBtn);
            this.splitContainer1.Panel1.Controls.Add(this.calendarioBtn);
            this.splitContainer1.Panel1.Controls.Add(this.fattureBtn);
            this.splitContainer1.Panel1.Controls.Add(this.materialDivider1);
            this.splitContainer1.Panel1.Controls.Add(this.emailBtn);
            this.splitContainer1.Panel1.Controls.Add(this.clientiBtn);
            this.splitContainer1.Panel1.Controls.Add(this.appuntamentoBtn);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.syncBtn);
            this.splitContainer1.Panel2.Controls.Add(this.AppunamentiList);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(688, 369);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // venditeBtn
            // 
            this.venditeBtn.AutoSize = true;
            this.venditeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.venditeBtn.Depth = 0;
            this.venditeBtn.Icon = null;
            this.venditeBtn.Location = new System.Drawing.Point(16, 306);
            this.venditeBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.venditeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.venditeBtn.Name = "venditeBtn";
            this.venditeBtn.Primary = true;
            this.venditeBtn.Size = new System.Drawing.Size(76, 36);
            this.venditeBtn.TabIndex = 7;
            this.venditeBtn.Text = "Vendite";
            this.venditeBtn.UseVisualStyleBackColor = true;
            this.venditeBtn.Click += new System.EventHandler(this.venditeBtn_Click);
            // 
            // preventiviBtn
            // 
            this.preventiviBtn.AutoSize = true;
            this.preventiviBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.preventiviBtn.Depth = 0;
            this.preventiviBtn.Icon = null;
            this.preventiviBtn.Location = new System.Drawing.Point(16, 258);
            this.preventiviBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.preventiviBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.preventiviBtn.Name = "preventiviBtn";
            this.preventiviBtn.Primary = true;
            this.preventiviBtn.Size = new System.Drawing.Size(97, 36);
            this.preventiviBtn.TabIndex = 6;
            this.preventiviBtn.Text = "preventivi";
            this.preventiviBtn.UseVisualStyleBackColor = true;
            this.preventiviBtn.Click += new System.EventHandler(this.preventiviBtn_Click);
            // 
            // calendarioBtn
            // 
            this.calendarioBtn.AutoSize = true;
            this.calendarioBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calendarioBtn.Depth = 0;
            this.calendarioBtn.Icon = null;
            this.calendarioBtn.Location = new System.Drawing.Point(16, 114);
            this.calendarioBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.calendarioBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.calendarioBtn.Name = "calendarioBtn";
            this.calendarioBtn.Primary = true;
            this.calendarioBtn.Size = new System.Drawing.Size(104, 36);
            this.calendarioBtn.TabIndex = 5;
            this.calendarioBtn.Text = "Calendario";
            this.calendarioBtn.UseVisualStyleBackColor = true;
            this.calendarioBtn.Click += new System.EventHandler(this.calendarioBtn_Click);
            // 
            // fattureBtn
            // 
            this.fattureBtn.AutoSize = true;
            this.fattureBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fattureBtn.Depth = 0;
            this.fattureBtn.Icon = null;
            this.fattureBtn.Location = new System.Drawing.Point(16, 210);
            this.fattureBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fattureBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.fattureBtn.Name = "fattureBtn";
            this.fattureBtn.Primary = true;
            this.fattureBtn.Size = new System.Drawing.Size(80, 36);
            this.fattureBtn.TabIndex = 4;
            this.fattureBtn.Text = "Fatture";
            this.fattureBtn.UseVisualStyleBackColor = true;
            this.fattureBtn.Click += new System.EventHandler(this.fattureBtn_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Dock = System.Windows.Forms.DockStyle.Right;
            this.materialDivider1.Location = new System.Drawing.Point(197, 0);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(3, 369);
            this.materialDivider1.TabIndex = 3;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // emailBtn
            // 
            this.emailBtn.AutoSize = true;
            this.emailBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.emailBtn.Depth = 0;
            this.emailBtn.Icon = null;
            this.emailBtn.Location = new System.Drawing.Point(16, 162);
            this.emailBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.emailBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.emailBtn.Name = "emailBtn";
            this.emailBtn.Primary = true;
            this.emailBtn.Size = new System.Drawing.Size(61, 36);
            this.emailBtn.TabIndex = 2;
            this.emailBtn.Text = "Email";
            this.emailBtn.UseVisualStyleBackColor = true;
            this.emailBtn.Click += new System.EventHandler(this.emailBtn_Click);
            // 
            // clientiBtn
            // 
            this.clientiBtn.AutoSize = true;
            this.clientiBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.clientiBtn.Depth = 0;
            this.clientiBtn.Icon = null;
            this.clientiBtn.Location = new System.Drawing.Point(16, 66);
            this.clientiBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.clientiBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.clientiBtn.Name = "clientiBtn";
            this.clientiBtn.Primary = true;
            this.clientiBtn.Size = new System.Drawing.Size(71, 36);
            this.clientiBtn.TabIndex = 1;
            this.clientiBtn.Text = "Clienti";
            this.clientiBtn.UseVisualStyleBackColor = true;
            this.clientiBtn.Click += new System.EventHandler(this.clientiBtn_Click);
            // 
            // appuntamentoBtn
            // 
            this.appuntamentoBtn.AutoSize = true;
            this.appuntamentoBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.appuntamentoBtn.Depth = 0;
            this.appuntamentoBtn.Icon = null;
            this.appuntamentoBtn.Location = new System.Drawing.Point(16, 18);
            this.appuntamentoBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.appuntamentoBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.appuntamentoBtn.Name = "appuntamentoBtn";
            this.appuntamentoBtn.Primary = true;
            this.appuntamentoBtn.Size = new System.Drawing.Size(126, 36);
            this.appuntamentoBtn.TabIndex = 0;
            this.appuntamentoBtn.Text = "Appuntamenti";
            this.appuntamentoBtn.UseVisualStyleBackColor = true;
            this.appuntamentoBtn.Click += new System.EventHandler(this.appuntamentoBtn_Click);
            // 
            // syncBtn
            // 
            this.syncBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.syncBtn.AnimateIcon = false;
            this.syncBtn.AnimateShowHideButton = false;
            this.syncBtn.Depth = 0;
            this.syncBtn.Icon = global::IngegneriaDelSoftware.Properties.Resources.ic_settings_black_48dp;
            this.syncBtn.Location = new System.Drawing.Point(414, 297);
            this.syncBtn.Mini = false;
            this.syncBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.syncBtn.Name = "syncBtn";
            this.syncBtn.Size = new System.Drawing.Size(56, 56);
            this.syncBtn.TabIndex = 5;
            this.syncBtn.Text = "materialFloatingActionButton1";
            this.syncBtn.UseVisualStyleBackColor = true;
            this.syncBtn.Click += new System.EventHandler(this.syncBtn_Click);
            // 
            // AppunamentiList
            // 
            this.AppunamentiList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AppunamentiList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.AppunamentiList.Depth = 0;
            this.AppunamentiList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppunamentiList.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.AppunamentiList.FullRowSelect = true;
            this.AppunamentiList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AppunamentiList.Location = new System.Drawing.Point(0, 0);
            this.AppunamentiList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AppunamentiList.MouseState = MaterialSkin.MouseState.OUT;
            this.AppunamentiList.Name = "AppunamentiList";
            this.AppunamentiList.OwnerDraw = true;
            this.AppunamentiList.Size = new System.Drawing.Size(484, 369);
            this.AppunamentiList.TabIndex = 6;
            this.AppunamentiList.UseCompatibleStateImageBehavior = false;
            this.AppunamentiList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Appuntamento";
            this.columnHeader1.Width = 169;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Con chi";
            this.columnHeader2.Width = 162;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Luogo";
            this.columnHeader3.Width = 152;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 447);
            this.Controls.Add(this.backGroundPanel);
            this.Name = "HomeForm";
            this.Text = "Home";
            this.backGroundPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel backGroundPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MaterialSkin.Controls.MaterialFlatButton emailBtn;
        private MaterialSkin.Controls.MaterialFlatButton clientiBtn;
        private MaterialSkin.Controls.MaterialFlatButton appuntamentoBtn;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialFlatButton venditeBtn;
        private MaterialSkin.Controls.MaterialFlatButton preventiviBtn;
        private MaterialSkin.Controls.MaterialFlatButton calendarioBtn;
        private MaterialSkin.Controls.MaterialFlatButton fattureBtn;
        private MaterialSkin.Controls.MaterialFloatingActionButton syncBtn;
        private MaterialSkin.Controls.MaterialListView AppunamentiList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}