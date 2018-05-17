using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public class Esterno : IObservable<Esterno>
    {
        public event EventHandler<ArgsModifica<Esterno>> OnModifica;

        /// <summary>
        /// Identificativo dell'esterno
        /// </summary>
        public string ID { get; private set; }
        /// <summary>
        /// Nome dell'esterno
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Cognome dell'esterno. Può essere nullo.
        /// </summary>
        public string Cognome { get; private set; }
        /// <summary>
        /// Partita IVA. Può essere nullo.
        /// </summary>
        public string PartitaIVA { get; private set; }
        /// <summary>
        /// Codice fiscale. Può essere nullo.
        /// </summary>
        public string CodiceFiscale { get; private set; }
        /// <summary>
        /// Telefono. Può essere nullo.
        /// </summary>
        public string Telefono { get; private set; }
        /// <summary>
        /// Email. Può essere nullo.
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// Indirizzo. Può essere nullo.
        /// </summary>
        public string Indirizzo { get; private set; }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="ID">Identificativo</param>
        /// <param name="nome">Nome dell'esterno</param>
        /// <param name="cognome">Cognome dell'esterno</param>
        /// <param name="partitaIVA">Partita IVA</param>
        /// <param name="codiceFiscale">Codice fiscale</param>
        /// <param name="telefono">Telefono</param>
        /// <param name="email">Email</param>
        /// <param name="indirizzo">Indirizzo</param>
        /// <exception cref="ArgumentNullException">Se i parametri obbligatori sono <c>null</c></exception>
        public Esterno(string ID, string nome, string cognome = null, string partitaIVA = null, string codiceFiscale = null, string telefono = null, string email = null, string indirizzo = null)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));
            if (nome == null)
                throw new ArgumentNullException(nameof(nome));
            this.ID = ID;
            Nome = nome;
            Cognome = cognome;
            PartitaIVA = partitaIVA;
            CodiceFiscale = codiceFiscale;
            Telefono = telefono;
            Email = email;
            Indirizzo = indirizzo;
        }


    }
}
