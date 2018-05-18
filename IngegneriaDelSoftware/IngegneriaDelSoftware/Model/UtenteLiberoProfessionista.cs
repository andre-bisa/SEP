using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class UtenteLiberoProfessionista : Utente, IObservable<UtenteLiberoProfessionista>
    {
        private string _nome, _cognome;
        public event EventHandler<ArgsModifica<UtenteLiberoProfessionista>> OnModifica;

        #region Costruttore
        /// <summary>
        /// Costruttore di un Utente di tipologia LiberoProfessionista
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UtenteLiberoProfessionista(string nome, string cognome)
        {
            _nome = nome ?? throw new ArgumentNullException(nameof(nome));
            _cognome = cognome ?? throw new ArgumentNullException(nameof(cognome));
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
        #endregion
    }
}
