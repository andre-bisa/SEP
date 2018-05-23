using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;
using MySql.Data.MySqlClient;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLClienteDAO : IClienteDAO
    {

        private readonly string SELEZIONATUTTO = "SELECT CLIENTE.* FROM CLIENTE";

        private readonly string INSERISCI = "INSERT INTO CLIENTE (IDUTENTE,IDCLIENTE,TIPO,IDPERSONA,NOTE) VALUES ('{0}','{1}','{2}','{3}','{4}')";

        public bool Aggiorna(Cliente clienteVecchio, Cliente clienteNuovo)
        {
            return true;
        }

        public bool Crea(Cliente cliente)
        {
            return true;
            /*
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            if (connessione == null)
                return false;

            MySqlCommand cmd = connessione.CreateCommand();
            string tipo = "";
            switch (cliente.TipoCliente)
            {
                case EnumTipoCliente.Attivo:
                    tipo = "A";
                    break;
                case EnumTipoCliente.Ex:
                    tipo = "E";
                    break;
                case EnumTipoCliente.Potenziale:
                    tipo = "P";
                    break;
            }
            cmd.CommandText = String.Format(INSERISCI, "IDUTENTE", cliente.IDCliente, tipo, "IDPERSONA", cliente.Nota);

            int modifiche = cmd.ExecuteNonQuery();

            connessione.Close();

            return (modifiche == 1);*/
        }

        public bool Elimina(string IDCliente)
        {
            return true;
        }

        public Cliente Leggi(string IDCliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> LeggiTuttiClienti()
        {
            return new List<Cliente>();
        }
    }
}
