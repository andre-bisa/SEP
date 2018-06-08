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

using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.View;
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
            try {
                col.Add(new FatturaScripting(datiFattura, venditeDiProvenienza, voci));
            }catch(ArgumentException e) {
                FormConfim.Show("Errore", "Si è verificato un errore in: " + e.Message, System.Windows.Forms.MessageBoxButtons.OK);
            }
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
                System.Diagnostics.Debug.WriteLine(voci.Count);
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
