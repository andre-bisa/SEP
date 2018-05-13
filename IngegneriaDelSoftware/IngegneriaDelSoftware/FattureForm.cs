using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.Graphics {
    public partial class FattureForm: MaterialSkin.Controls.MaterialForm {
        //Enum per la creazione;
        public enum TipoPersona {
            FISICA, GIURIDICA
        };

       
        #region Campi privati

        private int _numeroInserimentoRigheVociFattura;
        private bool _provvigione;
        private MaterialSkin.Controls.MaterialLabel _provvigioneLabel;

        #endregion

        #region Costruttore

        /// <param name="provvigione">Se la FatturaForm contiene la provvigione o meno</param>
        public FattureForm(bool provvigione) {
            // Settato a 1 perchè 0 è l'intestazione;
            this._numeroInserimentoRigheVociFattura = 1;
            //Se la fattura deve essere dotata di provvigione;
            this._provvigione = provvigione;

            InitializeComponent();
            //Se la fattura è di tipo con provvigione;
            if(this._provvigione) {
                //Crea un nuova colonna;
                this.FattureValoriPanel.ColumnCount += 1;
                //Aggiungi uno stile per la colonna;
                this.FattureValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
                //Aggiungi una label per la colonna;
                _provvigioneLabel = new MaterialSkin.Controls.MaterialLabel();
                //Testo della label;
                _provvigioneLabel.Text = "Provvigione (%)";
                //Larghezza della label;
                _provvigioneLabel.Width = 120;
                //Aggiunge la label al panel;
                this.FattureValoriPanel.Controls.Add(_provvigioneLabel, 4, 0);
            }
            //Aggiunge ai due radioButton della persona fiscia/giuridica un handler;
            this.PersonaFisicaRadio.CheckedChanged += this.ChangedPersona;
            this.PersonaGiuridicaRadio.CheckedChanged += this.ChangedPersona;

            //Mock dei campi di prova;
            this.mock();
        }


        //Genera dei campi di prova;
        private void mock() {
            this.AggiungiFatturaBarraLaterale("1/2018");
            this.AggiungiFatturaBarraLaterale("2/2018");
            this.AggiungiFatturaBarraLaterale("3/2018");
            this.AggiungiFatturaBarraLaterale("4/2018");
            this.AggiungiFatturaBarraLaterale("5/2018");
        }

        #endregion

        #region Setters GUI

        #region Inserimento nuove voci fattura

        /// <summary>
        /// Crea una nuova MaterialDesign TextBox Per la valuta
        /// </summary>
        /// <param name="Input">Il valore dell'importo</param>
        /// <param name="Width">La larghezza del controllo</param>
        /// <param name="FormatStyle">Il tipo di formattazione che le nuove righe inserite devono assumere al LostFOcus event</param>
        /// <returns>Il nuovo controllo</returns>
        private MaterialSkin.Controls.MaterialSingleLineTextField CreateValueBox(string Input, int Width, string FormatStyle) {
            //Crea l'oggetto TextField;
            MaterialSkin.Controls.MaterialSingleLineTextField Result = new MaterialSkin.Controls.MaterialSingleLineTextField();
            //Setta il testo;
            Result.Text = Input;
            //Lo disegna con la grandezza scelta;
            Result.Size = new System.Drawing.Size(Width, 23);
            //Assegna al suo LostFocusEvent un handler;
            Result.LostFocus += (o, s) => {
                double value = 0;
                //Prova a parsare il valore o lancia eccezione;
                if(Double.TryParse(Result.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out value)) {
                    //Se possibile formatta il valore con il format economico corrente;
                    Result.Text = value.ToString(FormatStyle, System.Globalization.CultureInfo.CurrentCulture);
                }else {
                    throw new ArgumentException("The inserted value must be a number");
                }
            };
            //Restituisce il risultato
            return Result;
        }

        /// <summary>
        /// Crea una nuova MaterialDesign TextBox Per la descrizione
        /// </summary>
        /// <param name="Input">Il valore della descrizione</param>
        /// <param name="Width">La larghezza del controllo</param>
        /// <returns>Il nuovo controllo</returns>
        private MaterialSkin.Controls.MaterialSingleLineTextField CreateTextBox(string Input, int Width) {
            //Crea l'oggetto TextField;
            MaterialSkin.Controls.MaterialSingleLineTextField Result = new MaterialSkin.Controls.MaterialSingleLineTextField();
            //Setta il testo;
            Result.Text = Input;
            //Lo disegna con la grandezza scelta;
            Result.Size = new System.Drawing.Size(Width, 23);
            //Assegna al suo LostFocusEvent un handler;
            Result.LostFocus += (o, s) => {
                //Se la string della TextBox non è vuota;
                if(!String.IsNullOrEmpty(Result.Text)) {
                    //La nuova stringa della TextBox è il primo carattere di quella vecchia in uppercase più tutto il resto nel case precendente;
                    Result.Text = Result.Text.First().ToString().ToUpper() + Result.Text.Substring(1);
                }
            };
            //Restituisce il risultato;
            return Result;
        }

        /// <summary>
        /// Crea un nuovo bottone per la cancellazione della riga
        /// </summary>
        /// <param name="ControlliDaRimuovere">Lista coi controlli che saranno rimossi all'OnClick</param>
        /// <returns></returns>
        private MaterialSkin.Controls.MaterialFlatButton CreateDeleteButton(List<Control> ControlliDaRimuovere) {
            //Crea il nuovo bottone;
            MaterialSkin.Controls.MaterialFlatButton Result = new MaterialSkin.Controls.MaterialFlatButton();
            //Assegna il testo del bottone;
            Result.Text = "ELIMINA";
            //Lo aggiunge alla lista dei controlli da rimuovere;
            ControlliDaRimuovere.Add(Result);
            //Evento onClick del bottone;
            Result.Click += (o, s) => {
                //Il numero corrente della riga (si suppone che tutti i controlli siano sulla stessa riga);
                int row = this.FattureValoriPanel.GetRow(ControlliDaRimuovere[0]);
                //Rimuove i controlli;
                //1)Per ogni controllo lo rimuove dalla lista dei controlli nel panel e lo segna come da eliminare;
                ControlliDaRimuovere.ForEach((e) => {
                    //Elimina dal panel;
                    this.FattureValoriPanel.Controls.Remove(e);
                    //Rilascia le risorse;
                    e.Dispose();
                });
                //Rimuove l'ultima riga dalla tabella degli stili (siccome sono tutte uguali tranne la prima non importa quale sia);
                this.FattureValoriPanel.RowStyles.RemoveAt(this.FattureValoriPanel.RowStyles.Count - 1);
                //Riga corrente del controll;
                int controlRow = 0;
                //Per ogni controllo della tabella;
                foreach(Control c in this.FattureValoriPanel.Controls) {
                    //Se la riga corrente è maggiore di quella del controllo rimosso;
                    if((controlRow = this.FattureValoriPanel.GetRow(c)) > row) {
                        //Sposta in alto di uno il controllo corrente;
                        this.FattureValoriPanel.SetRow(c, controlRow - 1);
                    }
                }
                //Diminuisce il numero della riga corrente di inserimento;
                this._numeroInserimentoRigheVociFattura--;
                //Diminuisce il numero di righe della tabella;
                this.FattureValoriPanel.RowCount -= 1;
                //Ordina il refresh del panel;
                this.FattureValoriPanel.Refresh();
                
            };
            //Ritorna il bottone appena creato;
            return Result;
        }

        /// <summary>
        /// Aggiunge una riga ai campi della fattura
        /// </summary>
        /// <param name="Tipologia">La tipologia della voce, ovvero il tag di raggruppamento</param>
        /// <param name="Causale">La causale della voce</param>
        /// <param name="Importo">L'importo della voce</param>
        /// <param name="Provvigione">L'importo della provvigione espresso come double. e.g. 10% => 10F</param>
        private void AggiungiRigaCampiFattura(string Tipologia, string Causale, double Importo, double Provvigione) {

            //Aumenta il numero delle righe;
            this.FattureValoriPanel.RowCount += 1;
            //Crea il nuovo stile;
            this.FattureValoriPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            //Lista con i controlli che verranno cancellati dal bottone elimina riga;
            List<Control> Controlli = new List<Control>();
            //Inserisce i controlli appena creati nella tabella;
            //Tipologia;
            var Controllo = this.CreateTextBox(Tipologia, 100);
            Controlli.Add(Controllo);
            this.FattureValoriPanel.Controls.Add(Controllo, 1, this._numeroInserimentoRigheVociFattura);
            //Descrizione;
            Controllo = this.CreateTextBox(Causale, 500);
            Controlli.Add(Controllo);
            this.FattureValoriPanel.Controls.Add(Controllo, 2, this._numeroInserimentoRigheVociFattura);
            //Importo;
            Controllo = this.CreateValueBox(Importo.ToString("C", System.Globalization.CultureInfo.CurrentCulture), 300, "C");
            Controlli.Add(Controllo);
            this.FattureValoriPanel.Controls.Add(Controllo, 3, this._numeroInserimentoRigheVociFattura);
            //Se è di tipo provvigione;
            if(this._provvigione) {
                //Provvigione;
                Controllo = this.CreateValueBox(Provvigione.ToString("F2", System.Globalization.CultureInfo.CurrentCulture), 100, "F2");
                Controlli.Add(Controllo);
                this.FattureValoriPanel.Controls.Add(Controllo, 4, this._numeroInserimentoRigheVociFattura);
            }
            //Bottone di cancellazione;
            this.FattureValoriPanel.Controls.Add(this.CreateDeleteButton(Controlli), 0, this._numeroInserimentoRigheVociFattura);
            //Aumenta conseguente il numero della prossima riga d'inserimento;
            this._numeroInserimentoRigheVociFattura++;
        }
        #endregion

        #region Cancellazione voci fattura

        private void CancellaTutteLeVoci() {
            //Elimina tutti i componenenti;
            this.FattureValoriPanel.Controls.Clear();
            //Elimina tutti gli stili tranne i primi quattro (le intestazioni); 
            for(int i = 4; i < this.FattureValoriPanel.RowCount; i++) {
                try {
                    //Rimuove l'elemento;
                    this.FattureValoriPanel.RowStyles.RemoveAt(i);
                }catch(Exception) {
                    //Non ci interessa si cerca di rimuovere linee inesistenti perchè dovrebbero esserci;
                    continue;
                }
            }
            //Setta il nuovo numero di linee;
            this.FattureValoriPanel.RowCount = 1;
            //Reimposta le intestazioni;
            this.FattureValoriPanel.Controls.Add(this.materialLabel1, 2, 0);
            this.FattureValoriPanel.Controls.Add(this.materialLabel2, 3, 0);
            this.FattureValoriPanel.Controls.Add(this.materialLabel3, 1, 0);
            if(this._provvigione) {
                this.FattureValoriPanel.Controls.Add(this._provvigioneLabel, 4, 0);
            }
            //Reimposta la riga corrente;
            this._numeroInserimentoRigheVociFattura = 1;
        }

        #endregion

        #region Inserimento dati fattura
        //Prepara le label per la modalità persona fisica;
        private void SetPersonaFisica() {
            this.CognomeField.Enabled = true;
            this.CognomeLbl.Enabled = true;
            this.NomeLbl.Text = "Nome";
        }
        //Prepara le label per la modalità persona giuridica;
        private void SetPersonaGiuridica() {
            this.CognomeField.Enabled = false;
            this.CognomeLbl.Enabled = false;
            this.CognomeField.Text = "";
            this.NomeLbl.Text = "Denominazione";
        }

        /// <summary>
        /// Inserisce i valori del destinatario della fattura nell'apposito riquadro laterale
        /// </summary>
        /// <param name="Anno">L'anno a cui la fattura fa riferimento</param>
        /// <param name="Numero">Il numero della fattura</param>
        /// <param name="Nome">Il nome del destinatario della fattura</param>
        /// <param name="Cognome">Il congnome del destinatario della fattura</param>
        /// <param name="CF">Il codice fiscale del destinatario della fattura</param>
        /// <param name="PIVA">La pratita IVA del destinatario della fattura</param>
        /// <param name="Telefono">Il numero di telefono del destinatario della fattura</param>
        /// <param name="ConPartitaIva">Se la fattura deve essere calcolata con la partita IVA o meno</param>
        /// <param name="Data">La data a cui la fattura fa riferimento</param>
        /// <param name="Indirizzo">L'indirizzo del destinatario</param>
        /// <param name="tipo">Il tipo di persona a cui fa riferimento</param>
        private void InserisciDatiDestinatarioFattura(string Anno, string Numero, string Data, string Nome, string Cognome, string Indirizzo,
            string CF, string PIVA, string Telefono, bool ConPartitaIva, TipoPersona tipo) {
            this.AnnoField.Text = Anno;
            this.NumeroField.Text = Numero;
            this.NomeField.Text = Nome;
            this.IndirizzoField.Text = Indirizzo;
            this.CFField.Text = CF;
            this.PIVAField.Text = PIVA;
            this.TelefonoField.Text = Telefono;
            this.IVACheckBox.Checked = ConPartitaIva;
            this.DataField.Text = Data;
            switch(tipo) {
                case TipoPersona.FISICA:
                    this.PersonaFisicaRadio.Checked = true;
                    this.CognomeField.Text = Cognome;
                    this.SetPersonaFisica();
                    break;
                case TipoPersona.GIURIDICA:
                    this.PersonaGiuridicaRadio.Checked = true;
                    this.SetPersonaGiuridica();
                    break;
            }
        }

        #endregion

        #region Gestione barra laterale fatture

        private void AggiungiFatturaBarraLaterale(string identificativo) {
            this.FattureInserite.Items.Add(identificativo);
        }

        #endregion

        #region Setters della visibilità

        /// <summary>
        ///Svuota e nasconde il panel delle voci
        /// </summary>
        private void HideVoci() {
            this.CancellaTutteLeVoci();
            if(this.FattureValoriPanel.Visible) {
                this.FattureValoriPanel.Visible = false;
                this.AggiungiVoceBtn.Visible = false;
            }
        }

        /// <summary>
        ///Mostra il panel delle voci
        /// </summary>
        private void ShowVoci() {
            this.CancellaTutteLeVoci();
            if(!this.FattureValoriPanel.Visible) {
                this.FattureValoriPanel.Visible = true;
                this.AggiungiVoceBtn.Visible = true;
            }
        }

        /// <summary>
        /// Mostra il panel con le info sulla fattura
        /// </summary>
        private void ShowInfo() {
            if(!this.FatturaSingolaPanel.Visible) {
                this.FatturaSingolaPanel.Visible = true;
                this.AggiungiVociBtn.Visible = true;
                this.EliminaVociBtn.Visible = true;
            }
            this.InserisciDatiDestinatarioFattura("", "", "", "", "", "", "", "", "", false, TipoPersona.FISICA);
        }

        /// <summary>
        /// Svuota e nasconde il panel con le info
        /// </summary>
        private void HideInfo() {
            if(this.FatturaSingolaPanel.Visible) {
                this.FatturaSingolaPanel.Visible = false;
                this.AggiungiVociBtn.Visible = false;
                this.EliminaVociBtn.Visible = false;
            }
        }

        #endregion

        #endregion

        #region Getters GUI

        #region Getters delle nuove voci

        //Struct di comodo per creare una voce;
        public struct Voce {
            public string Tipologia;
            public string Descrizione;
            public double Importo;
            public double Provvigione;
            //Costruttore;
            public Voce(string Tipologia, string Descrizione, double Importo, double Provvigione) {
                this.Tipologia = Tipologia;
                this.Descrizione = Descrizione;
                this.Importo = Importo;
                this.Provvigione = Provvigione;
            }
        }

        /// <summary>
        /// Recupera i dati dall'elenco voci per trasmetterli al controller
        /// </summary>
        private List<Voce> GetVociFatture() {
            //Numero della colonna che si sta parsando;
            int column = 0;
            //Il controllo corrente;
            MaterialSkin.Controls.MaterialSingleLineTextField current = null;
            //Una voce di comodo generata;
            Voce voce = new Voce("", "", 0, 0);
            List<Voce> result = new List<Voce>();
            //Per ogni campo del panel;
            foreach (Control c in this.FattureValoriPanel.Controls) {
                //Se è una TextForm;
                if(c is MaterialSkin.Controls.MaterialSingleLineTextField) {
                    //Cast a TextForm;
                    current = c as MaterialSkin.Controls.MaterialSingleLineTextField;
                    switch(column) {
                        case 0: //Tipologia
                            voce = new Voce("", "", 0, 0);
                            voce.Tipologia = current.Text;
                            break;
                        case 1: //Descrizione
                            voce.Descrizione = current.Text;
                            break;
                        case 2: //Importo
                            voce.Importo = Double.Parse(current.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture);
                            //
                            if(!this._provvigione) {
                                result.Add(voce);
                            }
                            break;
                        case 3: //Provvigione
                            voce.Importo = Double.Parse(current.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture);
                            if(this._provvigione) {
                                result.Add(voce);
                            }
                            break;
                        default: //Default
                            break;
                    }
                    //Aumenta alla colonna successiva e se questa è maggiore del numero di colonne
                    //resetta a zero per ricominciare dalla colonna zero della riga successiva;
                    //N.B. il numero massimo è quello delle colonne con campi utili ie 3 se ci sono tre campi
                    //2 se i campi sono solo due senza contare bottoni e altre cose;
                    column = (column + 1) % (this._provvigione ? 4 : 3);

                }
            }
            //Ritorna la lista
            return result;
        }

        /// <summary>
        /// Recupera i dati dall'elenco voci per trasmetterli al controller
        /// </summary>
        /// <param name="Tipologia">La tipologia che si desidera</param>
        /// <returns></returns>
        private List<Voce> GetVociFatturaPerTipologia(string Tipologia) {
            //Ritorna tuttle le voci che fanno match con quelle della tipologia desiderata;
            return (from voce in this.GetVociFatture()
                    where voce.Tipologia.Equals(Tipologia)
                    select voce).ToList();
        }

        #endregion
        
        #endregion

        #region Handlers bottoni ed eventi

        //Inserimento nuova voce dal bottone;
        private void materialFlatButton1_Click(object sender, EventArgs e) {
            this.AggiungiRigaCampiFattura("", "", 0, 0);
        }

        //Crea la fattura;
        private void materialRaisedButton1_Click(object sender, EventArgs e) {
            List<Voce> result = this.GetVociFatture();
            // Deve seguire elaborazione;

            result.ForEach((el) => {
                System.Diagnostics.Debug.WriteLine(el.Tipologia);
                System.Diagnostics.Debug.WriteLine(el.Descrizione);
                System.Diagnostics.Debug.WriteLine(el.Importo);
                System.Diagnostics.Debug.WriteLine(el.Provvigione);
            });

            this.GetVociFatturaPerTipologia("VENDITA").ForEach((el) => {
                System.Diagnostics.Debug.WriteLine(el.Tipologia);
                System.Diagnostics.Debug.WriteLine(el.Descrizione);
                System.Diagnostics.Debug.WriteLine(el.Importo);
                System.Diagnostics.Debug.WriteLine(el.Provvigione);
            });
        }
        
        //Evento generato dal cambio di fattura da visualizzare;
        private void FattureInserite_SelectedIndexChanged(object sender, EventArgs e) {
            if(!this.FatturaSingolaPanel.Visible) {
                this.FatturaSingolaPanel.Visible = true;
                this.AggiungiVociBtn.Visible = true;
                this.EliminaVociBtn.Visible = true;
            }

            //TODO implement the actual method
            this.InserisciDatiDestinatarioFattura(
                "PLACEHOLDER", 
                "PLACEHOLDER",
                "PLACEHOLDER", 
                "PLACEHOLDER", 
                "PLACEHOLDER", 
                "PLACEHOLDER", 
                "PLACEHOLDER", 
                "PLACEHOLDER", 
                "PLACEHOLDER", 
                false, 
                TipoPersona.FISICA
            );
            this.ShowVoci();
            this.AggiungiRigaCampiFattura(
                "VENDITA",
                "2Mt di corda robusta",
                150,
                3
            );

            System.Diagnostics.Debug.WriteLine((sender as MaterialSkin.Controls.MaterialListView).SelectedItems[0]);
        }
        
        //Evento generato del cambio di tipo di persona;
        private void ChangedPersona(object sender, EventArgs e) {
            if(sender is MaterialSkin.Controls.MaterialRadioButton) {
                if(this.PersonaFisicaRadio.Checked) {
                    this.SetPersonaFisica();
                }else if(this.PersonaGiuridicaRadio.Checked){
                    this.SetPersonaGiuridica();
                }
            }
        }

        //Evento generato dal bottone per l'aggiunta del pannello delle voci;
        private void AggiungiVociBtn_Click(object sender, EventArgs e) {
            this.ShowVoci();
        }

        //Evento generato dal bottone per la creazione di una nuova fattura;
        private void NuovaFatturaBtn_Click(object sender, EventArgs e) {
            //Svuota la info form;
            this.ShowInfo();
            this.HideVoci();
        }

        //Evento generato dal bottone per svuotare le voci;
        private void EliminaVociBtn_Click(object sender, EventArgs e) {
            //TODO: farsi dare conferma;
            this.HideVoci();
        }
        #endregion


    }


}
