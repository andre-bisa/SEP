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
using System.Text;
using System.Threading.Tasks;
using ScriptInCSharp;
using System.IO;

namespace IngegneriaDelSoftware.Controller {
    public class ScriptProvider {
        private ScriptInCSharp.Environment _env;
        private ScriptInCSharp.Evaluator _eval;
        private string _filename;
        private List<Line> _script;
        private List<Preprocessor> _preprocessor;

        // chimata diretta principalmente per debug;
        protected ScriptProvider(string tag, string[] lines) {
            this._filename = tag;
            this._env = new ScriptInCSharp.Environment();
            this._eval = new Evaluator(this._env);
            this._preprocessor = new List<Preprocessor>();
            // seleziona i .SET;
            foreach(string l in (from s in lines
                                 where s.StartsWith(".")
                                 select s)) {
                this._preprocessor.Add(Preprocessor.of(l));
            }
            this._script = new List<Line>();
            // seleziona i comandi di SCRIPTING;
            foreach(string l in (from s in lines
                                 where !s.StartsWith(".")
                                 select s)) {
                this._script.Add(new Line(l));
            }
            // inserimento delle funzioni di comodo;
            // somma su array;
            this._env.registerFunction("#SUM", (i) => {
                return i.Select((el) => decimal.Parse(el)).Sum().ToString();
            });
            // max su array;
            this._env.registerFunction("#MAX", (i) => {
                return i.Select((el) => decimal.Parse(el)).Max().ToString();
            });
            // min su array;
            this._env.registerFunction("#MIN", (i) => {
                return i.Select((el) => decimal.Parse(el)).Min().ToString();
            });
        }
        protected ScriptProvider(string filename) :this(filename, File.ReadAllLines(filename)) {
                        
        }

        public void Clear() {
            this._env.clearVariables();
        }
        public void AddArrayVariable(string name, decimal[] value) {
            // lock per garantire la consistenza in caso di stream paralleli;
            lock(this._env) {
                this._env.registerVariable("@" + name.ToUpper(), string.Join(",", value));
            }
        }
        public void AddVariable(string name, decimal value) {
            this._env.registerVariable("$" + name.ToUpper(), string.Join(",", value));
        }

        public string GetVariable(string name) {
            return this._env.getVariableValue(name.ToUpper());
        }
        public string GetLabel(string name) {
            return this._env.getLabel(name);
        }
        public List<string> GetSaved() {
            return this._env.getImportant();
        }
        public void CancellaSaved() {
            this._env.clearImportant();
        }
        public void Calculate() {
            this._script.ForEach((e) => {
                try {
                    this._eval.evaluate(e);
                } catch(Exception) {
                    // ignora gli errori;
                }
            });
            //Preprocessore così chiamato perchè si lancia _dopo_;
            this._preprocessor.ForEach((e) => {
                this._env.setUp(e);
            });
        }


        #region Fly
        private static Dictionary<string, ScriptProvider> _instance = new Dictionary<string, ScriptProvider>();

        internal static void create(string tag, string[] lines) {
            if(!_instance.ContainsKey(tag)) {
                _instance.Add(tag, new ScriptProvider(tag, lines));
            }
        }
        public static void Drop(string input)
        {
            _instance.Remove(input);
        }
        internal static void create(string filename) {
            string name = Path.GetFileNameWithoutExtension(filename);
            if (!_instance.ContainsKey(name)) {
                _instance.Add(name, new ScriptProvider(filename));
            }
        }

        public static ScriptProvider get(string filename) {
            if(_instance.ContainsKey(filename)) {
                return _instance[filename];
            }else {
                return null;
            }
            
        }
        #endregion
    }
}
