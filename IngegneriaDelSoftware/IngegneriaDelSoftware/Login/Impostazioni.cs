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
using IngegneriaDelSoftware.Model.ArgsEvent;
using System.Drawing;
using IngegneriaDelSoftware.Persistenza;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;
using IngegneriaDelSoftware.View;
using System.Reflection;

namespace IngegneriaDelSoftware.Model
{
    public class Impostazioni
    {
        private static readonly string NOME_FILE_INI = "impostazioni.ini";
        private static readonly string PASSWORD_INI = "6507A3778280984FBB26651BB0CD421ECD87CBBD4B92ACBDCEA9057504F060F0";

        #region Costruttore
        protected Impostazioni()
        {
            if (File.Exists(NOME_FILE_INI))
            {
                CaricaImpostazioniDaIni();
            }
            else
            {
                CaricaImpostazioniDefault();
                SalvaImpostazioni();
            }
        }

        private void CaricaImpostazioniDaIni()
        {
            IniFile ini = new IniFile(NOME_FILE_INI);
            
            try
            { 
                foreach (PropertyInfo prop in this.GetType().GetProperties())
                {
                    var attributo = (Persistente)prop.GetCustomAttribute(typeof(Persistente), true);
                    if (attributo != null)
                    {
                        string chiave = attributo.Chiave ?? prop.Name;
                        string sezione = attributo.Sezione; // null è accettato

                        string valoreStringa = ini.Leggi(chiave, sezione);

                        if (attributo.Cifrato)
                            valoreStringa = Decrypt(valoreStringa, PASSWORD_INI);

                        object valore = valoreStringa;

                        if(attributo.Tipo == typeof(int))
                            valore = Int32.Parse(valoreStringa);
                        else if(attributo.Tipo == typeof(EnumTipoPersistenza))
                            valore = Enum.Parse(typeof(EnumTipoPersistenza), valoreStringa);

                        prop.SetValue(this, valore);
                    }
                }
            } catch (Exception)
            {
                FormConfim.Show("Errore lettura file impostazioni", "Il file di impostazioni non è valido, verrà sovrascritto con il file di default.", System.Windows.Forms.MessageBoxButtons.OK);
                File.Delete(NOME_FILE_INI);
                CaricaImpostazioniDefault();
                SalvaImpostazioni();
            }
        }

        private void CaricaImpostazioniDefault()
        {
            // MySQL
            this.IndirizzoServerMySQL = "andre-bisa.ddns.net";
            this.UtenteServerMySQL = "SEP";
            this.PasswordServerMySQL = "password";

            // Email
            this.Email = "andreabisacchi@gmail.com";
            this.PasswordEmail = "";
            this.PortaEmail = 587;
            this.HostEmail = "smtp.gmail.com";

            // Script fattura
            this.FileScriptFattura = "fattura.sep";

            // Persistenza
            this.TipoPersistenza = EnumTipoPersistenza.MySQL;
        }
        #endregion

        #region Metodi Encrypt/Decrypt
        //AES;

        private const int Keysize = 256;
        private const int DerivationIterations = 1000;
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
        private static string Encrypt(string plainText, string passPhrase)
        {
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }
        private static string Decrypt(string cipherText, string passPhrase)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Singleton
        private static Impostazioni _instance = null;
        public static Impostazioni GetInstance()
        {
            if (_instance == null)
                _instance = new Impostazioni();
            return _instance;
        }
        #endregion

        #region Colori clienti
        public Color ColoreClienteAttivo { get; set; } = Color.LightYellow;
        public Color ColoreClienteEx { get; set; } = Color.LightSalmon;
        public Color ColoreClientePotenziale { get; set; } = Color.LightGreen;

        public Color ColoreCliente(EnumTipoCliente tipoCliente)
        {
            switch (tipoCliente)
            {
                case EnumTipoCliente.Attivo:
                default:
                    return this.ColoreClienteAttivo;
                case EnumTipoCliente.Ex:
                    return this.ColoreClienteEx;
                case EnumTipoCliente.Potenziale:
                    return this.ColoreClientePotenziale;
            }
        }
        #endregion

        #region Database
        [Persistente(Chiave = "Persistenza", Sezione = "Persistenza", Tipo = typeof(EnumTipoPersistenza))]
        public EnumTipoPersistenza TipoPersistenza { get; set; }
        [Persistente(Chiave = "Indirizzo", Sezione = "MYSQL", Cifrato = false)]
        public string IndirizzoServerMySQL { get; set; }
        [Persistente(Chiave = "Utente", Sezione = "MYSQL", Cifrato = true)]
        public string UtenteServerMySQL { get; set; }
        [Persistente(Chiave = "Password", Sezione = "MYSQL", Cifrato = true)]
        public string PasswordServerMySQL { get; set; }
        #endregion

        #region Dati pubblici
        public int IDUtente { get; internal set; }
        public Utente UtenteLoggato { get; internal set; } = null;
        #endregion

        #region Email
        [Persistente (Chiave = "Email", Sezione = "Email", Cifrato = false)]
        public string Email { get; private set; }
        [Persistente(Chiave = "Password", Sezione = "Email", Cifrato = true)]
        public string PasswordEmail { get; private set; }
        [Persistente(Chiave = "Porta", Sezione = "Email", Cifrato = false, Tipo = typeof(int))]
        public int PortaEmail { get; set; }
        [Persistente(Chiave = "Host", Sezione = "Email", Cifrato = false)]
        public string HostEmail { get; set; }
        #endregion

        #region Script fattura
        [Persistente(Chiave = "File", Sezione = "Script", Cifrato = false)]
        public string FileScriptFattura { get; set; }
        #endregion

        #region
        public bool ModalitaTest { get; set; } = false;
        #endregion

        #region Funzioni salvataggio impostazioni
        public void SalvaImpostazioni()
        {
            IniFile ini = new IniFile(NOME_FILE_INI);

            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                var attributo = (Persistente) prop.GetCustomAttribute(typeof(Persistente), true);
                if (attributo != null)
                {
                    string chiave = attributo.Chiave ?? prop.Name;
                    string sezione = attributo.Sezione; // null è accettato

                    // Cast dinamico
                    object valore = Convert.ChangeType(prop.GetValue(this, null), attributo.Tipo);
                    
                    if (attributo.Cifrato)
                        valore = Encrypt(valore.ToString(), PASSWORD_INI);

                    ini.Scrivi(chiave, valore.ToString(), sezione);
                }
            }
        }
        #endregion
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    internal class Persistente : Attribute
    {
        public string Chiave { get; set; } = null;
        public string Sezione { get; set; } = null;
        public bool Cifrato { get; set; } = false;
        public Type Tipo { get; set; } = typeof(string);
    }

}
