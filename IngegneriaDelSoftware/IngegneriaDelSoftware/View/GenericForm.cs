using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngegneriaDelSoftware.View {

    /// <summary>
    /// Rappresenta una form generica per visualizzare il caso di FattureForm, VenditeForm e PreventiviForm.
    /// <para/>
    /// Utilizza <see cref="TipoForm"/> per distinguere i tipi.
    /// La classe contiene anche alcuni metodi statici per la generazione rapida senza costruttore: <see cref="CreaFormFattura"/>
    ///  <see cref="CreaFormVendita(bool)"/> e <see cref="CreaFormPreventivo"/>
    /// </summary>
    public partial class GenericForm: MaterialSkin.Controls.MaterialForm {
        //Enum per la creazione DA SOSTITUIRE;
        public enum TipoPersona {
            FISICA, GIURIDICA
        };

        #region Delegati ed eventi
        //delegati per gli eventi;
        /// <param name="o"></param>
        /// <param name="e"></param>
        public delegate void PannelloLateraleClick(object o, EventArgs e);
        /// <summary>
        /// Rappresenta il click sul pannello delle collezioni a sinistra.<para/>
        /// Significa il cambio dell'oggetto col focus
        /// </summary>
        public event PannelloLateraleClick OnPannelloLateraleClick;

        /// <param name="l">Lista delle voci presenti nel pannello</param>
        /// <param name="e"></param>
        public delegate void CreaClick(List<Voce> l, EventArgs e);
        /// <summary>
        /// Rappresenta il click sul bottone di conferma/creazione
        /// </summary>
        public event CreaClick OnCreaClick;

        /// <param name="o">La form corrente</param>
        /// <param name="e"></param>
        public delegate void RifiutaClick(object o, EventArgs e);
        /// <summary>
        /// Rappresenta il click sul bottone di rifiuto
        /// </summary>
        public event RifiutaClick OnRifiutaClick;

        /// <param name="o">La form corrente</param>
        /// <param name="e"></param>
        public delegate void AccettaClick(object o, EventArgs e);
        /// <summary>
        /// Rappresenta il click sul bottone di accettazione
        /// </summary>
        public event AccettaClick OnAccettaClick;

        /// <param name="o">La form corrente</param>
        /// <param name="e"></param>
        public delegate void NuovaClick(object o, EventArgs e);
        /// <summary>
        /// Rappresenta il click sul bottone di creazione di una nuova
        /// </summary>
        public event NuovaClick OnNuovaClick;

        /// <param name="s">Il valore della string nella casella di testo della ricerca/param>
        /// <param name="e"></param>
        public delegate void CercaClick(string s, EventArgs e);
        /// <summary>
        /// Rappresenta il click sul bottone di creazione di una nuova
        /// </summary>
        public event CercaClick OnCercaClick;

        #endregion

        #region Campi privati

        private int _numeroInserimentoRigheVoci;
        private bool _provvigione;
        private MaterialSkin.Controls.MaterialLabel _provvigioneLabel;
        private MaterialSkin.Controls.MaterialLabel _quantitaLabel;
        private System.Windows.Forms.TableLayoutPanel ValoriPanel;
        private TipoForm tipo;
        private TipoPersona tipoPersona;

        #endregion

        #region Costruttore

        /// <param name="tipo">Il tipo della Form</param>
        /// <param name="provvigione">Se la FatturaForm contiene la provvigione o meno, false di default</param>
        ///  <see cref="TipoForm"/>
        ///  <exception cref="ArgumentException"></exception>
        public GenericForm(TipoForm tipo, bool provvigione = false) {
            if(tipo != TipoForm.VENDITE && provvigione) {
                throw new ArgumentException("Sono una form di tipo VENDITE può avere il campo provvigione settato a true");
            }
            // Settato a 1 perchè 0 è l'intestazione;
            this._numeroInserimentoRigheVoci = 1;
            //Se la  deve essere dotata di provvigione;
            this._provvigione = provvigione && tipo == TipoForm.VENDITE;
            this.tipo = tipo;
            InitializeComponent();

            //Label della quantità;
            _quantitaLabel = new MaterialSkin.Controls.MaterialLabel();
            //Testo della label;
            _quantitaLabel.Text = GenericForm.LABELTEXT[tipo].quantitaLabel;
            //Larghezza della label;
            _quantitaLabel.Width = 50;

            //Crea il pannello delle voci;
            this.ValoriPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ValoriPanel.AutoScroll = true;
            this.ValoriPanel.ColumnCount = 5;
            //Stili delle colonne;
            this.ValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.ValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            //Aggiunge le label;
            this.ValoriPanel.Controls.Add(this.CausaleLabel, 2, 0);
            this.ValoriPanel.Controls.Add(this.ImportoLabel, 3, 0);
            this.ValoriPanel.Controls.Add(this._quantitaLabel, 4, 0);
            this.ValoriPanel.Controls.Add(this.TipologiaLabel, 1, 0);
            this.ValoriPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValoriPanel.Location = new System.Drawing.Point(373, 102);
            this.ValoriPanel.Name = "ValoriPanel";
            this.ValoriPanel.RowCount = 1;
            this.ValoriPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ValoriPanel.TabIndex = 0;
            this.ValoriPanel.Visible = false;
            //Aggiunge il controllo;
            this.GrigliaSfondoPanel.Controls.Add(this.ValoriPanel, 2, 1);


            //Inizializza le label;
            this.ImportoLabel.Text = GenericForm.LABELTEXT[tipo].importoLabel;
            this.CausaleLabel.Text = GenericForm.LABELTEXT[tipo].causaleLabel;
            this.TipologiaLabel.Text = GenericForm.LABELTEXT[tipo].tipologiaLabel;
            this.columnHeader.Text = GenericForm.LABELTEXT[tipo].columnHeader;
            this.Text = GenericForm.LABELTEXT[tipo].titolo;

            //Se è di tipo con provvigione;
            if(this._provvigione) {
                //Crea un nuova colonna;
                this.ValoriPanel.ColumnCount += 1;
                //Aggiungi uno stile per la colonna;
                this.ValoriPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
                //Aggiungi una label per la colonna;
                _provvigioneLabel = new MaterialSkin.Controls.MaterialLabel();
                //Testo della label;
                _provvigioneLabel.Text = GenericForm.LABELTEXT[tipo].provvigioneLabel;
                //Larghezza della label;
                _provvigioneLabel.Width = 120;
                //Aggiunge la label al panel;
                this.ValoriPanel.Controls.Add(this._provvigioneLabel, 5, 0);
            }
            //Aggiunge ai due radioButton della persona fiscia/giuridica un handler;
            this.PersonaFisicaRadio.CheckedChanged += this.ChangedPersona;
            this.PersonaGiuridicaRadio.CheckedChanged += this.ChangedPersona;

            this.SearchLabel.KeyDown += this.CercaText_Enter;

            //I bottoni di accettazione ci vogliono solo se si tratta di un preventivo
            this.RifiutaBtn.Visible = this.AccettaBtn.Visible = this.tipo == TipoForm.PREVENTIVI;

            //Mock dei campi di prova;
            this.mock();
        }


        //Genera dei campi di prova;
        private void mock() {
            this.AggiungiBarraLaterale("1/2018");
            this.AggiungiBarraLaterale("2/2018");
            this.AggiungiBarraLaterale("3/2018");
            this.AggiungiBarraLaterale("4/2018");
            this.AggiungiBarraLaterale("5/2018");
        }

        #endregion

        #region Setters GUI

        #region Inserimento nuove voci 

        /// <summary>
        /// Crea una nuova MaterialDesign TextBox Per la valuta
        /// </summary>
        /// <param name="Input">Il valore dell'importo</param>
        /// <param name="Width">La larghezza del controllo</param>
        /// <param name="FormatStyle">Il tipo di formattazione che le nuove righe inserite devono assumere al LostFOcus event</param>
        /// <returns>Il nuovo controllo</returns>
        /// <exception cref="ArgumentException"/>
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
                int row = this.ValoriPanel.GetRow(ControlliDaRimuovere[0]);
                //Rimuove i controlli;
                //1)Per ogni controllo lo rimuove dalla lista dei controlli nel panel e lo segna come da eliminare;
                ControlliDaRimuovere.ForEach((e) => {
                    //Elimina dal panel;
                    this.ValoriPanel.Controls.Remove(e);
                    //Rilascia le risorse;
                    e.Dispose();
                });
                //Rimuove l'ultima riga dalla tabella degli stili (siccome sono tutte uguali tranne la prima non importa quale sia);
                this.ValoriPanel.RowStyles.RemoveAt(this.ValoriPanel.RowStyles.Count - 1);
                //Riga corrente del controll;
                int controlRow = 0;
                //Per ogni controllo della tabella;
                foreach(Control c in this.ValoriPanel.Controls) {
                    //Se la riga corrente è maggiore di quella del controllo rimosso;
                    if((controlRow = this.ValoriPanel.GetRow(c)) > row) {
                        //Sposta in alto di uno il controllo corrente;
                        this.ValoriPanel.SetRow(c, controlRow - 1);
                    }
                }
                //Diminuisce il numero della riga corrente di inserimento;
                this._numeroInserimentoRigheVoci--;
                //Diminuisce il numero di righe della tabella;
                this.ValoriPanel.RowCount -= 1;
                //Ordina il refresh del panel;
                this.ValoriPanel.Refresh();
                
            };
            //Ritorna il bottone appena creato;
            return Result;
        }

        /// <summary>
        /// Aggiunge una riga ai campi della 
        /// </summary>
        /// <param name="Tipologia">La tipologia della voce, ovvero il tag di raggruppamento</param>
        /// <param name="Causale">La causale della voce</param>
        /// <param name="Importo">L'importo della voce</param>
        /// <param name="Provvigione">L'importo della provvigione espresso come double. e.g. 10% => 10F</param>
        public void AggiungiRigaCampi(string Tipologia, string Causale, double Importo, double Provvigione, int Quantita) {

            //Aumenta il numero delle righe;
            this.ValoriPanel.RowCount += 1;
            //Crea il nuovo stile;
            this.ValoriPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            //Lista con i controlli che verranno cancellati dal bottone elimina riga;
            List<Control> Controlli = new List<Control>();
            //Inserisce i controlli appena creati nella tabella;
            //Tipologia;
            var Controllo = this.CreateTextBox(Tipologia, 100);
            Controlli.Add(Controllo);
            this.ValoriPanel.Controls.Add(Controllo, 1, this._numeroInserimentoRigheVoci);
            //Descrizione;
            Controllo = this.CreateTextBox(Causale, 500);
            Controlli.Add(Controllo);
            this.ValoriPanel.Controls.Add(Controllo, 2, this._numeroInserimentoRigheVoci);
            //Importo;
            Controllo = this.CreateValueBox(Importo.ToString("C", System.Globalization.CultureInfo.CurrentCulture), 100, "C");
            Controlli.Add(Controllo);
            this.ValoriPanel.Controls.Add(Controllo, 3, this._numeroInserimentoRigheVoci);
            //Numero;
            Controllo = this.CreateValueBox(Quantita.ToString("D", System.Globalization.CultureInfo.CurrentCulture), 50, "D");
            this.ValoriPanel.Controls.Add(Controllo, 4, this._numeroInserimentoRigheVoci);
            Controlli.Add(Controllo);
            //Se è di tipo provvigione;
            if(this._provvigione) {
                //Provvigione;
                Controllo = this.CreateValueBox(Provvigione.ToString("F2", System.Globalization.CultureInfo.CurrentCulture), 100, "F2");
                Controlli.Add(Controllo);
                this.ValoriPanel.Controls.Add(Controllo, 5, this._numeroInserimentoRigheVoci);
            }
            //Bottone di cancellazione;
            this.ValoriPanel.Controls.Add(this.CreateDeleteButton(Controlli), 0, this._numeroInserimentoRigheVoci);
            //Aumenta conseguente il numero della prossima riga d'inserimento;
            this._numeroInserimentoRigheVoci++;
        }
        #endregion

        #region Cancellazione voci 

        private void CancellaTutteLeVoci() {
            //Elimina tutti i componenenti;
            this.ValoriPanel.Controls.Clear();
            //Elimina tutti gli stili tranne i primi sei (le intestazioni); 
            for(int i = 6; i < this.ValoriPanel.RowCount; i++) {
                try {
                    //Rimuove l'elemento;
                    this.ValoriPanel.RowStyles.RemoveAt(i);
                }catch(Exception) {
                    //Non ci interessa si cerca di rimuovere linee inesistenti perchè dovrebbero esserci;
                    continue;
                }
            }
            //Setta il nuovo numero di linee;
            this.ValoriPanel.RowCount = 1;
            //Reimposta le intestazioni;
            this.ValoriPanel.Controls.Add(this.CausaleLabel, 2, 0);
            this.ValoriPanel.Controls.Add(this.ImportoLabel, 3, 0);
            this.ValoriPanel.Controls.Add(this.TipologiaLabel, 1, 0);
            this.ValoriPanel.Controls.Add(this._quantitaLabel, 4, 0);
            if(this._provvigione) {
                this.ValoriPanel.Controls.Add(this._provvigioneLabel, 5, 0);
            }
            //Reimposta la riga corrente;
            this._numeroInserimentoRigheVoci = 1;
        }

        #endregion

        #region Inserimento dati 
        //Prepara le label per la modalità persona fisica;
        private void SetPersonaFisica() {
            this.CognomeField.Enabled = true && this.InfoPanelEditable;
            this.CognomeLbl.Enabled = true;
            this.NomeLbl.Text = "Nome";
            this.tipoPersona = TipoPersona.FISICA;
        }
        //Prepara le label per la modalità persona giuridica;
        private void SetPersonaGiuridica() {
            this.CognomeField.Enabled = false;
            this.CognomeLbl.Enabled = false;
            this.CognomeField.Text = "";
            this.NomeLbl.Text = "Denominazione";
            this.tipoPersona = TipoPersona.GIURIDICA;
        }

        /// <summary>
        /// Inserisce i valori del destinatario della  nell'apposito riquadro laterale
        /// </summary>
        /// <param name="Anno">L'anno a cui la  fa riferimento</param>
        /// <param name="Numero">Il numero della </param>
        /// <param name="Nome">Il nome del destinatario della </param>
        /// <param name="Cognome">Il congnome del destinatario della </param>
        /// <param name="CF">Il codice fiscale del destinatario della </param>
        /// <param name="PIVA">La pratita IVA del destinatario della </param>
        /// <param name="Telefono">Il numero di telefono del destinatario della </param>
        /// <param name="ConPartitaIva">Se la  deve essere calcolata con la partita IVA o meno</param>
        /// <param name="Data">La data a cui la  fa riferimento</param>
        /// <param name="Indirizzo">L'indirizzo del destinatario</param>
        /// <param name="tipo">Il tipo di persona a cui fa riferimento</param>
        public void InserisciDatiDestinatario(string Anno, string Numero, string Data, string Nome, string Cognome, string Indirizzo,
            string CF, string PIVA, string Telefono, bool ConPartitaIva, TipoPersona tipo) {
            this.AnnoField.Text = Anno ?? "N/D";
            this.NumeroField.Text = Numero ?? "N/D";
            this.NomeField.Text = Nome ?? "N/D";
            this.IndirizzoField.Text = Indirizzo ?? "N/D";
            this.CFField.Text = CF ?? "N/D";
            this.PIVAField.Text = PIVA ?? "N/D";
            this.TelefonoField.Text = Telefono ?? "N/D";
            this.IVACheckBox.Checked = ConPartitaIva;
            this.DataField.Text = Data ?? "N/D";
            this.tipoPersona = tipo;
            switch(tipo) {
                case TipoPersona.FISICA:
                    this.PersonaFisicaRadio.Checked = true;
                    this.CognomeField.Text = Cognome ?? "N/D";
                    this.SetPersonaFisica();
                    break;
                case TipoPersona.GIURIDICA:
                    this.PersonaGiuridicaRadio.Checked = true;
                    this.SetPersonaGiuridica();
                    break;
            }
        }

        #endregion

        #region Gestione barra laterale 

        public void AggiungiBarraLaterale(string identificativo) {
            this.Inserite.Items.Add(identificativo);
        }

        #endregion

        #region Setters della visibilità

        /// <summary>
        ///Svuota e nasconde il panel delle voci
        /// </summary>
        private void HideVoci() {
            this.CancellaTutteLeVoci();
            if(this.ValoriPanel.Visible) {
                this.ValoriPanel.Visible = false;
                this.AggiungiVoceBtn.Visible = false;
            }
        }

        /// <summary>
        ///Mostra il panel delle voci
        /// </summary>
        private void ShowVoci() {
            this.CancellaTutteLeVoci();
            if(!this.ValoriPanel.Visible) {
                this.ValoriPanel.Visible = true;
                this.AggiungiVoceBtn.Visible = true;
            }
        }

        /// <summary>
        /// Mostra il panel con le info sulla 
        /// </summary>
        private void ShowInfo() {
            if(!this.SingolaPanel.Visible) {
                this.SingolaPanel.Visible = true;
                this.AggiungiVociBtn.Visible = true;
                this.EliminaVociBtn.Visible = true;
            }
            this.InserisciDatiDestinatario("", "", "", "", "", "", "", "", "", false, TipoPersona.FISICA);
        }

        /// <summary>
        /// Svuota e nasconde il panel con le info
        /// </summary>
        private void HideInfo() {
            if(this.SingolaPanel.Visible) {
                this.SingolaPanel.Visible = false;
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
            public int Numero;

            //Costruttore;
            public Voce(string Tipologia, string Descrizione, double Importo, double Provvigione, int Numero) {
                this.Tipologia = Tipologia;
                this.Descrizione = Descrizione;
                this.Importo = Importo;
                this.Provvigione = Provvigione;
                this.Numero = Numero;
            }
        }

        /// <summary>
        /// Recupera i dati dall'elenco voci per trasmetterli al controller
        /// </summary>
        private List<Voce> GetVoci() {
            //Numero della colonna che si sta parsando;
            int column = 0;
            //Il controllo corrente;
            MaterialSkin.Controls.MaterialSingleLineTextField current = null;
            //Una voce di comodo generata;
            Voce voce = new Voce("", "", 0, 0, 0);
            List<Voce> result = new List<Voce>();
            //Per ogni campo del panel;
            foreach (Control c in this.ValoriPanel.Controls) {
                //Se è una TextForm;
                if(c is MaterialSkin.Controls.MaterialSingleLineTextField) {
                    //Cast a TextForm;
                    current = c as MaterialSkin.Controls.MaterialSingleLineTextField;
                    switch(column) {
                        case 0: //Tipologia
                            voce = new Voce("", "", 0, 0, 0);
                            voce.Tipologia = current.Text;
                            break;
                        case 1: //Descrizione
                            voce.Descrizione = current.Text;
                            break;
                        case 2: //Importo
                            voce.Importo = Double.Parse(current.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture);
                            break;
                        case 3: //Numero
                            voce.Numero = int.Parse(current.Text);
                            if(!this._provvigione) {
                                result.Add(voce);
                            }
                            break;
                        case 4: //Provvigione
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
                    column = (column + 1) % (this._provvigione ? 5 : 4);

                }
            }
            //Ritorna la lista
            return result;
        }

        #endregion

        #region Getters dei valori della infoBox

        public string Nome { get { return this.NomeField.Text; } }
        public string Cognome { get { return this.CognomeField.Text; } }
        public string Anno { get { return this.AnnoField.Text; } }
        public string Numero { get { return this.NumeroField.Text; } }
        public string Data { get { return this.DataField.Text; } }
        public string Indirizzo { get { return this.IndirizzoField.Text; } }
        public string CF { get { return this.CFField.Text; } }
        public string PIVA { get { return this.PIVAField.Text; } }
        public bool ConPIVA { get { return this.IVACheckBox.Checked; } }
        public TipoPersona? Persona { get { return this.tipoPersona; } }
        public bool InfoPanelVisible { get { return this.SingolaPanel.Visible; } }

        #endregion

        #endregion

        #region Setter Form

        /// <summary>
        /// Se l'infopanel contenente i dati del cliente può essere modificato.<para/>
        /// <see cref="false"/> di default.
        /// </summary>
        public bool InfoPanelEditable {
            set {
                this.AnnoField.Enabled =
                    this.CFField.Enabled =
                    this.DataField.Enabled =
                    this.IndirizzoField.Enabled =
                    this.NomeField.Enabled =
                    this.NumeroField.Enabled =
                    this.PIVAField.Enabled =
                    this.TelefonoField.Enabled = value;
                this.CognomeField.Enabled = value && this.PersonaFisicaRadio.Checked;
            }
            ///Questo metodo non è affidabile
            get {
                return this.AnnoField.Enabled;
            }
        }

        #endregion

        #region Getter Form
        public TipoForm getType() {
            return this.tipo;
        }
        #endregion

        #region Handlers bottoni ed eventi

        //Inserimento nuova voce dal bottone;
        private void materialFlatButton1_Click(object sender, EventArgs e) {
            this.AggiungiRigaCampi("", "", 0, 0, 1);
        }

        //Crea la;
        private void materialRaisedButton1_Click(object sender, EventArgs e) {
            // Deve seguire elaborazione;
            this.OnCreaClick?.Invoke(this.GetVoci(), e);

        }
        
        //Evento generato dal cambio di  da visualizzare;
        private void Inserite_SelectedIndexChanged(object sender, EventArgs e) {
            if(!this.SingolaPanel.Visible) {
                this.SingolaPanel.Visible = true;
                this.AggiungiVociBtn.Visible = true;
                this.EliminaVociBtn.Visible = true;
            }

            //TODO implement the actual method
            this.InserisciDatiDestinatario(
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
            this.AggiungiRigaCampi(
                "VENDITA",
                "2Mt di corda robusta",
                150,
                3,
                1
            );
            //Se non è null invoca il delegato;
            this.OnPannelloLateraleClick?.Invoke(sender, e);
            System.Diagnostics.Debug.WriteLine((sender as MaterialSkin.Controls.MaterialListView).SelectedItems.Count);
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
            if(!this.ValoriPanel.Visible) {
                this.ShowVoci();
            }
        }

        //Evento generato dal bottone per la creazione di una nuova;
        private void NuovaBtn_Click(object sender, EventArgs e) {
            //Svuota la info form;
            this.ShowInfo();
            this.HideVoci();

            this.OnNuovaClick?.Invoke(this, e);
        }

        //Evento generato dal bottone per svuotare le voci;
        private void EliminaVociBtn_Click(object sender, EventArgs e) {
            //TODO: farsi dare conferma;
            this.HideVoci();
        }

        //Evento generato dal bottone per accettare l'elemento corrente;
        private void AccettaBtn_Click(object sender, EventArgs e) {
            this.OnAccettaClick?.Invoke(this, e);
        }

        //Evento generato dal bottone per rifutare l'elemento corrente;
        private void RifiutaBtn_Click(object sender, EventArgs e) {
            this.OnRifiutaClick?.Invoke(this, e);
        }

        //Evento generato dalla barra di ricerca quando si preme enter;
        private void CercaText_Enter(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {

                this.OnCercaClick?.Invoke(this.SearchLabel.Text, e);

                this.SearchLabel.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            
        }

        #endregion

        #region Statics

        /// <summary>
        /// Rappresenta il tipo della form che sarà generato.<para/>
        /// <list type="table">
        /// <item>
        /// <term><see cref="PREVENTIVI"/></term>  
        /// <description>Rappresenta un preventivo, abilita i bottoni di accettazione e rifiuto nella infoBox.</description>
        /// </item><para/>
        /// <item>
        /// <term><see cref="VENDITE"/></term>  
        /// <description>Rappresenta una vendita, abilita il campo provvigione se esso è messo a true.</description>
        /// </item><para/>
        /// <item>
        /// <term><see cref="FATTURE"/></term>  
        /// <description>Rappresenta una fattura.</description>
        /// </item>
        /// </list>
        /// </summary>
        public enum TipoForm {
            PREVENTIVI,
            VENDITE,
            FATTURE
        };

        /// <summary>
        /// Crea una nuova form di tipo vendita.<para/>Equivale a <c>new GenericForm(TipoForm.VENDITE, provvigione);</c>
        /// </summary>
        /// <param name="provvigione">Se la form di tipo vendita ha il campo provvigione o meno</param>
        /// <returns>La nuova form. N.B. non c'è alcun controllo su quale tipo di form si sta lavorando <seealso cref="getType()"/></returns>
        public static GenericForm CreaFormVendita(bool provvigione = false) {
            return new GenericForm(TipoForm.VENDITE, provvigione);
        }

        /// <summary>
        /// Crea una nuova form di tipo fattura.<para/>Equivale a <c>new GenericForm(TipoForm.FATTURE);</c>
        /// </summary>
        /// <returns>La nuova form. N.B. non c'è alcun controllo su quale tipo di form si sta lavorando <seealso cref="getType()"/></returns>
        public static GenericForm CreaFormFattura() {
            return new GenericForm(TipoForm.FATTURE);
        }

        /// <summary>
        /// Crea una nuova form di tipo preventivo.<para/>Equivale a <c>new GenericForm(TipoForm.PREVENTIVI);</c>
        /// </summary>
        /// <returns>La nuova form. N.B. non c'è alcun controllo su quale tipo di form si sta lavorando <seealso cref="getType()"/></returns>
        public static GenericForm CreaFormPreventivo() {
            return new GenericForm(TipoForm.PREVENTIVI);
        }

        /// <summary>
        /// Recupera i dati dall'elenco voci per trasmetterli al controller
        /// </summary>
        /// <param name="Tipologia">La tipologia che si desidera</param>
        /// <param name="Voci">La lista con le voci da coi si desidera selezionare la tipologia</param>
        /// <returns></returns>
        public static List<Voce> GetVociPerTipologia(string Tipologia, List<Voce> Voci) {
            //Ritorna tuttle le voci che fanno match con quelle della tipologia desiderata;
            return (from voce in Voci
                    where voce.Tipologia.Equals(Tipologia)
                    select voce).ToList();
        }

        #region Private Statics

        //Struttura di comodo per lo storage delle label;
        private struct LabelText {
            public string importoLabel;
            public string causaleLabel;
            public string tipologiaLabel;
            public string titolo;
            public string provvigioneLabel;
            internal string columnHeader;
            internal string quantitaLabel;

            public LabelText(string importoLabel, string causaleLabel, string tipologiaLabel,
                string provvigioneLabel, string columnHeaderLabel, string titolo, string quantitaLabel) {
                this.importoLabel = importoLabel;
                this.causaleLabel = causaleLabel;
                this.tipologiaLabel = tipologiaLabel;
                this.titolo = titolo;
                this.provvigioneLabel = provvigioneLabel;
                this.columnHeader = columnHeaderLabel;
                this.quantitaLabel = quantitaLabel;
            }
        }

        //Le label internet;
        private static readonly Dictionary<TipoForm, LabelText> LABELTEXT = new Dictionary<TipoForm, LabelText>
        {
            { TipoForm.FATTURE, new LabelText("Importo (€)", "Causale", "Tipologia", "", "Fatture inserite", "Fatture", "Quantità") },
            { TipoForm.PREVENTIVI, new LabelText("Importo (€)", "Causale", "Tipologia", "", "Preventivi inseriti", "Preventivi", "Quantità") },
            { TipoForm.VENDITE, new LabelText("Importo (€)", "Causale", "Tipologia", "Provvigione (%)", "Vendite inserite", "Vendite", "Quantità") }
        };

        #endregion

        #endregion

    }

}
