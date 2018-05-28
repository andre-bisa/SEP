using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.View {
    public partial class HomeForm: MaterialForm {

        private ControllerHome _controller;

        public HomeForm(ControllerHome controller) {
            this._controller = controller;
            InitializeComponent();
            this.riempiAppuntamenti();
        }

        private void riempiAppuntamenti() {
            this._controller.AppuntamentiDiOggi().ForEach((a) => {
                this.AppunamentiList.Items.Add(new ListViewItem(new string[] { a.DataOra.ToString(), a.ConChi.getDenominazione(), a.Luogo.ToString() }));
            });
        }

        private void appuntamentoBtn_Click(object sender, EventArgs e) {
            this.Hide();
            this._controller.MostraAppuntamento();
            this.Show();
        }

        private void clientiBtn_Click(object sender, EventArgs e) {
            this.Hide();
            this._controller.MostraClienti();
            this.Show();
        }

        private void calendarioBtn_Click(object sender, EventArgs e) {
            this.Hide();
            this._controller.MostraCalendario();
            this.Show();
        }

        private void emailBtn_Click(object sender, EventArgs e) {
            this.Hide();
            this._controller.MostraEmail();
            this.Show();
        }

        private void fattureBtn_Click(object sender, EventArgs e) {
            this.Hide();
            this._controller.MostraFatture();
            this.Show();
        }

        private void preventiviBtn_Click(object sender, EventArgs e) {
            this.Hide();
            this._controller.MostraPreventivi();
            this.Show();
        }

        private void venditeBtn_Click(object sender, EventArgs e) {
            this.Hide();
            this._controller.MostraVendite();
            this.Show();
        }

        private void syncBtn_Click(object sender, EventArgs e) {
            this.Hide();
            this._controller.MostraImpostazioni();
            this.Show();
        }
    }
}
