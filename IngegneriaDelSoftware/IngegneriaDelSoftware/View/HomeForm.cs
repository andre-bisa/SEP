using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model;
using MaterialSkin;
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
            MaterialSkinManager.Instance.AddFormToManage(this);
            this.riempiAppuntamenti();
        }

        private void riempiAppuntamenti() {
            this._controller.AppuntamentiDiOggi().ForEach((a) => {
                this.AppunamentiList.Items.Add(new ListViewItem(new string[] { a.DataOra.ToString(), a.ConChi.getDenominazione(), a.Luogo.ToString() }));
            });
        }

        private void appuntamentoBtn_Click(object sender, EventArgs e) {
            this._controller.MostraAppuntamento();
        }

        private void clientiBtn_Click(object sender, EventArgs e) {
            this._controller.MostraClienti();
        }

        private void calendarioBtn_Click(object sender, EventArgs e) {
            this._controller.MostraCalendario();
        }

        private void emailBtn_Click(object sender, EventArgs e) {
            this._controller.MostraEmail();
        }

        private void fattureBtn_Click(object sender, EventArgs e) {
            this._controller.MostraFatture();
        }

        private void preventiviBtn_Click(object sender, EventArgs e) {
            this._controller.MostraPreventivi();
        }

        private void venditeBtn_Click(object sender, EventArgs e) {
            this._controller.MostraVendite();
        }

        private void syncBtn_Click(object sender, EventArgs e) {
            this._controller.MostraImpostazioni();
        }
    }
}
