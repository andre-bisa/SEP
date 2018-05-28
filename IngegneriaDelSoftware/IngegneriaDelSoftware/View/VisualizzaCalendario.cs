using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.Model;
using MaterialSkin.Controls;
using IngegneriaDelSoftware.Controller;

namespace IngegneriaDelSoftware.View
{
    public partial class VisualizzaCalendario : MaterialForm
    {
        //private Appuntamento _a1, _a2;

        public VisualizzaCalendario(ControllerCalendario c)
        {
            InitializeComponent();

            this.dateTimePickerDa.ValueChanged += new System.EventHandler(this.DataCambiata);
            this.dateTimePickerA.ValueChanged += new System.EventHandler(this.DataCambiata);

            //Righe di prova
            /*
            Persona p1 = new PersonaFisica("cf", "indirizzo", "Nome", "Cognome");

            DatiAppuntamento d1 = new DatiAppuntamento(1, p1, "Riunione", "Bologna", DateTime.Now);
            DatiAppuntamento d2 = new DatiAppuntamento(1, p1, "Riunione", "Napoli", DateTime.MaxValue);

            _a1 = new Appuntamento(d1);
            _a2 = new Appuntamento(d2);
            
            ListViewItem item1 = new ListViewItem(_a1.ToString().Split(' '));
            ListViewItem item2 = new ListViewItem(_a2.ToString().Split(' '));

            listCalendario.Items.Add(item1);
            listCalendario.Items.Add(item2);*/
            /*c.GetAppuntamenti().ForEach((el) => {
                // this method is bad and evil;
                listCalendario.Items.Add(new ListViewItem(el.ToString().Split(' ')));
            });*/
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
            //Application.Run(new FormAppuntamenti());
        }
    }
}
