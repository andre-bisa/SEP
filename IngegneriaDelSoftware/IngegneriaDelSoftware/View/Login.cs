using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Security;
using IngegneriaDelSoftware.Controller;

namespace IngegneriaDelSoftware
{
    public partial class Login : MaterialForm
    {
        private ControllerLogin _contrller;
        public Login(ControllerLogin c)
        {
            this._contrller = c;
            InitializeComponent();
        }

        private bool Verify() {
            bool result;
            SecureString s = new SecureString();
            {
                //Quante copie ombra nella memoria? Who knows?;
                //Sul serio: questo metodo è più inutile che altro, ma rende una parvenza di sicurezza
                //nella trasmissione e, inoltre, limita un poco il leak al controller;
                this.txtPassword.Text.ToCharArray().ToList().ForEach((e) => {
                    s.AppendChar(e);
                });
                s.MakeReadOnly();
            }
            System.GC.Collect();
            result = this._contrller.VerificaCredenziali(this.txtUsername.Text, s);
            try {
                //Nel caso il contoller non abbia liberato la risorsa;
                s.Dispose();
            } catch(Exception) { };
            return result;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) {
            if(this.Verify()) {
                //Login;
            }else {
                //Mostra form di errore;
            }
        }
    }
}
