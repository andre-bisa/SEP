﻿using System.Collections.Generic;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.None
{
    public class NoneGenericoDao : IAppuntamentoDAO, IClienteDAO, IDatoreLavoroDAO, IEsternoDAO, IFatturaDAO, IMailInviataDAO, IIntermediarioDAO, IPreventivoDAO, IUtenteDAO, IVenditaDAO
    {
        public bool Aggiorna(Appuntamento appuntamentoVecchio, Appuntamento nuovoAppuntamento)
        {
            return true;
        }

        public bool Aggiorna(Cliente clienteVecchio, Cliente clienteNuovo)
        {
            return true;
        }

        public bool Aggiorna(DatoreLavoro vecchio, DatoreLavoro nuovo)
        {
            return true;
        }

        public bool Aggiorna(Esterno vecchio, Esterno nuovo)
        {
            return true;
        }

        public bool Aggiorna(Fattura vecchia, Fattura nuova)
        {
            return true;
        }

        public bool Aggiorna(Intermediario vecchio, Intermediario nuovo)
        {
            return true;
        }

        public bool Aggiorna(Preventivo vecchio, Preventivo nuovo)
        {
            return true;
        }

        public bool Aggiorna(Utente vecchia, Utente nuova)
        {
            return true;
        }

        public bool Aggiorna(Vendita vecchia, Vendita nuova)
        {
            return true;
        }

        public bool Crea(Appuntamento appuntamento)
        {
            return true;
        }

        public bool Crea(Cliente cliente)
        {
            return true;
        }

        public bool Crea(DatoreLavoro nuovo)
        {
            return true;
        }

        public bool Crea(Esterno nuovo)
        {
            return true;
        }

        public bool Crea(Fattura nuova)
        {
            return true;
        }

        public bool Crea(MailInviata nuova)
        {
            return true;
        }

        public bool Crea(Intermediario nuovo)
        {
            return true;
        }

        public bool Crea(Preventivo nuovo)
        {
            return true;
        }

        public bool Crea(Utente nuova)
        {
            return true;
        }

        public bool Crea(Vendita nuova)
        {
            return true;
        }

        public bool Elimina(string ID)
        {
            return true;
        }

        public List<MailInviata> GetListaMailInviate()
        {
            return new List<MailInviata>();
        }

        public Appuntamento Leggi(string ID)
        {
            return null;
        }

        public List<Appuntamento> LeggiTuttiAppuntamenti()
        {
            return new List<Appuntamento>();
        }

        public List<Cliente> LeggiTuttiClienti()
        {
            return new List<Cliente>();
        }

        public List<DatoreLavoro> LeggiTuttiDatoriLavoro()
        {
            return new List<DatoreLavoro>();
        }

        Cliente IClienteDAO.Leggi(string IDCliente)
        {
            return null;
        }

        DatoreLavoro IDatoreLavoroDAO.Leggi(string ID)
        {
            return null;
        }

        Esterno IEsternoDAO.Leggi(string ID)
        {
            return null;
        }

        Fattura IFatturaDAO.Leggi(string ID)
        {
            return null;
        }

        MailInviata IMailInviataDAO.Leggi(string ID)
        {
            return null;
        }

        Intermediario IIntermediarioDAO.Leggi(string ID)
        {
            return null;
        }

        Preventivo IPreventivoDAO.Leggi(string ID)
        {
            return null;
        }

        Utente IUtenteDAO.Leggi(string ID)
        {
            return null;
        }

        Vendita IVenditaDAO.Leggi(string ID)
        {
            return null;
        }
    }
}