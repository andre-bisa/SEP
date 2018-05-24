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
    public partial class GetClienteForm: MaterialForm {
        private Dictionary<string, Cliente> _clienti;
        public Cliente ClienteRitorno { get; set; } = null;

        private GetClienteForm(List<Cliente> clienti) {
            this._clienti = new Dictionary<string, Model.Cliente>();
            clienti.ForEach((e) => {
                this._clienti.Add(e.Denominazione, e);
            });
            InitializeComponent();

            foreach(var key in this._clienti.Keys) {
                this.ClientiList.Items.Add(new ListViewItem(new string[] { key, this._clienti[key].Persona.CodiceFiscale }));
            }
        }

        private void SelezionaBtn_Click(object sender, EventArgs e) {
            if(this.ClienteRitorno != null) {
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
            if(this.ClientiList.SelectedItems.Count == 1) {
                this.ClienteRitorno = this._clienti[this.ClientiList.SelectedItems[0].Text];
            }
        }

        public static Cliente Get(List<Cliente> clienti) {
            using(GetClienteForm g = new GetClienteForm(clienti)) {
                DialogResult dia = g.ShowDialog();
                if(dia == DialogResult.OK) {
                    return g.ClienteRitorno;
                } else {
                    return null;
                }
            }
        }
    }
}
