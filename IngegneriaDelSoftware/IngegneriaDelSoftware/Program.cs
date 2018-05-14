using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var g = new Graphics.GenericForm(true);
            g.OnCreaClick += (result, e) => {
                result.ForEach((el) => {
                    System.Diagnostics.Debug.WriteLine(el.Tipologia);
                    System.Diagnostics.Debug.WriteLine(el.Descrizione);
                    System.Diagnostics.Debug.WriteLine(el.Importo);
                    System.Diagnostics.Debug.WriteLine(el.Provvigione);
                });
            };
            Application.Run(g);
        }
    }
}
