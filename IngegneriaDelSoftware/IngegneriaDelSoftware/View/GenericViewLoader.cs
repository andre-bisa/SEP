using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IngegneriaDelSoftware.View {
    public static class GenericViewLoader {

        private static void CaricaCliente(GenericForm g, Cliente c){
            if(c.Persona.TipoPersona == EnumTipoPersona.Fisica) {
                var persona = c.Persona as PersonaFisica;

                g.InserisciDatiDestinatario(null,
                    null,
                    null,
                    persona.Nome,
                    persona.Cognome,
                    persona.Indirizzo,
                    persona.CodiceFiscale,
                    persona.PartitaIVA,
                    persona.Telefoni.FirstOrDefault().ToString(),
                    false,
                    GenericForm.TipoPersona.FISICA);
            } else if(c.Persona.TipoPersona == EnumTipoPersona.Giuridica) {
                var persona = c.Persona as PersonaGiuridica;

                g.InserisciDatiDestinatario(null,
                    null,
                    null,
                    persona.RagioneSociale,
                    null,
                    persona.Indirizzo,
                    persona.CodiceFiscale,
                    persona.PartitaIVA,
                    persona.Telefoni.FirstOrDefault().ToString(),
                    false,
                    GenericForm.TipoPersona.GIURIDICA);
            }
        }

        public static GenericForm getPreventivoForm(List<Preventivo> preventivi) {
            GenericForm result = GenericForm.CreaFormPreventivo();
            Dictionary<string, Preventivo> prev = new Dictionary<string, Preventivo>();
            Cliente tmpCliente = null;
            preventivi.ForEach((e) => {
                prev.Add(e.ID.ToString(), e);
                result.AggiungiBarraLaterale(e.ID);
            });
            result.OnPannelloLateraleClick += (o, e)=> {
                if(o.SelectedItems.Count == 1) {
                    var preventivo = prev[o.SelectedItems[0].Text];
                    var cliente = preventivo.Cliente;
                    CaricaCliente(result, cliente);
                    foreach(VocePreventivo voce in preventivo) {
                        result.AggiungiRigaCampi(voce.Tipologia, voce.Causale, Convert.ToDouble(voce.Importo), 0, voce.Quantita);
                    }
                    result.Key = preventivo.ID.ToString();
                }
            };
            result.OnAccettaClick += (o, e) => {
                if(o.Key != null) {
                    prev[o.Key].DatiPreventivoInterni = new Preventivo.DatiPreventivo(prev[o.Key].DatiPreventivoInterni, accettato: true);
                }
            };
            result.OnRifiutaClick += (o, e) => {
                if(o.Key != null) {
                    prev[o.Key].DatiPreventivoInterni = new Preventivo.DatiPreventivo(prev[o.Key].DatiPreventivoInterni, accettato: false);
                }

            };
            result.OnCreaClick += (o, e) => {
                if(String.IsNullOrEmpty(o.Key)) {
                    //TODO what do i do with this?;
                    new Preventivo(Convert.ToUInt64(o.Numero), tmpCliente, null, false, o.GetVoci().Select((el) => {
                        return new VocePreventivo(el.Descrizione, Convert.ToDecimal(el.Importo), el.Tipologia, el.Numero);
                    }).ToList());
                } else {
                    var old = prev[o.Key];
                    DateTime? da = DateTime.Parse(o.Data);
                    ulong? id = Convert.ToUInt64(o.Numero);
                    bool mod = false;
                    if(mod = (da == old.Data)) {
                        da = null;
                    }else {
                        mod = true;
                    }
                    if(id == old.ID) {
                        da = null;
                    }else {
                        mod = true;
                    }
                    if(mod) {
                        Preventivo.DatiPreventivo dat = new Preventivo.DatiPreventivo(old.DatiPreventivoInterni, id, null, da, null);
                        old.DatiPreventivoInterni = dat;
                    }
                    old.Add(
                        o.GetVoci().Select((el) => {
                            return new VocePreventivo(el.Descrizione, Convert.ToDecimal(el.Importo), el.Tipologia, el.Numero);
                        }).ToList().Where((f) => {
                            return !old.Voci.Any((ff) => {
                                return f.Equals(ff);
                            });
                        }).ToArray()
                    );
                }
            };
            result.OnNuovaClick += (o, e) => {
                o.Key = null;
                o.Enabled = false;
                Cliente c = null;
                if((c = GetClienteForm.Get(CollezioneClienti.GetInstance().ToList())) == null) {
                    o.CleanAll();
                } else {
                    CaricaCliente(result, c);
                    tmpCliente = c;
                }
                o.Enabled = true;
            };
            return result;
        }
        public static GenericForm getVenditaForm(List<Vendita> vendite) {
            GenericForm result = GenericForm.CreaFormVendita();
            Cliente tmpCliente = null;
            Dictionary<string, Vendita> vend = new Dictionary<string, Vendita>();
            vendite.ForEach((e) => {
                vend.Add(e.ID.ToString(), e);
                result.AggiungiBarraLaterale(e.ID);
            });
            result.OnPannelloLateraleClick += (o, e) => {
                if(o.SelectedItems.Count == 1) {
                    var vendita = vend[o.SelectedItems[0].Text];
                    var cliente = vendita.Cliente;
                    CaricaCliente(result, cliente);
                    foreach(VoceVendita voce in vendita) {
                        result.AggiungiRigaCampi(voce.Tipologia, voce.Causale, Convert.ToDouble(voce.Importo), voce.Provvigione, voce.Quantita);
                    }
                    result.Key = vendita.ID.ToString();
                }
            };
            result.OnCreaClick += (o, e) => {
                if(String.IsNullOrEmpty(o.Key)) {
                    //TODO what do i do with this?;
                    new Preventivo(Convert.ToUInt64(o.Numero), tmpCliente, null, false, o.GetVoci().Select((el) => {
                        return new VocePreventivo(el.Descrizione, Convert.ToDecimal(el.Importo), el.Tipologia, el.Numero);
                    }).ToList());
                } else {
                    var old = vend[o.Key];
                    DateTime? da = DateTime.Parse(o.Data);
                    ulong? id = Convert.ToUInt64(o.Numero);
                    bool mod = false;
                    if(mod = (da == old.Data)) {
                        da = null;
                    } else {
                        mod = true;
                    }
                    if(id == old.ID) {
                        da = null;
                    } else {
                        mod = true;
                    }
                    if(mod) {
                        Vendita.DatiVendita dat = new Vendita.DatiVendita(old.DatiVenditaInterni, id, null, da, null);
                        old.DatiVenditaInterni = dat;
                    }
                    old.Add(
                        o.GetVoci().Select((el) => {
                            return new VoceVendita(el.Descrizione, Convert.ToDecimal(el.Importo), Convert.ToSingle(el.Opzionale), el.Tipologia, el.Numero);
                        }).ToList().Where((f) => {
                            return !old.Voci.Any((ff) => {
                                return f.Equals(ff);
                            });
                        }).ToArray()
                    );
                }
        };
            result.OnNuovaClick += (o, e) => {
                o.Key = null;
                o.Enabled = false;
                Cliente c = null;
                if((c = GetClienteForm.Get(CollezioneClienti.GetInstance().ToList())) == null) {
                    o.CleanAll();
                } else {
                    CaricaCliente(result, c);
                    tmpCliente = c;
                }
                o.Enabled = true;
            };
            return result;
        }
        public static GenericForm getFatturaForm(List<Fattura> fatture) {
            Cliente tmpCliente = null;
            List<Vendita> vendite = null;
            GenericForm result = GenericForm.CreaFormFattura();
            Dictionary<string, Fattura> fatt = new Dictionary<string, Fattura>();
            fatture.ForEach((e) => {
                fatt.Add(e.Numero, e);
                result.AggiungiBarraLaterale(e.Numero);
            });
            result.OnPannelloLateraleClick += (o, e) => {
                if(o.SelectedItems.Count == 1) {
                    var fattura = fatt[o.SelectedItems[0].Text];
                    var cliente = fattura.Cliente;
                    CaricaCliente(result, cliente);
                    foreach(VoceFattura voce in fattura) {
                        result.AggiungiRigaCampi(voce.Tipologia, voce.Causale, Convert.ToDouble(voce.Importo), 0, voce.Quantita);
                    }
                    result.Key = fattura.Numero;
                }
            };
            result.OnCreaClick += (o, e) => {
                if(String.IsNullOrEmpty(o.Key)) {
                    //TODO what do i do with this?;
                    new Fattura(Convert.ToInt32(o.Anno), o.Numero, tmpCliente, vendite, DateTime.Parse(o.Data), 0, o.GetVoci().Select((el) => {
                        return new VoceFattura(el.Descrizione, Convert.ToDecimal(el.Importo), Convert.ToSingle(el.Opzionale),el.Tipologia, el.Numero);
                    }).ToList());
                } else {
                    var old = fatt[o.Key];
                    DateTime? da = DateTime.Parse(o.Data);
                    string numero = o.Numero;
                    bool mod = false;
                    int anno = Convert.ToInt32(o.Anno);
                    if(mod = (da == old.Data)) {
                        da = old.Data;
                    } else {
                        mod = true;
                    }
                    if(numero == old.Numero) {
                        numero = old.Numero;
                    } else {
                        mod = true;
                    }
                    if(anno == old.Anno) {
                        anno = old.Anno;
                    } else {
                        mod = true;
                    }
                    
                    if(mod) {
                        Fattura.DatiFattura dat = new Fattura.DatiFattura(old.DatiFatturaInterni,
                            anno, 
                            numero, 
                            null, 
                            da, null
                        );
                        old.DatiFatturaInterni = dat;
                    }
                    old.Add(
                        o.GetVoci().Select((el) => {
                            return new VoceFattura(el.Descrizione, Convert.ToDecimal(el.Importo), Convert.ToSingle(el.Opzionale), el.Tipologia, el.Numero);
                        }).ToList().Where((f) => {
                            return !old.Voci.Any((ff) => {
                                return f.Equals(ff);
                            });
                        }).ToArray()
                    );
                }
            };
            result.OnNuovaClick += (o, e) => {
                o.Key = null;
                o.Enabled = false;
                Cliente c = null;
                if((c = GetClienteForm.Get(CollezioneClienti.GetInstance().ToList())) == null) {
                    o.CleanAll();
                } else {
                    CaricaCliente(result, c);
                    tmpCliente = c;
                }
                //TODO
                Vendita[] v = null;
                var persona = new PersonaFisica("AAAAAAAAAA", "Via del Cane 11", "Anna", "Bartolini");
                var cliente = new Cliente(persona, "1");
                var vendita = new Vendita(1, cliente);
                if((v = GetVenditaForm.Get((new Vendita[] { vendita }).ToList())) == null) {
                    o.CleanAll();
                    tmpCliente = null;
                } else {
                    vendite = new List<Vendita>();
                    vendite.AddRange(v);
                }
                o.Enabled = true;
            };
            return result;
        }
    }
}
