using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MaterialSkin.Controls;
using IngegneriaDelSoftware.View.Overlay;
using IngegneriaDelSoftware.View.Controlli;
using System.Windows.Forms;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Controller;

namespace IngegneriaDelSoftware.View
{
    public partial class FormClienti : MaterialForm
    {
        private const int NUMERO_CLIENTI_PER_PAGINA = 12;
        private const int NUMERO_PAGINE_CARICATE_INIZIALMENTE = 2;

        private ControllerClienti _controller;
        private VisualizzatoreCliente _visualizzatoreCliente;

        private List<ClienteMostrato<PannelloCliente>> _clientiCaricati = new List<ClienteMostrato<PannelloCliente>>();

        private int quantiClientiCaricare = NUMERO_CLIENTI_PER_PAGINA * NUMERO_PAGINE_CARICATE_INIZIALMENTE;

        #region "Costruttori"
        protected FormClienti()
        {
            InitializeComponent();
            this.txtSearchBar.KeyDown += (sender, e) => 
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    RicercaTraClienti();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
        }

        public FormClienti(ControllerClienti controller): this()
        {
            // Funzione che permette di effettuare la ricerca per tutti i campi
            var ricercaTuttiParametri = new Func<Cliente, string, bool>((cliente, stringa) =>
            {
                return cliente.IDCliente.Contains(stringa) || cliente.Denominazione.Contains(stringa) || cliente.Referenti.Any(referente => referente.Nome.Contains(stringa));
            });
            this._visualizzatoreCliente = new VisualizzatoreCliente(controller.CollezioneClienti, ricercaTuttiParametri);
            this._controller = controller;

            _controller.CollezioneClienti.OnRimozione += this.RimossoCliente;
        }
        #endregion

        #region "Carica clienti"
        private void CaricaClientiMancanti()
        {
            for (int i = this._clientiCaricati.Count; i < this.quantiClientiCaricare; i++)
            {
                CaricaClienteSullaForm();
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void CaricaClienteSullaForm()
        {
            Cliente clienteDaCaricare = _visualizzatoreCliente.ProssimoCliente();

            if (clienteDaCaricare == null) // Sono già mostrati tutti i clienti
                return;

            PannelloCliente pannelloCliente = new PannelloCliente(_controller, clienteDaCaricare, this.panelForm);
            pannelloCliente.Margin = new Padding(5, 3, 5, 3);
            pannelloCliente.ModificataSelezione += new EventHandler<ArgsPannelloCliente>(this.AbilitaDelete);
            this.flowClienti.Controls.Add(pannelloCliente);
            this._clientiCaricati.Add(new ClienteMostrato<PannelloCliente>(clienteDaCaricare, pannelloCliente, false));
        }

        private void RimossoCliente(object sender, ArgsCliente e)
        {
            if (e.Cliente == null)
                return;

            ClienteMostrato<PannelloCliente> cliente = this._clientiCaricati.Find(c => e.Cliente == c.Cliente);
            if (cliente == null) // non è stato visualizzato
                return;

            PannelloCliente pannelloDaRimuovere = cliente.DoveMostrato;
            if (pannelloDaRimuovere != null)
            {
                this.flowClienti.Controls.Remove(pannelloDaRimuovere);
                this._clientiCaricati.Remove(cliente);
                CaricaClientiMancanti();
            }
        }

        #endregion

        private void RicercaTraClienti()
        {
            this._visualizzatoreCliente.ImpostaFiltroTuttiParametri(txtSearchBar.Text.Trim());

            var queryClientiDaRimuovere =
                (from tripla in this._clientiCaricati
                 where ! this._visualizzatoreCliente.Visualizzabile(tripla.Cliente)    // dove i clienti non devono essere visualizzati
                 select tripla
                 );

            foreach (ClienteMostrato<PannelloCliente> cliente in new List<ClienteMostrato<PannelloCliente>>(queryClientiDaRimuovere))
            {
                this.flowClienti.Controls.Remove(cliente.DoveMostrato);
                this._clientiCaricati.Remove(cliente);
            }

            CaricaClientiMancanti();
        }

        #region "Gestione eventi pannello cliente"
        private void AbilitaDelete(object sender, ArgsPannelloCliente e)
        {
            if (e == null)
                return;
            ClienteMostrato<PannelloCliente> cliente = _clientiCaricati.Find(t => t.Cliente.Equals(e.Cliente));

            if (e.PannelloCliente.Selected)
            {
                cliente.Selezionato = true;
                lblElimina.Enabled = true;
            }
            else
            {
                cliente.Selezionato = false;
                if (_clientiCaricati.Sum(t => (t.Selezionato) ? 1 : 0 ) == 0)
                    lblElimina.Enabled = false;
            }
        }
        #endregion

        #region "Gestione eventi form"
        private void FormClienti_Shown(object sender, EventArgs e)
        {
            // Carica i clienti per arrivare al numero iniziale
            CaricaClientiMancanti();
        }

        private void BtnCaricaAltri_Click(object sender, EventArgs e)
        {
            this.quantiClientiCaricare += NUMERO_CLIENTI_PER_PAGINA;
            CaricaClientiMancanti();
        }

        private void LblIconSearchBar_Click(object sender, EventArgs e)
        {
            RicercaTraClienti();
        }

        private void LblElimina_Click(object sender, EventArgs e)
        {
            if (FormConfim.Show("Eliminare clienti?", "Confermi l'eliminazione dei clienti?") == DialogResult.OK)
            {
                foreach (Cliente c in this._clientiCaricati.FindAll(t => t.Selezionato).Select(t => t.Cliente))
                {
                    this._controller.RimuoviCliente(c);
                }
            }
            MessageBox.Show("Eliminati con successo");
            lblElimina.Enabled = false;
        }

        private void LblOrdina_Click(object sender, EventArgs e)
        {
            this._visualizzatoreCliente.ImpostaComparatore(Comparer<Cliente>.Create((x, y) => x.Denominazione.CompareTo(y.Denominazione)));

            foreach (ClienteMostrato<PannelloCliente> c in this._clientiCaricati)
            {
                this.flowClienti.Controls.Remove(c.DoveMostrato);
            }
            this._clientiCaricati.Clear();
            CaricaClientiMancanti();
        }

        private void MaterialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            OverlayCliente overlayCliente = new OverlayCliente(_controller, this.panelForm);
            overlayCliente.OverlayChiuso += (s, ee) => CaricaClientiMancanti();
            overlayCliente.Open();
        }
        #endregion
    }

}
