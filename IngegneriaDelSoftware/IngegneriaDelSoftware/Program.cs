/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.View;
using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza;
using MaterialSkin;

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

            MaterialSkinManager.Instance.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.Instance.ColorScheme = new ColorScheme(Primary.BlueGrey500, Primary.BlueGrey700, Primary.BlueGrey100, Accent.LightBlue200, TextShade.WHITE);

            Impostazioni impostazioni = Impostazioni.GetInstance();

            // Set del formato per varii motivi: 1) il programma è strutturato per un utenza italiana 2) è il formato del linguaggio di scripting;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");

            //impostazioni.TipoPersistenza = EnumTipoPersistenza.MySQL;
            //impostazioni.IDUtente = 1;
            /*
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
           */
            //XXX testare questo;
            ScriptProvider.create(impostazioni.FileScriptFattura);

            if((new Login()).ShowDialog() == DialogResult.OK) {
                try {
                    {
                        LoadingForm l = new LoadingForm();
                        l.MaxValue = 6;
                        l.Show();

                        l.Status = "Caricamento Clienti";
                        CollezioneClienti.GetInstance();
                        l.Value++;

                        l.Status = "Caricamento Appuntamenti";
                        CollezioneAppuntamenti.GetInstance();
                        l.Value++;

                        l.Status = "Caricamento Email";
                        CollezioneEmailInviate.GetInstance();
                        l.Value++;

                        l.Status = "Caricamento Preventivi";
                        CollezionePreventivi.GetInstance();
                        l.Value++;

                        l.Status = "Caricamento Vendite";
                        CollezioneVendite.GetInstance();
                        l.Value++;


                        l.Status = "Caricamento Fatture";
                        CollezioneFatture.GetInstance();
                        l.Value++;

                        l.Close();
                        l.Dispose();
                    }
                    Application.Run(new HomeForm(new ControllerHome()));
                }catch(Exception e) {
                    FormConfim.Show("Errore Fatale", "Si è verificato un errore in: " + e.Message, MessageBoxButtons.OK);
                }
        }
            return;

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
            //Application.Run(new FormClienti());
            /*Email email = new Email("gne", "buu");
            CollezioneClienti.GetInstance().Get("1").Persona.Email.Add(email);
            CollezioneClienti.GetInstance().Get("1").Persona.Email.Remove(email);

            Telefono tel = new Telefono("051", "nota");
            CollezioneClienti.GetInstance().Get("1").Persona.Telefoni.Add(tel);
            CollezioneClienti.GetInstance().Get("1").Persona.Telefoni.Remove(tel);

            Referente r = new Referente("Nome", "nota");
            CollezioneClienti.GetInstance().Get("1").Referenti.Add(r);
            CollezioneClienti.GetInstance().Get("1").Referenti.Remove(r);*//*
            Application.Run(new FormEmail());
            Application.Run(new Login());
            Application.Run(new VisualizzaCalendario(new ControllerCalendario()));
            if (FormConfim.Show("Titolo", "Messaggio") == DialogResult.OK)
                MessageBox.Show("Premuto OK");*/

#pragma warning disable CS0162 // Unreachable code detected
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
#pragma warning restore CS0162 // Unreachable code detected
        }
    }
}
