using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerFatture {
        public ControllerFatture() {

        }

        public async void AggiungiFattura(Fattura.DatiFattura datiFattura, List<Vendita> venditeDiProvenienza, List<VoceFattura> voci) {
            CollezioneFatture col = await Task.Run<CollezioneFatture>(() => { return CollezioneFatture.GetInstance(); });
            col.Add(new Fattura(datiFattura, venditeDiProvenienza, voci));
        }

        public async void UpdateFattura(string id, Fattura.DatiFattura? datiFattura = null, List<VoceFattura> voci = null) {
            var fatturaCercata = await Task.Run<Fattura>(() => {
                return (from fattura in CollezioneFatture.GetInstance()
                        where fattura.ID == id
                        select fattura).FirstOrDefault();
            });
            if(datiFattura != null) {
                fatturaCercata.DatiFatturaInterni = datiFattura.Value;
            }
            if(voci != null) {
                fatturaCercata.Clear();
                fatturaCercata.Add(voci.ToArray());
            }
        }
        public async void RimuoviFattura(string id) {
            var fatturaCercata = await Task.Run<Fattura>(() => {
                return (from fattura in CollezioneFatture.GetInstance()
                        where fattura.ID == id
                        select fattura).FirstOrDefault();
            });
            CollezioneFatture.GetInstance().Remove(fatturaCercata);
        }
    }
}
