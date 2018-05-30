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

namespace IngegneriaDelSoftware.View
{
    public partial class FormAppuntamenti : MaterialForm
    {
        private Appuntamento _appuntamento = null;

        public FormAppuntamenti(Appuntamento appuntamento = null)
        {
            InitializeComponent();

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
            if (this._appuntamento != null)
            {
                string note = this._appuntamento.Note;
                string luogo = this._appuntamento.Luogo;
                DateTime data = this._appuntamento.DataOra;
                bool modificato = false;

                if (note != this.txtNoteAppuntamento.Text)
                {
                    modificato = true;

                    note = this.txtNoteAppuntamento.Text;
                }
                if (luogo != this.txtLuogoAppuntamento.Text)
                {
                    modificato = true;

                    luogo = this.txtLuogoAppuntamento.Text;
                }
                if (data != this.dataAppuntamento.Value)
                {
                    modificato = true;

                    data = this.dataAppuntamento.Value;
                }

                if (modificato)
                {
                    //Creo nuovi dati dell'appuntamento
                    DatiAppuntamento nuoviDatiAppuntamento = new DatiAppuntamento(this._appuntamento.IDAppuntamento, this._appuntamento.ConChi, note, luogo, data);

                    this._appuntamento.cambiaDatiAppuntamento(nuoviDatiAppuntamento);
                }
            }
            this.Close();
        }
    }
}
