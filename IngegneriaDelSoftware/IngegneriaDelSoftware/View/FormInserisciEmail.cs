using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.Model.ArgsEvent;
using MaterialSkin.Controls;
using System.Text.RegularExpressions;

namespace IngegneriaDelSoftware.View
{
    public partial class FormInserisciEmail : MaterialForm
    {
        public event EventHandler<ArgsEmail> OnAggiunta;

        public FormInserisciEmail()
        {
            InitializeComponent();
        }

        private void BtnSalva_Click(object sender, EventArgs e)
        {
            Regex controlloEmail = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
            if (!controlloEmail.Match(txtEmail.Text.Trim()).Success)
            {
                FormConfim.Show("Errore email", "Errore, la e-mail inserita non è valida.");
                return;
            }

            if (OnAggiunta != null)
            {
                ArgsEmail args = new ArgsEmail(new Model.Email(txtEmail.Text.Trim(), txtNota.Text.Trim()));
                OnAggiunta(this, args);
            }
            this.Close();
        }

        private void BtnCancella_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
