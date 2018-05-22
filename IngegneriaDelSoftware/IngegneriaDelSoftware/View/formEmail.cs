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
        private ControllerClienti _controller;
        private VisualizzatoreCliente _visualizzatore;

        private List<ClienteMostrato<SchedaCliente>> _clientiCaricati = new List<ClienteMostrato<SchedaCliente>>();

        #region "Costruttore"
        protected FormEmail()
        {
            InitializeComponent();

            flowClienti.Scroll += (s, e) => HandleScroll();
            flowClienti.MouseWheel += (s, e) => HandleScroll();
        }

        public FormEmail(ControllerClienti controller) : this()
        {
            this._controller = controller;
            this._visualizzatore = new VisualizzatoreCliente(controller.CollezioneClienti);

            this._controller.CollezioneClienti.OnRimozione += this.RimossoCliente;
        }
        #endregion

        #region "Carica schede cliente"
        /// <summary>
        /// Funzione che mostra le schede dei clienti nella form
        /// </summary>
        private void CaricaSchedaCliente()
        {
            Cliente clienteDaMostrare = _visualizzatore.ProssimoCliente();
            if (clienteDaMostrare == null)
                return;

            SchedaCliente schedaCliente = new SchedaCliente(_controller, clienteDaMostrare, this.panelForm);
            this.flowClienti.Controls.Add(schedaCliente);
            this._clientiCaricati.Add(new ClienteMostrato<SchedaCliente>(clienteDaMostrare, schedaCliente, false));

        }

        /// <summary>
        /// Funzione che permette di visualizzare un certo numero di clienti nella form
        /// </summary>
        /// <param name="quanti">Quanti clienti mostrare</param>
        private void RiempiSchedeClienti(int quanti)
        {
            for (int i = 0; i < quanti; i++)
            {
                CaricaSchedaCliente();
            }
        }
        #endregion

        private void FormEmail_Load(object sender, EventArgs e)
        {
            // Carico il numero di clienti che possono essere visti in base alle dimensioni dello schermo
            RiempiSchedeClienti(Screen.FromControl(this).Bounds.Height / SchedaCliente.AltezzaSchedaClienti() + 1);
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
    }

}
