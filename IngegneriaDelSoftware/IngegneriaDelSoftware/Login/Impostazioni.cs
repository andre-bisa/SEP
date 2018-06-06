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
                // MySQL
                this.IndirizzoServerMySQL = Decrypt(ini.Leggi("IndirizzoServer", "MYSQL"), PASSWORD_INI);
                this.UtenteServerMySQL = Decrypt(ini.Leggi("Utente", "MYSQL"), PASSWORD_INI);
                this.PasswordServerMySQL = Decrypt(ini.Leggi("Password", "MYSQL"), PASSWORD_INI);

                // Email
                this.Email = Decrypt(ini.Leggi("Email", "Email"), PASSWORD_INI);
                this.PasswordEmail = Decrypt(ini.Leggi("Password", "Email"), PASSWORD_INI);
                this.PortaEmail = Int32.Parse(Decrypt(ini.Leggi("Porta", "Email"), PASSWORD_INI));
                this.HostEmail = Decrypt(ini.Leggi("Host", "Email"), PASSWORD_INI);

                // Script fattura
                this.FileScriptFattura = Decrypt(ini.Leggi("File", "Script"), PASSWORD_INI);


            } catch (Exception)
            {
                FormConfim.Show("Errore lettura file impostazioni", "Il file di impostazioni non è valido, verrà sovrascritto con il file di default.", System.Windows.Forms.MessageBoxButtons.OK);
                ini.EliminaSezione("MYSQL");
                ini.EliminaSezione("Email");
                ini.EliminaSezione("Script");
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
            this.Email = "";
            this.PasswordEmail = "";
            this.PortaEmail = 587;
            this.HostEmail = "smtp.gmail.com";

            // Script fattura
            this.FileScriptFattura = "";
        }
        #endregion

        #region Metodi Encrypt/Decrypt
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
        public static string Encrypt(string plainText, string passPhrase)
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
        public static string Decrypt(string cipherText, string passPhrase)
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
        public EnumTipoPersistenza TipoPersistenza { get; set; } = EnumTipoPersistenza.NONE;
        public string IndirizzoServerMySQL { get; set; }
        public string UtenteServerMySQL { get; set; }
        public string PasswordServerMySQL { get; set; }
        #endregion

        #region Dati pubblici
        public int IDUtente { get; internal set; }
        public Utente UtenteLoggato { get; internal set; } = null;
        #endregion

        #region Email
        public string Email { get; private set; }
        public string PasswordEmail { get; private set; }
        public int PortaEmail { get; set; }
        public string HostEmail { get; set; }
        #endregion

        #region Script fattura
        public string FileScriptFattura { get; set; }
        #endregion

        #region Funzioni salvataggio impostazioni
        public void SalvaImpostazioni()
        {
            IniFile ini = new IniFile(NOME_FILE_INI);

            // MySQL
            ini.Scrivi("IndirizzoServer", Encrypt(this.IndirizzoServerMySQL, PASSWORD_INI), "MYSQL");
            ini.Scrivi("Utente", Encrypt(this.UtenteServerMySQL, PASSWORD_INI), "MYSQL");
            ini.Scrivi("Password", Encrypt(this.PasswordServerMySQL, PASSWORD_INI), "MYSQL");

            // Email
            ini.Scrivi("Email", Encrypt(this.Email, PASSWORD_INI), "Email");
            ini.Scrivi("Password", Encrypt(this.PasswordEmail, PASSWORD_INI), "Email");
            ini.Scrivi("Porta", Encrypt(this.PortaEmail.ToString(), PASSWORD_INI), "Email");
            ini.Scrivi("Host", Encrypt(this.HostEmail, PASSWORD_INI), "Email");

            // Script fattura
            ini.Scrivi("File", Encrypt(this.FileScriptFattura, PASSWORD_INI), "Script");
        }
        #endregion


    }
}
