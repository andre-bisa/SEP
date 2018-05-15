namespace IngegneriaDelSoftware.View
{
    partial class VisualizzaCalendario
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
            this.listCalendario = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimePickerDa = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerA = new System.Windows.Forms.DateTimePicker();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // listCalendario
            // 
            this.listCalendario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listCalendario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listCalendario.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listCalendario.Depth = 0;
            this.listCalendario.Enabled = false;
            this.listCalendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listCalendario.FullRowSelect = true;
            this.listCalendario.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listCalendario.Location = new System.Drawing.Point(12, 124);
            this.listCalendario.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listCalendario.MouseState = MaterialSkin.MouseState.OUT;
            this.listCalendario.Name = "listCalendario";
            this.listCalendario.OwnerDraw = true;
            this.listCalendario.Size = new System.Drawing.Size(564, 256);
            this.listCalendario.TabIndex = 0;
            this.listCalendario.UseCompatibleStateImageBehavior = false;
            this.listCalendario.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Data";
            this.columnHeader1.Width = 127;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Luogo";
            this.columnHeader2.Width = 114;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Oggetto";
            this.columnHeader3.Width = 165;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Con chi";
            this.columnHeader4.Width = 152;
            // 
            // dateTimePickerDa
            // 
            this.dateTimePickerDa.Location = new System.Drawing.Point(68, 68);
            this.dateTimePickerDa.Name = "dateTimePickerDa";
            this.dateTimePickerDa.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDa.TabIndex = 1;
            this.dateTimePickerDa.ValueChanged += new System.EventHandler(this.dateTimePickerDa_ValueChanged);
            // 
            // dateTimePickerA
            // 
            this.dateTimePickerA.Location = new System.Drawing.Point(68, 94);
            this.dateTimePickerA.Name = "dateTimePickerA";
            this.dateTimePickerA.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerA.TabIndex = 2;
            this.dateTimePickerA.ValueChanged += new System.EventHandler(this.dateTimePickerA_ValueChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(35, 68);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(27, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Da";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(35, 94);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(19, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "A";
            // 
            // VisualizzaCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 392);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dateTimePickerA);
            this.Controls.Add(this.dateTimePickerDa);
            this.Controls.Add(this.listCalendario);
            this.Name = "VisualizzaCalendario";
            this.Text = "VisualizzaCalendario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView listCalendario;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.DateTimePicker dateTimePickerDa;
        private System.Windows.Forms.DateTimePicker dateTimePickerA;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}