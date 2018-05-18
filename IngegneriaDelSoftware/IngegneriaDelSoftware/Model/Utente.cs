using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public abstract class Utente : IObservable<Utente>
    {
        public abstract event EventHandler<ArgsModifica<Utente>> OnModifica;
        private string _username, _pIva, _cf, _indirizzo;
        private ListaTelefoni _telefoni;
        private Telefono _email;

        #region Costruttore
        /// <summary>
        /// Costruttore di un Utente, inizializza solo i campi comuni ai figli
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pIva"></param>
        /// <param name="cF"></param>
        /// <param name="indirizzo"></param>
        /// <param name="telefoni">Campo opzionale</param>
        /// <param name="email">Campo opzionale</param>
        public Utente(string username, string pIva, string cF, string indirizzo, List<Telefono> telefoni = null, Telefono email = null)
        {
            #region Controlli
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }
            if (pIva == null)
            {
                throw new ArgumentNullException(nameof(pIva));
            }
            if (cF == null)
            {
                throw new ArgumentNullException(nameof(cF));
            }
            if (indirizzo == null)
            {
                throw new ArgumentNullException(nameof(indirizzo));
            }
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            #endregion

            _username = username;
            _pIva = pIva;
            _cf = cF;
            _indirizzo = indirizzo;
            //Se argomento nullo da' lista vuota, altrimenti crea una copia della lista data
            _telefoni = new ListaTelefoni(telefoni);
            _email = email;
        }
        #endregion

        #region Getters e setters
        public string Username
        {
            get { return _username; }
            protected set { _username = value; }
        }
        public string PartitaIva
        {
            get { return _pIva; }
            protected set { _pIva = value; }
        }
        public string CodiceFiscale
        {
            get { return _cf; }
            protected set { _cf = value; }
        }
        public string Indirizzo
        {
            get { return _indirizzo; }
            protected set { _indirizzo = value; }
        }
        public List<Telefono> Telefoni
        {
            get
            {
                //Ritorna la copia della lista
                return new List<Telefono>(_telefoni);
            }
        }
        public Telefono Email
        {
            get { return _email; }
            protected set { _email = value; }
        }
        #endregion

    }
}
