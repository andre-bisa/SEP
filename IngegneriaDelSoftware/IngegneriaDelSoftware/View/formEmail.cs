using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin.Controls;
using IngegneriaDelSoftware.View.Overlay;
using IngegneriaDelSoftware.View.Controlli;
using System.Windows.Forms;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.View
{
    public partial class FormEmail : MaterialForm
    {
        private ControllerInviaMail _controllerInviaMail = new ControllerInviaMail();

        private ControllerClienti _controllerClienti;
        private VisualizzatoreCliente _visualizzatore;

        private List<ClienteMostrato<SchedaCliente>> _clientiCaricati = new List<ClienteMostrato<SchedaCliente>>();
        private int quantiClientiMostrare;

        private List<Email> _indirizziACuiMandare = new List<Email>();

        private CollezioneEmailInviate _emailInviate = CollezioneEmailInviate.GetInstance();

        #region "Costruttore"
        protected FormEmail()
        {
            InitializeComponent();

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
        }

        public FormEmail(ControllerClienti controller) : this()
        {
            this._controllerClienti = controller;

            // Funzione che permette di effettuare la ricerca per tutti i campi
            var ricercaTuttiParametri = new Func<Cliente, string, bool>((cliente, stringa) =>
            {
                return cliente.IDCliente.ToLower().Contains(stringa.ToLower()) || cliente.Persona.Indirizzo.ToLower().Contains(stringa.ToLower()) || cliente.Denominazione.ToLower().Contains(stringa.ToLower()) || cliente.Referenti.Any(referente => referente.Nome.ToLower().Contains(stringa.ToLower()));
            });
            this._visualizzatore = new VisualizzatoreCliente(controller.CollezioneClienti, ricercaTuttiParametri);

            this._controllerClienti.CollezioneClienti.OnRimozione += this.RimossoCliente;
        }
        #endregion

        #region "Carica schede cliente"
        /// <summary>
        /// Funzione che mostra le schede dei clienti nella form
        /// </summary>
        private void CaricaSchedaCliente()
        {
            Cliente clienteDaMostrare;

            do // Non mostro i clienti che non hanno indirizzi Email
            {
                clienteDaMostrare = _visualizzatore.ProssimoCliente();
            } while (clienteDaMostrare != null && clienteDaMostrare.Persona.Email.Count == 0);

            if (clienteDaMostrare == null)
                return;

            SchedaCliente schedaCliente = new SchedaCliente(_controllerClienti, clienteDaMostrare, this.panelForm);
            schedaCliente.ModificataSelezione += ModificataSelezione;
            this.flowClienti.Controls.Add(schedaCliente);
            this._clientiCaricati.Add(new ClienteMostrato<SchedaCliente>(clienteDaMostrare, schedaCliente, false));

        }

        private void ModificataSelezione(object sender, ArgsSchedaCliente e)
        {
            if (e.SchedaCliente.Selected)
            {
                this._indirizziACuiMandare.AddRange(e.Cliente.Persona.Email);
            }
            else
            {
                foreach (Email email in e.Cliente.Persona.Email)
                {
                    this._indirizziACuiMandare.Remove(email);
                }
            }
        }

        /// <summary>
        /// Funzione che permette di visualizzare un certo numero di clienti nella form
        /// </summary>
        /// <param name="quanti">Quanti clienti mostrare</param>
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
        #endregion

        #region Carica email in lista
        private void CaricaEmailNellaLista()
        {
            foreach (MailInviata email in this._emailInviate)
            {
                string[] row = { email.Data.ToString(), email.Oggetto, email.Email, email.Corpo };
                ListViewItem item = new ListViewItem(row);
                this.listMailInviate.Items.Add(item);
            }
        }
        #endregion

        private void FormEmail_Load(object sender, EventArgs e)
        {
            // Carico il numero di clienti che possono essere visti in base alle dimensioni dello schermo
            RiempiSchedeClienti(Screen.FromControl(this).Bounds.Height / SchedaCliente.AltezzaSchedaClienti() + 1);
            CaricaEmailNellaLista();
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

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            RicercaTraClienti();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInvia_Click(object sender, EventArgs e)
        {
            bool mandate = this._controllerInviaMail.InviaMail(DateTime.Now, txtOggetto.Text.Trim(), txtCorpo.Text, this._indirizziACuiMandare);
            if (mandate)
                MessageBox.Show("Mail inviata con successo.");
        }
    }

}
