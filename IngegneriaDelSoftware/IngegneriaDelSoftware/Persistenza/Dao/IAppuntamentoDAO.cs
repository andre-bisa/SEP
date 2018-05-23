using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IAppuntamentoDAO
    {
        bool Crea(Appuntamento appuntamento);

        Appuntamento Leggi(string ID);

        bool Aggiorna(Appuntamento appuntamentoVecchio, Appuntamento nuovoAppuntamento);

        bool Elimina(string ID);

        List<Appuntamento> LeggiTuttiAppuntamenti();
    }
}
