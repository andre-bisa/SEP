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
using static System.Windows.Forms.ListView;

namespace IngegneriaDelSoftware.View
{
    public partial class VisualizzaCalendario : MaterialForm
    {
        private Appuntamento _a1, _a2;
        private ControllerCalendario _controller;

        /// <summary>
        /// Costruttore di <see cref="VisualizzaCalendario"/>
        /// </summary>
        /// <param name="c">Controller da usare</param>
        /// <exception cref="ArgumentNullException"></exception>
        public VisualizzaCalendario(ControllerCalendario c)
        {

            if (c == null)
            {
                throw new ArgumentNullException("Controller del calendario nullo!");
            }

            this._controller = c;

            InitializeComponent();

            this.dateTimePickerDa.ValueChanged += new System.EventHandler(this.DataCambiata);
            this.dateTimePickerA.ValueChanged += new System.EventHandler(this.DataCambiata);

            //Righe di prova
            
            Persona p1 = new PersonaFisica("cf", "indirizzo", "Nome", "Cognome");

            DatiAppuntamento d1 = new DatiAppuntamento(1, p1, "Riunione", "Bologna", DateTime.Now);
            DatiAppuntamento d2 = new DatiAppuntamento(2, p1, "Riunione", "Napoli", new DateTime(2500, 12, 31, 15, 54, 34));

            _a1 = new Appuntamento(d1);
            _a2 = new Appuntamento(d2);
            
            ListViewItem item1 = new ListViewItem(_a1.ToString().Split(';'));
            ListViewItem item2 = new ListViewItem(_a2.ToString().Split(';'));

            //Riempio preventivamente la ListView con gli appuntamenti presi dal database
            /*foreach(Appuntamento appuntamento in this._controller.GetAppuntamenti())
            {
                ListViewItem item = new ListViewItem(appuntamento.ToString().Split(' '));
            }*/

            listCalendario.Items.Add(item1);
            listCalendario.Items.Add(item2);

            this._controller.AggiungiAppuntamento(_a1);
            this._controller.AggiungiAppuntamento(_a2);

            /*c.GetAppuntamenti().ForEach((el) => {
                // this method is bad and evil;
                listCalendario.Items.Add(new ListViewItem(el.ToString().Split(' ')));
            });*/
        }

        private void DataCambiata(object sender, EventArgs e)
        {
            if (DataValida())
            {
                listCalendario.Enabled = true;

                //Ricavo la lista degli appuntamenti da visualizzare per le date inserite
                List<Appuntamento> appuntamenti = new List<Appuntamento>();
                appuntamenti = this._controller.GetAppuntamentiDaA(dateTimePickerDa.Value, dateTimePickerA.Value);

                foreach(Appuntamento appuntamento in appuntamenti)
                {
                    ListViewItem item = new ListViewItem(appuntamento.ToString().Split(';'));
                }
            }
            else
            {
                listCalendario.Enabled = false;
            }
        }

        private bool DataValida()
        {
            if (dateTimePickerA.Value == null || dateTimePickerDa == null)
                return false;

            if (dateTimePickerDa.Value > dateTimePickerA.Value)
                return false;

            return true;
        }

        private void ListCalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lancio form di visualizzazione dettagliata dell'appuntamento selezionato
            int idAppuntamento = 0;

            //Controllo l'elemento selezionato, che e' l'ID
            foreach (ListViewItem item in this.listCalendario.SelectedItems)
            {
                idAppuntamento = Convert.ToInt32(item.Text);
            }

            Appuntamento appuntamento = this._controller.GetAppuntamenti()[idAppuntamento];

            new FormAppuntamenti(appuntamento).Show();
        }
    }
}
