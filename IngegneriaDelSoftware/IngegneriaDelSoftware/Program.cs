using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.View;
using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ControllerClienti controller = new ControllerClienti();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);/*
            var g = new View.GenericForm(View.GenericForm.TipoForm.FATTURE);
            g.OnCreaClick += (result, e) => {
                result.ForEach((el) => {
                    System.Diagnostics.Debug.WriteLine(el.Tipologia);
                    System.Diagnostics.Debug.WriteLine(el.Descrizione);
                    System.Diagnostics.Debug.WriteLine(el.Importo);
                    System.Diagnostics.Debug.WriteLine(el.Opzionale);
                    System.Diagnostics.Debug.WriteLine(el.Numero);
                });
            };
            g.InfoPanelEditable = false;
            Application.Run(g);
            /*
            //Application.Run(new FormAppuntamenti());
            Application.Run(new FormClienti(controller));
            Application.Run(new FormEmail(controller));
            Application.Run(new Login());
            Application.Run(new VisualizzaCalendario());
            if (FormConfim.Show("Titolo", "Messaggio") == DialogResult.OK)
                MessageBox.Show("Premuto OK");*/
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new Fattura(2018, "2", cliente, vendita);
            var voce1 = new VoceFattura("Corda", 30, 0.20f);
            var voce2 = new VoceFattura("Canapa", 20, 0.20f);

            fattura.Add(voce1, voce2);
            var list = new List<Fattura>();
            list.Add(fattura);
            CollezioneClienti.GetInstance().Add(cliente);
            Application.Run(GenericViewLoader.getFatturaForm(list));
        }
    }
}
