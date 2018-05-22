using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Persistenza.Dao;
using IngegneriaDelSoftware.Persistenza.MySQL;

namespace IngegneriaDelSoftware.Persistenza
{
    public abstract class PersistenzaFactory
    { 

        public static PersistenzaFactory OttieniDAO(EnumTipoPersistenza tipoPersistenza)
        {
            switch (tipoPersistenza)
            {
                case EnumTipoPersistenza.MySQL:
                    return MySQLDaoFactory.GetInstance();
                case EnumTipoPersistenza.XML:
                    break;
            }
            return null;
        }

        public abstract ClienteDAO GetClienteDAO();

        public abstract PersonaDAO GetPersonaDAO();

    }
}
