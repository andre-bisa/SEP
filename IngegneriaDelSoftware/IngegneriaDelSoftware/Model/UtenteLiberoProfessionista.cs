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
        private DatiUtenteLiberoProfessionista _datiUtenteLiberoProfessionista;

        #region Costruttore
        public UtenteLiberoProfessionista(DatiUtenteLiberoProfessionista datiUtenteLiberoProfessionista)
        {
            _datiUtenteLiberoProfessionista = datiUtenteLiberoProfessionista;
        }
        #endregion

        #region Properties
        public string Nome
        {
            get { return _datiUtenteLiberoProfessionista.Nome; }
        }
        public string Cognome
        {
            get { return _datiUtenteLiberoProfessionista.Cognome; }
        }
        public override string Username
        {
            get { return _datiUtenteLiberoProfessionista.Username; }
        }
        public override string PartitaIva
        {
            get { return _datiUtenteLiberoProfessionista.PartitaIva; }
        }
        public override string CodiceFiscale
        {
            get { return _datiUtenteLiberoProfessionista.CodiceFiscale; }
        }
        public override string Indirizzo
        {
            get { return _datiUtenteLiberoProfessionista.Indirizzo; }
        }
        public override CollezioneTelefoni Telefoni
        {
            get { return _datiUtenteLiberoProfessionista.Telefoni; }
        }
        public override Email Email
        {
            get { return _datiUtenteLiberoProfessionista.Email; }
        }
        #endregion

        public override string ToString()
        {
            return String.Format("{0} \nNome: {1} \nCognome: {2}", base.ToString(),  Nome, Cognome);
        }
    }


    public class DatiUtenteLiberoProfessionista : DatiUtente
    {
        public string Nome { get; private set; }
        public string Cognome { get; private set; }

        /// <summary>
        /// Costruttore di Dati Utente di tipo LiberoProfessionista
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pIva"></param>
        /// <param name="cf"></param>
        /// <param name="indirizzo"></param>
        /// <param name="email"></param>
        /// <param name="ragioneSociale"></param>
        /// <param name="sedeLegale"></param>
        /// <param name="telefoni"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DatiUtenteLiberoProfessionista(string username, string pIva, string cf, string indirizzo, Email email, string nome, string cognome, List<Telefono> telefoni = null)
            : base(username, pIva, cf, indirizzo, email, telefoni)
        {
            if (nome == null || cognome == null)
            {
                throw new ArgumentNullException();
            }

            Nome = nome;
            Cognome = cognome;
        }
    }
}
