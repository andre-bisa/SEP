using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace IngegneriaDelSoftware.View
{
    public partial class VisualizzaCalendario : MaterialForm
    {
        public VisualizzaCalendario()
        {
            InitializeComponent();

            this.dateTimePickerDa.ValueChanged += new System.EventHandler(this.DataCambiata);
            this.dateTimePickerA.ValueChanged += new System.EventHandler(this.DataCambiata);

            //Riga di prova
            string[] row = { "20/05/2018, 17:30", "Bologna", "Riunione", "Mario Rossi" };
            ListViewItem item = new ListViewItem(row);

            listCalendario.Items.Add(item);
        }

        private void DataCambiata(object sender, EventArgs e)
        {
            listCalendario.Enabled = dataValida();
        }

        private bool dataValida()
        {
            if (dateTimePickerA.Value == null || dateTimePickerDa == null)
                return false;

            if (dateTimePickerDa.Value > dateTimePickerA.Value)
                return false;

            return true;
        }

        private void listCalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lancio form di visualizzazione dettagliata dell'appuntamento selezionato
            //Application.Run(new FormAppuntamenti);
        }
    }
}
