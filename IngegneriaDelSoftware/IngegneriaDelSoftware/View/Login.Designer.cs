namespace IngegneriaDelSoftware
{
    partial class Login
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
            this.BtnLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
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
            materialLabel1.Location = new System.Drawing.Point(12, 81);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(77, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Username";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel2.Location = new System.Drawing.Point(14, 116);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(75, 19);
            materialLabel2.TabIndex = 1;
            materialLabel2.Text = "Password";
            // 
            // BtnLogin
            // 
            this.BtnLogin.AutoSize = true;
            this.BtnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnLogin.Depth = 0;
            this.BtnLogin.Icon = null;
            this.BtnLogin.Location = new System.Drawing.Point(117, 162);
            this.BtnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Primary = true;
            this.BtnLogin.Size = new System.Drawing.Size(61, 36);
            this.BtnLogin.TabIndex = 5;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Depth = 0;
            this.txtUsername.Hint = "";
            this.txtUsername.Location = new System.Drawing.Point(99, 77);
            this.txtUsername.MaxLength = 30;
            this.txtUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.Size = new System.Drawing.Size(114, 23);
            this.txtUsername.TabIndex = 8;
            this.txtUsername.TabStop = false;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Depth = 0;
            this.txtPassword.Hint = "";
            this.txtPassword.Location = new System.Drawing.Point(99, 116);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(114, 23);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.TabStop = false;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(256, 233);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(materialLabel2);
            this.Controls.Add(materialLabel1);
            this.Name = "Login";
            this.Sizable = false;
            this.Text = "Login";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsername;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private MaterialSkin.Controls.MaterialRaisedButton BtnLogin;
    }
}