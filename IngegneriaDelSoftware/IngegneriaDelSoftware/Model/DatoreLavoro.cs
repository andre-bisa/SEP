using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class DatoreLavoro : IObservable<DatoreLavoro>
    {
        private string _nome, _cognome, _ragioneSociale, _pIva, _cF, _indirizzo;
        private List<Telefono> _telefoni;
        private Email _email;

        public event EventHandler<ArgsModifica<DatoreLavoro>> OnModifica;

        #region Costruttori
        /// <summary>
        /// Costruttore di DatoreLavoro completo
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="regioneSociale"></param>
        /// <param name="pIva"></param>
        /// <param name="cF"></param>
        /// <param name="indirizzo"></param>
        /// <param name="telefoni"></param>
        /// <param name="email"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected DatoreLavoro(string nome, string cognome, string ragioneSociale, string pIva, string cF, string indirizzo, List<Telefono> telefoni, Email email)
        {
            _nome = nome ?? throw new ArgumentNullException(nameof(nome));
            _cognome = cognome ?? throw new ArgumentNullException(nameof(cognome));
            _ragioneSociale = ragioneSociale ?? throw new ArgumentNullException(nameof(ragioneSociale));
            _pIva = pIva ?? throw new ArgumentNullException(nameof(pIva));
            _cF = cF ?? throw new ArgumentNullException(nameof(cF));
            _indirizzo = indirizzo ?? throw new ArgumentNullException(nameof(indirizzo));
            this._telefoni = telefoni ?? throw new ArgumentNullException(nameof(telefoni));
            this._email = email ?? throw new ArgumentNullException(nameof(email));
        }

        /// <summary>
        /// Costruttore di DatoreLavoro minimale
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="regioneSociale"></param>
        /// <param name="pIva"></param>
        /// <param name="cF"></param>
        /// <param name="indirizzo"></param>
        /// <param name="telefoni"></param>
        /// <param name="email"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected DatoreLavoro(string nome, string cognome, string ragioneSociale, string pIva, string cF, string indirizzo)
        {
            _nome = nome ?? throw new ArgumentNullException(nameof(nome));
            _cognome = cognome ?? throw new ArgumentNullException(nameof(cognome));
            _ragioneSociale = ragioneSociale ?? throw new ArgumentNullException(nameof(ragioneSociale));
            _pIva = pIva ?? throw new ArgumentNullException(nameof(pIva));
            _cF = cF ?? throw new ArgumentNullException(nameof(cF));
            _indirizzo = indirizzo ?? throw new ArgumentNullException(nameof(indirizzo));

            this._telefoni = null;
            this._email = null;
        }

        /// <summary>
        /// Costruttore di DatoreLavoro senza email
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="regioneSociale"></param>
        /// <param name="pIva"></param>
        /// <param name="cF"></param>
        /// <param name="indirizzo"></param>
        /// <param name="telefoni"></param>
        /// <param name="email"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected DatoreLavoro(string nome, string cognome, string ragioneSociale, string pIva, string cF, string indirizzo, List<Telefono> telefoni)
        {
            _nome = nome ?? throw new ArgumentNullException(nameof(nome));
            _cognome = cognome ?? throw new ArgumentNullException(nameof(cognome));
            _ragioneSociale = ragioneSociale ?? throw new ArgumentNullException(nameof(ragioneSociale));
            _pIva = pIva ?? throw new ArgumentNullException(nameof(pIva));
            _cF = cF ?? throw new ArgumentNullException(nameof(cF));
            _indirizzo = indirizzo ?? throw new ArgumentNullException(nameof(indirizzo));

            this._telefoni = telefoni ?? throw new ArgumentNullException(nameof(telefoni));
            this._email = null;
        }

        /// <summary>
        /// Costruttore di DatoreLavoro senza telefono
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="regioneSociale"></param>
        /// <param name="pIva"></param>
        /// <param name="cF"></param>
        /// <param name="indirizzo"></param>
        /// <param name="telefoni"></param>
        /// <param name="email"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected DatoreLavoro(string nome, string cognome, string ragioneSociale, string pIva, string cF, string indirizzo, Email email)
        {
            _nome = nome ?? throw new ArgumentNullException(nameof(nome));
            _cognome = cognome ?? throw new ArgumentNullException(nameof(cognome));
            _ragioneSociale = ragioneSociale ?? throw new ArgumentNullException(nameof(ragioneSociale));
            _pIva = pIva ?? throw new ArgumentNullException(nameof(pIva));
            _cF = cF ?? throw new ArgumentNullException(nameof(cF));
            _indirizzo = indirizzo ?? throw new ArgumentNullException(nameof(indirizzo));

            this._telefoni = null;
            this._email = email ?? throw new ArgumentNullException(nameof(email));
        }


        #endregion

        #region Getters e setters
        /// <summary>
        /// Nome del datore di lavoro
        /// </summary>
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        /// <summary>
        /// Cognome del datore di lavoro
        /// </summary>
        public string Cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }
        /// <summary>
        /// Ragione sociale del datore di lavoro
        /// </summary>
        public string RagioneSociale
        {
            get { return _ragioneSociale; }
            set { _ragioneSociale = value; }
        }
        /// <summary>
        /// Partita Iva del datore di lavoro
        /// </summary>
        public string PartitaIva
        {
            get { return _pIva; }
            set { _pIva = value; }
        }
        /// <summary>
        /// Codice fiscale del datore di lavoro
        /// </summary>
        public string CodiceFiscale
        {
            get { return _cF; }
            set { _cF = value; }
        }
        /// <summary>
        /// Indirizzo del datore di lavoro
        /// </summary>
        public string Indirizzo
        {
            get { return _indirizzo; }
            set { _indirizzo = value; }
        }
        /// <summary>
        /// Eventuali numeri di telefono del datore di lavoro
        /// </summary>
        public List<Telefono> Telefono
        {
            get { return _telefoni; }
            set { _telefoni = value; }
        }
        /// <summary>
        /// Eventuale email del datore di lavoro
        /// </summary>
        public Email Email
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion
    }
}
