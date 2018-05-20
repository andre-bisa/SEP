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
        private DatiDatoreLavoro _datiDatoreLavoro;

        #region Costruttore
        /// <summary>
        /// Costruttore di DatoreLavoro
        /// </summary>
        /// <param name="datiDatoreLavoro"></param>
        public DatoreLavoro(DatiDatoreLavoro datiDatoreLavoro)
        {
            _datiDatoreLavoro = datiDatoreLavoro;
        }


        #endregion

        #region Properties
        /// <summary>
        /// Nome del datore di lavoro
        /// </summary>
        public string Nome
        {
            get { return _datiDatoreLavoro.Nome; }
        }
        /// <summary>
        /// Cognome del datore di lavoro
        /// </summary>
        public string Cognome
        {
            get { return _datiDatoreLavoro.Cognome; }
        }
        /// <summary>
        /// Ragione sociale del datore di lavoro
        /// </summary>
        public string RagioneSociale
        {
            get { return _datiDatoreLavoro.RagioneSociale; }
        }
        /// <summary>
        /// Partita Iva del datore di lavoro
        /// </summary>
        public string PartitaIva
        {
            get { return _datiDatoreLavoro.PartitaIva; }
        }
        /// <summary>
        /// Codice fiscale del datore di lavoro
        /// </summary>
        public string CodiceFiscale
        {
            get { return _datiDatoreLavoro.CodiceFiscale; }
        }
        /// <summary>
        /// Indirizzo del datore di lavoro
        /// </summary>
        public string Indirizzo
        {
            get { return _datiDatoreLavoro.Indirizzo; }
        }
        /// <summary>
        /// Eventuali numeri di telefono del datore di lavoro
        /// </summary>
        public CollezioneTelefoni Telefoni
        {
            get { return _datiDatoreLavoro.Telefoni; }
        }
        /// <summary>
        /// Eventuale email del datore di lavoro
        /// </summary>
        public Email? Email
        {
            get { return _datiDatoreLavoro.Email; }
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return String.Format("Nome: {0} \nCognome: {1} \nPartita Iva: {2} \nCodice Fiscale: {3}" +
                " \nIndirizzo: {4}  \nTelefoni: {4} \nEmail: {5}", Nome, Cognome, PartitaIva, CodiceFiscale,
                Indirizzo, Telefoni.ToString(), Email.ToString());
        }
        #endregion
    }

    #region Struct interna
    public struct DatiDatoreLavoro
    {
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public string RagioneSociale { get; private set; }
        public string PartitaIva { get; private set; }
        public string CodiceFiscale { get; private set; }
        public string Indirizzo { get; private set; }
        public CollezioneTelefoni Telefoni { get; private set; }
        //Email? siccome e' una struct che puo' essere nulla
        public Email? Email { get; private set; }
        
        public DatiDatoreLavoro(string nome, string cognome, string pIva, string cf, string ragioneSociale, string indirizzo, List<Telefono> telefoni = null, Email? email = null)
        {
            #region Controlli
            if (nome == null)
            {
                throw new ArgumentNullException();
            }
            if (cognome == null)
            {
                throw new ArgumentNullException();
            }
            if (pIva == null)
            {
                throw new ArgumentNullException();
            }
            if (indirizzo == null)
            {
                throw new ArgumentNullException();
            }
            if (ragioneSociale == null)
            {
                throw new ArgumentNullException();
            }
            #endregion

            Nome = nome;
            Cognome = cognome;
            PartitaIva = pIva;
            CodiceFiscale = cf;
            Indirizzo = indirizzo;
            RagioneSociale = ragioneSociale;
            //Se argomento nullo da' lista vuota, altrimenti crea una copia della lista data
            Telefoni = new CollezioneTelefoni(telefoni);
            Email = email;
        }
    }
    #endregion
}
