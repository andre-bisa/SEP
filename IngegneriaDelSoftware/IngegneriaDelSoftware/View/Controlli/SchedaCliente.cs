using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.View.Overlay;

namespace IngegneriaDelSoftware.View.Controlli
{
    public partial class SchedaCliente : UserControl
    {
        /// <summary>
        /// Evento lanciato quando si fa click sulla freccia di apertura.
        /// </summary>
        public event EventHandler<ArgsCliente> AperturaCliente;
        /// <summary>
        /// Evento lanciato quando cambia la selezione della casella di controllo.
        /// </summary>
        public event EventHandler<ArgsCliente> ModificataSelezione;

        /// <summary>
        /// Il cliente cui la scheda fa riferimento.
        /// </summary>
        public int Cliente { get; private set; }

        private bool _selected = false;
        /// <summary>
        /// Dice se la scheda è selezionata.
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            private set
            {
                _selected = value;
                if (Selected)
                {
                    this.BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    this.BackColor = System.Drawing.SystemColors.Info;
                }
                LanciaEvento(ModificataSelezione);
            }
        }

        private OverlayCliente _overlayCliente = null;

        /// <summary>
        /// Costruttore base
        /// </summary>
        /// <param name="cliente">Cliente</param>
        public SchedaCliente(int cliente)
        {
            InitializeComponent();

            Cliente = cliente;
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="panelContainer">Pannello che conterrà l'overlay a seguito della pressione del pulsante di espansione</param>
        public SchedaCliente(int cliente, Panel panelContainer) : this(cliente)
        {
            _overlayCliente = new OverlayCliente(Cliente, panelContainer);
            AperturaCliente += new EventHandler<ArgsCliente>(this.ApriOverlayCliente);
        }

        private void CheckScheda_CheckedChanged(object sender, EventArgs e)
        {
            Selected = !Selected;
        }

        private void LblEspandi_Click(object sender, EventArgs e)
        {
            LanciaEvento(AperturaCliente);
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

        private void ApriOverlayCliente(object sender, ArgsCliente e)
        {
            _overlayCliente?.Open();
        }

        public static int AltezzaSchedaClienti()
        {
            return 150;
        }

    }
}
