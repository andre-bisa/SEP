using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public abstract class Utente
    {
        private string _username, _password, _pIva, _cf, _indirizzo;
        private List<Telefono> _telefoni;
        private Email _email;

        #region Getters e setters
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        protected string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        protected string PartitaIva
        {
            get { return _pIva; }
            set { _pIva = value; }
        }
        protected string CodiceFiscale
        {
            get { return _cf; }
            set { _cf = value; }
        }
        protected string Indirizzo
        {
            get { return _indirizzo; }
            set { _indirizzo = value; }
        }
        protected List<Telefono> Telefono
        {
            get { return _telefoni; }
            set { _telefoni = value; }
        }
        protected Email Eamil
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion
    }
}
