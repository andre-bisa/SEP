using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngegneriaDelSoftware.View.Overlay;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.View.Controlli;
using IngegneriaDelSoftware.Controller;

namespace IngegneriaDelSoftware.View.Overlay
{
    public partial class OverlayCliente : Overlay
    {
        /// <summary>
        /// Cliente dell'overlay
        /// </summary>
        public Cliente Cliente { get; private set; }
        private ControllerClienti _controller;

        private Impostazioni _impostazioni = Impostazioni.GetInstance();

        #region "Costruttori"
        /// <summary>
        /// Costruttore da usare per la creazione di un overlay vuoto. Utile per l'inserimento di un cliente.
        /// </summary>
        /// <param name="controller">Il controller dei clienti a cui dovrà fare riferimento la view (serve a chiedere di inserire/modificare/eliminare i clienti)</param>
        /// <param name="panelContainer">Pannello che conterrà l'overlay</param>
        /// <param name="cliente">Cliente a cui si riferisce l'overlay</param>
        public OverlayCliente(ControllerClienti controller, Panel panelContainer, Cliente cliente = null) : base(panelContainer)
        {
            InitializeComponent();
            base.AddPanel(this.panel1);
            btnSalva.Click += this.BottoneSalva;

            this.Titolo = "Cliente";

            this._controller = controller;
            if (cliente != null)
            {
                Cliente = cliente;
                CaricaClienteSuForm();
            }
            else // se non c'è un cliente non puoi inserire referenti/telefoni/email
            {
                BtnAggiungiEmail.Enabled = false;
                btnAggiungiReferente.Enabled = false;
                BtnAggiungiTelefono.Enabled = false;
            }
        }
        #endregion

        #region "Gestione eventi controlli"
        private void CambiaRadioPersona(object sender, EventArgs e)
        {
            if ( this.radioFisica.Checked ) // Fisica selezionato
            {
                lblDenominazione.Visible = false;
                txtDenominazione.Visible = false;

                lblNome.Visible = true;
                lblCognome.Visible = true;
                txtNome.Visible = true;
                txtCognome.Visible = true;
            } else if ( this.radioGiuridica.Checked ) // Giuridica selezionato
            {
                lblDenominazione.Visible = true;
                txtDenominazione.Visible = true;

                lblNome.Visible = false;
                lblCognome.Visible = false;
                txtNome.Visible = false;
                txtCognome.Visible = false;
            }
        }

        private void BottoneSalva(object sender, EventArgs e)
        {
            // Controllo inserimento dei campi
            if (
                txtCodice.Text.Trim().Length == 0 ||
                txtCodiceFiscale.Text.Trim().Length == 0 ||
                txtIndirizzo.Text.Trim().Length == 0 ||
                (radioFisica.Checked && (txtNome.Text.Trim().Length == 0 || txtCognome.Text.Trim().Length == 0)) ||
                (radioGiuridica.Checked && txtDenominazione.Text.Trim().Length == 0)
                )
            {
                FormConfim.Show("Errore, inserire tutti i campi obbligatori", "Errore nell'inserimento dei campi obbligatori." + System.Environment.NewLine + "I campi obbligatori sono: Codice, Indirizzo, Codice Fiscale, Nome e Cognome oppure Denominazione.", MessageBoxButtons.OK);
                return;
            }

            DatiPersona datiPersona;
            EnumTipoCliente tipoCliente = EnumTipoCliente.Attivo;
            DatiCliente datiCliente;
            List<Referente> listaReferenti = new List<Referente>();
            string nota = txtNote.Text;

            if (radioFisica.Checked)
            {
                datiPersona = new DatiPersonaFisica(txtCodiceFiscale.Text, txtIndirizzo.Text, txtNome.Text, txtCognome.Text, txtPartitaIVA.Text);
            }
            else // Giuridica
            {
                datiPersona = new DatiPersonaGiuridica(txtCodiceFiscale.Text, txtIndirizzo.Text, txtDenominazione.Text, "Sede legale", txtPartitaIVA.Text);
            }

            if (checkEx.Checked)
                tipoCliente = EnumTipoCliente.Ex;
            else if (checkPotenziale.Checked)
                tipoCliente = EnumTipoCliente.Potenziale;

            datiCliente = new DatiCliente(txtCodice.Text, tipoCliente, nota);

            try
            {
                if (Cliente == null) // devo creare un cliente
                {
                    Cliente = this._controller.AggiungiCliente(datiCliente, datiPersona);
                }
                else
                {
                    this._controller.ModificaCliente(Cliente, datiCliente, datiPersona);
                }
            } catch (Persistenza.ExceptionPersistenza)
            {
                MessageBox.Show("Errore durante la comunicazione con il DataBase. L'applicazione termina.", "Errore connessione DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (Cliente != null)
                this.Close(); // Chiudo l'overlay
            else
            {
                FormConfim.Show("Errore", "Il codice cliente esiste già.", MessageBoxButtons.OK);
                txtCodice.Focus();
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Funzioni private"
        private void CaricaClienteSuForm()
        {
            txtCodice.Text = Cliente.IDCliente;
            txtCodiceFiscale.Text = Cliente.Persona.CodiceFiscale;
            txtIndirizzo.Text = Cliente.Persona.Indirizzo;
            txtNote.Text = Cliente.Nota;

            // Carico Email
            foreach (Email email in Cliente.Persona.Email)
            {
                string[] rows = { email.Indirizzo, email.Nota };
                ListViewItem item = new ListViewItem(rows);
                listEmail.Items.Add(item);
            }

            // Carico Telefoni
            foreach (Telefono tel in Cliente.Persona.Telefoni)
            {
                string[] rows = { tel.Numero, tel.Nota };
                ListViewItem item = new ListViewItem(rows);
                listTelefoni.Items.Add(item);
            }

            // Carico Referenti
            foreach (Referente referente in Cliente.Referenti)
            {
                string[] rows = { referente.Nome, referente.Nota };
                ListViewItem item = new ListViewItem(rows);
                listReferenti.Items.Add(item);
            }

            if (Cliente.Persona.TipoPersona == EnumTipoPersona.Fisica)
            {
                PersonaFisica personaFisica = (PersonaFisica) Cliente.Persona;
                txtNome.Text = personaFisica.Nome;
                txtCognome.Text = personaFisica.Cognome;
                txtPartitaIVA.Text = personaFisica.PartitaIVA;

                radioFisica.Checked = true;
                radioGiuridica.Enabled = false;
            }
            else
            {
                PersonaGiuridica personaGiuridica = (PersonaGiuridica) Cliente.Persona;
                txtDenominazione.Text = personaGiuridica.RagioneSociale;
                txtPartitaIVA.Text = personaGiuridica.PartitaIVA;

                radioGiuridica.Checked = true;
                radioFisica.Enabled = false;
            }
            if (Cliente.TipoCliente == EnumTipoCliente.Ex)
                checkEx.Checked = true;
            else if (Cliente.TipoCliente == EnumTipoCliente.Potenziale)
                checkPotenziale.Checked = true;

            AbilitaCheckPerTipologiaCliente();

            // Colore di sfondo
            base.ColoreSfondo = this._impostazioni.ColoreCliente(Cliente.TipoCliente);
        }
        #endregion

        private void checkPotenziale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPotenziale.Checked)
            {
                checkEx.Enabled = false;
                checkEx.Checked = false;
            }
            else
            {
                checkEx.Enabled = true;
            }
            AbilitaCheckPerTipologiaCliente();
        }

        private void AbilitaCheckPerTipologiaCliente()
        {
            if (Cliente == null)
                return;

            // Disattivo scelte non valide
            switch (Cliente.TipoCliente)
            {
                case EnumTipoCliente.Attivo:
                    checkEx.Enabled = true;
                    checkPotenziale.Enabled = false;
                    break;
                case EnumTipoCliente.Ex:
                    checkPotenziale.Enabled = false;
                    checkEx.Enabled = true;
                    break;
                case EnumTipoCliente.Potenziale:
                    checkEx.Enabled = false;
                    checkPotenziale.Enabled = true;
                    break;
            }
        }

        private void checkEx_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEx.Checked)
            {
                checkPotenziale.Enabled = false;
                checkPotenziale.Checked = false;
            }
            else
            {
                checkPotenziale.Enabled = true;
            }
            AbilitaCheckPerTipologiaCliente();
        }

        private void BtnAggiungiEmail_Click(object sender, EventArgs e)
        {
            FormInserisciEmail inserisciEmail = new FormInserisciEmail();
            if (Cliente != null)
            { // se c'è un cliente aggancio l'handler per salvare la nuova email
                inserisciEmail.OnAggiunta += (o, email) => 
                {
                    try
                    {
                        Cliente.Persona.Email.Add(email.Email);
                    } catch (Persistenza.ExceptionPersistenza)
                    {
                        MessageBox.Show("Errore durante la comunicazione con il DataBase. L'applicazione termina.", "Errore connessione DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    };
            }
            // inserisco la mail nella lista grafica
            inserisciEmail.OnAggiunta += (o, email) => 
            {
                string[] rows = {email.Email.Indirizzo, email.Email.Nota };
                ListViewItem item = new ListViewItem(rows);
                listEmail.Items.Add(item);
            };
            inserisciEmail.ShowDialog();
        }

        private void BtnAggiungiTelefono_Click(object sender, EventArgs e)
        {
            FormInserisciTelefono inserisciTelefono = new FormInserisciTelefono();
            if (Cliente != null)
            { // se c'è un cliente aggancio l'handler per salvare la nuova email
                inserisciTelefono.OnAggiunta += (o, tel) => 
                {
                    try
                    {
                        Cliente.Persona.Telefoni.Add(tel.Telefono);
                    } catch(Persistenza.ExceptionPersistenza)
                    {
                        MessageBox.Show("Errore durante la comunicazione con il DataBase. L'applicazione termina.", "Errore connessione DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                };
            }
            // inserisco la mail nella lista grafica
            inserisciTelefono.OnAggiunta += (o, tel) =>
            {
                string[] rows = { tel.Telefono.Numero, tel.Telefono.Nota };
                ListViewItem item = new ListViewItem(rows);
                listTelefoni.Items.Add(item);
            };
            inserisciTelefono.ShowDialog();
        }

        private void btnAggiungiReferente_Click(object sender, EventArgs e)
        {
            FormInserisciReferente inserisciReferente = new FormInserisciReferente();
            if (Cliente != null)
            { // se c'è un cliente aggancio l'handler per salvare la nuova email
                inserisciReferente.OnAggiunta += (o, r) => 
                {
                    try
                    {
                        Cliente.Referenti.Add(r.Referente);
                    } catch (Persistenza.ExceptionPersistenza)
                    {
                        MessageBox.Show("Errore durante la comunicazione con il DataBase. L'applicazione termina.", "Errore connessione DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                };
            }
            // inserisco la mail nella lista grafica
            inserisciReferente.OnAggiunta += (o, r) =>
            {
                string[] rows = { r.Referente.Nome, r.Referente.Nota };
                ListViewItem item = new ListViewItem(rows);
                listReferenti.Items.Add(item);
            };
            inserisciReferente.ShowDialog();
        }

        private void listEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && Cliente != null && listEmail.SelectedItems.Count > 0)
            {
                if (FormConfim.Show("Rimuovere?", "Sei sicuro di voler eliminare la mail: " + listEmail.SelectedItems[0].SubItems[0].Text + "?") == DialogResult.OK)
                {
                    Email emailMock = new Email(listEmail.SelectedItems[0].SubItems[0].Text);
                    Cliente.Persona.Email.Remove(emailMock);
                    listEmail.Items.Remove(listEmail.SelectedItems[0]);

                    FormConfim.Show("Rimosso", "Email rimossa.", MessageBoxButtons.OK);
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void listTelefoni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && Cliente != null && listTelefoni.SelectedItems.Count > 0)
            {
                if (FormConfim.Show("Rimuovere?", "Sei sicuro di voler eliminare il telefono: " + listTelefoni.SelectedItems[0].SubItems[0].Text + "?") == DialogResult.OK)
                {
                    Telefono telefonoMock = new Telefono(listTelefoni.SelectedItems[0].SubItems[0].Text);
                    Cliente.Persona.Telefoni.Remove(telefonoMock);
                    listTelefoni.Items.Remove(listTelefoni.SelectedItems[0]);

                    FormConfim.Show("Rimosso", "Telefono rimosso.", MessageBoxButtons.OK);
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void listReferenti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && Cliente != null && listReferenti.SelectedItems.Count > 0)
            {
                if (FormConfim.Show("Rimuovere?", "Sei sicuro di voler eliminare il referente: " + listReferenti.SelectedItems[0].SubItems[0].Text + "?") == DialogResult.OK)
                {
                    Referente referenteMock = new Referente(listReferenti.SelectedItems[0].SubItems[0].Text);
                    Cliente.Referenti.Remove(referenteMock);
                    listReferenti.Items.Remove(listReferenti.SelectedItems[0]);

                    FormConfim.Show("Rimosso", "Referente rimosso.", MessageBoxButtons.OK);
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
