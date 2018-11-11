namespace IngegneriaDelSoftware.View
{
    partial class /*
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

FormClienti
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Panel panelSearchBar;
            System.Windows.Forms.Panel panelTextboxSearchBar;
            System.Windows.Forms.Panel panelIconSearchBar;
            MaterialSkin.Controls.MaterialLabel lblIconSearchBar;
            System.Windows.Forms.Panel panelMainContent;
            System.Windows.Forms.SplitContainer splitMainContent;
            System.Windows.Forms.Panel panelCaricaAltri;
            this.txtSearchBar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.panelControlli = new System.Windows.Forms.Panel();
            this.lblElimina = new MaterialSkin.Controls.MaterialLabel();
            this.lblOrdina = new MaterialSkin.Controls.MaterialLabel();
            this.flowClienti = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCaricaAltri = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFloatingActionButton1 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.panelForm = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panelSearchBar = new System.Windows.Forms.Panel();
            panelTextboxSearchBar = new System.Windows.Forms.Panel();
            panelIconSearchBar = new System.Windows.Forms.Panel();
            lblIconSearchBar = new MaterialSkin.Controls.MaterialLabel();
            panelMainContent = new System.Windows.Forms.Panel();
            splitMainContent = new System.Windows.Forms.SplitContainer();
            panelCaricaAltri = new System.Windows.Forms.Panel();
            tableLayoutPanel1.SuspendLayout();
            panelSearchBar.SuspendLayout();
            panelTextboxSearchBar.SuspendLayout();
            panelIconSearchBar.SuspendLayout();
            panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(splitMainContent)).BeginInit();
            splitMainContent.Panel1.SuspendLayout();
            splitMainContent.Panel2.SuspendLayout();
            splitMainContent.SuspendLayout();
            this.panelControlli.SuspendLayout();
            panelCaricaAltri.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(panelSearchBar, 1, 0);
            tableLayoutPanel1.Controls.Add(panelMainContent, 1, 1);
            tableLayoutPanel1.Controls.Add(panelCaricaAltri, 1, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            tableLayoutPanel1.Size = new System.Drawing.Size(898, 732);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panelSearchBar
            // 
            panelSearchBar.Controls.Add(panelTextboxSearchBar);
            panelSearchBar.Controls.Add(panelIconSearchBar);
            panelSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSearchBar.Location = new System.Drawing.Point(47, 3);
            panelSearchBar.Name = "panelSearchBar";
            panelSearchBar.Size = new System.Drawing.Size(802, 30);
            panelSearchBar.TabIndex = 0;
            // 
            // panelTextboxSearchBar
            // 
            panelTextboxSearchBar.Controls.Add(this.txtSearchBar);
            panelTextboxSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTextboxSearchBar.Location = new System.Drawing.Point(0, 0);
            panelTextboxSearchBar.Name = "panelTextboxSearchBar";
            panelTextboxSearchBar.Size = new System.Drawing.Size(762, 30);
            panelTextboxSearchBar.TabIndex = 1;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBar.Depth = 0;
            this.txtSearchBar.Hint = "Search";
            this.txtSearchBar.Location = new System.Drawing.Point(3, 4);
            this.txtSearchBar.MaxLength = 32767;
            this.txtSearchBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.PasswordChar = '\0';
            this.txtSearchBar.SelectedText = "";
            this.txtSearchBar.SelectionLength = 0;
            this.txtSearchBar.SelectionStart = 0;
            this.txtSearchBar.Size = new System.Drawing.Size(756, 23);
            this.txtSearchBar.TabIndex = 10000;
            this.txtSearchBar.TabStop = false;
            this.txtSearchBar.UseSystemPasswordChar = false;
            // 
            // panelIconSearchBar
            // 
            panelIconSearchBar.Controls.Add(lblIconSearchBar);
            panelIconSearchBar.Dock = System.Windows.Forms.DockStyle.Right;
            panelIconSearchBar.Location = new System.Drawing.Point(762, 0);
            panelIconSearchBar.Name = "panelIconSearchBar";
            panelIconSearchBar.Size = new System.Drawing.Size(40, 30);
            panelIconSearchBar.TabIndex = 0;
            // 
            // lblIconSearchBar
            // 
            lblIconSearchBar.Depth = 0;
            lblIconSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            lblIconSearchBar.EnableAnimations = true;
            lblIconSearchBar.Font = new System.Drawing.Font("Roboto", 11F);
            lblIconSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            lblIconSearchBar.Image = global::IngegneriaDelSoftware.Properties.Resources.baseline_search_black_18dp;
            lblIconSearchBar.Location = new System.Drawing.Point(0, 0);
            lblIconSearchBar.MouseState = MaterialSkin.MouseState.HOVER;
            lblIconSearchBar.Name = "lblIconSearchBar";
            lblIconSearchBar.Size = new System.Drawing.Size(40, 30);
            lblIconSearchBar.TabIndex = 0;
            lblIconSearchBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblIconSearchBar.Click += new System.EventHandler(this.LblIconSearchBar_Click);
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(splitMainContent);
            panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMainContent.Location = new System.Drawing.Point(47, 39);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new System.Drawing.Size(802, 628);
            panelMainContent.TabIndex = 1;
            // 
            // splitMainContent
            // 
            splitMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            splitMainContent.Location = new System.Drawing.Point(0, 0);
            splitMainContent.Name = "splitMainContent";
            splitMainContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMainContent.Panel1
            // 
            splitMainContent.Panel1.Controls.Add(this.panelControlli);
            // 
            // splitMainContent.Panel2
            // 
            splitMainContent.Panel2.Controls.Add(this.flowClienti);
            splitMainContent.Size = new System.Drawing.Size(802, 628);
            splitMainContent.SplitterDistance = 74;
            splitMainContent.TabIndex = 0;
            // 
            // panelControlli
            // 
            this.panelControlli.Controls.Add(this.lblElimina);
            this.panelControlli.Controls.Add(this.lblOrdina);
            this.panelControlli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlli.Location = new System.Drawing.Point(0, 0);
            this.panelControlli.Name = "panelControlli";
            this.panelControlli.Size = new System.Drawing.Size(802, 74);
            this.panelControlli.TabIndex = 0;
            // 
            // lblElimina
            // 
            this.lblElimina.Depth = 0;
            this.lblElimina.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblElimina.EnableAnimations = true;
            this.lblElimina.Enabled = false;
            this.lblElimina.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblElimina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblElimina.Image = global::IngegneriaDelSoftware.Properties.Resources.baseline_delete_black_18dp;
            this.lblElimina.Location = new System.Drawing.Point(730, 0);
            this.lblElimina.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblElimina.Name = "lblElimina";
            this.lblElimina.Size = new System.Drawing.Size(36, 74);
            this.lblElimina.TabIndex = 1;
            this.lblElimina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblElimina.Click += new System.EventHandler(this.LblElimina_Click);
            // 
            // lblOrdina
            // 
            this.lblOrdina.Depth = 0;
            this.lblOrdina.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblOrdina.EnableAnimations = true;
            this.lblOrdina.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblOrdina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOrdina.Image = global::IngegneriaDelSoftware.Properties.Resources.baseline_filter_list_black_18dp;
            this.lblOrdina.Location = new System.Drawing.Point(766, 0);
            this.lblOrdina.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOrdina.Name = "lblOrdina";
            this.lblOrdina.Size = new System.Drawing.Size(36, 74);
            this.lblOrdina.TabIndex = 0;
            this.lblOrdina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrdina.Click += new System.EventHandler(this.LblOrdina_Click);
            // 
            // flowClienti
            // 
            this.flowClienti.AutoScroll = true;
            this.flowClienti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowClienti.Location = new System.Drawing.Point(0, 0);
            this.flowClienti.Name = "flowClienti";
            this.flowClienti.Size = new System.Drawing.Size(802, 550);
            this.flowClienti.TabIndex = 0;
            // 
            // panelCaricaAltri
            // 
            panelCaricaAltri.AutoSize = true;
            panelCaricaAltri.BackColor = System.Drawing.Color.White;
            panelCaricaAltri.Controls.Add(this.panel1);
            panelCaricaAltri.Controls.Add(this.materialFloatingActionButton1);
            panelCaricaAltri.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCaricaAltri.Location = new System.Drawing.Point(47, 673);
            panelCaricaAltri.Name = "panelCaricaAltri";
            panelCaricaAltri.Size = new System.Drawing.Size(802, 56);
            panelCaricaAltri.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCaricaAltri);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 56);
            this.panel1.TabIndex = 2;
            // 
            // btnCaricaAltri
            // 
            this.btnCaricaAltri.AutoSize = true;
            this.btnCaricaAltri.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCaricaAltri.BackColor = System.Drawing.Color.Yellow;
            this.btnCaricaAltri.Depth = 0;
            this.btnCaricaAltri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCaricaAltri.Icon = null;
            this.btnCaricaAltri.Location = new System.Drawing.Point(0, 0);
            this.btnCaricaAltri.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCaricaAltri.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCaricaAltri.Name = "btnCaricaAltri";
            this.btnCaricaAltri.Primary = true;
            this.btnCaricaAltri.Size = new System.Drawing.Size(746, 56);
            this.btnCaricaAltri.TabIndex = 0;
            this.btnCaricaAltri.Text = "Carica altri";
            this.btnCaricaAltri.UseVisualStyleBackColor = false;
            this.btnCaricaAltri.Click += new System.EventHandler(this.BtnCaricaAltri_Click);
            // 
            // materialFloatingActionButton1
            // 
            this.materialFloatingActionButton1.AnimateIcon = false;
            this.materialFloatingActionButton1.AnimateShowHideButton = false;
            this.materialFloatingActionButton1.Depth = 0;
            this.materialFloatingActionButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.materialFloatingActionButton1.Icon = global::IngegneriaDelSoftware.Properties.Resources.ic_add_black_48dp;
            this.materialFloatingActionButton1.Location = new System.Drawing.Point(746, 0);
            this.materialFloatingActionButton1.Mini = false;
            this.materialFloatingActionButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFloatingActionButton1.Name = "materialFloatingActionButton1";
            this.materialFloatingActionButton1.Size = new System.Drawing.Size(56, 56);
            this.materialFloatingActionButton1.TabIndex = 1;
            this.materialFloatingActionButton1.Text = "materialFloatingActionButton1";
            this.materialFloatingActionButton1.UseVisualStyleBackColor = true;
            this.materialFloatingActionButton1.Click += new System.EventHandler(this.MaterialFloatingActionButton1_Click);
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForm.AutoScroll = true;
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(tableLayoutPanel1);
            this.panelForm.Location = new System.Drawing.Point(1, 64);
            this.panelForm.Margin = new System.Windows.Forms.Padding(0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(898, 732);
            this.panelForm.TabIndex = 1;
            // 
            // FormClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 800);
            this.Controls.Add(this.panelForm);
            this.MinimumSize = new System.Drawing.Size(900, 800);
            this.Name = "FormClienti";
            this.Text = "Clienti";
            this.Shown += new System.EventHandler(this.FormClienti_Shown);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelSearchBar.ResumeLayout(false);
            panelTextboxSearchBar.ResumeLayout(false);
            panelIconSearchBar.ResumeLayout(false);
            panelMainContent.ResumeLayout(false);
            splitMainContent.Panel1.ResumeLayout(false);
            splitMainContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitMainContent)).EndInit();
            splitMainContent.ResumeLayout(false);
            this.panelControlli.ResumeLayout(false);
            panelCaricaAltri.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtSearchBar;
        private System.Windows.Forms.FlowLayoutPanel flowClienti;
        private MaterialSkin.Controls.MaterialFlatButton btnCaricaAltri;
        private System.Windows.Forms.Panel panelControlli;
        private System.Windows.Forms.Panel panelForm;
        private MaterialSkin.Controls.MaterialLabel lblElimina;
        private MaterialSkin.Controls.MaterialLabel lblOrdina;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton1;
        private System.Windows.Forms.Panel panel1;
    }
}