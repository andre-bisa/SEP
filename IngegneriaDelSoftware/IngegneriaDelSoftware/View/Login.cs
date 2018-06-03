using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using IngegneriaDelSoftware.Controller;
using MaterialSkin;
using IngegneriaDelSoftware.View;

namespace IngegneriaDelSoftware
{
    public partial class Login : MaterialForm
    {

        private DialogResult _risultato = DialogResult.Cancel;

        public Login()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.AddFormToManage(this);

            this.txtPassword.KeyDown += this.SubmitLogin;
            this.txtUsername.KeyDown += this.SubmitLogin;
        }

        private void SubmitLogin(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin.PerformClick();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool accesso = ControllerLogin.GetInstance().ControllaCredenziali(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (!accesso)
                    FormConfim.Show("Errore accesso", "Errore, username e/o password errati.", MessageBoxButtons.OK);
                else
                {
                    _risultato = DialogResult.OK;
                    this.Close();
                }
            } catch (Persistenza.ExceptionPersistenza)
            {
                MessageBox.Show("Errore, connessione assente. Il programma termina", "Errore connessione DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = _risultato;
        }
    }
}
