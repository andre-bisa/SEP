namespace IngegneriaDelSoftware.Graphics
{
    partial class FormAppuntamenti
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
            MaterialSkin.Controls.MaterialLabel materialLabel3;
            MaterialSkin.Controls.MaterialLabel materialLabel4;
            this.txtLuogoAppuntamento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.dataAppuntamento = new System.Windows.Forms.DateTimePicker();
            this.txtNoteAppuntamento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnAggiungi = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton3 = new MaterialSkin.Controls.MaterialRaisedButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.BackColor = System.Drawing.Color.Transparent;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel1.Location = new System.Drawing.Point(12, 97);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(212, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Creazione di un appuntamento";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.BackColor = System.Drawing.Color.Transparent;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel2.Location = new System.Drawing.Point(12, 223);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(51, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Luogo";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.BackColor = System.Drawing.Color.Transparent;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel3.Location = new System.Drawing.Point(12, 159);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new System.Drawing.Size(78, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "Data e ora";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.BackColor = System.Drawing.Color.Transparent;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel4.Location = new System.Drawing.Point(12, 288);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new System.Drawing.Size(42, 19);
            materialLabel4.TabIndex = 6;
            materialLabel4.Text = "Note";
            // 
            // txtLuogoAppuntamento
            // 
            this.txtLuogoAppuntamento.Depth = 0;
            this.txtLuogoAppuntamento.Hint = "Luogo";
            this.txtLuogoAppuntamento.Location = new System.Drawing.Point(160, 219);
            this.txtLuogoAppuntamento.MaxLength = 32767;
            this.txtLuogoAppuntamento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLuogoAppuntamento.Name = "txtLuogoAppuntamento";
            this.txtLuogoAppuntamento.PasswordChar = '\0';
            this.txtLuogoAppuntamento.SelectedText = "";
            this.txtLuogoAppuntamento.SelectionLength = 0;
            this.txtLuogoAppuntamento.SelectionStart = 0;
            this.txtLuogoAppuntamento.Size = new System.Drawing.Size(183, 23);
            this.txtLuogoAppuntamento.TabIndex = 2;
            this.txtLuogoAppuntamento.TabStop = false;
            this.txtLuogoAppuntamento.UseSystemPasswordChar = false;
            // 
            // dataAppuntamento
            // 
            this.dataAppuntamento.CustomFormat = "dd/MM/yyyy";
            this.dataAppuntamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataAppuntamento.Location = new System.Drawing.Point(160, 159);
            this.dataAppuntamento.Name = "dataAppuntamento";
            this.dataAppuntamento.Size = new System.Drawing.Size(183, 20);
            this.dataAppuntamento.TabIndex = 1;
            // 
            // txtNoteAppuntamento
            // 
            this.txtNoteAppuntamento.Depth = 0;
            this.txtNoteAppuntamento.Hint = "Note";
            this.txtNoteAppuntamento.Location = new System.Drawing.Point(160, 284);
            this.txtNoteAppuntamento.MaxLength = 32767;
            this.txtNoteAppuntamento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNoteAppuntamento.Name = "txtNoteAppuntamento";
            this.txtNoteAppuntamento.PasswordChar = '\0';
            this.txtNoteAppuntamento.SelectedText = "";
            this.txtNoteAppuntamento.SelectionLength = 0;
            this.txtNoteAppuntamento.SelectionStart = 0;
            this.txtNoteAppuntamento.Size = new System.Drawing.Size(183, 23);
            this.txtNoteAppuntamento.TabIndex = 3;
            this.txtNoteAppuntamento.TabStop = false;
            this.txtNoteAppuntamento.UseSystemPasswordChar = false;
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.AnimateIcon = true;
            this.btnAggiungi.AnimateShowHideButton = true;
            this.btnAggiungi.Depth = 0;
            this.btnAggiungi.Icon = global::IngegneriaDelSoftware.Properties.Resources.ic_save_black_48dp;
            this.btnAggiungi.Location = new System.Drawing.Point(472, 408);
            this.btnAggiungi.Mini = false;
            this.btnAggiungi.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(56, 56);
            this.btnAggiungi.TabIndex = 4;
            this.btnAggiungi.UseVisualStyleBackColor = true;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(16, 344);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(138, 36);
            this.materialRaisedButton1.TabIndex = 7;
            this.materialRaisedButton1.Text = "Aggiungi clienti";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.AutoSize = true;
            this.materialRaisedButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Icon = null;
            this.materialRaisedButton2.Location = new System.Drawing.Point(176, 344);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(142, 36);
            this.materialRaisedButton2.TabIndex = 8;
            this.materialRaisedButton2.Text = "Aggiungi esterni";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            // 
            // materialRaisedButton3
            // 
            this.materialRaisedButton3.AutoSize = true;
            this.materialRaisedButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton3.Depth = 0;
            this.materialRaisedButton3.Icon = null;
            this.materialRaisedButton3.Location = new System.Drawing.Point(344, 344);
            this.materialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton3.Name = "materialRaisedButton3";
            this.materialRaisedButton3.Primary = true;
            this.materialRaisedButton3.Size = new System.Drawing.Size(181, 36);
            this.materialRaisedButton3.TabIndex = 9;
            this.materialRaisedButton3.Text = "Aggiungi intermediari";
            this.materialRaisedButton3.UseVisualStyleBackColor = true;
            // 
            // formAppuntamenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 472);
            this.Controls.Add(this.materialRaisedButton3);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.txtNoteAppuntamento);
            this.Controls.Add(materialLabel4);
            this.Controls.Add(this.dataAppuntamento);
            this.Controls.Add(materialLabel3);
            this.Controls.Add(this.txtLuogoAppuntamento);
            this.Controls.Add(materialLabel2);
            this.Controls.Add(materialLabel1);
            this.MaximizeBox = false;
            this.Name = "formAppuntamenti";
            this.Text = "Inserimento appuntamenti";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLuogoAppuntamento;
        private System.Windows.Forms.DateTimePicker dataAppuntamento;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNoteAppuntamento;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnAggiungi;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton3;
    }
}