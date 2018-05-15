using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.Graphics.Controlli
{
    public partial class PannelloCliente : UserControl
    {
        public event EventHandler<ArgsCliente> DoppioClickCliente;
        public event EventHandler<ArgsCliente> ModificataSelezione;

        public int Cliente { get; private set; }

        private bool _selected = false;
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                if ( Selected )
                {
                    this.BackColor = System.Drawing.Color.LightCyan;
                } else {
                    this.BackColor = System.Drawing.SystemColors.Info;
                }
                LanciaEvento(ModificataSelezione);
            }
        }

        protected PannelloCliente()
        {
            InitializeComponent();
        }

        public PannelloCliente(int cliente) : this()
        {
            Cliente = cliente;
        }

        private void MouseClickOnPanel(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                DoubleClick_Panel();
                Click_Panel();      // Perchè lancia 2 eventi, uno per il click e l'altro per il doppio-click
            }
            else
            {
                Click_Panel();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Panel()
        {
            Selected = !Selected;   // Nego la selezione
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleClick_Panel()
        {
            LanciaEvento(DoppioClickCliente);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evento"></param>
        private void LanciaEvento(EventHandler<ArgsCliente> evento)
        {
            if (evento != null)
            {
                ArgsCliente args = new ArgsCliente(Cliente, this);
                evento(this, args);
            }
        }
    }

}
