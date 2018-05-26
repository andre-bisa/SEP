using IngegneriaDelSoftware.Model;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.View {
    public partial class GetPreventivoForm: MaterialForm {
        private Dictionary<string, Preventivo> _preventivi;
        public Preventivo PreventivoRitorno { get; set; } = null;

        private GetPreventivoForm(List<Preventivo> preventivi) {
            this._preventivi = new Dictionary<string, Model.Preventivo>();
            preventivi.ForEach((e) => {
                this._preventivi.Add(e.ID.ToString(), e);
            });
            InitializeComponent();

            foreach(var key in this._preventivi.Keys) {
                this.PreventiviList.Items.Add(new ListViewItem(new string[] { key, this._preventivi[key].Cliente.ToString()}));
            }
        }

        private void SelezionaBtn_Click(object sender, EventArgs e) {
            if(this.PreventivoRitorno != null) {
                this.DialogResult = DialogResult.OK;
            } else {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        private void AnnullaBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ClientiList_SelectedIndexChanged(object sender, EventArgs e) {
            if(this.PreventiviList.SelectedItems.Count == 1) {
                this.PreventivoRitorno = this._preventivi[this.PreventiviList.SelectedItems[0].Text];
            }
        }

        public static Preventivo Get(List<Preventivo> clienti) {
            using(GetPreventivoForm g = new GetPreventivoForm(clienti)) {
                DialogResult dia = g.ShowDialog();
                if(dia == DialogResult.OK) {
                    return g.PreventivoRitorno;
                } else {
                    return null;
                }
            }
        }
    }
}
