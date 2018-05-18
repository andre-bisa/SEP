using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class UtenteAgente : Utente, IObservable<UtenteAgente>
    {
        private string _nome, _cognome;
        private float _provvigioneDefault;
        public event EventHandler<ArgsModifica<UtenteAgente>> OnModifica;

        #region Costruttore
        /// <summary>
        /// Costruttore di un Utente di tipologia Agente
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="provvigioneDefault">La percentuale di provvigione di default (espressa come numero da 0 a 1, es. 100% = 1, 50% = 0,5)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public UtenteAgente(string nome, string cognome, float provvigioneDefault)
        {
            _nome = nome ?? throw new ArgumentNullException(nameof(nome));
            _cognome = cognome ?? throw new ArgumentNullException(nameof(cognome));

            if (provvigioneDefault > 1 || provvigioneDefault < 0)
            {
                throw new ArgumentException();
            }

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
    }
}
