using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;
using System.Drawing;

namespace IngegneriaDelSoftware.Model
{
    public class Impostazioni
    {

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

    }
}
