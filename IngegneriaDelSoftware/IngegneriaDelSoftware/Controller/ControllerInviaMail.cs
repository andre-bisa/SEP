﻿using System;
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
        /// <param name="email">Elenco di destinatari</param>
        /// <returns><c>true</c> solo se ha mandato correttamente le mail a TUTTI i destinatari</returns>
        public bool InviaMail(string oggetto, string corpo, IEnumerable<Email> destinatari)
        {
            bool mandateTutte = true;
            foreach (Email e in destinatari)
            {
                MailInviata mail = new MailInviata(DateTime.Now, oggetto, corpo, e.Indirizzo);
                if (SpedisciMail(mail))
                { // se spedita
                    if (PersistenzaFactory.OttieniDAO(Impostazioni.GetInstance().TipoPersistenza).GetMailInviataDAO().Crea(mail))
                    { // se inserita nella persistenza
                        CollezioneEmailInviate.Add(mail);
                    }
                }
                else
                    mandateTutte = false;
            }

            return mandateTutte;
        }

        private bool SpedisciMail(MailInviata destinatario)
        {
            MailMessage mail = new MailMessage(Impostazioni.GetInstance().Email, destinatario.Email);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 2000;
            client.Credentials = new NetworkCredential(Impostazioni.GetInstance().Email, Impostazioni.GetInstance().PasswordEmail);
            mail.Subject = destinatario.Oggetto;
            mail.Body = destinatario.Corpo;
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
