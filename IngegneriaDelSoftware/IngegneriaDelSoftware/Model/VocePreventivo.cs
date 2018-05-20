using IngegneriaDelSoftware.Model.ArgsEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model {
    public class VocePreventivo: Voce {

        #region Costruttore
        /// <summary>
        /// Crea una nuova voce inseribile in qualsiasi <see cref="VoceContainer"/>.
        /// </summary>
        /// <param name="causale">La causale della voce.</param>
        /// <param name="importo">L'importo della voce</param>
        /// <param name="tipologia">La tipologia della voce. Cioè un campo opzionale 
        /// riempibile dall'utente per raggruppare le voci in macro gruppi.
        /// <para>L'importo è sempre da intendersi singolo</para></param>
        /// <param name="quantita">La quantità di una voce</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public VocePreventivo(string causale, decimal importo, string tipologia = null, int quantita = 1) : base(causale, importo, tipologia, quantita) {
        }
        #endregion

        /// <summary>
        /// Crea una nuova <see cref="VoceVendita"/> a partire da una <see cref="VocePreventivo"/>.
        /// <para>Il valore della provvigione è quello di default (<c>0</c>)</para>
        /// </summary>
        /// <param name="input"></param>
        public static explicit operator VoceVendita(VocePreventivo input) {
            return new VoceVendita(input.Causale, input.Importo,tipologia:input.Tipologia, quantita:input.Quantita);
        }
    }
}
