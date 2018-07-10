/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

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
            Calendario.GetInstance().OnModifica += (e, s) => this.riempiAppuntamenti();
            Calendario.GetInstance().OnAggiunta += (e, s) => this.riempiAppuntamenti();
            Calendario.GetInstance().OnRimozione += (e, s) => this.riempiAppuntamenti();
        }

        private void riempiAppuntamenti() {
            this.AppunamentiList.Items.Clear();
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
