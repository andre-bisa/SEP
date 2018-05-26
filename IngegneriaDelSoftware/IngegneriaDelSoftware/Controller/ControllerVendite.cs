using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerVendite {
        public async void AggiungiVendita(Vendita.DatiVendita datiVendita, List<VoceVendita> voci) {
            CollezioneVendite col = await Task.Run<CollezioneVendite>(() => { return CollezioneVendite.GetInstance(); });
            col.Add(new Model.Vendita(datiVendita, voci));
        }

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
