using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.View;
using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza;

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
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles(); // senza questo non si vedono gli Hint
            //Application.Run(new Login());

            Impostazioni impostazioni = Impostazioni.GetInstance();
            impostazioni.TipoPersistenza = EnumTipoPersistenza.NONE;
            impostazioni.IDUtente = 1;
            ScriptProvider.create("Test", (""
               + "$ON=( #SUM( @ONORARIO ) )\n"
               + "$CPA=( $ON * 0,04 )\n"
               + "$IMPIVA=( $ON + $CPA )\n"
               + "$IVA=( $IMPIVA * 0,22 )\n"
               + "$TOTPAR=( $IMPIVA + $IVA )\n"
               + "$NON=( #SUM( @NONIMPONIBILI ) )\n"
               + "$TOTALE=( $TOTPAR + $NON )\n"
               + ".SET $ON AS IMPORTANT\n"
               + ".SET $CPA AS IMPORTANT\n"
               + ".SET $IMPIVA AS IMPORTANT\n"
               + ".SET $IVA AS IMPORTANT\n"
               + ".SET $TOTPAR AS IMPORTANT\n"
               + ".SET $NON AS IMPORTANT\n"
               + ".SET $TOTALE AS IMPORTANT\n"
               + ".SET LABEL FOR $ON AS \"Totale onorari \"\n"
               + ".SET LABEL FOR $CPA AS \"Cpa \"\n"
               + ".SET LABEL FOR $IMPIVA AS \"Imponibile iva \"\n"
               + ".SET LABEL FOR $IVA AS \"Iva \"\n"
               + ".SET LABEL FOR $TOTPAR AS \"Totale parziale \"\n"
               + ".SET LABEL FOR $NON AS \"Anticipazioni \"\n"
               + ".SET LABEL FOR $TOTALE AS \"Totale generale \""
           + "").Split('\n'));

            //ControllerClienti controller = new ControllerClienti();

            /*
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
            */
            //Application.Run(new FormAppuntamenti());
            //Application.Run(new FormClienti(controller));
            /*Email email = new Email("gne", "buu");
            CollezioneClienti.GetInstance().Get("1").Persona.Email.Add(email);
            CollezioneClienti.GetInstance().Get("1").Persona.Email.Remove(email);

            Telefono tel = new Telefono("051", "nota");
            CollezioneClienti.GetInstance().Get("1").Persona.Telefoni.Add(tel);
            CollezioneClienti.GetInstance().Get("1").Persona.Telefoni.Remove(tel);

            Referente r = new Referente("Nome", "nota");
            CollezioneClienti.GetInstance().Get("1").Referenti.Add(r);
            CollezioneClienti.GetInstance().Get("1").Referenti.Remove(r);*//*
            Application.Run(new FormEmail(controller));
            Application.Run(new Login());
            Application.Run(new VisualizzaCalendario(new ControllerCalendario()));
            if (FormConfim.Show("Titolo", "Messaggio") == DialogResult.OK)
                MessageBox.Show("Premuto OK");*/
            var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
            var cliente = new Cliente(persona, "1");
            var vendita = new Vendita(1, cliente);
            var fattura = new FatturaScripting(2018, "2", cliente, vendita);
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
            CollezioneFatture.GetInstance().Add(fattura);
            //Application.Run(GenericViewLoader.getPreventivoForm(new ControllerPreventivi()));
            //Application.Run(GenericViewLoader.getVenditaForm(new ControllerVendite()));
            //Application.Run(GenericViewLoader.getFatturaForm(new ControllerFatture()));
            
            var app1 = new Appuntamento(1, persona, "I like this one", "Cucina", DateTime.Now);
            var app2 = new Appuntamento(2, persona, "I like this one", "Cucina", DateTime.Now.AddDays(1));
            var app3 = new Appuntamento(3, persona, "I like this one", "Cucina", DateTime.Now.AddHours(2));
            var app4 = new Appuntamento(4, persona, "I like this one", "Cucina", DateTime.Now.AddDays(3));
            Calendario.GetInstance().Add(app1);
            Calendario.GetInstance().Add(app2);
            Calendario.GetInstance().Add(app3);
            Calendario.GetInstance().Add(app4);

            Application.Run(new HomeForm(new ControllerHome()));
        }
    }
}
