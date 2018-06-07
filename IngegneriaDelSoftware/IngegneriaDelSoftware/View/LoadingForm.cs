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
    public partial class LoadingForm: Form {
        public LoadingForm() {
            InitializeComponent();
        }
        public int Value {
            set {
                this.Bar.Value = value;
            }
            get {
                return this.Bar.Value;
            }
        }
        public string Status {
            set {
                this.StatusLabel.Text = value;
            }
        }
    }
}
