using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.Graphics {
    public partial class FattureForm: MaterialSkin.Controls.MaterialForm {
        private int NumeroInserimentoRigheVociFattura;

        public FattureForm() {
            this.NumeroInserimentoRigheVociFattura = 1;
            InitializeComponent();
            
        }

        // Crea una nuova MaterialDesign TextBox
        private MaterialSkin.Controls.MaterialSingleLineTextField CreateTextBox(string Input, int Width) {
            MaterialSkin.Controls.MaterialSingleLineTextField Result = new MaterialSkin.Controls.MaterialSingleLineTextField();
            Result.Text = Input;
            Result.Size = new System.Drawing.Size(Width, 23);
            return Result;
        }

        // Aggiunge una riga ai campi della fattura
        public void AggiungiRigaCampiFattura(string Causale, double Importo) {

            this.FattureValoriPanel.RowCount += 1;

            this.FattureValoriPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            //TODO: Auto generare la lunghezza ad "INFINITO"
            var TmpField = this.CreateTextBox(Causale, 600);
            this.FattureValoriPanel.Controls.Add(TmpField, 0, this.NumeroInserimentoRigheVociFattura);
            //TODO: inserire un formatter qui
            TmpField = this.CreateTextBox(Importo.ToString(), 300);
            this.FattureValoriPanel.Controls.Add(TmpField, 1, this.NumeroInserimentoRigheVociFattura);

            this.NumeroInserimentoRigheVociFattura++;
        }

        // Handler click bottone
        private void materialFlatButton1_Click(object sender, EventArgs e) {
            this.AggiungiRigaCampiFattura("", 0);
        }
    }

    
}
