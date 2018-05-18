using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class UtenteAgente : Utente
    {
        public override event EventHandler<ArgsModifica<Utente>> OnModifica;
        private string _nome, _cognome;
        private float _provvigioneDefault;

        #region Costruttore
        /// <summary>
        /// Costruttore di un Utente di tipologia Agente
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pIva"></param>
        /// <param name="cF"></param>
        /// <param name="indirizzo"></param>
        /// <param name="telefoni"></param>
        /// <param name="email"></param>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="provvigioneDefault"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public UtenteAgente(string username, string pIva, string cF, string indirizzo, List<Telefono> telefoni, Telefono email, string nome, string cognome, float provvigioneDefault = 0)
            : base(username, pIva, cF, indirizzo, telefoni, email)
        {
            #region Controlli
            if (nome == null)
            {
                throw new ArgumentNullException(nameof(nome));
            }
            if(cognome == null)
            {
                throw new ArgumentNullException(nameof(cognome));
            }

            if (provvigioneDefault > 1 || provvigioneDefault < 0)
            {
                throw new ArgumentException();
            }
            #endregion
            
            _nome = nome;
            _cognome = cognome;
            _provvigioneDefault = provvigioneDefault;
        }
        #endregion

        #region Getters e setters
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public float ProvvigioneDefault
        {
            get { return _provvigioneDefault; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException();
                }

                _provvigioneDefault = value;
            }
        }
        #endregion

        public override string ToString()
        {
            return String.Format("Nome: {0} \nCognome: {1} \nProvvigione di Default: {2}", Nome, Cognome, ProvvigioneDefault);
        }
    }
}
