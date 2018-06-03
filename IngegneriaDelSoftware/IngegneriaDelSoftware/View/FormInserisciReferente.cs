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

namespace IngegneriaDelSoftware.View
{
    public partial class FormInserisciReferente : MaterialForm
    {
        public event EventHandler<ArgsReferente> OnAggiunta;

        public FormInserisciReferente()
        {
            InitializeComponent();
        }

        private void BtnSalva_Click(object sender, EventArgs e)
        {
            if (OnAggiunta != null)
            {
                ArgsReferente args = new ArgsReferente(new Model.Referente(txtNome.Text.Trim(), txtNota.Text.Trim()));
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
