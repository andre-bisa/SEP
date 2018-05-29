using IngegneriaDelSoftware.Controller;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Model.ArgsEvent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.View {
    public static class GenericViewLoader {

        private static void CaricaCliente(GenericForm g, Cliente c, string anno, string numero, string data) {
            if(c.Persona.TipoPersona == EnumTipoPersona.Fisica) {
                var persona = c.Persona as PersonaFisica;

                g.InserisciDatiDestinatario(anno,
                    numero,
                    data,
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

                g.InserisciDatiDestinatario(anno,
                    numero,
                    data,
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

        public static GenericForm getPreventivoForm(ControllerPreventivi controller) {
            GenericForm result = GenericForm.CreaFormPreventivo();
            Cliente tmpCliente = null;
            CollezionePreventivi.GetInstance().ToList().ForEach((e) => {
                result.AggiungiBarraLaterale(e.ID);
            });
            EventHandler<ArgsPreventivo> l = async (o, ev) => {
                var t = Task.Run<CollezionePreventivi>(() => { return CollezionePreventivi.GetInstance(); });
                result.SvuotaBarraLaterale();
                CollezionePreventivi col = await t;
                lock(result) {
                    col.ToList().ForEach((e) => {
                        result.AggiungiBarraLaterale(e.ID);

                    });
                }
            };
            CollezionePreventivi.GetInstance().OnAggiunta += l;
            CollezionePreventivi.GetInstance().OnRimozione += l;
            CollezionePreventivi.GetInstance().OnModifica += async (o, ev) => {
                var t = Task.Run<CollezionePreventivi>(() => { return CollezionePreventivi.GetInstance(); });
                result.SvuotaBarraLaterale();
                CollezionePreventivi col = await t;
                col.ToList().ForEach((e) => {
                    result.AggiungiBarraLaterale(e.ID);

                });
            };

            result.OnPannelloLateraleClick += async (o, e) => {
                if(o.SelectedItems.Count == 1) {
                    CollezionePreventivi col = await Task.Run<CollezionePreventivi>(() => { return CollezionePreventivi.GetInstance(); });
                    //CollezionePreventivi col =  CollezionePreventivi.GetInstance();
                    var preventivo = (from preve in col
                                      where preve.ID == Convert.ToUInt64(o.SelectedItems[0].Text)
                                      select preve).FirstOrDefault();
                    if(preventivo == null) {
                        return;
                    }
                    var cliente = preventivo.Cliente;
                    CaricaCliente(result, cliente, null, preventivo.ID.ToString(), preventivo.Data.Date.ToShortDateString());
                    foreach(VocePreventivo voce in preventivo) {
                        result.AggiungiRigaCampi(voce.Tipologia, voce.Causale, Convert.ToDouble(voce.Importo), 0, voce.Quantita);
                    }
                    result.Key = preventivo.ID.ToString();
                }
            };
            result.OnAccettaClick += (o, e) => {
                if(o.Key != null) {
                    controller.AccettaPreventivo(Convert.ToUInt64(o.Key));
                }
            };
            result.OnRifiutaClick += (o, e) => {
                if(o.Key != null) {
                    controller.RifiutaPreventivo(Convert.ToUInt64(o.Key));
                    //TODO: generare la vendita da qui!
                }

            };
            result.OnCreaClick += async (o, e) => {
                var t = Task.Run<CollezionePreventivi>(() => { return CollezionePreventivi.GetInstance(); });
                if(string.IsNullOrEmpty(o.Key)) {
                    try {
                        controller.AggiungiPreventivo(
                            new Preventivo.DatiPreventivo(Convert.ToUInt64(o.Numero), tmpCliente, DateTime.Parse(o.Data), false),
                            o.GetVoci().Select((el) => {
                                return new VocePreventivo(el.Descrizione, Convert.ToDecimal(el.Importo), el.Tipologia, el.Numero);
                            }).ToList()
                        );
                    }catch(FormatException) {
                        FormConfim.Show("Errore di formato", String.Format("Un valore inserito non rispetta il formato corretto."), MessageBoxButtons.OK);
                    }
                } else {
                    CollezionePreventivi col = await t;
                    //CollezionePreventivi col = CollezionePreventivi.GetInstance();
                    var old = (from preve in col
                               where preve.ID == Convert.ToUInt64(o.Key)
                               select preve).FirstOrDefault();
                    if(old == null) {
                        return;
                    }
                    DateTime? da = null;
                    ulong id = 0;
                    try { 
                        da = DateTime.Parse(o.Data);
                        id = Convert.ToUInt64(o.Numero);
                    } catch(FormatException) {
                        FormConfim.Show("Errore di formato", String.Format("Un valore inserito non rispetta il formato corretto."), MessageBoxButtons.OK);
                    }
                    bool mod = false;
                    if(da == old.Data) {
                        da = null;
                    } else {
                        mod = true;
                    }
                    if(id == old.ID) {
                        id = old.ID;
                    } else {
                        mod = true;
                    }
                    Preventivo.DatiPreventivo? dat = null;
                    if(mod) {
                        dat = new Preventivo.DatiPreventivo(old.DatiPreventivoInterni, id, null, da, null);
                    }
                    List<VocePreventivo> voci = new List<VocePreventivo>();
                    voci.AddRange(
                        o.GetVoci().Select((el) => {
                            return new VocePreventivo(el.Descrizione, Convert.ToDecimal(el.Importo), el.Tipologia, el.Numero);
                        })
                    );
                    controller.UpdatePreventivo(Convert.ToUInt64(o.Key), dat, voci);
                    if(Convert.ToUInt64(o.Key) != id) {
                        o.Key = id.ToString();
                    }
                }
            };
            result.OnNuovaClick += async (o, e) => {
                var t = Task.Run<CollezioneClienti>(() => { return CollezioneClienti.GetInstance(); });
                o.Key = null;
                o.Enabled = false;
                Cliente c = null;
                CollezioneClienti col = await t;
                //CollezioneClienti col = CollezioneClienti.GetInstance();
                if((c = GetForm<Cliente>.Get(col.ToList())) == null) {
                    o.CleanAll();
                } else {
                    CaricaCliente(result, c, null, null, null);
                    tmpCliente = c;
                }
                o.Enabled = true;
            };
            result.OnCalcolaClick += async (o, e) => {
                if(o.Key != null) {
                    Preventivo current = (from fa in CollezionePreventivi.GetInstance()
                                       where fa.ID == Convert.ToUInt64(o.Key)
                                       select fa).FirstOrDefault();
                    if(current != null) {
                        var t = Task.Run<string>(() => {
                            return current.Totale().ToString("C");
                        });
                        result.CleanPrettyVoce();
                        current.ToList().ForEach((v) => {
                            result.AggiungiPrettyVoce(v.ToString());
                        });
                        string res = await t;
                        result.AggiungiResult(res);
                    }
                }
            };
            return result;
        }
        public static GenericForm getVenditaForm(ControllerVendite controller) {
            GenericForm result = GenericForm.CreaFormVendita();
            Cliente tmpCliente = null;
            CollezioneVendite.GetInstance().ToList().ForEach((e) => {
                result.AggiungiBarraLaterale(e.ID);
            });
            EventHandler<ArgsVendita> l = async (o, ev) => {
                var t = Task.Run<CollezioneVendite>(() => { return CollezioneVendite.GetInstance(); });
                result.SvuotaBarraLaterale();
                CollezioneVendite col = await t;
                col.ToList().ForEach((e) => {
                    result.AggiungiBarraLaterale(e.ID);
                });
            };
            CollezioneVendite.GetInstance().OnAggiunta += l;
            CollezioneVendite.GetInstance().OnRimozione += l;
            CollezioneVendite.GetInstance().OnModifica += async (o, ev) => {
                var t = Task.Run<CollezioneVendite>(() => { return CollezioneVendite.GetInstance(); });
                result.SvuotaBarraLaterale();
                CollezioneVendite col = await t;
                lock(result) {
                    //CollezioneVendite col = CollezioneVendite.GetInstance();
                    col.ToList().ForEach((e) => {
                        result.AggiungiBarraLaterale(e.ID);
                    });
                }
            }; ;
            result.OnPannelloLateraleClick += async (o, e) => {
                if(o.SelectedItems.Count == 1) {
                    CollezioneVendite col = await Task.Run<CollezioneVendite>(() => { return CollezioneVendite.GetInstance(); });
                    //CollezioneVendite col =  CollezioneVendite.GetInstance();
                    var vendita = (from vendi in col
                                   where vendi.ID == Convert.ToUInt64(o.SelectedItems[0].Text)
                                   select vendi).FirstOrDefault();
                    if(vendita == null) {
                        return;
                    }
                    var cliente = vendita.Cliente;
                    CaricaCliente(result, cliente, null, vendita.ID.ToString(), vendita.Data.Date.ToShortDateString());
                    foreach(VoceVendita voce in vendita) {
                        result.AggiungiRigaCampi(voce.Tipologia, voce.Causale, Convert.ToDouble(voce.Importo), voce.Provvigione, voce.Quantita);
                    }
                    result.Key = vendita.ID.ToString();
                }
            };
            result.OnCreaClick += async (o, e) => {
                var t = Task.Run<CollezioneVendite>(() => { return CollezioneVendite.GetInstance(); });
                if(string.IsNullOrEmpty(o.Key)) {
                    try {
                        controller.AggiungiVendita(
                            new Vendita.DatiVendita(Convert.ToUInt64(o.Numero), tmpCliente, DateTime.Parse(o.Data), null),
                            o.GetVoci().Select((el) => {
                                return new VoceVendita(el.Descrizione, Convert.ToDecimal(el.Importo), Convert.ToSingle(el.Opzionale), el.Tipologia, el.Numero);
                            }).ToList()
                        );
                    } catch(FormatException) {
                        FormConfim.Show("Errore di formato", String.Format("Un valore inserito non rispetta il formato corretto."), MessageBoxButtons.OK);
                    }
                } else {
                    CollezioneVendite col = await t;
                    //CollezioneVendite col =  CollezioneVendite.GetInstance();
                    var old = (from vendi in col
                               where vendi.ID == Convert.ToUInt64(o.Key)
                               select vendi).FirstOrDefault();
                    if(old == null) {
                        return;
                    }
                    DateTime? da = null;
                    ulong id = 0;
                    try {
                        da = DateTime.Parse(o.Data);
                        id = Convert.ToUInt64(o.Numero);
                    } catch(FormatException) {
                        FormConfim.Show("Errore di formato", String.Format("Un valore inserito non rispetta il formato corretto."), MessageBoxButtons.OK);
                    }
                    bool mod = false;
                    if(mod = (da == old.Data)) {
                        da = null;
                    } else {
                        mod = true;
                    }
                    if(id == old.ID) {
                        id = old.ID;
                    } else {
                        mod = true;
                    }
                    Vendita.DatiVendita? dat = null;
                    if(mod) {
                        dat = new Vendita.DatiVendita(old.DatiVenditaInterni, id, tmpCliente, da, null);
                    }
                    List<VoceVendita> voci = new List<VoceVendita>();
                    voci.AddRange(
                        o.GetVoci().Select((el) => {
                            return new VoceVendita(el.Descrizione, Convert.ToDecimal(el.Importo), Convert.ToSingle(el.Opzionale), el.Tipologia, el.Numero);
                        })
                    );
                    controller.UpdateVendita(Convert.ToUInt64(o.Key), dat, voci);
                    if(Convert.ToUInt64(o.Key) != id) {
                        o.Key = id.ToString();
                    }
                }
            };
            result.OnNuovaClick += async (o, e) => {
                var t = Task.Run<CollezioneClienti>(() => { return CollezioneClienti.GetInstance(); });
                var t2 = Task.Run<CollezionePreventivi>(() => { return CollezionePreventivi.GetInstance(); });
                o.Key = null;
                o.Enabled = false;
                Cliente c = null;
                Preventivo prop = null;
                CollezioneClienti col = await t;
                CollezionePreventivi colp = await t2;
                //CollezioneClienti col = CollezioneClienti.GetInstance();
                if((c = GetForm<Cliente>.Get(col.ToList())) == null) {
                    o.CleanAll();
                } else {
                    if((prop = GetForm<Preventivo>.Get((from p in colp.ToList()
                                                      where p.Cliente.Equals(c)
                                                      select p).ToList())) != null) {
                        var vendita = Vendita.FromPreventivo(0, prop, null);
                        CaricaCliente(result, vendita.Cliente, "", null, vendita.Data.Date.ToShortDateString());
                        foreach(VoceVendita voce in vendita) {
                            result.AggiungiRigaCampi(voce.Tipologia, voce.Causale, Convert.ToDouble(voce.Importo), 0, voce.Quantita);
                        }
                        tmpCliente = vendita.Cliente;
                    } else {
                        CaricaCliente(result, c, null, null, null);
                        tmpCliente = c;
                    }
                }
                o.Enabled = true;
            };
            result.OnCalcolaClick += async (o, e) => {
                if(o.Key != null) {
                    Vendita current = (from fa in CollezioneVendite.GetInstance()
                                       where fa.ID == Convert.ToUInt64(o.Key)
                                       select fa).FirstOrDefault();
                    if(current != null) {
                        var t = Task.Run<string>(() => {
                            return current.Totale().ToString("C");
                        });
                        result.CleanPrettyVoce();
                        current.ToList().ForEach((v) => {
                            result.AggiungiPrettyVoce(v.ToString());
                        });
                        string res = await t;
                        result.AggiungiResult(res);
                    }
                }
            };
            return result;
        }
        public static GenericForm getFatturaForm(ControllerFatture controller) {
            Cliente tmpCliente = null;
            List<Vendita> vendite = null;
            GenericForm result = GenericForm.CreaFormFattura();
            CollezioneFatture.GetInstance().ToList().ForEach((e) => {
                result.SvuotaBarraLaterale();
                result.AggiungiBarraLaterale(e.ID);
            });
            EventHandler<ArgsFattura> l = async (o, ev) => {
                var t = Task.Run<CollezioneFatture>(() => { return CollezioneFatture.GetInstance(); });
                result.SvuotaBarraLaterale();
                CollezioneFatture col = await t;
                col.ToList().ForEach((e) => {
                    result.AggiungiBarraLaterale(e.ID);
                });
            };
            CollezioneFatture.GetInstance().OnAggiunta += l;
            CollezioneFatture.GetInstance().OnRimozione += l;
            CollezioneFatture.GetInstance().OnModifica += async (o, ev) => {
                var t = Task.Run<CollezioneFatture>(() => { return CollezioneFatture.GetInstance(); });
                result.SvuotaBarraLaterale();
                CollezioneFatture col = await t;
                lock(result) {
                    col.ToList().ForEach((e) => {
                        result.AggiungiBarraLaterale(e.ID);
                    });
                }
            };
            result.OnPannelloLateraleClick += async (o, e) => {
                if(o.SelectedItems.Count == 1) {
                    //CollezioneFatture col =  CollezioneFatture.GetInstance();
                    CollezioneFatture col = await Task.Run<CollezioneFatture>(() => { return CollezioneFatture.GetInstance(); });
                    var fattura = (from fa in col
                                   where fa.ID == o.SelectedItems[0].Text
                                   select fa).FirstOrDefault();
                    if(fattura == null) {
                        return;
                    }
                    var cliente = fattura.Cliente;
                    CaricaCliente(result, cliente, fattura.Anno.ToString(), fattura.Numero, fattura.Data.Date.ToShortDateString());
                    foreach(VoceFattura voce in fattura) {
                        result.AggiungiRigaCampi(voce.Tipologia, voce.Causale, Convert.ToDouble(voce.Importo), voce.Iva * 100, voce.Quantita);
                    }
                    result.Key = fattura.ID;
                }
            };
            result.OnCreaClick += async (o, e) => {
                var t = Task.Run<CollezioneFatture>(() => { return CollezioneFatture.GetInstance(); });
                if(String.IsNullOrEmpty(o.Key)) {
                    try {
                        controller.AggiungiFattura(new Fattura.DatiFattura(Convert.ToInt32(o.Anno), o.Numero, tmpCliente, DateTime.Parse(o.Data), 0), vendite, o.GetVoci().Select((el) => {
                            return new VoceFattura(el.Descrizione, Convert.ToDecimal(el.Importo), Convert.ToSingle(el.Opzionale / 100), el.Tipologia, el.Numero);
                        }).ToList());
                    } catch(FormatException) {
                        FormConfim.Show("Errore di formato", String.Format("Un valore inserito non rispetta il formato corretto."), MessageBoxButtons.OK);
                    }
                } else {
                    CollezioneFatture col = await t;
                    //CollezioneFatture col = CollezioneFatture.GetInstance();
                    var old = (from fa in col
                               where fa.ID == o.Key
                               select fa).FirstOrDefault();
                    if(old == null) {
                        return;
                    }
                    DateTime? da = null;
                    string numero = null;
                    try {
                        da = DateTime.Parse(o.Data);
                        numero = o.Numero;
                    } catch(FormatException) {
                        FormConfim.Show("Errore di formato", String.Format("Un valore inserito non rispetta il formato corretto."), MessageBoxButtons.OK);
                    }
                    bool mod = false;
                    int anno = Convert.ToInt32(o.Anno);
                    if(da == old.Data) {
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
                    Fattura.DatiFattura? dat = null;
                    if(mod) {
                        dat = new Fattura.DatiFattura(old.DatiFatturaInterni,
                            anno,
                            numero,
                            null,
                            da, null
                        );
                    }
                    List<VoceFattura> voci = new List<VoceFattura>();
                    voci.AddRange(
                        o.GetVoci().Select((el) => {
                            return new VoceFattura(el.Descrizione, Convert.ToDecimal(el.Importo), Convert.ToSingle(el.Opzionale / 100), el.Tipologia, el.Numero);
                        })
                    );
                    controller.UpdateFattura(o.Key, dat, voci);
                    if(dat != null && dat.Value.ID.Equals(o.Key)) {
                        o.Key = dat.Value.ID;
                    }
                }
            };
            result.OnNuovaClick += async (o, e) => {
                var t = Task.Run<CollezioneVendite>(() => { return CollezioneVendite.GetInstance(); });
                o.Key = null;
                o.Enabled = false;
                Vendita[] v = null;
                CollezioneVendite col = await t;
                //CollezioneVendite col =  CollezioneVendite.GetInstance();
                if((v = GetForm<Vendita>.Gets(col.ToList())) == null || v.Length == 0) {
                    o.CleanAll();
                    tmpCliente = null;
                } else {
                    vendite = new List<Vendita>();
                    vendite.AddRange(v);
                    var fattura = Fattura.FromVendite(DateTime.Now.Year, "", vendite);
                    tmpCliente = fattura.Cliente;
                    CaricaCliente(result, tmpCliente, null, null, null);
                    foreach(VoceFattura voce in fattura) {
                        result.AggiungiRigaCampi(voce.Tipologia, voce.Causale, Convert.ToDouble(voce.Importo), 0, voce.Quantita);
                    }
                }
                o.Enabled = true;
            };
            result.OnCalcolaClick += async (o, e) => {
                if(o.Key != null) {
                    Fattura current = (from fa in CollezioneFatture.GetInstance()
                     where fa.ID == o.Key
                     select fa).FirstOrDefault();
                    if(current != null) {
                        var t = Task.Run<string>(() => {
                            return current.Calcola();
                        });
                        result.CleanPrettyVoce();
                        current.ToList().ForEach((v) => {
                            result.AggiungiPrettyVoce(v.ToString());
                        });
                        string res = await t;
                        result.AggiungiResult(res);
                    }
                }
            };
            return result;
        }
    }
}
