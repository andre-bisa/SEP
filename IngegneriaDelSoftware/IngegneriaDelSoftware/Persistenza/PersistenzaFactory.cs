﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza.Dao;
using IngegneriaDelSoftware.Persistenza.MySQL;
using IngegneriaDelSoftware.Persistenza.None;

namespace IngegneriaDelSoftware.Persistenza
{
    public abstract class PersistenzaFactory
    { 

        public static PersistenzaFactory OttieniDAO(EnumTipoPersistenza tipoPersistenza)
        {
            switch (tipoPersistenza)
            {
                case EnumTipoPersistenza.NONE:
                    return NONEDaoFactory.GetInstance();
                case EnumTipoPersistenza.MySQL:
                    return MySQLDaoFactory.GetInstance();
                case EnumTipoPersistenza.XML:
                    break;
            }
            return null;
        }

        public abstract IClienteDAO GetClienteDAO();

        public abstract IAppuntamentoDAO GetAppuntamentoDAO();

        public abstract IDatoreLavoroDAO GetDatoreLavoroDAO();

        public abstract IEsternoDAO GetEsternoDAO();

        public abstract IFatturaDAO GetFatturaDAO();

        public abstract IIntermediarioDAO GetIntermediarioDAO();

        public abstract IMailInviataDAO GetMailInviataDAO();

        public abstract IPreventivoDAO GetPreventivoDAO();

        public abstract IUtenteDAO GetUtenteDAO();

        public abstract IVenditaDAO GetVenditaDAO();

        public abstract IPersonaDAO GetPersonaDAO();

    }
}
