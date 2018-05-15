namespace IngegneriaDelSoftware.Graphics.Overlay
{
    partial class OverlayCliente
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
            MaterialSkin.Controls.MaterialLabel label1;
            MaterialSkin.Controls.MaterialLabel materialLabel1;
            MaterialSkin.Controls.MaterialLabel materialLabel2;
            MaterialSkin.Controls.MaterialLabel materialLabel3;
            MaterialSkin.Controls.MaterialLabel materialLabel4;
            MaterialSkin.Controls.MaterialLabel materialLabel5;
            MaterialSkin.Controls.MaterialLabel materialLabel6;
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCognome = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNome = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblCognome = new MaterialSkin.Controls.MaterialLabel();
            this.lblNome = new MaterialSkin.Controls.MaterialLabel();
            this.btnSalva = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAnnulla = new MaterialSkin.Controls.MaterialFlatButton();
            this.listReferenti = new MaterialSkin.Controls.MaterialListView();
            this.ReferentiReferente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReferentiNota = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listTelefoni = new MaterialSkin.Controls.MaterialListView();
            this.TelefoniTelefono = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TelefoniNota = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listEmail = new MaterialSkin.Controls.MaterialListView();
            this.EmailEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmailNota = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtCodiceFiscale = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPartitaIVA = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtIndirizzo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDenominazione = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCodice = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblDenominazione = new MaterialSkin.Controls.MaterialLabel();
            this.checkPotenziale = new MaterialSkin.Controls.MaterialCheckBox();
            this.checkEx = new MaterialSkin.Controls.MaterialCheckBox();
            this.radioGiuridica = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioFisica = new MaterialSkin.Controls.MaterialRadioButton();
            label1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.Font = new System.Drawing.Font("Roboto", 11F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            label1.Location = new System.Drawing.Point(35, 85);
            label1.MouseState = MaterialSkin.MouseState.HOVER;
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 19);
            label1.TabIndex = 3;
            label1.Text = "Codice";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel1.Location = new System.Drawing.Point(35, 143);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(65, 19);
            materialLabel1.TabIndex = 7;
            materialLabel1.Text = "Indirizzo";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel2.Location = new System.Drawing.Point(35, 201);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(81, 19);
            materialLabel2.TabIndex = 9;
            materialLabel2.Text = "Partita IVA";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel3.Location = new System.Drawing.Point(273, 201);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new System.Drawing.Size(105, 19);
            materialLabel3.TabIndex = 10;
            materialLabel3.Text = "Codice fiscale";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel4.Location = new System.Drawing.Point(35, 263);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new System.Drawing.Size(47, 19);
            materialLabel4.TabIndex = 14;
            materialLabel4.Text = "Email";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel5.Location = new System.Drawing.Point(273, 263);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new System.Drawing.Size(64, 19);
            materialLabel5.TabIndex = 16;
            materialLabel5.Text = "Telefoni";
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel6.Location = new System.Drawing.Point(35, 385);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new System.Drawing.Size(69, 19);
            materialLabel6.TabIndex = 18;
            materialLabel6.Text = "Referenti";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtCognome);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.lblCognome);
            this.panel1.Controls.Add(this.lblNome);
            this.panel1.Controls.Add(this.btnSalva);
            this.panel1.Controls.Add(this.btnAnnulla);
            this.panel1.Controls.Add(materialLabel6);
            this.panel1.Controls.Add(this.listReferenti);
            this.panel1.Controls.Add(materialLabel5);
            this.panel1.Controls.Add(this.listTelefoni);
            this.panel1.Controls.Add(materialLabel4);
            this.panel1.Controls.Add(this.listEmail);
            this.panel1.Controls.Add(this.txtCodiceFiscale);
            this.panel1.Controls.Add(this.txtPartitaIVA);
            this.panel1.Controls.Add(materialLabel3);
            this.panel1.Controls.Add(materialLabel2);
            this.panel1.Controls.Add(this.txtIndirizzo);
            this.panel1.Controls.Add(materialLabel1);
            this.panel1.Controls.Add(this.txtDenominazione);
            this.panel1.Controls.Add(this.txtCodice);
            this.panel1.Controls.Add(this.lblDenominazione);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.checkPotenziale);
            this.panel1.Controls.Add(this.checkEx);
            this.panel1.Controls.Add(this.radioGiuridica);
            this.panel1.Controls.Add(this.radioFisica);
            this.panel1.Location = new System.Drawing.Point(41, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 520);
            this.panel1.TabIndex = 2;
            // 
            // txtCognome
            // 
            this.txtCognome.Depth = 0;
            this.txtCognome.Hint = "Cognome";
            this.txtCognome.Location = new System.Drawing.Point(336, 107);
            this.txtCognome.MaxLength = 32767;
            this.txtCognome.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.PasswordChar = '\0';
            this.txtCognome.SelectedText = "";
            this.txtCognome.SelectionLength = 0;
            this.txtCognome.SelectionStart = 0;
            this.txtCognome.Size = new System.Drawing.Size(159, 23);
            this.txtCognome.TabIndex = 24;
            this.txtCognome.TabStop = false;
            this.txtCognome.UseSystemPasswordChar = false;
            this.txtCognome.Visible = false;
            // 
            // txtNome
            // 
            this.txtNome.Depth = 0;
            this.txtNome.Hint = "Nome";
            this.txtNome.Location = new System.Drawing.Point(154, 107);
            this.txtNome.MaxLength = 32767;
            this.txtNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNome.Name = "txtNome";
            this.txtNome.PasswordChar = '\0';
            this.txtNome.SelectedText = "";
            this.txtNome.SelectionLength = 0;
            this.txtNome.SelectionStart = 0;
            this.txtNome.Size = new System.Drawing.Size(142, 23);
            this.txtNome.TabIndex = 23;
            this.txtNome.TabStop = false;
            this.txtNome.UseSystemPasswordChar = false;
            this.txtNome.Visible = false;
            // 
            // lblCognome
            // 
            this.lblCognome.AutoSize = true;
            this.lblCognome.Depth = 0;
            this.lblCognome.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCognome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCognome.Location = new System.Drawing.Point(322, 85);
            this.lblCognome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCognome.Name = "lblCognome";
            this.lblCognome.Size = new System.Drawing.Size(74, 19);
            this.lblCognome.TabIndex = 22;
            this.lblCognome.Text = "Cognome";
            this.lblCognome.Visible = false;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Depth = 0;
            this.lblNome.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNome.Location = new System.Drawing.Point(146, 85);
            this.lblNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(50, 19);
            this.lblNome.TabIndex = 21;
            this.lblNome.Text = "Nome";
            this.lblNome.Visible = false;
            // 
            // btnSalva
            // 
            this.btnSalva.AutoSize = true;
            this.btnSalva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalva.Depth = 0;
            this.btnSalva.Icon = null;
            this.btnSalva.Location = new System.Drawing.Point(339, 459);
            this.btnSalva.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Primary = true;
            this.btnSalva.Size = new System.Drawing.Size(64, 36);
            this.btnSalva.TabIndex = 20;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.AutoSize = true;
            this.btnAnnulla.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAnnulla.Depth = 0;
            this.btnAnnulla.Icon = null;
            this.btnAnnulla.Location = new System.Drawing.Point(423, 459);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAnnulla.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Primary = false;
            this.btnAnnulla.Size = new System.Drawing.Size(83, 36);
            this.btnAnnulla.TabIndex = 19;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // listReferenti
            // 
            this.listReferenti.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listReferenti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ReferentiReferente,
            this.ReferentiNota});
            this.listReferenti.Depth = 0;
            this.listReferenti.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listReferenti.FullRowSelect = true;
            this.listReferenti.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listReferenti.Location = new System.Drawing.Point(39, 407);
            this.listReferenti.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listReferenti.MouseState = MaterialSkin.MouseState.OUT;
            this.listReferenti.Name = "listReferenti";
            this.listReferenti.OwnerDraw = true;
            this.listReferenti.Size = new System.Drawing.Size(207, 97);
            this.listReferenti.TabIndex = 17;
            this.listReferenti.UseCompatibleStateImageBehavior = false;
            this.listReferenti.View = System.Windows.Forms.View.Details;
            // 
            // ReferentiReferente
            // 
            this.ReferentiReferente.Text = "Nome";
            this.ReferentiReferente.Width = 80;
            // 
            // ReferentiNota
            // 
            this.ReferentiNota.Text = "Nota";
            // 
            // listTelefoni
            // 
            this.listTelefoni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listTelefoni.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TelefoniTelefono,
            this.TelefoniNota});
            this.listTelefoni.Depth = 0;
            this.listTelefoni.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listTelefoni.FullRowSelect = true;
            this.listTelefoni.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listTelefoni.Location = new System.Drawing.Point(277, 285);
            this.listTelefoni.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listTelefoni.MouseState = MaterialSkin.MouseState.OUT;
            this.listTelefoni.Name = "listTelefoni";
            this.listTelefoni.OwnerDraw = true;
            this.listTelefoni.Size = new System.Drawing.Size(218, 97);
            this.listTelefoni.TabIndex = 15;
            this.listTelefoni.UseCompatibleStateImageBehavior = false;
            this.listTelefoni.View = System.Windows.Forms.View.Details;
            // 
            // TelefoniTelefono
            // 
            this.TelefoniTelefono.Text = "Tel";
            this.TelefoniTelefono.Width = 80;
            // 
            // TelefoniNota
            // 
            this.TelefoniNota.Text = "Nota";
            // 
            // listEmail
            // 
            this.listEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listEmail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EmailEmail,
            this.EmailNota});
            this.listEmail.Depth = 0;
            this.listEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listEmail.FullRowSelect = true;
            this.listEmail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listEmail.Location = new System.Drawing.Point(39, 285);
            this.listEmail.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.listEmail.Name = "listEmail";
            this.listEmail.OwnerDraw = true;
            this.listEmail.Size = new System.Drawing.Size(207, 97);
            this.listEmail.TabIndex = 13;
            this.listEmail.UseCompatibleStateImageBehavior = false;
            this.listEmail.View = System.Windows.Forms.View.Details;
            // 
            // EmailEmail
            // 
            this.EmailEmail.Text = "Email";
            this.EmailEmail.Width = 80;
            // 
            // EmailNota
            // 
            this.EmailNota.Text = "Nota";
            // 
            // txtCodiceFiscale
            // 
            this.txtCodiceFiscale.Depth = 0;
            this.txtCodiceFiscale.Hint = "Codice fiscale";
            this.txtCodiceFiscale.Location = new System.Drawing.Point(285, 223);
            this.txtCodiceFiscale.MaxLength = 32767;
            this.txtCodiceFiscale.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCodiceFiscale.Name = "txtCodiceFiscale";
            this.txtCodiceFiscale.PasswordChar = '\0';
            this.txtCodiceFiscale.SelectedText = "";
            this.txtCodiceFiscale.SelectionLength = 0;
            this.txtCodiceFiscale.SelectionStart = 0;
            this.txtCodiceFiscale.Size = new System.Drawing.Size(210, 23);
            this.txtCodiceFiscale.TabIndex = 12;
            this.txtCodiceFiscale.TabStop = false;
            this.txtCodiceFiscale.UseSystemPasswordChar = false;
            // 
            // txtPartitaIVA
            // 
            this.txtPartitaIVA.Depth = 0;
            this.txtPartitaIVA.Hint = "Partita IVA";
            this.txtPartitaIVA.Location = new System.Drawing.Point(47, 223);
            this.txtPartitaIVA.MaxLength = 32767;
            this.txtPartitaIVA.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPartitaIVA.Name = "txtPartitaIVA";
            this.txtPartitaIVA.PasswordChar = '\0';
            this.txtPartitaIVA.SelectedText = "";
            this.txtPartitaIVA.SelectionLength = 0;
            this.txtPartitaIVA.SelectionStart = 0;
            this.txtPartitaIVA.Size = new System.Drawing.Size(199, 23);
            this.txtPartitaIVA.TabIndex = 11;
            this.txtPartitaIVA.TabStop = false;
            this.txtPartitaIVA.UseSystemPasswordChar = false;
            // 
            // txtIndirizzo
            // 
            this.txtIndirizzo.Depth = 0;
            this.txtIndirizzo.Hint = "Indirizzo";
            this.txtIndirizzo.Location = new System.Drawing.Point(45, 165);
            this.txtIndirizzo.MaxLength = 32767;
            this.txtIndirizzo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIndirizzo.Name = "txtIndirizzo";
            this.txtIndirizzo.PasswordChar = '\0';
            this.txtIndirizzo.SelectedText = "";
            this.txtIndirizzo.SelectionLength = 0;
            this.txtIndirizzo.SelectionStart = 0;
            this.txtIndirizzo.Size = new System.Drawing.Size(450, 23);
            this.txtIndirizzo.TabIndex = 8;
            this.txtIndirizzo.TabStop = false;
            this.txtIndirizzo.UseSystemPasswordChar = false;
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Depth = 0;
            this.txtDenominazione.Hint = "Denominazione";
            this.txtDenominazione.Location = new System.Drawing.Point(154, 107);
            this.txtDenominazione.MaxLength = 32767;
            this.txtDenominazione.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.PasswordChar = '\0';
            this.txtDenominazione.SelectedText = "";
            this.txtDenominazione.SelectionLength = 0;
            this.txtDenominazione.SelectionStart = 0;
            this.txtDenominazione.Size = new System.Drawing.Size(341, 23);
            this.txtDenominazione.TabIndex = 6;
            this.txtDenominazione.TabStop = false;
            this.txtDenominazione.UseSystemPasswordChar = false;
            // 
            // txtCodice
            // 
            this.txtCodice.Depth = 0;
            this.txtCodice.Hint = "Codice";
            this.txtCodice.Location = new System.Drawing.Point(48, 107);
            this.txtCodice.MaxLength = 32767;
            this.txtCodice.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.PasswordChar = '\0';
            this.txtCodice.SelectedText = "";
            this.txtCodice.SelectionLength = 0;
            this.txtCodice.SelectionStart = 0;
            this.txtCodice.Size = new System.Drawing.Size(52, 23);
            this.txtCodice.TabIndex = 5;
            this.txtCodice.TabStop = false;
            this.txtCodice.UseSystemPasswordChar = false;
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.AutoSize = true;
            this.lblDenominazione.Depth = 0;
            this.lblDenominazione.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDenominazione.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDenominazione.Location = new System.Drawing.Point(141, 85);
            this.lblDenominazione.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(113, 19);
            this.lblDenominazione.TabIndex = 4;
            this.lblDenominazione.Text = "Denominazione";
            // 
            // checkPotenziale
            // 
            this.checkPotenziale.AutoSize = true;
            this.checkPotenziale.Depth = 0;
            this.checkPotenziale.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkPotenziale.Location = new System.Drawing.Point(400, 24);
            this.checkPotenziale.Margin = new System.Windows.Forms.Padding(0);
            this.checkPotenziale.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkPotenziale.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkPotenziale.Name = "checkPotenziale";
            this.checkPotenziale.Ripple = true;
            this.checkPotenziale.Size = new System.Drawing.Size(95, 30);
            this.checkPotenziale.TabIndex = 3;
            this.checkPotenziale.Text = "Potenziale";
            this.checkPotenziale.UseVisualStyleBackColor = true;
            // 
            // checkEx
            // 
            this.checkEx.AutoSize = true;
            this.checkEx.Depth = 0;
            this.checkEx.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkEx.Location = new System.Drawing.Point(355, 24);
            this.checkEx.Margin = new System.Windows.Forms.Padding(0);
            this.checkEx.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkEx.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkEx.Name = "checkEx";
            this.checkEx.Ripple = true;
            this.checkEx.Size = new System.Drawing.Size(45, 30);
            this.checkEx.TabIndex = 2;
            this.checkEx.Text = "Ex";
            this.checkEx.UseVisualStyleBackColor = true;
            // 
            // radioGiuridica
            // 
            this.radioGiuridica.AutoSize = true;
            this.radioGiuridica.Checked = true;
            this.radioGiuridica.Depth = 0;
            this.radioGiuridica.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioGiuridica.Location = new System.Drawing.Point(112, 24);
            this.radioGiuridica.Margin = new System.Windows.Forms.Padding(0);
            this.radioGiuridica.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioGiuridica.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioGiuridica.Name = "radioGiuridica";
            this.radioGiuridica.Ripple = true;
            this.radioGiuridica.Size = new System.Drawing.Size(84, 30);
            this.radioGiuridica.TabIndex = 1;
            this.radioGiuridica.TabStop = true;
            this.radioGiuridica.Text = "Giuridica";
            this.radioGiuridica.UseVisualStyleBackColor = true;
            this.radioGiuridica.CheckedChanged += new System.EventHandler(this.CambiaRadioPersona);
            // 
            // radioFisica
            // 
            this.radioFisica.AutoSize = true;
            this.radioFisica.Depth = 0;
            this.radioFisica.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioFisica.Location = new System.Drawing.Point(40, 24);
            this.radioFisica.Margin = new System.Windows.Forms.Padding(0);
            this.radioFisica.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioFisica.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioFisica.Name = "radioFisica";
            this.radioFisica.Ripple = true;
            this.radioFisica.Size = new System.Drawing.Size(65, 30);
            this.radioFisica.TabIndex = 0;
            this.radioFisica.Text = "Fisica";
            this.radioFisica.UseVisualStyleBackColor = true;
            this.radioFisica.CheckedChanged += new System.EventHandler(this.CambiaRadioPersona);
            // 
            // OverlayCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "OverlayCliente";
            this.Size = new System.Drawing.Size(810, 650);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialCheckBox checkPotenziale;
        private MaterialSkin.Controls.MaterialCheckBox checkEx;
        private MaterialSkin.Controls.MaterialRadioButton radioGiuridica;
        private MaterialSkin.Controls.MaterialRadioButton radioFisica;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCodice;
        private MaterialSkin.Controls.MaterialLabel lblDenominazione;
        private MaterialSkin.Controls.MaterialRaisedButton btnSalva;
        private MaterialSkin.Controls.MaterialFlatButton btnAnnulla;
        private MaterialSkin.Controls.MaterialListView listReferenti;
        private System.Windows.Forms.ColumnHeader ReferentiReferente;
        private System.Windows.Forms.ColumnHeader ReferentiNota;
        private MaterialSkin.Controls.MaterialListView listTelefoni;
        private System.Windows.Forms.ColumnHeader TelefoniTelefono;
        private System.Windows.Forms.ColumnHeader TelefoniNota;
        private MaterialSkin.Controls.MaterialListView listEmail;
        private System.Windows.Forms.ColumnHeader EmailEmail;
        private System.Windows.Forms.ColumnHeader EmailNota;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCodiceFiscale;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPartitaIVA;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIndirizzo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDenominazione;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCognome;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNome;
        private MaterialSkin.Controls.MaterialLabel lblCognome;
        private MaterialSkin.Controls.MaterialLabel lblNome;
    }
}
