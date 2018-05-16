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

            //Riga di prova
            string[] row = { "20/05/2018, 17:30", "Bologna", "Riunione", "Mario Rossi" };
            ListViewItem item = new ListViewItem(row);

            listCalendario.Items.Add(item);
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerDa_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerA.Value != null && dateTimePickerDa != null)
            {
                listCalendario.Enabled = true;
            }
            else
            {
                listCalendario.Enabled = false;
            }
        }

        private void dateTimePickerA_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerA.Value != null && dateTimePickerDa != null)
            {
                listCalendario.Enabled = true;
            }
            else
            {
                listCalendario.Enabled = false;
            }
        }

        private void listCalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lancio form di visualizzazione dettagliata dell'appuntamento selezionato
            //Application.Run(new FormAppuntamenti);
        }
    }
}
