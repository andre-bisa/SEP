using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class FatturaAgente : FatturaScripting
    {
        private DatoreLavoro _datoreDiLavoro;

        #region Costruttore
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datiFattura"></param>
        /// <param name="finalizzato">Se la fattura è in stato di lock o meno (finalizzato)</param>
        /// <param name="venditeDiProvenienza">Le vendite di provenienza</param>
        /// <param name="voci">Le voci della fattura.<para>Se posto a <c>null</c> una lista vuota viene inserita</para></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public FatturaAgente(DatoreLavoro datoreDiLavoro, DatiFattura datiFattura, List<Vendita> venditeDiProvenienza, List<VoceFattura> voci = null, bool finalizzato = false) 
            :base(datiFattura, venditeDiProvenienza, voci, finalizzato){
            this._datoreDiLavoro = datoreDiLavoro;
        }
        /// <summary>
        /// Una nuova fattura
        /// </summary>
        /// <param name="anno">L'anno di emissione della fattura</param>
        /// <param name="numero">Il numero della fattura</param>
        /// <param name="cliente">Il cliente a cui la fattura è rivolta. Deve essere <see cref="EnumTipoCliente.Attivo"/> </param>
        /// <param name="venditeDiProvenienza">Le vendite di provenienza</param>
        /// <param name="data">La data della fattura.<para>Se posta a <c>null</c> è <see cref="DateTime.Now"/></para></param>
        /// <param name="sconto">Lo sconto della fattura.<para>Di default è 0</para></param>
        /// <param name="voci">Le voci della fattura.<para>Se posto a <c>null</c> una lista vuota viene inserita</para></param>
        /// <param name="finalizzato">Se la fattura è in stato di lock o meno (finalizzato)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public FatturaAgente(DatoreLavoro datoreDiLavoro, int anno, string numero, Cliente cliente, List<Vendita> venditeDiProvenienza,
             DateTime? data = null, float sconto = 0, List<VoceFattura> voci = null, bool finalizzato = false) 
            :base(new DatiFattura(anno, numero, cliente, data, sconto), venditeDiProvenienza, voci, finalizzato){
            this._datoreDiLavoro = datoreDiLavoro;
        }
        /// <summary>
        /// Una nuova fattura
        /// </summary>
        /// <param name="anno">L'anno di emissione della fattura</param>
        /// <param name="numero">Il numero della fattura</param>
        /// <param name="cliente">Il cliente a cui la fattura è rivolta</param>
        /// <param name="venditaDiProvenienza">La vendita di provenienza</param>
        /// <param name="data">La data della fattura.<para>Se posta a <c>null</c> è <see cref="DateTime.Now"/></para></param>
        /// <param name="sconto">Lo sconto della fattura.<para>Di default è 0</para></param>
        /// <param name="voci">Le voci della fattura.<para>Se posto a <c>null</c> una lista vuota viene inserita</para></param>
        /// <param name="finalizzato">Se la fattura è in stato di lock o meno (finalizzato)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public FatturaAgente(DatoreLavoro datoreDiLavoro, int anno, string numero, Cliente cliente, Vendita venditaDiProvenienza,
             DateTime? data = null, float sconto = 0, List<VoceFattura> voci = null, bool finalizzato = false)
            :base(anno, numero, cliente, new List<Vendita>(new Vendita[] { venditaDiProvenienza }), data, sconto, voci, finalizzato) {
            //                                      ^ Don't hit me for this plz ^
            this._datoreDiLavoro = datoreDiLavoro;
        }

        public DatoreLavoro DatoreDiLavoro {
            get {
                return _datoreDiLavoro;
            }

            set {
                this._datoreDiLavoro = value;
            }
        }
        #endregion
    }
}
