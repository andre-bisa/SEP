using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class UtenteLiberoProfessionista : Utente
    {
        public override event EventHandler<ArgsModifica<Utente>> OnModifica;
        private string _nome, _cognome;

        #region Costruttore
        /// <summary>
        /// Costruttore di un Utente di tipologia LiberoProfessionista
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pIva"></param>
        /// <param name="cF"></param>
        /// <param name="indirizzo"></param>
        /// <param name="telefoni"></param>
        /// <param name="email"></param>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UtenteLiberoProfessionista(string username, string pIva, string cF, string indirizzo, List<Telefono> telefoni, Telefono email, string nome, string cognome) 
            : base(username, pIva, cF, indirizzo, telefoni, email)
        {
            if(nome == null)
            {
                throw new ArgumentNullException();
            }
            if(cognome == null)
            {
                throw new ArgumentNullException();
            }

            _nome = nome;
            _cognome = cognome;
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

        public override string ToString()
        {
            return String.Format("Nome: {0} \nCognome: {1}", Nome, Cognome);
        }
    }
}
