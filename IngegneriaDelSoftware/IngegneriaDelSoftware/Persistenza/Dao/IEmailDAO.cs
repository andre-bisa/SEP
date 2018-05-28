using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;

namespace IngegneriaDelSoftware.Persistenza.Dao
{
    public interface IEmailDAO
    {
        bool Aggiungi(Email emai, string IDCliente);

        bool Rimuovi(Email email, string IDCliente);

    }
}
