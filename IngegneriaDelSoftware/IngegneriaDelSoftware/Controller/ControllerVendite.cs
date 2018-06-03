using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerVendite {
        /// <summary>
        /// Funzione che permette di aggiungere una vendita
        /// </summary>
        /// <param name="datiVendita">Dati della vendita da aggiungere</param>
        /// <param name="voci">Voci da aggiungere alla vendita</param>
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
        public async void AggiungiVendita(Vendita.DatiVendita datiVendita, List<VoceVendita> voci) {
            CollezioneVendite col = await Task.Run<CollezioneVendite>(() => { return CollezioneVendite.GetInstance(); });
            col.Add(new Model.Vendita(datiVendita, voci));
        }

        /// <summary>
        /// Funzione che permette di modificare una vendita
        /// </summary>
        /// <param name="id">ID della vendita da modificare</param>
        /// <param name="datiVendita">Nuovi dati della vendita</param>
        /// <param name="voci">Nuove voci della vendita</param>
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
        public async void UpdateVendita(ulong id, Vendita.DatiVendita? datiVendita = null, List<VoceVendita> voci = null) {
            var venditaCercata = await Task.Run<Vendita>(() => {
                return (from vendita in CollezioneVendite.GetInstance()
                        where vendita.ID == id
                        select vendita).FirstOrDefault();
            });
            if(datiVendita != null) {
                venditaCercata.DatiVenditaInterni = datiVendita.Value;
            }
            if(voci != null) {
                venditaCercata.Clear();
                venditaCercata.Add(voci.ToArray());
            }
        }

        /// <summary>
        /// Funzione che permette di eliminare una vendita
        /// </summary>
        /// <param name="id">ID della vendita ad eliminare</param>
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
        public async void RimuoviVendita(ulong id) {
            var venditaCercata = await Task.Run<Vendita>(() => {
                return (from vendita in CollezioneVendite.GetInstance()
                        where vendita.ID == id
                        select vendita).FirstOrDefault();
            });
            CollezioneVendite.GetInstance().Remove(venditaCercata);
        }
    }
}
