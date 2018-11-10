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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using MaterialSkin.Controls;
using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.View.Controlli;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.View
{
    public partial class FormAppuntamenti : MaterialForm
    {
        private Appuntamento _appuntamento = null;
        private ControllerCalendario _controllerCalendario = new ControllerCalendario();

        public FormAppuntamenti(Appuntamento appuntamento = null)
        {
            InitializeComponent();
            this.visualizzatoreClienti.NumeroMassimoClientiSelezionati = 1;

            if (appuntamento != null)
            {
                VisualizzaAppuntamento(appuntamento);
            }
        }

        /// <summary>
        /// Visualizza l'<see cref="Appuntamento"/> dato
        /// </summary>
        /// <param name="a"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void VisualizzaAppuntamento(Appuntamento appuntamento)
        {
            this.dataAppuntamento.Value = appuntamento.DataOra;
            this.txtLuogoAppuntamento.Text = appuntamento.Luogo;
            this.txtNoteAppuntamento.Text = appuntamento.Note;

            this._appuntamento = appuntamento;
        }

        /// <summary>
        /// Salva l'appuntamento sul DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            DatiAppuntamento nuoviDatiAppuntamento = new DatiAppuntamento(this._appuntamento.IDAppuntamento, this._appuntamento.ConChi, txtNoteAppuntamento.Text.Trim(), txtLuogoAppuntamento.Text.Trim(), dataAppuntamento.Value);

            if (this._appuntamento == null)
            {
                _controllerCalendario.AggiungiAppuntamento(this._appuntamento);
            }
            else
            {
                this._appuntamento.cambiaDatiAppuntamento(nuoviDatiAppuntamento);
            }
            this.Close();
        }
    }
}
