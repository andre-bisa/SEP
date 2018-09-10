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
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.None
{
    public class NONEDaoFactory : PersistenzaFactory
    {
        #region Singleton
        private static NONEDaoFactory _instance = null;

        protected NONEDaoFactory() { }

        public static NONEDaoFactory GetInstance()
        {
            if (_instance == null)
                _instance = new NONEDaoFactory();
            return _instance;
        }
        #endregion

        public override IAppuntamentoDAO GetAppuntamentoDAO()
        {
            return new NoneGenericoDao();
        }

        public override IClienteDAO GetClienteDAO()
        {
            return new NoneGenericoDao();
        }

        public override IDatoreLavoroDAO GetDatoreLavoroDAO()
        {
            return new NoneGenericoDao();
        }

        public override IEsternoDAO GetEsternoDAO()
        {
            return new NoneGenericoDao();
        }

        public override IFatturaDAO GetFatturaDAO()
        {
            return new NoneGenericoDao();
        }

        public override IIntermediarioDAO GetIntermediarioDAO()
        {
            return new NoneGenericoDao();
        }

        public override IMailInviataDAO GetMailInviataDAO()
        {
            return new NoneGenericoDao();
        }

        public override IPersonaDAO GetPersonaDAO()
        {
            return new NoneGenericoDao();
        }

        public override IPreventivoDAO GetPreventivoDAO()
        {
            return new NoneGenericoDao();
        }

        public override IUtenteDAO GetUtenteDAO()
        {
            throw new NotImplementedException();
        }

        public override IVenditaDAO GetVenditaDAO()
        {
            return new NoneGenericoDao();
        }
    }
}
