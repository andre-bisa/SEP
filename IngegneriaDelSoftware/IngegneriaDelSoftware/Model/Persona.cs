using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public abstract class Persona : IObservable<Persona>
    {
        public event EventHandler<ArgsModifica<Persona>> OnModifica;

        public abstract EnumTipoPersona TipoPersona { get; }
        protected abstract Persona Clone();

        #region Proprietà
        public abstract string CodiceFiscale { get; }
        public abstract string Indirizzo { get; }
        public abstract CollezioneTelefoni Telefoni { get; }
        public abstract CollezioneEmail Email { get; }
        #endregion

        #region "Funzioni pubbliche"
        /// <summary>
        /// Restituisce il nome della persona da visualizzare
        /// </summary>
        /// <returns>La denominazione</returns>
        public abstract string getDenominazione();

        public abstract void CambiaDatiPersona(DatiPersona datiPersona);

        protected void LanciaEvento(Persona vecchio)
        {
            if (OnModifica != null)
            {
                ArgsModifica<Persona> args = new ArgsModifica<Persona>(vecchio, this);
                OnModifica(this, args);
            }
        }

        public override bool Equals(object obj)
        {
            var persona = obj as Persona;
            return persona != null &&
                   CodiceFiscale == persona.CodiceFiscale;
        }

        public override int GetHashCode()
        {
            return 542064849 + EqualityComparer<string>.Default.GetHashCode(CodiceFiscale);
        }
        #endregion

    }

    public abstract class DatiPersona
    {
        public abstract string CodiceFiscale { get; }
        public abstract string Indirizzo { get; }

        public abstract EnumTipoPersona TipoDatiPersona();

    }
}
