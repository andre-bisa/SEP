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

namespace IngegneriaDelSoftware.View
{
    public partial class FormEmail : MaterialForm
    {
        private ControllerClienti _controller;

        private VisualizzatoreCliente _visualizzatore;

        private Dictionary<string, Tuple<Cliente, PannelloCliente>> _clienti = new Dictionary<string, Tuple<Cliente, PannelloCliente>>();

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

            foreach (Cliente c in _controller.CollezioneClienti)
            {
                this._clienti.Add(c.IDCliente, new Tuple<Cliente, PannelloCliente>(c, null));
            }
        }
        #endregion

        #region "Carica schede cliente"
        /// <summary>
        /// Funzione che mostra le schede dei clienti nella form
        /// </summary>
        private void CaricaSchedaCliente()
        {
            Cliente clienteDaMostrare = _visualizzatore.ProssimoCliente();
            SchedaCliente schedaCliente = new SchedaCliente(_controller, clienteDaMostrare, this.panelForm);
            flowClienti.Controls.Add(schedaCliente);
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
    }

}
