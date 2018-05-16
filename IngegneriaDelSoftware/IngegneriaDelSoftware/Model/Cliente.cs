using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class Cliente
    {
        public EventHandler<ArgsModificaCliente> ModificaCliente;

        private string _idCliente;
        public string IDCliente {
            get
            {
                return _idCliente;
            }
            set
            {
                _idCliente = value;
                LanciaEvento();
            }
        }
        private Persona _persona;
        public Persona Persona {
            get
            {
                return _persona;
            }
            set
            {
                _persona = value;
                LanciaEvento();
            }
        }
        private string _nota;
        public string Nota {
            get
            {
                return _nota;
            }
            set
            {
                _nota = value;
                LanciaEvento();
            }
        }
        public EnumTipoCliente TipoCliente { get; private set; }
        public List<Referente> Referenti { get; } = new List<Referente>();

        #region "Costruttori"
        public Cliente(Persona persona, string IDCliente, EnumTipoCliente tipoCliente)
        {
            this.IDCliente = IDCliente ?? throw new ArgumentNullException(nameof(IDCliente));
            Persona = persona ?? throw new ArgumentNullException(nameof(persona));
            Persona.ModificaPersona += this.PersonaModificata; // Se ci sono modifiche dico che il cliente è stato modificato
            TipoCliente = tipoCliente;
        }

        public Cliente (Persona persona, string IDCliente) : this(persona, IDCliente, EnumTipoCliente.Attivo)
        {
        }

        public Cliente (Persona persona, string iDCliente, string nota) : this(persona, iDCliente)
        {
            Nota = nota ?? throw new ArgumentNullException(nameof(nota));
        }

        public Cliente (Persona persona, string IDCliente, EnumTipoCliente tipoCliente, string nota) : this(persona, IDCliente, tipoCliente)
        {
            Nota = nota ?? throw new ArgumentNullException(nameof(nota));
        }
        #endregion

        #region "Funzioni Referenti"
        public void AggiungiReferente(Referente referente)
        {
            if (referente != null)
                this.Referenti.Add(referente);
        }

        public void RimuoviReferente(Referente referente)
        {
            if (referente != null)
                this.Referenti.Remove(referente);
        }
        #endregion

        #region "Funzioni pubbliche"
        /// <summary>
        /// Funzione che permette di promuovere il Cliente. Ci sono alcuni vincoli:
        /// Un cliente Attivo non può diventare Potenziale
        /// Un cliente Potenziale non può diventare Ex e viceversa
        /// </summary>
        /// <param name="nuovoTipoCliente">Nuovo tipo che si intende impostare</param>
        public void CambiaTipoCliente(EnumTipoCliente nuovoTipoCliente)
        {
            if (TipoCliente == EnumTipoCliente.Attivo && nuovoTipoCliente == EnumTipoCliente.Potenziale)
                throw new ArgumentException();

            if (TipoCliente == EnumTipoCliente.Potenziale && nuovoTipoCliente == EnumTipoCliente.Ex)
                throw new ArgumentException();

            if (TipoCliente == EnumTipoCliente.Ex && nuovoTipoCliente == EnumTipoCliente.Potenziale)
                throw new ArgumentException();

            TipoCliente = nuovoTipoCliente;
            LanciaEvento();
        }

        public override bool Equals(object obj)
        {
            var cliente = obj as Cliente;
            return cliente != null &&
                   IDCliente == cliente.IDCliente;
        }

        public override int GetHashCode()
        {
            var hashCode = 2011232026;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IDCliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<Persona>.Default.GetHashCode(Persona);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nota);
            hashCode = hashCode * -1521134295 + TipoCliente.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Referente>>.Default.GetHashCode(Referenti);
            return hashCode;
        }
        #endregion

        #region "Funzioni private"
        protected void LanciaEvento()
        {
            if (ModificaCliente != null)
            {
                ArgsModificaCliente args = new ArgsModificaCliente(this);
                ModificaCliente(this, args);
            }
        }

        private void PersonaModificata(object sender, ArgsModificaPersona p)
        {
            LanciaEvento();
        }

        #endregion
    }
}
