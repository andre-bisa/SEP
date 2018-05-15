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
using IngegneriaDelSoftware.Graphics.Overlay;
using IngegneriaDelSoftware.Graphics.Controlli;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.Graphics
{
    public partial class FormEmail : MaterialForm
    {
        private List<Int32> _clienti = new List<Int32>();
        private int clienteDaCaricare = 0;


        public FormEmail()
        {
            InitializeComponent();

            flowClienti.Scroll += (s, e) => HandleScroll();
            flowClienti.MouseWheel += (s, e) => HandleScroll();
        }

        private void CaricaListaClienti()
        {
            for (int i = 0; i < 100; i++)
                _clienti.Add(i);
        }

        private void CaricaSchedaCliente()
        {
            if (clienteDaCaricare >= _clienti.Count /*|| _clienti[clienteDaCaricare] == null*/)
                return;

            SchedaCliente schedaCliente = new SchedaCliente(_clienti[clienteDaCaricare], this.panelForm);
            flowClienti.Controls.Add(schedaCliente);

            clienteDaCaricare++;
        }

        private void RiempiSchedeClienti(int quanti)
        {
            for (int i = 0; i < quanti; i++)
            {
                CaricaSchedaCliente();
            }
        }

        private void FormEmail_Load(object sender, EventArgs e)
        {
            CaricaListaClienti();
            RiempiSchedeClienti(Screen.FromControl(this).Bounds.Height / SchedaCliente.AltezzaSchedaClienti() + 1);
        }

        private void HandleScroll()
        {
            if (flowClienti.VerticalScroll.Value >= flowClienti.VerticalScroll.Maximum - flowClienti.VerticalScroll.LargeChange - SchedaCliente.AltezzaSchedaClienti())
                RiempiSchedeClienti(1);
        }
    }

}
