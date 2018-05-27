using IngegneriaDelSoftware.Model;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.View {
    public partial class GetForm<T>: MaterialForm {
        private Dictionary<string, T> _storage;
        public T ElementoRitorno { get; private set; } = default(T);
        public T[] ElementiRitorno { get; private set; } = new T[0];
        private bool _multiple = false;

        private GetForm(List<T> inList, bool multiple) {
            this._storage = new Dictionary<string, T>();
            this._multiple = multiple;
            InitializeComponent();
            string tmp = "";
            inList.ForEach((e) => {
                tmp = (e.GetType().GetProperties()?.Where((i) => {
                    return i.Name.Contains("ID");
                }).FirstOrDefault<PropertyInfo>()?.GetValue(e).ToString() ?? e.ToString());
                this._storage.Add(tmp, e);
                this.ClientiList.Items.Add(new ListViewItem(new string[] { tmp, e.ToString() }));
                //this._storage.Add(e.ToString(), e);
            });/*
            foreach(var key in this._storage.Keys) {
                this.ClientiList.Items.Add(new ListViewItem(new string[] { key, this._storage[key].ToString() }));
            }*/
        }

        private void SelezionaBtn_Click(object sender, EventArgs e) {
            if(this.ElementoRitorno != null || (this.ElementiRitorno != null && this.ElementiRitorno.Length > 0)) {
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
            if(this.ClientiList.SelectedItems.Count == 1 && !this._multiple) {
                this.ElementoRitorno = this._storage[this.ClientiList.SelectedItems[0].Text];
            } else if(this._multiple && this.ClientiList.SelectedItems.Count >= 1) {
                List<T> selected = new List<T>();
                for(int i = 0; i < this.ClientiList.SelectedItems.Count; i++) {
                    selected.Add(this._storage[this.ClientiList.SelectedItems[i].Text]);
                }
                this.ElementiRitorno = selected.ToArray();
            }
        }

        public static T Get(List<T> list) {
            using(GetForm<T> g = new GetForm<T>(list, false)) {
                DialogResult dia = g.ShowDialog();
                if(dia == DialogResult.OK) {
                    return g.ElementoRitorno;
                } else {
                    return default(T);
                }
            }
        }

        public static T[] Gets(List<T> list) {
            using(GetForm<T> g = new GetForm<T>(list, true)) {
                DialogResult dia = g.ShowDialog();
                if(dia == DialogResult.OK) {
                    return g.ElementiRitorno;
                } else {
                    return default(T[]);
                }
            }
        }
    }
}
