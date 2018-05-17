﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Model
{
    public class Appuntamento
    {
        private Persona _conChi;
        private string _oggetto;
        private string _luogo;
        private DateTime _dataOra;

        #region Costruttore
        /// <summary>
        /// 
        /// </summary>
        /// <param name="luogo"></param>
        /// <param name="conChi"></param>
        /// <param name="oggetto"></param>
        /// <param name="dataOra"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Appuntamento(string luogo, Persona conChi, string oggetto, DateTime dataOra)
        {
            if (conChi == null || oggetto == null || dataOra == null || luogo == null)
            {
                throw new ArgumentNullException();
            }

            _conChi = conChi;
            _oggetto = oggetto;
            _dataOra = dataOra;
            _luogo = luogo;
        }
        #endregion

        #region Getters and Setters
        public string Oggetto
        {
            get { return _oggetto; }
            set { this._oggetto = value; }
        }

        public Persona ConChi
        {
            get { return _conChi; }
            set { this._conChi = value; }
        }

        public string Luogo
        {
            get { return _luogo; }
            set { this._luogo = value; }
        }

        public DateTime DataOra
        {
            get { return _dataOra; }
            set { this._dataOra = value; }
        }
        #endregion

    }
}
