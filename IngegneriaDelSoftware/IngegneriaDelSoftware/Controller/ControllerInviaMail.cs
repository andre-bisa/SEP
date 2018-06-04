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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza;
using System.Net.Mail;
using System.Net;

namespace IngegneriaDelSoftware.Controller
{
    public class ControllerInviaMail
    {
        #region Singleton
        private static ControllerInviaMail _instance = null;
        private ControllerInviaMail()
        { }
        public static ControllerInviaMail GetInstance()
        {
            if (_instance == null)
                _instance = new ControllerInviaMail();
            return _instance;
        }
        #endregion

        public CollezioneEmailInviate CollezioneEmailInviate { get; private set; } = CollezioneEmailInviate.GetInstance();

        /// <summary>
        /// Funzione che permette di mandare le mail
        /// </summary>
        /// <param name="oggetto">Oggetto della mail</param>
        /// <param name="corpo">Corpo della mail</param>
        /// <param name="destinatari">Elenco di destinatari</param>
        /// <returns><c>true</c> solo se ha mandato correttamente le mail a TUTTI i destinatari</returns>
        public bool InviaMail(string oggetto, string corpo, IEnumerable<Cliente> destinatari)
        {
            List<Email> email = new List<Email>();
            int MAIL_ALLA_VOLTA = 100;

            foreach (Cliente c in destinatari)
            {
                email.AddRange(c.Persona.Email);
            }

            bool mandateTutte = true;
            
            // Invio gruppo di MAIL_ALLA_VOLTA
            for (int i = 0; i < email.Count; i++)
            {
                List<Email> gruppoMail = email.Skip(i * MAIL_ALLA_VOLTA).Take(MAIL_ALLA_VOLTA).ToList();
                if (SpedisciMail(oggetto, corpo, gruppoMail))
                { // se spedite
                    foreach (Email e in gruppoMail)
                    {
                        MailInviata mail = new MailInviata(DateTime.Now, oggetto, corpo, e.Indirizzo);
                        if (PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza).GetMailInviataDAO().Crea(mail))
                        { // se inserita nella persistenza
                            CollezioneEmailInviate.Add(mail);
                        }
                    }
                }
                else
                    mandateTutte = false;
            }

            return mandateTutte;
        }

        private bool SpedisciMail(string oggetto, string corpo, IEnumerable<Email> emails)
        {
            MailMessage mail = new MailMessage(Impostazioni.GetInstance().Email, "dummy@dummy.com");
            mail.To.Clear(); // Rimuovo il to

            // Inserisco i mittenti in Bcc
            foreach (Email e in emails)
                mail.Bcc.Add(new MailAddress(e.Indirizzo));

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 5000;
            client.Credentials = new NetworkCredential(Impostazioni.GetInstance().Email, Impostazioni.GetInstance().PasswordEmail);
            mail.Subject = oggetto;
            mail.Body = corpo;
            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
