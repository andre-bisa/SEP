using IngegneriaDelSoftware.Model;
using System;

namespace IngegneriaDelSoftware.View
{
    partial class FormAppuntamenti
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
            MaterialSkin.Controls.MaterialLabel materialLabel1;
            MaterialSkin.Controls.MaterialLabel materialLabel2;
            MaterialSkin.Controls.MaterialLabel materialLabel3;
            MaterialSkin.Controls.MaterialLabel materialLabel4;
            System.Windows.Forms.Panel panelSchedeClienteGenerico;
            System.Windows.Forms.Panel panelSearchBar;
            System.Windows.Forms.Panel panelSearchBarIcon;
            this.txtLuogoAppuntamento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.dataAppuntamento = new System.Windows.Forms.DateTimePicker();
            this.txtNoteAppuntamento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnAggiungi = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.flowClienti = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearchBar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.mainPanel = new System.Windows.Forms.Panel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            panelSchedeClienteGenerico = new System.Windows.Forms.Panel();
            panelSearchBar = new System.Windows.Forms.Panel();
            panelSearchBarIcon = new System.Windows.Forms.Panel();
            panelSchedeClienteGenerico.SuspendLayout();
            this.panel1.SuspendLayout();
            panelSearchBar.SuspendLayout();
            panelSearchBarIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.BackColor = System.Drawing.Color.Transparent;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel1.Location = new System.Drawing.Point(280, 20);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(212, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Creazione di un appuntamento";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.BackColor = System.Drawing.Color.Transparent;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel2.Location = new System.Drawing.Point(280, 146);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(51, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Luogo";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.BackColor = System.Drawing.Color.Transparent;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel3.Location = new System.Drawing.Point(280, 82);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new System.Drawing.Size(78, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "Data e ora";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.BackColor = System.Drawing.Color.Transparent;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            materialLabel4.Location = new System.Drawing.Point(280, 211);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new System.Drawing.Size(42, 19);
            materialLabel4.TabIndex = 6;
            materialLabel4.Text = "Note";
            // 
            // txtLuogoAppuntamento
            // 
            this.txtLuogoAppuntamento.BackColor = System.Drawing.Color.White;
            this.txtLuogoAppuntamento.Depth = 0;
            this.txtLuogoAppuntamento.Hint = "Luogo";
            this.txtLuogoAppuntamento.Location = new System.Drawing.Point(428, 142);
            this.txtLuogoAppuntamento.MaxLength = 32767;
            this.txtLuogoAppuntamento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLuogoAppuntamento.Name = "txtLuogoAppuntamento";
            this.txtLuogoAppuntamento.PasswordChar = '\0';
            this.txtLuogoAppuntamento.SelectedText = "";
            this.txtLuogoAppuntamento.SelectionLength = 0;
            this.txtLuogoAppuntamento.SelectionStart = 0;
            this.txtLuogoAppuntamento.Size = new System.Drawing.Size(183, 23);
            this.txtLuogoAppuntamento.TabIndex = 2;
            this.txtLuogoAppuntamento.TabStop = false;
            this.txtLuogoAppuntamento.UseSystemPasswordChar = false;
            // 
            // dataAppuntamento
            // 
            this.dataAppuntamento.CustomFormat = "dd/MM/yyyy";
            this.dataAppuntamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataAppuntamento.Location = new System.Drawing.Point(428, 82);
            this.dataAppuntamento.Name = "dataAppuntamento";
            this.dataAppuntamento.Size = new System.Drawing.Size(183, 20);
            this.dataAppuntamento.TabIndex = 1;
            // 
            // txtNoteAppuntamento
            // 
            this.txtNoteAppuntamento.BackColor = System.Drawing.Color.White;
            this.txtNoteAppuntamento.Depth = 0;
            this.txtNoteAppuntamento.Hint = "Note";
            this.txtNoteAppuntamento.Location = new System.Drawing.Point(428, 207);
            this.txtNoteAppuntamento.MaxLength = 32767;
            this.txtNoteAppuntamento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNoteAppuntamento.Name = "txtNoteAppuntamento";
            this.txtNoteAppuntamento.PasswordChar = '\0';
            this.txtNoteAppuntamento.SelectedText = "";
            this.txtNoteAppuntamento.SelectionLength = 0;
            this.txtNoteAppuntamento.SelectionStart = 0;
            this.txtNoteAppuntamento.Size = new System.Drawing.Size(183, 23);
            this.txtNoteAppuntamento.TabIndex = 3;
            this.txtNoteAppuntamento.TabStop = false;
            this.txtNoteAppuntamento.UseSystemPasswordChar = false;
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.AnimateIcon = true;
            this.btnAggiungi.AnimateShowHideButton = true;
            this.btnAggiungi.Depth = 0;
            this.btnAggiungi.Icon = global::IngegneriaDelSoftware.Properties.Resources.ic_save_black_48dp;
            this.btnAggiungi.Location = new System.Drawing.Point(577, 314);
            this.btnAggiungi.Mini = false;
            this.btnAggiungi.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(56, 56);
            this.btnAggiungi.TabIndex = 4;
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // panelSchedeClienteGenerico
            // 
            panelSchedeClienteGenerico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            panelSchedeClienteGenerico.Controls.Add(this.flowClienti);
            panelSchedeClienteGenerico.Controls.Add(this.panel1);
            panelSchedeClienteGenerico.Location = new System.Drawing.Point(10, 3);
            panelSchedeClienteGenerico.Name = "panelSchedeClienteGenerico";
            panelSchedeClienteGenerico.Size = new System.Drawing.Size(230, 377);
            panelSchedeClienteGenerico.TabIndex = 11;
            // 
            // flowClienti
            // 
            this.flowClienti.AutoScroll = true;
            this.flowClienti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowClienti.Location = new System.Drawing.Point(0, 36);
            this.flowClienti.Name = "flowClienti";
            this.flowClienti.Size = new System.Drawing.Size(230, 341);
            this.flowClienti.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(panelSearchBar);
            this.panel1.Controls.Add(panelSearchBarIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 36);
            this.panel1.TabIndex = 0;
            // 
            // panelSearchBar
            // 
            panelSearchBar.Controls.Add(this.txtSearchBar);
            panelSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSearchBar.Location = new System.Drawing.Point(0, 0);
            panelSearchBar.Name = "panelSearchBar";
            panelSearchBar.Size = new System.Drawing.Size(194, 36);
            panelSearchBar.TabIndex = 1;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Depth = 0;
            this.txtSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchBar.Hint = "Search";
            this.txtSearchBar.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBar.MaxLength = 32767;
            this.txtSearchBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.PasswordChar = '\0';
            this.txtSearchBar.SelectedText = "";
            this.txtSearchBar.SelectionLength = 0;
            this.txtSearchBar.SelectionStart = 0;
            this.txtSearchBar.Size = new System.Drawing.Size(194, 23);
            this.txtSearchBar.TabIndex = 0;
            this.txtSearchBar.TabStop = false;
            this.txtSearchBar.UseSystemPasswordChar = false;
            // 
            // panelSearchBarIcon
            // 
            panelSearchBarIcon.Controls.Add(this.pictureBox1);
            panelSearchBarIcon.Dock = System.Windows.Forms.DockStyle.Right;
            panelSearchBarIcon.Location = new System.Drawing.Point(194, 0);
            panelSearchBarIcon.Name = "panelSearchBarIcon";
            panelSearchBarIcon.Size = new System.Drawing.Size(36, 36);
            panelSearchBarIcon.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::IngegneriaDelSoftware.Properties.Resources.ic_search_black_24dp;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // materialDivider1
            // 
            this.materialDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(246, 3);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(3, 377);
            this.materialDivider1.TabIndex = 10;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(panelSchedeClienteGenerico);
            this.mainPanel.Controls.Add(this.btnAggiungi);
            this.mainPanel.Controls.Add(this.materialDivider1);
            this.mainPanel.Controls.Add(this.txtNoteAppuntamento);
            this.mainPanel.Controls.Add(materialLabel1);
            this.mainPanel.Controls.Add(materialLabel4);
            this.mainPanel.Controls.Add(materialLabel2);
            this.mainPanel.Controls.Add(this.dataAppuntamento);
            this.mainPanel.Controls.Add(this.txtLuogoAppuntamento);
            this.mainPanel.Controls.Add(materialLabel3);
            this.mainPanel.Location = new System.Drawing.Point(5, 68);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(641, 377);
            this.mainPanel.TabIndex = 12;
            // 
            // FormAppuntamenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "FormAppuntamenti";
            this.Text = "Inserimento appuntamenti";
            panelSchedeClienteGenerico.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            panelSearchBar.ResumeLayout(false);
            panelSearchBarIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLuogoAppuntamento;
        private System.Windows.Forms.DateTimePicker dataAppuntamento;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNoteAppuntamento;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnAggiungi;
        private System.Windows.Forms.FlowLayoutPanel flowClienti;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSearchBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Panel mainPanel;
    }
}