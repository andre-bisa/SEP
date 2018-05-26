using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerPreventivi {
        public async void AggiungiPreventivo(Preventivo.DatiPreventivo datiPreventivo, List<VocePreventivo> voci) {
            CollezionePreventivi col = await Task.Run<CollezionePreventivi>(() => { return CollezionePreventivi.GetInstance(); });
            col.Add(new Model.Preventivo(datiPreventivo, voci));
        }
        public async void UpdatePreventivo(ulong id, Preventivo.DatiPreventivo? datiPreventivo = null, List<VocePreventivo> voci = null) {
            var preventivoCercato = await Task.Run<Preventivo>(() => {
                return (from fattura in CollezionePreventivi.GetInstance()
                        where fattura.ID == id
                        select fattura).FirstOrDefault();
            });
            if(datiPreventivo != null) {
                preventivoCercato.DatiPreventivoInterni = datiPreventivo.Value;
            }
            if(voci != null) {
                preventivoCercato.Clear();
                preventivoCercato.Add(voci.ToArray());
            }
        }
        public async void AccettaPreventivo(ulong id) {
            var preventivoCercato = await Task.Run<Preventivo>(() => {
                return (from fattura in CollezionePreventivi.GetInstance()
                        where fattura.ID == id
                        select fattura).FirstOrDefault();
            });
            preventivoCercato.DatiPreventivoInterni = new Preventivo.DatiPreventivo(preventivoCercato.DatiPreventivoInterni, accettato: true);
            /*Task.Run(() => {
                Vendita.FromPreventivo(0, preventivoCercato);
            });*/
        }
        public async void RifiutaPreventivo(ulong id) {
            var preventivoCercato = await Task.Run<Preventivo>(() => {
                return (from fattura in CollezionePreventivi.GetInstance()
                        where fattura.ID == id
                        select fattura).FirstOrDefault();
            });
            preventivoCercato.DatiPreventivoInterni = new Preventivo.DatiPreventivo(preventivoCercato.DatiPreventivoInterni, accettato: false);
        }
        public async void RimuoviPreventivo(ulong id) {
            var preventivoCercato = await Task.Run<Preventivo>(() => {
                return (from fattura in CollezionePreventivi.GetInstance()
                        where fattura.ID == id
                        select fattura).FirstOrDefault();
            });
            CollezionePreventivi.GetInstance().Remove(preventivoCercato);
        }
    }
}
