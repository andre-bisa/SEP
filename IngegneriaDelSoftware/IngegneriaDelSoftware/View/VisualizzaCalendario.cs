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
using System.Windows.Forms;
using IngegneriaDelSoftware.Model;
using MaterialSkin.Controls;
using IngegneriaDelSoftware.Controller;
using static System.Windows.Forms.ListView;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.View
{
    public partial class VisualizzaCalendario : MaterialForm
    {
        //private Appuntamento _a1, _a2;
        private ControllerCalendario _controller;

        private void Inserimento(object o, ArgsAppuntamento a)
        {
            //Cancello la ListView per reinserire tutto in ordine
            this.listCalendario.Items.Clear();

            foreach (Appuntamento appuntamento in this._controller.GetAppuntamentiDaA(dateTimePickerDa.Value, dateTimePickerA.Value))
            {
                ListViewItem item = new ListViewItem(appuntamento.ToString().Split(';'));
                listCalendario.Items.Add(item);
            }
        }

        private void Modifica(object o, ArgsModifica<Appuntamento> a)
        {
            //Cancello la ListView per reinserire tutto in ordine
            this.listCalendario.Items.Clear();

            foreach (Appuntamento appuntamento in this._controller.GetAppuntamentiDaA(dateTimePickerDa.Value, dateTimePickerA.Value))
            {
                ListViewItem item = new ListViewItem(appuntamento.ToString().Split(';'));
                listCalendario.Items.Add(item);
            }
        }

        /// <summary>
        /// Costruttore di <see cref="VisualizzaCalendario"/>
        /// </summary>
        /// <param name="c">Controller da usare</param>
        /// <exception cref="ArgumentNullException"></exception>
        public VisualizzaCalendario(ControllerCalendario c)
        {

            if (c == null)
            {
                throw new ArgumentNullException("Controller del calendario nullo!");
            }

            this._controller = c;

            InitializeComponent();

            this.dateTimePickerDa.ValueChanged += new System.EventHandler(this.DataCambiata);
            this.dateTimePickerA.ValueChanged += new System.EventHandler(this.DataCambiata);

            //Righe di prova

            /*Persona p1 = new PersonaFisica("cf", "indirizzo", "Nome", "Cognome");

            DatiAppuntamento d1 = new DatiAppuntamento(1, p1, "Riunione", "Bologna", DateTime.Now);
            DatiAppuntamento d2 = new DatiAppuntamento(2, p1, "Riunione", "Napoli", new DateTime(2500, 12, 31, 15, 54, 34));

            _a1 = new Appuntamento(d1);
            _a2 = new Appuntamento(d2);
            
            ListViewItem item1 = new ListViewItem(_a1.ToString().Split(';'));
            ListViewItem item2 = new ListViewItem(_a2.ToString().Split(';'));

            

            listCalendario.Items.Add(item1);
            listCalendario.Items.Add(item2);

            this._controller.AggiungiAppuntamento(_a1);
            this._controller.AggiungiAppuntamento(_a2);*/

            //Riempio preventivamente la ListView con gli appuntamenti presi dal database
            foreach(Appuntamento appuntamento in this._controller.GetAppuntamenti())
            {
                ListViewItem item = new ListViewItem(appuntamento.ToString().Split(';'));
                listCalendario.Items.Add(item);
            }

            Calendario.GetInstance().OnAggiunta += Inserimento;
            Calendario.GetInstance().OnModifica += Modifica;
            Calendario.GetInstance().OnRimozione += Inserimento;

            this.listCalendario.MouseDoubleClick += this.ListCalendario_SelectedIndexChanged;
        }

        private void DataCambiata(object sender, EventArgs e)
        {
            if (DataValida())
            {
                listCalendario.Enabled = true;

                //Ricavo la lista degli appuntamenti da visualizzare per le date inserite
                List<Appuntamento> appuntamenti = new List<Appuntamento>();
                appuntamenti = this._controller.GetAppuntamentiDaA(dateTimePickerDa.Value, dateTimePickerA.Value);

                //Cancello tutti gli elementi della ListView
                listCalendario.Items.Clear();

                //Inserisco gli appuntamenti che ho trovato in quel range di date
                foreach(Appuntamento appuntamento in appuntamenti)
                {
                    ListViewItem item = new ListViewItem(appuntamento.ToString().Split(';'));
                    listCalendario.Items.Add(item);
                }
            }
            else
            {
                listCalendario.Enabled = false;
            }
        }

        private bool DataValida()
        {
            if (dateTimePickerA.Value == null || dateTimePickerDa == null)
                return false;

            if (dateTimePickerDa.Value > dateTimePickerA.Value)
                return false;

            return true;
        }

        private void ListCalendario_SelectedIndexChanged(object sender, MouseEventArgs e)
        {
            //Lancio form di visualizzazione dettagliata dell'appuntamento selezionato
            int idAppuntamento = 0;

            //Controllo l'elemento selezionato, che e' l'ID
            if (this.listCalendario.SelectedItems.Count == 1)
            {
                //Risalgo all'elemento selezionato
                foreach (ListViewItem item in this.listCalendario.SelectedItems)
                {
                    idAppuntamento = Convert.ToInt32(item.Text);
                }

                Appuntamento appuntamento = this._controller.GetAppuntamenti()[idAppuntamento];
                
                new FormAppuntamenti(appuntamento).ShowDialog();
            }
        }

        private void ListCalendario_KeyDown(object sender, KeyEventArgs e)
        {
            int idAppuntamento = 0;

            if (e.KeyData == Keys.Delete)
            {

                if (FormConfim.Show("Eliminare l'appuntameto selezionato?", "Confermi l'eliminazione dell'appuntamento?") == DialogResult.OK)
                {

                    //Risalgo all'elemento selezionato
                    foreach (ListViewItem item in this.listCalendario.SelectedItems)
                    {
                        idAppuntamento = Convert.ToInt32(item.Text);
                    }

                    Appuntamento appuntamento = this._controller.GetAppuntamenti()[idAppuntamento];

                    this._controller.RimuoviAppuntamento(appuntamento);
                }
            }
        }
    }
}
