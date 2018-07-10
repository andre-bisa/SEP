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

using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.View;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerHome {

        private FormAppuntamenti _appuntamento = null;
        private FormClienti _clienti = null;
        private FormEmail _email = null;
        private GenericForm _fatture = null;
        private GenericForm _vendite = null;
        private GenericForm _preventivi = null;
        private VisualizzaCalendario _calendario = null;
        private Form _impostazioni = null;

        public void MostraAppuntamento() {
            if(this._appuntamento == null || this._appuntamento.IsDisposed) {
                this._appuntamento = new FormAppuntamenti();
                MaterialSkinManager.Instance.AddFormToManage(_appuntamento);
                this._appuntamento.Show();
            }
            this._appuntamento.BringToFront();
        }

        public void MostraClienti() {
            if(this._clienti == null || this._clienti.IsDisposed) {
                this._clienti = new FormClienti();
                MaterialSkinManager.Instance.AddFormToManage(_clienti);
                this._clienti.Show();
            }
            this._clienti.BringToFront();
        }

        public void MostraCalendario() {
            if(this._calendario == null || this._calendario.IsDisposed) {
                this._calendario = new VisualizzaCalendario(new ControllerCalendario());
                MaterialSkinManager.Instance.AddFormToManage(_calendario);
                this._calendario.Show();
            }
            this._calendario.BringToFront();
        }

        public void MostraEmail() {
            if(this._email == null || this._email.IsDisposed) {
                this._email = new FormEmail();
                MaterialSkinManager.Instance.AddFormToManage(_email);
                this._email.Show();
            }
            this._email.BringToFront();
        }

        public void MostraFatture() {
            if(this._fatture == null || this._fatture.IsDisposed) {
                this._fatture = GenericViewLoader.getFatturaForm(new ControllerFatture());
                MaterialSkinManager.Instance.AddFormToManage(_fatture);
                this._fatture.Show();
            }
            this._fatture.BringToFront();
        }

        public void MostraPreventivi() {
            if(this._preventivi == null || this._preventivi.IsDisposed) {
                this._preventivi = GenericViewLoader.getPreventivoForm(new ControllerPreventivi());
                MaterialSkinManager.Instance.AddFormToManage(_preventivi);
                this._preventivi.Show();
            }
            this._preventivi.BringToFront();
        }

        public void MostraVendite() {
            if(this._vendite == null || this._vendite.IsDisposed) {
                this._vendite = GenericViewLoader.getVenditaForm(new ControllerVendite());
                MaterialSkinManager.Instance.AddFormToManage(_vendite);
                this._vendite.Show();
            }
            this._vendite.BringToFront();
        }

        public void MostraImpostazioni() {
            if(this._impostazioni == null || this._impostazioni.IsDisposed) {
                this._impostazioni = new System.Windows.Forms.Form();
                this._impostazioni.Text = "S00N";
                this._impostazioni.Show();
            }
            this._impostazioni.BringToFront();
        }

        public List<Appuntamento> AppuntamentiDiOggi() {
            return Calendario.GetInstance().AppuntamentiDaA(DateTime.Now, DateTime.Now.AddDays(1));
        }
    }
}
