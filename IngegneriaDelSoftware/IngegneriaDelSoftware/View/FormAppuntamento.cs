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
        private ControllerClienti _controllerClienti = ControllerClienti.GetInstance();
        private List<ClienteMostrato<SchedaCliente>> _clientiCaricati = new List<ClienteMostrato<SchedaCliente>>();
        private int quantiClientiMostrare;
        private VisualizzatoreCliente _visualizzatore;
        private List<Cliente> _clientiAppuntamento = new List<Cliente>();

        public FormAppuntamenti(Appuntamento appuntamento = null)
        {
            InitializeComponent();

            if (appuntamento != null)
            {
                VisualizzaAppuntamento(appuntamento);
            }

            flowClienti.Scroll += (s, e) => HandleScroll();
            flowClienti.MouseWheel += (s, e) => HandleScroll();
            txtSearchBar.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    RicercaTraClienti();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };

            // Funzione che permette di effettuare la ricerca per tutti i campi
            var ricercaTuttiParametri = new Func<Cliente, string, bool>((cliente, stringa) =>
            {
                return cliente.IDCliente.ToLower().Contains(stringa.ToLower()) || cliente.Persona.Indirizzo.ToLower().Contains(stringa.ToLower()) || cliente.Denominazione.ToLower().Contains(stringa.ToLower()) || cliente.Referenti.Any(referente => referente.Nome.ToLower().Contains(stringa.ToLower()));
            });
            this._visualizzatore = new VisualizzatoreCliente(ricercaTuttiParametri);

            this._controllerClienti.CollezioneClienti.OnRimozione += this.RimossoCliente;
            this._controllerClienti.CollezioneClienti.OnAggiunta += (o, e) => { CaricaClientiMancanti(); };

            // Carico il numero di clienti che possono essere visti in base alle dimensioni dello schermo
            RiempiSchedeClienti(Screen.FromControl(this).Bounds.Height / SchedaCliente.AltezzaSchedaClienti() + 1);
        }

        private void RimossoCliente(object sender, ArgsCliente e)
        {
            if (e.Cliente == null)
                return;

            ClienteMostrato<SchedaCliente> cliente = this._clientiCaricati.Find(c => e.Cliente == c.Cliente);

            if (cliente == null) // Se non è stato mostrato
                return;

            SchedaCliente schedaDaRimuovere = this._clientiCaricati.Find(c => e.Cliente.Equals(c.Cliente)).DoveMostrato;
            if (schedaDaRimuovere != null)
            {
                this.flowClienti.Controls.Remove(schedaDaRimuovere);
                this._clientiCaricati.Remove(cliente);
                CaricaSchedaCliente();
            }
        }

        private void CaricaSchedaCliente()
        {
            Cliente clienteDaMostrare;

            clienteDaMostrare = _visualizzatore.ProssimoCliente();

            if (clienteDaMostrare == null)
                return;

            SchedaCliente schedaCliente = new SchedaCliente(clienteDaMostrare, this.mainPanel);
            schedaCliente.ModificataSelezione += ModificataSelezione;
            this.flowClienti.Controls.Add(schedaCliente);
            this._clientiCaricati.Add(new ClienteMostrato<SchedaCliente>(clienteDaMostrare, schedaCliente, false));

        }

        private void ModificataSelezione(object sender, ArgsSchedaCliente e)
        {
            if (e.SchedaCliente.Selected)
            {
                this._clientiAppuntamento.Add(e.Cliente);
            }
            else
            {
                this._clientiAppuntamento.Remove(e.Cliente);
            }
        }

        private void RicercaTraClienti()
        {
            this._visualizzatore.ImpostaFiltroTuttiParametri(txtSearchBar.Text.Trim());

            var queryClientiDaRimuovere =
                (from tripla in this._clientiCaricati
                 where !this._visualizzatore.Visualizzabile(tripla.Cliente)    // dove i clienti non devono essere visualizzati
                 select tripla
                 );

            foreach (ClienteMostrato<SchedaCliente> cliente in new List<ClienteMostrato<SchedaCliente>>(queryClientiDaRimuovere))
            {
                this.flowClienti.Controls.Remove(cliente.DoveMostrato);
                this._clientiCaricati.Remove(cliente);
            }

            CaricaClientiMancanti();
        }

        private void HandleScroll()
        {
            // if (sto visualizzando l'ultimo cliente) => ne carico un altro
            if (flowClienti.VerticalScroll.Value >= flowClienti.VerticalScroll.Maximum - flowClienti.VerticalScroll.LargeChange - SchedaCliente.AltezzaSchedaClienti())
                RiempiSchedeClienti(1);
        }

        private void RiempiSchedeClienti(int quanti)
        {
            this.quantiClientiMostrare += quanti;
            CaricaClientiMancanti();
        }

        private void CaricaClientiMancanti()
        {
            for (int i = this._clientiCaricati.Count; i < this.quantiClientiMostrare; i++)
            {
                CaricaSchedaCliente();
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

            if (this._appuntamento != null)
            {
                //Creo nuovi dati dell'appuntamento
                DatiAppuntamento nuoviDatiAppuntamento = new DatiAppuntamento(this._appuntamento.IDAppuntamento, this._appuntamento.ConChi, note, luogo, data);

                this._appuntamento.cambiaDatiAppuntamento(nuoviDatiAppuntamento);
            }
            else
            {
                _controllerCalendario.AggiungiAppuntamento(this._appuntamento);
            }
            this.Close();
        }
    }
}
