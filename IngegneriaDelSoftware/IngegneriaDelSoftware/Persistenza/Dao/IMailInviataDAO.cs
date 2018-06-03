using IngegneriaDelSoftware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IMailInviataDAO
    {
        bool Crea(MailInviata nuova);

        List<MailInviata> GetListaMailInviate();

    }
}
