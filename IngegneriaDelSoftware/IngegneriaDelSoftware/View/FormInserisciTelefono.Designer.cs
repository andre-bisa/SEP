namespace IngegneriaDelSoftware.View
{
    partial class FormInserisciTelefono
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
            MaterialSkin.Controls.MaterialLabel materialLabel1;
            MaterialSkin.Controls.MaterialLabel materialLabel2;
            this.txtTelefono = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.BtnSalva = new MaterialSkin.Controls.MaterialRaisedButton();
            this.BtnCancella = new MaterialSkin.Controls.MaterialFlatButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel1.Location = new System.Drawing.Point(12, 72);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(69, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Telefono";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel2.Location = new System.Drawing.Point(265, 72);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(42, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Nota";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Depth = 0;
            this.txtTelefono.Hint = "";
            this.txtTelefono.Location = new System.Drawing.Point(25, 94);
            this.txtTelefono.MaxLength = 32767;
            this.txtTelefono.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PasswordChar = '\0';
            this.txtTelefono.SelectedText = "";
            this.txtTelefono.SelectionLength = 0;
            this.txtTelefono.SelectionStart = 0;
            this.txtTelefono.Size = new System.Drawing.Size(200, 23);
            this.txtTelefono.TabIndex = 1;
            this.txtTelefono.TabStop = false;
            this.txtTelefono.UseSystemPasswordChar = false;
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(279, 97);
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(250, 100);
            this.txtNota.TabIndex = 3;
            // 
            // BtnSalva
            // 
            this.BtnSalva.AutoSize = true;
            this.BtnSalva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnSalva.Depth = 0;
            this.BtnSalva.Icon = null;
            this.BtnSalva.Location = new System.Drawing.Point(61, 202);
            this.BtnSalva.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnSalva.Name = "BtnSalva";
            this.BtnSalva.Primary = true;
            this.BtnSalva.Size = new System.Drawing.Size(64, 36);
            this.BtnSalva.TabIndex = 4;
            this.BtnSalva.Text = "Salva";
            this.BtnSalva.UseVisualStyleBackColor = true;
            this.BtnSalva.Click += new System.EventHandler(this.BtnSalva_Click);
            // 
            // BtnCancella
            // 
            this.BtnCancella.AutoSize = true;
            this.BtnCancella.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCancella.Depth = 0;
            this.BtnCancella.Icon = null;
            this.BtnCancella.Location = new System.Drawing.Point(145, 202);
            this.BtnCancella.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnCancella.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnCancella.Name = "BtnCancella";
            this.BtnCancella.Primary = true;
            this.BtnCancella.Size = new System.Drawing.Size(90, 36);
            this.BtnCancella.TabIndex = 5;
            this.BtnCancella.Text = "Cancella";
            this.BtnCancella.UseVisualStyleBackColor = true;
            this.BtnCancella.Click += new System.EventHandler(this.BtnCancella_Click);
            // 
            // FormInserisciTelefono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 250);
            this.Controls.Add(this.BtnCancella);
            this.Controls.Add(this.BtnSalva);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(materialLabel2);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(materialLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInserisciTelefono";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.Text = "Inserisci Telefono";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtTelefono;
        private System.Windows.Forms.TextBox txtNota;
        private MaterialSkin.Controls.MaterialRaisedButton BtnSalva;
        private MaterialSkin.Controls.MaterialFlatButton BtnCancella;
    }
}