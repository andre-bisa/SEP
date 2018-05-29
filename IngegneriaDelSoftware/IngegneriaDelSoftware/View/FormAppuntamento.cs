using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using MaterialSkin.Controls;

namespace IngegneriaDelSoftware.View
{
    public partial class FormAppuntamenti : MaterialForm
    {
        public FormAppuntamenti(Appuntamento appuntamento = null)
        {
            InitializeComponent();

            if (appuntamento != null)
            {
                VisualizzaAppuntamento(appuntamento);
            }
        }

        /// <summary>
        /// Visualizza l'<see cref="Appuntamento"/> dato
        /// </summary>
        /// <param name="a"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void VisualizzaAppuntamento(Appuntamento appuntamento)
        {
            this.dataAppuntamento.Value = appuntamento.DataOra;
            this.txtLuogoAppuntamento.Text = appuntamento.Luogo;
            this.txtNoteAppuntamento.Text = appuntamento.Note;

            //this.dataAppuntamento.
        }
    }
}
