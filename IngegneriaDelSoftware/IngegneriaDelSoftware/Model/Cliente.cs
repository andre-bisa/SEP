/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Model
{
    public class Cliente : IObservable<Cliente>
    {
        public event EventHandler<ArgsModifica<Cliente>> OnModifica;

        private PersistenzaFactory _persistenza = PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza);

        #region Campi privati
        private DatiCliente _datiCliente;
        private Persona _persona;
        private CollezioneReferenti _referenti;
        #endregion

        #region Proprietà
        /// <summary>
        /// L'identificativo del cliente
        /// </summary>
        public string IDCliente {
            get
            {
                return _datiCliente.IDCliente;
            }
        }
        /// <summary>
        /// La persona collegata al cliente
        /// </summary>
        public Persona Persona {
            get
            {
                return _persona;
            }
        }
        /// <summary>
        /// Le note legate all'utente
        /// </summary>
        public string Nota {
            get
            {
                return _datiCliente.Nota;
            }
        }
        /// <summary>
        /// L'enumerativo che determina il tipo di cliente
        /// </summary>
        public EnumTipoCliente TipoCliente
        {
            get
            {
                return this._datiCliente.TipoCliente;
            }
        }
        /// <summary>
        /// Restituisce una <see cref="CollezioneReferenti"/> che contiene l'elenco dei referenti
        /// </summary>
        public CollezioneReferenti Referenti
        {
            get
            {
                return _referenti;
            }
        }

        /// <summary>
        /// Restituisce il nome del cliente indistintamente tra PersonaFisica o PersonaGiuridica
        /// </summary>
        public string Denominazione
        {
            get
            {
                return this.Persona.getDenominazione();
            }
        }
        #endregion

        #region "Costruttori"
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="persona">La persona dalla quale verrà creato il cliente</param>
        /// <param name="IDCliente">Codice del cliente</param>
        /// <param name="referenti">L'elenco dei referenti</param>
        /// <param name="tipoCliente">Tipo del cliente. Default: Ativo</param>
        /// <param name="nota">Nota del cliente. Default: ""</param>
        /// /// <exception cref="ArgumentNullException"></exception>
        public Cliente(Persona persona, string IDCliente, IEnumerable<Referente> referenti = null, EnumTipoCliente tipoCliente = EnumTipoCliente.Attivo, string nota = "")
        {
            #region Controlli
            if(IDCliente == null)
            {
                 throw new ArgumentNullException(nameof(IDCliente));
            }
            if(persona == null)
            {
                 throw new ArgumentNullException(nameof(persona));
            }
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota));
            }
            #endregion
            this._datiCliente = new DatiCliente(IDCliente, tipoCliente, nota);
            _persona = persona;
            persona.OnModifica += this.PersonaModificata;
            this._referenti = new CollezioneReferenti(referenti);
            this._referenti.OnAggiunta += (o, e) => { _persistenza.GetClienteDAO().InserisciReferente(e.Referente, this); LanciaEvento(this); };
            this._referenti.OnRimozione += (o, e) => { _persistenza.GetClienteDAO().RimuoviReferente(e.Referente, this); LanciaEvento(this); };
        }

        public Cliente(DatiCliente cliente, Persona persona, IEnumerable<Referente> referenti = null) : this(persona, cliente.IDCliente, referenti, cliente.TipoCliente, cliente.Nota)
        {}
        #endregion

        #region "Funzioni pubbliche"

        /// <summary>
        /// Funzione che permette di impostare i nuovi <see cref="DatiCliente"/>
        /// </summary>
        /// <param name="nuoviDati">Nuovi dati del cliente</param>
        /// <exception cref="ExceptionPersistenza">Se si sono verificati errori con la persistenza</exception>
        public void CambiaDatiCliente(DatiCliente nuoviDati)
        {
            if (_datiCliente != nuoviDati)
            {
                Cliente vecchioCliente = this.Clone();
                this._datiCliente = nuoviDati;

                if (! _persistenza.GetClienteDAO().Aggiorna(vecchioCliente, this))
                { // se ci sono errori con la persistenza
                    this._datiCliente = vecchioCliente._datiCliente; // recupero i dati utente che avevo prima
                    throw new ExceptionPersistenza();
                }
                LanciaEvento(vecchioCliente);
            }
        }

        /* Non più supportato il cambio di una persona, ad esempio se un cliente è associato ad una persona fisica deve rimanere associato ad una persona fisica, non può "trasformarsi" in una persona giuridica
        public void CambiaPersona(DatiPersona datiPersona)
        {
            switch (datiPersona.TipoDatiPersona())
            {
                case EnumTipoPersona.Fisica:
                    this.CambiaPersona(new PersonaFisica((DatiPersonaFisica)datiPersona));
                    break;

                case EnumTipoPersona.Giuridica:
                    this.CambiaPersona(new PersonaGiuridica((DatiPersonaGiuridica)datiPersona));
                    break;
            }
        }

        public void CambiaPersona(Persona persona)
        {
            if (_persona != persona)
            {
                Cliente vecchioCliente = this.Clone();
                if (! _persistenza.GetPersonaDAO().CambiaPersona(vecchioCliente, persona))
                {
                    throw new ExceptionPersistenza();
                }
                this._persona = persona;
                persona.OnModifica += this.PersonaModificata;
                LanciaEvento(vecchioCliente);
            }
        }*/

        /// <summary>
        /// Funzione che permette di promuovere il Cliente. Ci sono alcuni vincoli:
        /// Un cliente Attivo non può diventare Potenziale
        /// Un cliente Potenziale non può diventare Ex e viceversa
        /// </summary>
        /// <param name="nuovoTipoCliente">Nuovo tipo che si intende impostare</param>
        /// <exception cref="ArgumentException">In caso di errori dello stato</exception>
        public void PromuoviCliente(EnumTipoCliente nuovoTipoCliente)
        {
            if (TipoCliente == nuovoTipoCliente)
            {
                return;
            }

            if (TipoCliente == EnumTipoCliente.Attivo && nuovoTipoCliente == EnumTipoCliente.Potenziale)
            { 
                throw new ArgumentException();
            }

            if (TipoCliente == EnumTipoCliente.Potenziale && nuovoTipoCliente == EnumTipoCliente.Ex)
            {
                throw new ArgumentException();
            }

            if (TipoCliente == EnumTipoCliente.Ex && nuovoTipoCliente == EnumTipoCliente.Potenziale)
            {
                throw new ArgumentException();
            }

            DatiCliente nuoviDati = new DatiCliente(this.IDCliente, nuovoTipoCliente, this.Nota);
            CambiaDatiCliente(nuoviDati);
        }

        public override string ToString() {
            return String.Format("{0}, {1}, {2}, {3}", this.IDCliente, this.Denominazione, this.Persona.CodiceFiscale, this.TipoCliente);
        }
        #endregion

        #region "Funzioni private"
        protected void LanciaEvento(Cliente vecchioCliente)
        {
            //ModificaCliente?.Invoke(this, new ArgsModificaCliente(this));
            if(OnModifica != null)
            {
                ArgsModifica<Cliente> args = new ArgsModifica<Cliente>(vecchioCliente, this);
                OnModifica(this, args);
            }
            
        }

        private void PersonaModificata(object sender, ArgsModifica<Persona> p)
        {
            Cliente clienteVecchio = this.Clone();
            this._persona = p.Nuovo;
            LanciaEvento(clienteVecchio);
        }

        protected Cliente Clone()
        {
            return new Cliente(this._datiCliente, this._persona, this._referenti);
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            var cliente = obj as Cliente;
            return cliente != null &&
                   IDCliente == cliente.IDCliente;
        }

        public override int GetHashCode()
        {
            return 65159214 + EqualityComparer<string>.Default.GetHashCode(IDCliente);
        }

        public static bool operator ==(Cliente cliente1, Cliente cliente2)
        {
            return EqualityComparer<Cliente>.Default.Equals(cliente1, cliente2);
        }

        public static bool operator !=(Cliente cliente1, Cliente cliente2)
        {
            return !(cliente1 == cliente2);
        }
        #endregion
    }

    public struct DatiCliente
    {
        public string IDCliente { get; private set; }
        public string Nota { get; private set; }
        public EnumTipoCliente TipoCliente { get; private set; }

        #region Costruttori
        public DatiCliente(string IDCliente, EnumTipoCliente tipoCliente, string nota = "")
        {
            #region Controlli
            if (IDCliente == null)
                throw new ArgumentNullException(nameof(IDCliente));
            if (nota == null)
                throw new ArgumentNullException(nameof(nota));
            #endregion

            this.IDCliente = IDCliente;
            this.TipoCliente = tipoCliente;
            this.Nota = nota;
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            if (!(obj is DatiCliente))
            {
                return false;
            }

            var cliente = (DatiCliente)obj;
            return IDCliente == cliente.IDCliente &&
                   Nota == cliente.Nota &&
                   TipoCliente == cliente.TipoCliente;
        }

        public override int GetHashCode()
        {
            var hashCode = -358072698;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IDCliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nota);
            hashCode = hashCode * -1521134295 + TipoCliente.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DatiCliente cliente1, DatiCliente cliente2)
        {
            return cliente1.Equals(cliente2);
        }

        public static bool operator !=(DatiCliente cliente1, DatiCliente cliente2)
        {
            return !(cliente1 == cliente2);
        }
        #endregion

    }

}
