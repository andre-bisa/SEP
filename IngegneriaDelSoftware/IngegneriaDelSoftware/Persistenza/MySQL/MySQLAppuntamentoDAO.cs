using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;
using MySql.Data.MySqlClient;

namespace IngegneriaDelSoftware.Persistenza.MySQL {
    public class MySQLAppuntamentoDAO: IAppuntamentoDAO {

        private static readonly string INSERISCI_APPUNTAMENTO = @"INSERT INTO APPUNTAMENTI (IDUTENTE, IDAPPUNTAMENTO, DATA, ORA, LUOGO, NOTE) VALUES (@idutente,@idappuntamento,@data,@ora,@luogo,@note);";
        private static readonly string SELEZIONA_APPUNTAMENTI = @"SELECT ";
        private static readonly string SELEZIONA_ULTIMO_ID_APPUNTAMENTO = "SELECT MAX(IDAPPUNTAMENTO) AS MAX FROM APPUNTAMENTO WHERE IDUTENTE = @idutente;";

        private static readonly string AGGIORNA_APPUNTAMENTO = @"UPDATE APPUNTAMENTO SET DATA=@data,ORA=@ora,LUOGO=@luogo,NOTE=@note WHERE IDUTENTE=@idutente AND IDAPPUNTAMENTO=@idappuntamento;";
        private static readonly string ELIMINA_APPUNTAMENTO = @"DELETE ";

        private int NuovoNumeroAppuntamentoLibero() {
            int ultimoID = -2;
            MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

            MySqlCommand cmd = connessione.CreateCommand();

            cmd.CommandText = SELEZIONA_ULTIMO_ID_APPUNTAMENTO;
            cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows) {
                reader.Read();
                if(reader.IsDBNull(0))
                    ultimoID = 0;
                else
                    ultimoID = reader.GetInt32(0);
            }

            connessione.Close();

            return ultimoID + 1;
        }
        public bool Aggiorna(Appuntamento appuntamentoVecchio, Appuntamento nuovoAppuntamento) {
            /* MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

             if(connessione == null) {
                 return false;
             }

             MySqlCommand cmd = connessione.CreateCommand();

             if(cmd == null) {
                 return false;
             }

             cmd.CommandText = "START TRANSACTION;";

             cmd.CommandText += AGGIORNA_CLIENTE;
             //InserisciParametriCliente(clienteNuovo, cmd);
             cmd.Parameters.AddWithValue("@old_idcliente", clienteVecchio.IDCliente);

             cmd.CommandText += "COMMIT;";

             cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);

             int modifiche = cmd.ExecuteNonQuery();

             connessione.Close();

             return (modifiche >= 1);*/
            throw new NotImplementedException();
        }

        public bool Crea(Appuntamento appuntamento) {
            /* MySqlConnection connessione = MySQLDaoFactory.ApriConnessione();

             if(connessione == null) {
                 return false;
             }

             MySqlCommand cmd = connessione.CreateCommand();

             if(cmd == null) {
                 return false;
             }

             cmd.CommandText = "START TRANSACTION;";

             int IDAppuntamento = NuovoNumeroAppuntamentoLibero();

             cmd.CommandText += INSERISCI_APPUNTAMENTO;
             //InserisciParametriPersona(cliente.Persona, cmd);

             if(IDAppuntamento <= 0) {
                 connessione.Close();
                 return false;
             }

             cmd.CommandText += "COMMIT;";

             cmd.Parameters.AddWithValue("@idutente", Impostazioni.GetInstance().IDUtente);
             cmd.Parameters.AddWithValue("@idpersona", "" + IDAppuntamento);

             int modifiche = cmd.ExecuteNonQuery();

             connessione.Close();

             return (modifiche >= 1);*/
            throw new NotImplementedException();
        }

        public bool Elimina(string ID) {
            throw new NotImplementedException();
        }

        public Appuntamento Leggi(string ID) {
            throw new NotImplementedException();
        }

        public List<Appuntamento> LeggiTuttiAppuntamenti() {
            throw new NotImplementedException();
        }
    }
}