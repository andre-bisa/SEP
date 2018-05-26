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
    public partial class GetVenditaForm: MaterialForm {
        private Dictionary<string, Vendita> _clienti;
        public Vendita[] VenditaRitorno { get; set; } = null;

        private GetVenditaForm(List<Vendita> clienti) {
            this._clienti = new Dictionary<string, Model.Vendita>();
            clienti.ForEach((e) => {
                this._clienti.Add(e.ID.ToString(), e);
            });
            InitializeComponent();

            foreach(var key in this._clienti.Keys) {
                this.ClientiList.Items.Add(new ListViewItem(new string[] { key, this._clienti[key].Cliente.ToString()}));
            }
        }

        private void SelezionaBtn_Click(object sender, EventArgs e) {
            if(this.VenditaRitorno != null) {
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
            if(this.ClientiList.SelectedItems.Count >= 1) {
                List<Vendita> tmp = new List<Vendita>();
                for(int i = 0; i < this.ClientiList.SelectedItems.Count; i++) {
                    tmp.Add(this._clienti[this.ClientiList.SelectedItems[i].Text]);
                }
                this.VenditaRitorno = tmp.ToArray();
            }
        }

        public static Vendita[] Get(List<Vendita> clienti) {
            using(GetVenditaForm g = new GetVenditaForm(clienti)) {
                DialogResult dia = g.ShowDialog();
                if(dia == DialogResult.OK) {
                    return g.VenditaRitorno;
                } else {
                    return null;
                }
            }
        }
    }
}
