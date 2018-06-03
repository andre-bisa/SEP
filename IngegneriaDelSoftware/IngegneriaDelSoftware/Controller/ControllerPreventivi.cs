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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza;

namespace IngegneriaDelSoftware.Controller {
    public class ControllerPreventivi {
        /// <summary>
        /// Funzione che permette di aggiungere un preventivo all'elenco
        /// </summary>
        /// <param name="datiPreventivo">Dati del preventivo da creare</param>
        /// <param name="voci">Voci del preventivo da creare</param>
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
        public async void AggiungiPreventivo(Preventivo.DatiPreventivo datiPreventivo, List<VocePreventivo> voci) {
            CollezionePreventivi col = await Task.Run<CollezionePreventivi>(() => { return CollezionePreventivi.GetInstance(); });
            col.Add(new Model.Preventivo(datiPreventivo, voci));
        }
        /// <summary>
        /// Funzione che permette di aggiornare un preventivo
        /// </summary>
        /// <param name="id">ID del preventivo da aggiornare</param>
        /// <param name="datiPreventivo">Nuovi dati</param>
        /// <param name="voci">Nuove voci</param>
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
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
        /// <summary>
        /// Funzione che permette di accettare un preventivo
        /// </summary>
        /// <param name="id">ID del preventivo</param>
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
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
        /// <summary>
        /// Funzione che permette di rifiutare un preventivo
        /// </summary>
        /// <param name="id">ID del preventivo</param>
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
        public async void RifiutaPreventivo(ulong id) {
            var preventivoCercato = await Task.Run<Preventivo>(() => {
                return (from fattura in CollezionePreventivi.GetInstance()
                        where fattura.ID == id
                        select fattura).FirstOrDefault();
            });
            preventivoCercato.DatiPreventivoInterni = new Preventivo.DatiPreventivo(preventivoCercato.DatiPreventivoInterni, accettato: false);
        }
        /// <summary>
        /// Funzione che elimina un preventivo
        /// </summary>
        /// <param name="id">ID del preventivo da rimuovere</param>
        /// <exception cref="ExceptionPersistenza">Eccezione lanciata in caso di insuccesso nelle comunicazioni con il DB</exception>
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
