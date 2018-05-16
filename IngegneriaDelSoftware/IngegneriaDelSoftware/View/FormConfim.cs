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

namespace IngegneriaDelSoftware.View
{
    public partial class FormConfim : MaterialForm
    {
        public string Titolo
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }
        public string Messaggio
        {
            get
            {
                return lblMessaggio.Text;
            }
            set
            {
                lblMessaggio.Text = value;
            }
        }

        #region "Costruttori"
        protected FormConfim()
        {
            InitializeComponent();
        }

        protected FormConfim(string titolo, string messaggio) : this()
        {
            Titolo = titolo;
            Messaggio = messaggio;
        }
        #endregion

        #region "Metodi privati"
        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        /// <summary>
        /// Funzione che mostra una richiesta all'utente. Prende spunto dal MessageBox
        /// </summary>
        /// <param name="titolo">Titolo che verrà mostrato nella finestra</param>
        /// <param name="messaggio">Messaggio che si vuole chiedere all'utente</param>
        /// <returns></returns>
        public static DialogResult Show(string titolo, string messaggio)
        {
            FormConfim formConfim = new FormConfim(titolo, messaggio);
            return formConfim.ShowDialog();
        }
    }
}
