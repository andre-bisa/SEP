namespace IngegneriaDelSoftware.Graphics {
    partial class FattureForm {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.GrigliaSfondoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FatturaSingolaPanel = new System.Windows.Forms.Panel();
            this.IndirizzoField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.IndirizzoLbl = new MaterialSkin.Controls.MaterialLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PersonaGiuridicaRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.PersonaFisicaRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.IVACheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.NumeroField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.AnnoField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.TelefonoField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.TelefonoLbl = new MaterialSkin.Controls.MaterialLabel();
            this.PIVAField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PIVALbl = new MaterialSkin.Controls.MaterialLabel();
            this.CFField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.CFLbl = new MaterialSkin.Controls.MaterialLabel();
            this.CognomeField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.CognomeLbl = new MaterialSkin.Controls.MaterialLabel();
            this.NomeField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.NomeLbl = new MaterialSkin.Controls.MaterialLabel();
            this.CreaFatturaBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.FattureValoriPanel = new System.Windows.Forms.TableLayoutPanel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AggiungiVoceBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.FattureInserite = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.DataLbl = new MaterialSkin.Controls.MaterialLabel();
            this.DataField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.panel5 = new System.Windows.Forms.Panel();
            this.AggiungiVociBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.NuovaFatturaBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.EliminaVociBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1.SuspendLayout();
            this.GrigliaSfondoPanel.SuspendLayout();
            this.FatturaSingolaPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.FattureValoriPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.GrigliaSfondoPanel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(3, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1385, 670);
            this.panel1.TabIndex = 0;
            // 
            // GrigliaSfondoPanel
            // 
            this.GrigliaSfondoPanel.AutoScroll = true;
            this.GrigliaSfondoPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GrigliaSfondoPanel.ColumnCount = 4;
            this.GrigliaSfondoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GrigliaSfondoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.GrigliaSfondoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GrigliaSfondoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GrigliaSfondoPanel.Controls.Add(this.FatturaSingolaPanel, 1, 1);
            this.GrigliaSfondoPanel.Controls.Add(this.FattureValoriPanel, 2, 1);
            this.GrigliaSfondoPanel.Controls.Add(this.panel2, 2, 0);
            this.GrigliaSfondoPanel.Controls.Add(this.panel5, 1, 0);
            this.GrigliaSfondoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrigliaSfondoPanel.Location = new System.Drawing.Point(200, 0);
            this.GrigliaSfondoPanel.Name = "GrigliaSfondoPanel";
            this.GrigliaSfondoPanel.RowCount = 2;
            this.GrigliaSfondoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.92537F));
            this.GrigliaSfondoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.07462F));
            this.GrigliaSfondoPanel.Size = new System.Drawing.Size(1185, 670);
            this.GrigliaSfondoPanel.TabIndex = 0;
            // 
            // FatturaSingolaPanel
            // 
            this.FatturaSingolaPanel.BackColor = System.Drawing.Color.White;
            this.FatturaSingolaPanel.Controls.Add(this.DataField);
            this.FatturaSingolaPanel.Controls.Add(this.DataLbl);
            this.FatturaSingolaPanel.Controls.Add(this.IndirizzoField);
            this.FatturaSingolaPanel.Controls.Add(this.IndirizzoLbl);
            this.FatturaSingolaPanel.Controls.Add(this.panel4);
            this.FatturaSingolaPanel.Controls.Add(this.materialDivider2);
            this.FatturaSingolaPanel.Controls.Add(this.IVACheckBox);
            this.FatturaSingolaPanel.Controls.Add(this.materialLabel10);
            this.FatturaSingolaPanel.Controls.Add(this.NumeroField);
            this.FatturaSingolaPanel.Controls.Add(this.materialLabel9);
            this.FatturaSingolaPanel.Controls.Add(this.AnnoField);
            this.FatturaSingolaPanel.Controls.Add(this.materialLabel8);
            this.FatturaSingolaPanel.Controls.Add(this.TelefonoField);
            this.FatturaSingolaPanel.Controls.Add(this.TelefonoLbl);
            this.FatturaSingolaPanel.Controls.Add(this.PIVAField);
            this.FatturaSingolaPanel.Controls.Add(this.PIVALbl);
            this.FatturaSingolaPanel.Controls.Add(this.CFField);
            this.FatturaSingolaPanel.Controls.Add(this.CFLbl);
            this.FatturaSingolaPanel.Controls.Add(this.CognomeField);
            this.FatturaSingolaPanel.Controls.Add(this.CognomeLbl);
            this.FatturaSingolaPanel.Controls.Add(this.NomeField);
            this.FatturaSingolaPanel.Controls.Add(this.NomeLbl);
            this.FatturaSingolaPanel.Controls.Add(this.CreaFatturaBtn);
            this.FatturaSingolaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FatturaSingolaPanel.Location = new System.Drawing.Point(23, 102);
            this.FatturaSingolaPanel.Name = "FatturaSingolaPanel";
            this.FatturaSingolaPanel.Size = new System.Drawing.Size(344, 565);
            this.FatturaSingolaPanel.TabIndex = 1;
            this.FatturaSingolaPanel.Visible = false;
            // 
            // IndirizzoField
            // 
            this.IndirizzoField.Depth = 0;
            this.IndirizzoField.Hint = "";
            this.IndirizzoField.Location = new System.Drawing.Point(28, 188);
            this.IndirizzoField.MaxLength = 32767;
            this.IndirizzoField.MouseState = MaterialSkin.MouseState.HOVER;
            this.IndirizzoField.Name = "IndirizzoField";
            this.IndirizzoField.PasswordChar = '\0';
            this.IndirizzoField.SelectedText = "";
            this.IndirizzoField.SelectionLength = 0;
            this.IndirizzoField.SelectionStart = 0;
            this.IndirizzoField.Size = new System.Drawing.Size(300, 23);
            this.IndirizzoField.TabIndex = 24;
            this.IndirizzoField.TabStop = false;
            this.IndirizzoField.UseSystemPasswordChar = false;
            // 
            // IndirizzoLbl
            // 
            this.IndirizzoLbl.AutoSize = true;
            this.IndirizzoLbl.Depth = 0;
            this.IndirizzoLbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.IndirizzoLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.IndirizzoLbl.Location = new System.Drawing.Point(15, 166);
            this.IndirizzoLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.IndirizzoLbl.Name = "IndirizzoLbl";
            this.IndirizzoLbl.Size = new System.Drawing.Size(65, 19);
            this.IndirizzoLbl.TabIndex = 23;
            this.IndirizzoLbl.Text = "Indirizzo";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.PersonaGiuridicaRadio);
            this.panel4.Controls.Add(this.PersonaFisicaRadio);
            this.panel4.Location = new System.Drawing.Point(12, 394);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(184, 61);
            this.panel4.TabIndex = 22;
            // 
            // PersonaGiuridicaRadio
            // 
            this.PersonaGiuridicaRadio.AutoSize = true;
            this.PersonaGiuridicaRadio.Depth = 0;
            this.PersonaGiuridicaRadio.Font = new System.Drawing.Font("Roboto", 10F);
            this.PersonaGiuridicaRadio.Location = new System.Drawing.Point(0, 30);
            this.PersonaGiuridicaRadio.Margin = new System.Windows.Forms.Padding(0);
            this.PersonaGiuridicaRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.PersonaGiuridicaRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.PersonaGiuridicaRadio.Name = "PersonaGiuridicaRadio";
            this.PersonaGiuridicaRadio.Ripple = true;
            this.PersonaGiuridicaRadio.Size = new System.Drawing.Size(136, 30);
            this.PersonaGiuridicaRadio.TabIndex = 21;
            this.PersonaGiuridicaRadio.TabStop = true;
            this.PersonaGiuridicaRadio.Text = "Persona giuridica";
            this.PersonaGiuridicaRadio.UseVisualStyleBackColor = true;
            // 
            // PersonaFisicaRadio
            // 
            this.PersonaFisicaRadio.AutoSize = true;
            this.PersonaFisicaRadio.Depth = 0;
            this.PersonaFisicaRadio.Font = new System.Drawing.Font("Roboto", 10F);
            this.PersonaFisicaRadio.Location = new System.Drawing.Point(0, 0);
            this.PersonaFisicaRadio.Margin = new System.Windows.Forms.Padding(0);
            this.PersonaFisicaRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.PersonaFisicaRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.PersonaFisicaRadio.Name = "PersonaFisicaRadio";
            this.PersonaFisicaRadio.Ripple = true;
            this.PersonaFisicaRadio.Size = new System.Drawing.Size(117, 30);
            this.PersonaFisicaRadio.TabIndex = 20;
            this.PersonaFisicaRadio.TabStop = true;
            this.PersonaFisicaRadio.Text = "Persona fisica";
            this.PersonaFisicaRadio.UseVisualStyleBackColor = true;
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Dock = System.Windows.Forms.DockStyle.Right;
            this.materialDivider2.Location = new System.Drawing.Point(342, 0);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(2, 565);
            this.materialDivider2.TabIndex = 19;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // IVACheckBox
            // 
            this.IVACheckBox.AutoSize = true;
            this.IVACheckBox.Depth = 0;
            this.IVACheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.IVACheckBox.Location = new System.Drawing.Point(12, 361);
            this.IVACheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.IVACheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.IVACheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.IVACheckBox.Name = "IVACheckBox";
            this.IVACheckBox.Ripple = true;
            this.IVACheckBox.Size = new System.Drawing.Size(169, 30);
            this.IVACheckBox.TabIndex = 18;
            this.IVACheckBox.Text = "Fattura con partita IVA";
            this.IVACheckBox.UseVisualStyleBackColor = true;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(67, 37);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(15, 19);
            this.materialLabel10.TabIndex = 17;
            this.materialLabel10.Text = "/";
            // 
            // NumeroField
            // 
            this.NumeroField.Depth = 0;
            this.NumeroField.Hint = "";
            this.NumeroField.Location = new System.Drawing.Point(19, 37);
            this.NumeroField.MaxLength = 32767;
            this.NumeroField.MouseState = MaterialSkin.MouseState.HOVER;
            this.NumeroField.Name = "NumeroField";
            this.NumeroField.PasswordChar = '\0';
            this.NumeroField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NumeroField.SelectedText = "";
            this.NumeroField.SelectionLength = 0;
            this.NumeroField.SelectionStart = 0;
            this.NumeroField.Size = new System.Drawing.Size(46, 23);
            this.NumeroField.TabIndex = 16;
            this.NumeroField.TabStop = false;
            this.NumeroField.UseSystemPasswordChar = false;
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(15, 15);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(63, 19);
            this.materialLabel9.TabIndex = 15;
            this.materialLabel9.Text = "Numero";
            // 
            // AnnoField
            // 
            this.AnnoField.Depth = 0;
            this.AnnoField.Hint = "";
            this.AnnoField.Location = new System.Drawing.Point(86, 37);
            this.AnnoField.MaxLength = 32767;
            this.AnnoField.MouseState = MaterialSkin.MouseState.HOVER;
            this.AnnoField.Name = "AnnoField";
            this.AnnoField.PasswordChar = '\0';
            this.AnnoField.SelectedText = "";
            this.AnnoField.SelectionLength = 0;
            this.AnnoField.SelectionStart = 0;
            this.AnnoField.Size = new System.Drawing.Size(37, 23);
            this.AnnoField.TabIndex = 14;
            this.AnnoField.TabStop = false;
            this.AnnoField.UseSystemPasswordChar = false;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.materialLabel8.Location = new System.Drawing.Point(84, 15);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(44, 19);
            this.materialLabel8.TabIndex = 13;
            this.materialLabel8.Text = "Anno";
            // 
            // TelefonoField
            // 
            this.TelefonoField.Depth = 0;
            this.TelefonoField.Hint = "";
            this.TelefonoField.Location = new System.Drawing.Point(28, 333);
            this.TelefonoField.MaxLength = 32767;
            this.TelefonoField.MouseState = MaterialSkin.MouseState.HOVER;
            this.TelefonoField.Name = "TelefonoField";
            this.TelefonoField.PasswordChar = '\0';
            this.TelefonoField.SelectedText = "";
            this.TelefonoField.SelectionLength = 0;
            this.TelefonoField.SelectionStart = 0;
            this.TelefonoField.Size = new System.Drawing.Size(300, 23);
            this.TelefonoField.TabIndex = 12;
            this.TelefonoField.TabStop = false;
            this.TelefonoField.UseSystemPasswordChar = false;
            // 
            // TelefonoLbl
            // 
            this.TelefonoLbl.AutoSize = true;
            this.TelefonoLbl.Depth = 0;
            this.TelefonoLbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.TelefonoLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TelefonoLbl.Location = new System.Drawing.Point(15, 311);
            this.TelefonoLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.TelefonoLbl.Name = "TelefonoLbl";
            this.TelefonoLbl.Size = new System.Drawing.Size(139, 19);
            this.TelefonoLbl.TabIndex = 11;
            this.TelefonoLbl.Text = "Numero di telefono";
            // 
            // PIVAField
            // 
            this.PIVAField.Depth = 0;
            this.PIVAField.Hint = "";
            this.PIVAField.Location = new System.Drawing.Point(28, 285);
            this.PIVAField.MaxLength = 32767;
            this.PIVAField.MouseState = MaterialSkin.MouseState.HOVER;
            this.PIVAField.Name = "PIVAField";
            this.PIVAField.PasswordChar = '\0';
            this.PIVAField.SelectedText = "";
            this.PIVAField.SelectionLength = 0;
            this.PIVAField.SelectionStart = 0;
            this.PIVAField.Size = new System.Drawing.Size(300, 23);
            this.PIVAField.TabIndex = 10;
            this.PIVAField.TabStop = false;
            this.PIVAField.UseSystemPasswordChar = false;
            // 
            // PIVALbl
            // 
            this.PIVALbl.AutoSize = true;
            this.PIVALbl.Depth = 0;
            this.PIVALbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.PIVALbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PIVALbl.Location = new System.Drawing.Point(15, 263);
            this.PIVALbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.PIVALbl.Name = "PIVALbl";
            this.PIVALbl.Size = new System.Drawing.Size(81, 19);
            this.PIVALbl.TabIndex = 9;
            this.PIVALbl.Text = "Partita IVA";
            // 
            // CFField
            // 
            this.CFField.Depth = 0;
            this.CFField.Hint = "";
            this.CFField.Location = new System.Drawing.Point(28, 237);
            this.CFField.MaxLength = 32767;
            this.CFField.MouseState = MaterialSkin.MouseState.HOVER;
            this.CFField.Name = "CFField";
            this.CFField.PasswordChar = '\0';
            this.CFField.SelectedText = "";
            this.CFField.SelectionLength = 0;
            this.CFField.SelectionStart = 0;
            this.CFField.Size = new System.Drawing.Size(300, 23);
            this.CFField.TabIndex = 8;
            this.CFField.TabStop = false;
            this.CFField.UseSystemPasswordChar = false;
            // 
            // CFLbl
            // 
            this.CFLbl.AutoSize = true;
            this.CFLbl.Depth = 0;
            this.CFLbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.CFLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CFLbl.Location = new System.Drawing.Point(15, 214);
            this.CFLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.CFLbl.Name = "CFLbl";
            this.CFLbl.Size = new System.Drawing.Size(108, 19);
            this.CFLbl.TabIndex = 7;
            this.CFLbl.Text = "Codice Fiscale";
            // 
            // CognomeField
            // 
            this.CognomeField.Depth = 0;
            this.CognomeField.Hint = "";
            this.CognomeField.Location = new System.Drawing.Point(28, 140);
            this.CognomeField.MaxLength = 32767;
            this.CognomeField.MouseState = MaterialSkin.MouseState.HOVER;
            this.CognomeField.Name = "CognomeField";
            this.CognomeField.PasswordChar = '\0';
            this.CognomeField.SelectedText = "";
            this.CognomeField.SelectionLength = 0;
            this.CognomeField.SelectionStart = 0;
            this.CognomeField.Size = new System.Drawing.Size(300, 23);
            this.CognomeField.TabIndex = 6;
            this.CognomeField.TabStop = false;
            this.CognomeField.UseSystemPasswordChar = false;
            // 
            // CognomeLbl
            // 
            this.CognomeLbl.AutoSize = true;
            this.CognomeLbl.Depth = 0;
            this.CognomeLbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.CognomeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CognomeLbl.Location = new System.Drawing.Point(15, 117);
            this.CognomeLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.CognomeLbl.Name = "CognomeLbl";
            this.CognomeLbl.Size = new System.Drawing.Size(74, 19);
            this.CognomeLbl.TabIndex = 5;
            this.CognomeLbl.Text = "Cognome";
            // 
            // NomeField
            // 
            this.NomeField.Depth = 0;
            this.NomeField.Hint = "";
            this.NomeField.Location = new System.Drawing.Point(28, 91);
            this.NomeField.MaxLength = 32767;
            this.NomeField.MouseState = MaterialSkin.MouseState.HOVER;
            this.NomeField.Name = "NomeField";
            this.NomeField.PasswordChar = '\0';
            this.NomeField.SelectedText = "";
            this.NomeField.SelectionLength = 0;
            this.NomeField.SelectionStart = 0;
            this.NomeField.Size = new System.Drawing.Size(300, 23);
            this.NomeField.TabIndex = 4;
            this.NomeField.TabStop = false;
            this.NomeField.UseSystemPasswordChar = false;
            // 
            // NomeLbl
            // 
            this.NomeLbl.AutoSize = true;
            this.NomeLbl.Depth = 0;
            this.NomeLbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.NomeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NomeLbl.Location = new System.Drawing.Point(15, 69);
            this.NomeLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.NomeLbl.Name = "NomeLbl";
            this.NomeLbl.Size = new System.Drawing.Size(50, 19);
            this.NomeLbl.TabIndex = 3;
            this.NomeLbl.Text = "Nome";
            // 
            // CreaFatturaBtn
            // 
            this.CreaFatturaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreaFatturaBtn.AutoSize = true;
            this.CreaFatturaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreaFatturaBtn.Depth = 0;
            this.CreaFatturaBtn.Icon = null;
            this.CreaFatturaBtn.Location = new System.Drawing.Point(234, 475);
            this.CreaFatturaBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreaFatturaBtn.Name = "CreaFatturaBtn";
            this.CreaFatturaBtn.Primary = true;
            this.CreaFatturaBtn.Size = new System.Drawing.Size(94, 36);
            this.CreaFatturaBtn.TabIndex = 0;
            this.CreaFatturaBtn.Text = "Conferma";
            this.CreaFatturaBtn.UseVisualStyleBackColor = true;
            this.CreaFatturaBtn.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // FattureValoriPanel
            // 
            this.FattureValoriPanel.AutoScroll = true;
            this.FattureValoriPanel.ColumnCount = 4;
            this.FattureValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.FattureValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.FattureValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.FattureValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.FattureValoriPanel.Controls.Add(this.materialLabel1, 2, 0);
            this.FattureValoriPanel.Controls.Add(this.materialLabel2, 3, 0);
            this.FattureValoriPanel.Controls.Add(this.materialLabel3, 1, 0);
            this.FattureValoriPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FattureValoriPanel.Location = new System.Drawing.Point(373, 102);
            this.FattureValoriPanel.Name = "FattureValoriPanel";
            this.FattureValoriPanel.RowCount = 1;
            this.FattureValoriPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FattureValoriPanel.Size = new System.Drawing.Size(789, 565);
            this.FattureValoriPanel.TabIndex = 0;
            this.FattureValoriPanel.Visible = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(183, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(63, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Causale";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(252, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(84, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Importo (€)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AggiungiVoceBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(373, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 93);
            this.panel2.TabIndex = 3;
            // 
            // AggiungiVoceBtn
            // 
            this.AggiungiVoceBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AggiungiVoceBtn.AutoSize = true;
            this.AggiungiVoceBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AggiungiVoceBtn.Depth = 0;
            this.AggiungiVoceBtn.Icon = null;
            this.AggiungiVoceBtn.Location = new System.Drawing.Point(662, 51);
            this.AggiungiVoceBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AggiungiVoceBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AggiungiVoceBtn.Name = "AggiungiVoceBtn";
            this.AggiungiVoceBtn.Primary = false;
            this.AggiungiVoceBtn.Size = new System.Drawing.Size(123, 36);
            this.AggiungiVoceBtn.TabIndex = 2;
            this.AggiungiVoceBtn.Text = "Aggiungi voce";
            this.AggiungiVoceBtn.UseVisualStyleBackColor = true;
            this.AggiungiVoceBtn.Visible = false;
            this.AggiungiVoceBtn.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.NuovaFatturaBtn);
            this.panel3.Controls.Add(this.materialDivider1);
            this.panel3.Controls.Add(this.FattureInserite);
            this.panel3.Controls.Add(this.materialLabel11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 670);
            this.panel3.TabIndex = 4;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Dock = System.Windows.Forms.DockStyle.Right;
            this.materialDivider1.Location = new System.Drawing.Point(198, 0);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(2, 670);
            this.materialDivider1.TabIndex = 3;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // FattureInserite
            // 
            this.FattureInserite.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FattureInserite.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.FattureInserite.Depth = 0;
            this.FattureInserite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FattureInserite.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.FattureInserite.FullRowSelect = true;
            this.FattureInserite.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.FattureInserite.Location = new System.Drawing.Point(0, 0);
            this.FattureInserite.MouseLocation = new System.Drawing.Point(-1, -1);
            this.FattureInserite.MouseState = MaterialSkin.MouseState.OUT;
            this.FattureInserite.Name = "FattureInserite";
            this.FattureInserite.OwnerDraw = true;
            this.FattureInserite.Size = new System.Drawing.Size(200, 670);
            this.FattureInserite.TabIndex = 2;
            this.FattureInserite.UseCompatibleStateImageBehavior = false;
            this.FattureInserite.View = System.Windows.Forms.View.Details;
            this.FattureInserite.SelectedIndexChanged += new System.EventHandler(this.FattureInserite_SelectedIndexChanged);
            // 
            // columnHeader
            // 
            this.columnHeader.Text = "Fatture Inserite";
            this.columnHeader.Width = 200;
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.materialLabel11.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(9, 17);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(56, 19);
            this.materialLabel11.TabIndex = 1;
            this.materialLabel11.Text = "Fatture";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(83, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(72, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Tipologia";
            // 
            // DataLbl
            // 
            this.DataLbl.AutoSize = true;
            this.DataLbl.Depth = 0;
            this.DataLbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.DataLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DataLbl.Location = new System.Drawing.Point(141, 15);
            this.DataLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.DataLbl.Name = "DataLbl";
            this.DataLbl.Size = new System.Drawing.Size(40, 19);
            this.DataLbl.TabIndex = 25;
            this.DataLbl.Text = "Data";
            // 
            // DataField
            // 
            this.DataField.Depth = 0;
            this.DataField.Hint = "";
            this.DataField.Location = new System.Drawing.Point(154, 36);
            this.DataField.MaxLength = 32767;
            this.DataField.MouseState = MaterialSkin.MouseState.HOVER;
            this.DataField.Name = "DataField";
            this.DataField.PasswordChar = '\0';
            this.DataField.SelectedText = "";
            this.DataField.SelectionLength = 0;
            this.DataField.SelectionStart = 0;
            this.DataField.Size = new System.Drawing.Size(174, 23);
            this.DataField.TabIndex = 26;
            this.DataField.TabStop = false;
            this.DataField.UseSystemPasswordChar = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.EliminaVociBtn);
            this.panel5.Controls.Add(this.AggiungiVociBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(23, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(344, 93);
            this.panel5.TabIndex = 4;
            // 
            // AggiungiVociBtn
            // 
            this.AggiungiVociBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AggiungiVociBtn.AutoSize = true;
            this.AggiungiVociBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AggiungiVociBtn.Depth = 0;
            this.AggiungiVociBtn.Icon = null;
            this.AggiungiVociBtn.Location = new System.Drawing.Point(221, 51);
            this.AggiungiVociBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AggiungiVociBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AggiungiVociBtn.Name = "AggiungiVociBtn";
            this.AggiungiVociBtn.Primary = false;
            this.AggiungiVociBtn.Size = new System.Drawing.Size(119, 36);
            this.AggiungiVociBtn.TabIndex = 0;
            this.AggiungiVociBtn.Text = "Aggiungi Voci";
            this.AggiungiVociBtn.UseVisualStyleBackColor = true;
            this.AggiungiVociBtn.Visible = false;
            this.AggiungiVociBtn.Click += new System.EventHandler(this.AggiungiVociBtn_Click);
            // 
            // NuovaFatturaBtn
            // 
            this.NuovaFatturaBtn.AutoSize = true;
            this.NuovaFatturaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NuovaFatturaBtn.Depth = 0;
            this.NuovaFatturaBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NuovaFatturaBtn.Icon = null;
            this.NuovaFatturaBtn.Location = new System.Drawing.Point(0, 634);
            this.NuovaFatturaBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.NuovaFatturaBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NuovaFatturaBtn.Name = "NuovaFatturaBtn";
            this.NuovaFatturaBtn.Primary = false;
            this.NuovaFatturaBtn.Size = new System.Drawing.Size(198, 36);
            this.NuovaFatturaBtn.TabIndex = 4;
            this.NuovaFatturaBtn.Text = "Nuova fattura";
            this.NuovaFatturaBtn.UseVisualStyleBackColor = true;
            this.NuovaFatturaBtn.Click += new System.EventHandler(this.NuovaFatturaBtn_Click);
            // 
            // EliminaVociBtn
            // 
            this.EliminaVociBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EliminaVociBtn.AutoSize = true;
            this.EliminaVociBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EliminaVociBtn.Depth = 0;
            this.EliminaVociBtn.Icon = null;
            this.EliminaVociBtn.Location = new System.Drawing.Point(104, 51);
            this.EliminaVociBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EliminaVociBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.EliminaVociBtn.Name = "EliminaVociBtn";
            this.EliminaVociBtn.Primary = false;
            this.EliminaVociBtn.Size = new System.Drawing.Size(109, 36);
            this.EliminaVociBtn.TabIndex = 1;
            this.EliminaVociBtn.Text = "Elimina voci";
            this.EliminaVociBtn.UseVisualStyleBackColor = true;
            this.EliminaVociBtn.Visible = false;
            this.EliminaVociBtn.Click += new System.EventHandler(this.EliminaVociBtn_Click);
            // 
            // FattureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 739);
            this.Controls.Add(this.panel1);
            this.Name = "FattureForm";
            this.Text = "FatturaForm";
            this.panel1.ResumeLayout(false);
            this.GrigliaSfondoPanel.ResumeLayout(false);
            this.FatturaSingolaPanel.ResumeLayout(false);
            this.FatturaSingolaPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.FattureValoriPanel.ResumeLayout(false);
            this.FattureValoriPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel GrigliaSfondoPanel;
        private System.Windows.Forms.TableLayoutPanel FattureValoriPanel;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Panel FatturaSingolaPanel;
        private MaterialSkin.Controls.MaterialRaisedButton CreaFatturaBtn;
        private MaterialSkin.Controls.MaterialLabel NomeLbl;
        private MaterialSkin.Controls.MaterialSingleLineTextField NomeField;
        private MaterialSkin.Controls.MaterialSingleLineTextField CognomeField;
        private MaterialSkin.Controls.MaterialLabel CognomeLbl;
        private MaterialSkin.Controls.MaterialSingleLineTextField CFField;
        private MaterialSkin.Controls.MaterialLabel CFLbl;
        private MaterialSkin.Controls.MaterialSingleLineTextField PIVAField;
        private MaterialSkin.Controls.MaterialLabel PIVALbl;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialSingleLineTextField NumeroField;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialSingleLineTextField AnnoField;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialSingleLineTextField TelefonoField;
        private MaterialSkin.Controls.MaterialLabel TelefonoLbl;
        private MaterialSkin.Controls.MaterialCheckBox IVACheckBox;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton AggiungiVoceBtn;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialListView FattureInserite;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialRadioButton PersonaGiuridicaRadio;
        private MaterialSkin.Controls.MaterialRadioButton PersonaFisicaRadio;
        private MaterialSkin.Controls.MaterialSingleLineTextField IndirizzoField;
        private MaterialSkin.Controls.MaterialLabel IndirizzoLbl;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField DataField;
        private MaterialSkin.Controls.MaterialLabel DataLbl;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialFlatButton AggiungiVociBtn;
        private MaterialSkin.Controls.MaterialFlatButton NuovaFatturaBtn;
        private MaterialSkin.Controls.MaterialFlatButton EliminaVociBtn;
    }
}