namespace IngegneriaDelSoftware.View {
    partial class GenericForm {
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
            this.SingolaPanel = new System.Windows.Forms.Panel();
            this.AccettaBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.RifiutaBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.DataField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.DataLbl = new MaterialSkin.Controls.MaterialLabel();
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
            this.CreaBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AggiungiVoceBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.EliminaVociBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.AggiungiVociBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SearchLabel = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.NuovaBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.Inserite = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.CausaleLabel = new MaterialSkin.Controls.MaterialLabel();
            this.ImportoLabel = new MaterialSkin.Controls.MaterialLabel();
            this.TipologiaLabel = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.GrigliaSfondoPanel.SuspendLayout();
            this.SingolaPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1388, 670);
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
            this.GrigliaSfondoPanel.Controls.Add(this.SingolaPanel, 1, 1);
            this.GrigliaSfondoPanel.Controls.Add(this.panel2, 2, 0);
            this.GrigliaSfondoPanel.Controls.Add(this.panel5, 1, 0);
            this.GrigliaSfondoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrigliaSfondoPanel.Location = new System.Drawing.Point(200, 0);
            this.GrigliaSfondoPanel.Name = "GrigliaSfondoPanel";
            this.GrigliaSfondoPanel.RowCount = 2;
            this.GrigliaSfondoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.92537F));
            this.GrigliaSfondoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.07462F));
            this.GrigliaSfondoPanel.Size = new System.Drawing.Size(1188, 670);
            this.GrigliaSfondoPanel.TabIndex = 0;
            // 
            // SingolaPanel
            // 
            this.SingolaPanel.BackColor = System.Drawing.Color.White;
            this.SingolaPanel.Controls.Add(this.AccettaBtn);
            this.SingolaPanel.Controls.Add(this.RifiutaBtn);
            this.SingolaPanel.Controls.Add(this.DataField);
            this.SingolaPanel.Controls.Add(this.DataLbl);
            this.SingolaPanel.Controls.Add(this.IndirizzoField);
            this.SingolaPanel.Controls.Add(this.IndirizzoLbl);
            this.SingolaPanel.Controls.Add(this.panel4);
            this.SingolaPanel.Controls.Add(this.materialDivider2);
            this.SingolaPanel.Controls.Add(this.IVACheckBox);
            this.SingolaPanel.Controls.Add(this.materialLabel10);
            this.SingolaPanel.Controls.Add(this.NumeroField);
            this.SingolaPanel.Controls.Add(this.materialLabel9);
            this.SingolaPanel.Controls.Add(this.AnnoField);
            this.SingolaPanel.Controls.Add(this.materialLabel8);
            this.SingolaPanel.Controls.Add(this.TelefonoField);
            this.SingolaPanel.Controls.Add(this.TelefonoLbl);
            this.SingolaPanel.Controls.Add(this.PIVAField);
            this.SingolaPanel.Controls.Add(this.PIVALbl);
            this.SingolaPanel.Controls.Add(this.CFField);
            this.SingolaPanel.Controls.Add(this.CFLbl);
            this.SingolaPanel.Controls.Add(this.CognomeField);
            this.SingolaPanel.Controls.Add(this.CognomeLbl);
            this.SingolaPanel.Controls.Add(this.NomeField);
            this.SingolaPanel.Controls.Add(this.NomeLbl);
            this.SingolaPanel.Controls.Add(this.CreaBtn);
            this.SingolaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SingolaPanel.Location = new System.Drawing.Point(23, 102);
            this.SingolaPanel.Name = "SingolaPanel";
            this.SingolaPanel.Size = new System.Drawing.Size(344, 565);
            this.SingolaPanel.TabIndex = 1;
            this.SingolaPanel.Visible = false;
            // 
            // AccettaBtn
            // 
            this.AccettaBtn.AutoSize = true;
            this.AccettaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AccettaBtn.Depth = 0;
            this.AccettaBtn.Icon = null;
            this.AccettaBtn.Location = new System.Drawing.Point(86, 460);
            this.AccettaBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AccettaBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AccettaBtn.Name = "AccettaBtn";
            this.AccettaBtn.Primary = false;
            this.AccettaBtn.Size = new System.Drawing.Size(82, 36);
            this.AccettaBtn.TabIndex = 28;
            this.AccettaBtn.Text = "Accetta";
            this.AccettaBtn.UseVisualStyleBackColor = true;
            this.AccettaBtn.Click += new System.EventHandler(this.AccettaBtn_Click);
            // 
            // RifiutaBtn
            // 
            this.RifiutaBtn.AutoSize = true;
            this.RifiutaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RifiutaBtn.Depth = 0;
            this.RifiutaBtn.Icon = null;
            this.RifiutaBtn.Location = new System.Drawing.Point(8, 460);
            this.RifiutaBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RifiutaBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.RifiutaBtn.Name = "RifiutaBtn";
            this.RifiutaBtn.Primary = false;
            this.RifiutaBtn.Size = new System.Drawing.Size(71, 36);
            this.RifiutaBtn.TabIndex = 27;
            this.RifiutaBtn.Text = "Rifiuta";
            this.RifiutaBtn.UseVisualStyleBackColor = true;
            this.RifiutaBtn.Click += new System.EventHandler(this.RifiutaBtn_Click);
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
            this.IVACheckBox.Size = new System.Drawing.Size(125, 30);
            this.IVACheckBox.TabIndex = 18;
            this.IVACheckBox.Text = " con partita IVA";
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
            // CreaBtn
            // 
            this.CreaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreaBtn.AutoSize = true;
            this.CreaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreaBtn.Depth = 0;
            this.CreaBtn.Icon = null;
            this.CreaBtn.Location = new System.Drawing.Point(167, 512);
            this.CreaBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreaBtn.Name = "CreaBtn";
            this.CreaBtn.Primary = true;
            this.CreaBtn.Size = new System.Drawing.Size(161, 36);
            this.CreaBtn.TabIndex = 0;
            this.CreaBtn.Text = "Conferma Modifica";
            this.CreaBtn.UseVisualStyleBackColor = true;
            this.CreaBtn.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AggiungiVoceBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(373, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 93);
            this.panel2.TabIndex = 3;
            // 
            // AggiungiVoceBtn
            // 
            this.AggiungiVoceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AggiungiVoceBtn.AutoSize = true;
            this.AggiungiVoceBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AggiungiVoceBtn.Depth = 0;
            this.AggiungiVoceBtn.Icon = null;
            this.AggiungiVoceBtn.Location = new System.Drawing.Point(664, 51);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.SearchLabel);
            this.panel3.Controls.Add(this.NuovaBtn);
            this.panel3.Controls.Add(this.materialDivider1);
            this.panel3.Controls.Add(this.Inserite);
            this.panel3.Controls.Add(this.materialLabel11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 670);
            this.panel3.TabIndex = 4;
            // 
            // SearchLabel
            // 
            this.SearchLabel.Depth = 0;
            this.SearchLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchLabel.Hint = "Cerca";
            this.SearchLabel.Location = new System.Drawing.Point(0, 0);
            this.SearchLabel.MaxLength = 32767;
            this.SearchLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.PasswordChar = '\0';
            this.SearchLabel.SelectedText = "";
            this.SearchLabel.SelectionLength = 0;
            this.SearchLabel.SelectionStart = 0;
            this.SearchLabel.Size = new System.Drawing.Size(198, 23);
            this.SearchLabel.TabIndex = 5;
            this.SearchLabel.TabStop = false;
            this.SearchLabel.UseSystemPasswordChar = false;
            // 
            // NuovaBtn
            // 
            this.NuovaBtn.AutoSize = true;
            this.NuovaBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NuovaBtn.Depth = 0;
            this.NuovaBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NuovaBtn.Icon = null;
            this.NuovaBtn.Location = new System.Drawing.Point(0, 634);
            this.NuovaBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.NuovaBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NuovaBtn.Name = "NuovaBtn";
            this.NuovaBtn.Primary = false;
            this.NuovaBtn.Size = new System.Drawing.Size(198, 36);
            this.NuovaBtn.TabIndex = 4;
            this.NuovaBtn.Text = "Nuova ";
            this.NuovaBtn.UseVisualStyleBackColor = true;
            this.NuovaBtn.Click += new System.EventHandler(this.NuovaBtn_Click);
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
            // Inserite
            // 
            this.Inserite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Inserite.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Inserite.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.Inserite.Depth = 0;
            this.Inserite.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.Inserite.FullRowSelect = true;
            this.Inserite.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Inserite.Location = new System.Drawing.Point(0, 21);
            this.Inserite.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Inserite.MouseState = MaterialSkin.MouseState.OUT;
            this.Inserite.Name = "Inserite";
            this.Inserite.OwnerDraw = true;
            this.Inserite.Size = new System.Drawing.Size(200, 604);
            this.Inserite.TabIndex = 2;
            this.Inserite.UseCompatibleStateImageBehavior = false;
            this.Inserite.View = System.Windows.Forms.View.Details;
            this.Inserite.SelectedIndexChanged += new System.EventHandler(this.Inserite_SelectedIndexChanged);
            // 
            // columnHeader
            // 
            this.columnHeader.Text = " Inserite";
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
            this.materialLabel11.Size = new System.Drawing.Size(0, 19);
            this.materialLabel11.TabIndex = 1;
            // 
            // CausaleLabel
            // 
            this.CausaleLabel.AutoSize = true;
            this.CausaleLabel.Depth = 0;
            this.CausaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CausaleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CausaleLabel.Location = new System.Drawing.Point(183, 0);
            this.CausaleLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.CausaleLabel.Name = "CausaleLabel";
            this.CausaleLabel.Size = new System.Drawing.Size(63, 19);
            this.CausaleLabel.TabIndex = 0;
            this.CausaleLabel.Text = "Causale";
            // 
            // ImportoLabel
            // 
            this.ImportoLabel.AutoSize = true;
            this.ImportoLabel.Depth = 0;
            this.ImportoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ImportoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ImportoLabel.Location = new System.Drawing.Point(252, 0);
            this.ImportoLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ImportoLabel.Name = "ImportoLabel";
            this.ImportoLabel.Size = new System.Drawing.Size(84, 19);
            this.ImportoLabel.TabIndex = 1;
            this.ImportoLabel.Text = "Importo (€)";
            // 
            // TipologiaLabel
            // 
            this.TipologiaLabel.AutoSize = true;
            this.TipologiaLabel.Depth = 0;
            this.TipologiaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TipologiaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TipologiaLabel.Location = new System.Drawing.Point(83, 0);
            this.TipologiaLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.TipologiaLabel.Name = "TipologiaLabel";
            this.TipologiaLabel.Size = new System.Drawing.Size(72, 19);
            this.TipologiaLabel.TabIndex = 2;
            this.TipologiaLabel.Text = "Tipologia";
            // 
            // GenericForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 739);
            this.Controls.Add(this.panel1);
            this.Name = "GenericForm";
            this.Text = "Form";
            this.panel1.ResumeLayout(false);
            this.GrigliaSfondoPanel.ResumeLayout(false);
            this.SingolaPanel.ResumeLayout(false);
            this.SingolaPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel GrigliaSfondoPanel;
        
        private MaterialSkin.Controls.MaterialLabel CausaleLabel;
        private MaterialSkin.Controls.MaterialLabel ImportoLabel;
        private System.Windows.Forms.Panel SingolaPanel;
        private MaterialSkin.Controls.MaterialRaisedButton CreaBtn;
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
        private MaterialSkin.Controls.MaterialListView Inserite;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialRadioButton PersonaGiuridicaRadio;
        private MaterialSkin.Controls.MaterialRadioButton PersonaFisicaRadio;
        private MaterialSkin.Controls.MaterialSingleLineTextField IndirizzoField;
        private MaterialSkin.Controls.MaterialLabel IndirizzoLbl;
        private MaterialSkin.Controls.MaterialLabel TipologiaLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField DataField;
        private MaterialSkin.Controls.MaterialLabel DataLbl;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialFlatButton AggiungiVociBtn;
        private MaterialSkin.Controls.MaterialFlatButton NuovaBtn;
        private MaterialSkin.Controls.MaterialFlatButton EliminaVociBtn;
        private MaterialSkin.Controls.MaterialFlatButton AccettaBtn;
        private MaterialSkin.Controls.MaterialFlatButton RifiutaBtn;
        private MaterialSkin.Controls.MaterialSingleLineTextField SearchLabel;
    }
}