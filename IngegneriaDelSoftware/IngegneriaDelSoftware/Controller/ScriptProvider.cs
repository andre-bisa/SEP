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
        private Evaluator _eval;
        private string _filename;
        private List<Line> _script;
        private List<Preprocessor> _preprocessor;

        protected ScriptProvider(string tag, string[] lines) {
            this._filename = tag;
            this._env = new ScriptInCSharp.Environment();
            this._eval = new Evaluator(this._env);
            this._preprocessor = new List<Preprocessor>();
            foreach(string l in (from s in lines
                                 where s.StartsWith(".")
                                 select s)) {
                this._preprocessor.Add(Preprocessor.of(l));
            }
            this._script = new List<Line>();
            foreach(string l in (from s in lines
                                 where !s.StartsWith(".")
                                 select s)) {
                this._script.Add(new Line(l));
            }
            this._env.registerFunction("#SUM", (i) => {
                return i.Select((el) => decimal.Parse(el)).Sum().ToString();
            });
            this._env.registerFunction("#MAX", (i) => {
                return i.Select((el) => decimal.Parse(el)).Max().ToString();
            });
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
#pragma warning disable CS0168 // Variable is declared but never used;
                } catch(Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used;
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
        internal static void create(string filename) {
            if(!_instance.ContainsKey(filename)) {
                _instance.Add(filename, new ScriptProvider(filename));
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
