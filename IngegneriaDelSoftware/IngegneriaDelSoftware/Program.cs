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
            var preventivo = new Preventivo(1, cliente, accettato: true);
            var voce3 = new VocePreventivo("Corda", 30);
            var voce4 = new VocePreventivo("Canapa", 20);

            preventivo.Add(voce3, voce4);

            fattura.Add(voce1, voce2);
            var list = new List<Fattura>();
            list.Add(fattura);
            CollezioneClienti.GetInstance().Add(cliente);
            CollezioneVendite.GetInstance().Add(vendita);
            CollezionePreventivi.GetInstance().Add(preventivo);
            //Application.Run(GenericViewLoader.getPreventivoForm(new ControllerPreventivi()));
            Application.Run(GenericViewLoader.getVenditaForm(new ControllerVendite()));
            //Application.Run(GenericViewLoader.getFatturaForm(new ControllerFatture()));
            //GetForm<Fattura>.Get(list);
        }
    }
}
