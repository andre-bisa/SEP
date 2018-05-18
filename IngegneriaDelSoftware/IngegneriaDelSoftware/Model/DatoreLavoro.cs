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
        public event EventHandler<ArgsModifica<DatoreLavoro>> OnModifica;
        private string _nome, _cognome, _ragioneSociale, _pIva, _cF, _indirizzo;
        private List<Telefono> _telefoni;
        private Telefono _email;


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
        protected DatoreLavoro(string nome, string cognome, string ragioneSociale, string pIva, string cF, string indirizzo, List<Telefono> telefoni =  null, Telefono email = null)
        {
            #region Controlli
            if(nome == null)
            {
                throw new ArgumentNullException(nameof(nome));
            }
            if (cognome == null)
            {
                throw new ArgumentNullException(nameof(cognome));
            }
            if(ragioneSociale == null)
            {
                throw new ArgumentNullException(nameof(ragioneSociale));
            }
            if(pIva == null)
            {
                throw new ArgumentNullException(nameof(pIva));
            }
            if(cF == null)
            {
                throw new ArgumentNullException(nameof(cF));
            }
            if(indirizzo == null)
            {
                throw new ArgumentNullException(nameof(indirizzo));
            }
            #endregion

            _nome = nome;
            _cognome = cognome;
            _ragioneSociale = ragioneSociale;
            _pIva = pIva;
            _cF = cF;
            _indirizzo = indirizzo;
            //Se argomento nullo da' lista vuota, altrimenti crea una copia della lista data
            _telefoni = (telefoni == null) ? new List<Telefono>() : new List<Telefono>(telefoni);
            _email = email;
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
        public Telefono Email
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion
    }
}
