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
using MaterialSkin;

namespace IngegneriaDelSoftware.View.Overlay
{
    public partial class Overlay : UserControl
    {
        public event EventHandler OverlayChiuso;

        /// <summary>
        /// Pannello contenuto all'interno all'overlay
        /// </summary>
        public Panel Panel { get; private set; }
        /// <summary>
        /// Titolo dell'overlay
        /// </summary>
        public string Titolo
        {
            get { return lblTitolo.Text; }
            set { lblTitolo.Text = value; }
        }

        public Color ColoreSfondo
        {
            get
            {
                return this.mainPanel.BackColor;
            }
            internal set
            {
                if (value != null)
                    this.mainPanel.BackColor = value;
            }
        }

        private Panel _panelContainer;  // Pannello dove mostrare l'overlay

        #region "Costruttori"

        private Overlay()
        {
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            panelTitle.BackColor = lblTitolo.BackColor = lblClose.BackColor = manager.ColorScheme.PrimaryColor;
            tableLayoutPanel1.BackColor = manager.ColorScheme.LightPrimaryColor;
            this.Dock = DockStyle.Fill;
            this.Visible = false;
        }

        /// <summary>
        /// Costruttore di default
        /// </summary>
        /// <param name="panel">Pannello nel quale apparirà l'overlay</param>
        public Overlay(Panel panelContainer) : this()
        {
            _panelContainer = panelContainer;
        }
        #endregion

        #region "Distruttore"
        ~Overlay()
        {
            _panelContainer.Controls.Remove(this);  // Rimuovi l'overlay tra i componenti
        }
        #endregion

        #region "Gestione eventi controlli"
        private void LblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClose_MouseHover(object sender, EventArgs e)
        {
            lblClose.BackColor = MaterialSkinManager.Instance.ColorScheme.DarkPrimaryColor;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
        }
        #endregion

        #region "Metodi pubblici"
        public virtual void Open()
        {
            if (!_panelContainer.Controls.Contains(this))
                _panelContainer.Controls.Add(this);
            this.Visible = true;
            this.BringToFront();
        }

        public virtual void Close()
        {
            this.Visible = false;
            this.SendToBack();
            if (OverlayChiuso != null)
                OverlayChiuso(this, null);
        }
        #endregion

        #region "Metodi protected"
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
        #endregion

    }
}
