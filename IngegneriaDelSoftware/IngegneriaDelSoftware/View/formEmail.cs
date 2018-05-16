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

namespace IngegneriaDelSoftware.View
{
    public partial class FormEmail : MaterialForm
    {
        private List<Cliente> _clienti = new List<Cliente>();
        private int clienteDaCaricare = 0;

        #region "Costruttore"
        public FormEmail()
        {
            InitializeComponent();

            flowClienti.Scroll += (s, e) => HandleScroll();
            flowClienti.MouseWheel += (s, e) => HandleScroll();
        }
        #endregion

        #region "Carica schede cliente"
        /// <summary>
        /// Funzione che riempie la lista di clienti presente nella form
        /// </summary>
        private void CaricaListaClienti()
        {
            for (int i = 0; i < 100; i++)
            {
                Cliente cliente = new Cliente(new PersonaFisica("Codice fiscale", "indirizzo" + i, "nome" + i, "cognome"), "ID" + i);
                _clienti.Add(cliente);
            }
        }

        /// <summary>
        /// Funzione che mostra le schede dei clienti nella form
        /// </summary>
        private void CaricaSchedaCliente()
        {
            if (clienteDaCaricare >= _clienti.Count /*|| _clienti[clienteDaCaricare] == null*/)
                return;

            SchedaCliente schedaCliente = new SchedaCliente(_clienti[clienteDaCaricare], this.panelForm);
            flowClienti.Controls.Add(schedaCliente);

            clienteDaCaricare++;
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
            CaricaListaClienti();
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
