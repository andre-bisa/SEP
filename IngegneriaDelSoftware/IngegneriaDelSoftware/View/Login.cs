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

namespace IngegneriaDelSoftware
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool accesso = ControllerLogin.GetInstance().ControllaCredenziali(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (!accesso)
                MessageBox.Show("Errore, username e/o password errati.");
            else
                this.Close();
        }
    }
}
