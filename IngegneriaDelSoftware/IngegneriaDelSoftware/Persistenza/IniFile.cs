using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza
{
    public class IniFile
    {
        private readonly string _percorso;
        private readonly string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        /// <summary>
        /// Costruttore di un file INI
        /// </summary>
        /// <param name="percorso">Percorso del file, può essere relativo. DEFAULT: nome dell'applicazione</param>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public IniFile(string percorso = null)
        {
            _percorso = new FileInfo(percorso ?? EXE).FullName.ToString();
        }

        /// <summary>
        /// Funzione che legge all'interno di un file INI
        /// </summary>
        /// <param name="chiave">Chiave da leggere</param>
        /// <param name="sezione">Sezione in cui si intende agire. DEFAULT: Nome del programma</param>
        /// <returns>Il valore letto. Se non presente restituisce una stringa vuota ("").</returns>
        public string Leggi(string chiave, string sezione = null)
        {
            var risultato = new StringBuilder(255);
            GetPrivateProfileString(sezione ?? EXE, chiave, "", risultato, 255, _percorso);
            return risultato.ToString();
        }

        /// <summary>
        /// Funzione che scrive all'interno di un file INI
        /// </summary>
        /// <param name="chiave">Chiave da scrivere</param>
        /// <param name="valore">Valore da salvare</param>
        /// <param name="sezione">Sezione in cui si intende agire. DEFAULT: Nome del programma</param>
        public void Scrivi(string chiave, string valore, string sezione = null)
        {
            WritePrivateProfileString(sezione ?? EXE, chiave, valore, _percorso);
        }

        /// <summary>
        /// Funzione che elimina una chiave da un file INI
        /// </summary>
        /// <param name="chiave">Chiave da eliminare</param>
        /// <param name="sezione">Sezione in cui si intende agire. DEFAULT: Nome del programma</param>
        public void EliminaChiave(string chiave, string sezione = null)
        {
            Scrivi(chiave, null, sezione ?? EXE);
        }

        /// <summary>
        /// Funzione che elimina una intera sezione di un file INI
        /// </summary>
        /// <param name="sezione">Sezione in cui si intende agire. DEFAULT: Nome del programma</param>
        public void EliminaSezione(string sezione = null)
        {
            Scrivi(null, null, sezione ?? EXE);
        }

        /// <summary>
        /// Funzione che dice se esiste una chiave
        /// </summary>
        /// <param name="chiave">Chiave da cercare</param>
        /// <param name="sezione">Sezione in cui si intende agire. DEFAULT: Nome del programma</param>
        /// <returns><c>true</c> o <c>false</c></returns>
        public bool EsisteChiave(string chiave, string sezione = null)
        {
            return Leggi(chiave, sezione).Length > 0;
        }
    }
}
