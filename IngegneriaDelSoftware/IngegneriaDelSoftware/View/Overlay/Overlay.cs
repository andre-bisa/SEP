using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.View.Overlay
{
    public partial class Overlay : UserControl
    {

        /// <summary>
        /// Pannello contenuto all'interno all'overlay
        /// </summary>
        public Panel Panel { get; private set; }
        /// <summary>
        /// Titolo dell'overlay
        /// </summary>
        public string Titolo
        {
            get => lblTitolo.Text;
            set => lblTitolo.Text = value;
        }

        private Panel _panelContainer;

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="panel">Pannello nel quale apparirà l'overlay</param>
        public Overlay(Panel panelContainer)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Visible = false;
            _panelContainer = panelContainer;

            //_panelContainer.Controls.Add(this);   // Aggiungi questo overlay al pannello passato
        }

        ~Overlay()
        {
            _panelContainer.Controls.Remove(this);  // Rimuovi l'overlay tra i componenti
        }

        private void LblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void Open()
        {
            this.SuspendLayout();
            if (!_panelContainer.Controls.Contains(this))
                _panelContainer.Controls.Add(this);
            this.Visible = true;
            this.BringToFront();
            this.ResumeLayout(false);
        }

        public virtual void Close()
        {
            this.Visible = false;
            this.SendToBack();
        }

        protected virtual void AddPanel(Panel panel)
        {
            if (this.Panel == panel)
                return;
            this.Panel = panel;
            this.Panel.BackColor = System.Drawing.Color.White;
            this.Panel.Visible = true;
            this.Panel.Dock = DockStyle.Fill;
            this.Panel.AutoSize = true;
            this.Panel.AutoScroll = true;
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(this.Panel);
            this.Panel.BringToFront();
        }
    }
}
