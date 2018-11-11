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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.View.Controlli
{
    public partial class VisualizzatoreColonnaClienti : UserControl
    {
        private List<Cliente> _clientiSelezionati = new List<Cliente>();
        private List<ClienteMostrato<SchedaCliente>> _clientiCaricati = new List<ClienteMostrato<SchedaCliente>>();
        private int quantiClientiMostrare;
        private VisualizzatoreClienti _visualizzatore;
        private ControllerClienti _controllerClienti = ControllerClienti.GetInstance();

        #region Proprietà
        /// <summary>
        /// Pannello dove verrà mostrato l'overlay
        /// </summary>
        public Panel PannelloForm { get; set; } = null;

        private Predicate<Cliente> _filtroCliente = null;
        /// <summary>
        /// Ulteriore filtro da applicare alla visualizzazione dei clienti
        /// </summary>
        public Predicate<Cliente> FiltroCliente
        {
            get
            {
                return this._filtroCliente;
            }
            set
            {
                if (value == null)
                    return;
                if (this._filtroCliente == null)
                {
                    this._filtroCliente = value;
                    this._visualizzatore.AggiungiFiltro(value);
                }
            }
        }

        /// <summary>
        /// Restituisce l'elenco dei clienti selezionati
        /// </summary>
        public List<Cliente> ClientiSelezionati
        {
            get
            {
                return new List<Cliente>(_clientiSelezionati);
            }
        }

        /// <summary>
        /// Imposta il numero massimo di clienti selezionabili
        /// </summary>
        public uint NumeroMassimoClientiSelezionati = uint.MaxValue;

        #endregion

        public VisualizzatoreColonnaClienti() : this(null, null) { }

        /// <summary>
        /// Crea un visualizzatore in colonna di clienti
        /// </summary>
        /// <param name="pannelloForm">Pannello OPZIONALE della form (dove verrà aperto l'overlay)</param>
        /// <param name="filtroCliente">Filtro OPZIONALE che consente di mostrare solo i clienti che verificano il filtro</param>
        public VisualizzatoreColonnaClienti(Panel pannelloForm = null, Predicate<Cliente> filtroCliente = null)
        {
            InitializeComponent();

            this.PannelloForm = pannelloForm;
            this.FiltroCliente = filtroCliente;

            // Funzione che permette di effettuare la ricerca per tutti i campi
            var ricercaTuttiParametri = new Func<Cliente, string, bool>((cliente, stringa) =>
            {
                return cliente.IDCliente.ToLower().Contains(stringa.ToLower()) || cliente.Persona.Indirizzo.ToLower().Contains(stringa.ToLower()) || cliente.Denominazione.ToLower().Contains(stringa.ToLower()) || cliente.Referenti.Any(referente => referente.Nome.ToLower().Contains(stringa.ToLower()));
            });
            this._visualizzatore = new VisualizzatoreClienti(ricercaTuttiParametri);

            this._controllerClienti.CollezioneClienti.OnRimozione += this.RimossoCliente;
            this._controllerClienti.CollezioneClienti.OnAggiunta += (o, e) => { CaricaClientiMancanti(); };

            flowClienti.Scroll += (s, e) => HandleScroll();
            flowClienti.MouseWheel += (s, e) => HandleScroll();
            txtSearchBar.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RicercaTraClienti();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };

        }

        #region "Carica clienti graficamente"
        /// <summary>
        /// Funzione che permette di visualizzare un certo numero di clienti nella form
        /// </summary>
        /// <param name="quanti">Quanti clienti mostrare</param>
        private void RiempiSchedeClienti(int quanti)
        {
            this.quantiClientiMostrare += quanti;
            CaricaClientiMancanti();
        }

        /// <summary>
        /// Funzione che mostra le schede dei clienti nella form
        /// </summary>
        private void CaricaSchedaCliente()
        {
            Cliente clienteDaMostrare = _visualizzatore.ProssimoCliente();

            if (clienteDaMostrare == null)
                return;

            SchedaCliente schedaCliente = new SchedaCliente(clienteDaMostrare, this.PannelloForm);
            schedaCliente.ModificataSelezione += ModificataSelezione;
            this.flowClienti.Controls.Add(schedaCliente);
            this._clientiCaricati.Add(new ClienteMostrato<SchedaCliente>(clienteDaMostrare, schedaCliente, false));
        }

        private void CaricaClientiMancanti()
        {
            for (int i = this._clientiCaricati.Count; i < this.quantiClientiMostrare; i++)
            {
                CaricaSchedaCliente();
            }
        }
        #endregion

        #region "Gestione eventi"
        #region "Gestione eventi controlli"
        private void OnLoad(object sender, EventArgs e)
        {
            // Carico il numero di clienti che possono essere visti in base alle dimensioni dello schermo
            RiempiSchedeClienti(Screen.FromControl(this).Bounds.Height / SchedaCliente.AltezzaSchedaClienti() + 1);
        }

        private void SearchPicture_Click(object sender, EventArgs e)
        {
            RicercaTraClienti();
        }
        #endregion

        private void ModificataSelezione(object sender, ArgsSchedaCliente e)
        {
            if (e.SchedaCliente.Selected)
            {
                if (this._clientiSelezionati.Count < this.NumeroMassimoClientiSelezionati)
                    this._clientiSelezionati.Add(e.Cliente);
                else
                    e.SchedaCliente.Selected = false;
            }
            else
            {
                if (this._clientiSelezionati.Contains(e.Cliente))
                    this._clientiSelezionati.Remove(e.Cliente);
            }
        }

        /// <summary>
        /// Funzione che permette di caricare i clienti solo quando si sta visualizzando l'ultimo cliente
        /// </summary>
        private void HandleScroll()
        {
            // if (sto visualizzando l'ultimo cliente) => ne carico un altro
            if (flowClienti.VerticalScroll.Value >= flowClienti.VerticalScroll.Maximum - flowClienti.VerticalScroll.LargeChange - SchedaCliente.AltezzaSchedaClienti())
                RiempiSchedeClienti(1);
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
        #endregion

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

        

    }
}
