using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLAppuntamentoDAO : IAppuntamentoDAO
    {
        public bool Aggiorna(Appuntamento appuntamentoVecchio, Appuntamento nuovoAppuntamento)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Appuntamento appuntamento)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string ID)
        {
            throw new NotImplementedException();
        }

        public Appuntamento Leggi(string ID)
        {
            throw new NotImplementedException();
        }

        public List<Appuntamento> LeggiTuttiAppuntamenti()
        {
            throw new NotImplementedException();
        }
    }
}