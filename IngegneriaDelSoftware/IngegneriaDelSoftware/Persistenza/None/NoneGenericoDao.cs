/*
    Copyright (C) 2018 Andrea Bisacchi, chkrr00k, Davide Giordano
  
    This file is part of SEP.

    SEP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SEP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SEP.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.None
{
    public class NoneGenericoDao : IAppuntamentoDAO, IClienteDAO, IDatoreLavoroDAO, IEsternoDAO, IFatturaDAO, IMailInviataDAO, IIntermediarioDAO, IPreventivoDAO, IVenditaDAO, IPersonaDAO
    {
        bool IAppuntamentoDAO.Aggiorna(Appuntamento appuntamentoVecchio, Appuntamento nuovoAppuntamento)
        {
            return true;
        }

        bool IClienteDAO.Aggiorna(Cliente clienteVecchio, Cliente clienteNuovo)
        {
            return true;
        }

        bool IDatoreLavoroDAO.Aggiorna(DatoreLavoro vecchio, DatoreLavoro nuovo)
        {
            return true;
        }

        bool IEsternoDAO.Aggiorna(Esterno vecchio, Esterno nuovo)
        {
            return true;
        }

        bool IFatturaDAO.Aggiorna(Fattura vecchia, Fattura nuova)
        {
            return true;
        }

        bool IIntermediarioDAO.Aggiorna(Intermediario vecchio, Intermediario nuovo)
        {
            return true;
        }

        bool IPreventivoDAO.Aggiorna(Preventivo vecchio, Preventivo nuovo)
        {
            return true;
        }

        bool IVenditaDAO.Aggiorna(Vendita vecchia, Vendita nuova)
        {
            return true;
        }

        bool IPersonaDAO.Aggiorna(Persona vecchiaPersona, Persona nuovaPersona)
        {
            return true;
        }

        bool IFatturaDAO.AggiungiVoce(VoceFattura item)
        {
            return true;
        }

        bool IAppuntamentoDAO.Crea(Appuntamento appuntamento)
        {
            return true;
        }

        bool IClienteDAO.Crea(Cliente cliente)
        {
            return true;
        }

        bool IDatoreLavoroDAO.Crea(DatoreLavoro nuovo)
        {
            return true;
        }

        bool IEsternoDAO.Crea(Esterno nuovo)
        {
            return true;
        }

        bool IFatturaDAO.Crea(Fattura nuova)
        {
            return true;
        }

        bool IMailInviataDAO.Crea(MailInviata nuova)
        {
            return true;
        }

        bool IIntermediarioDAO.Crea(Intermediario nuovo)
        {
            return true;
        }

        bool IPreventivoDAO.Crea(Preventivo nuovo)
        {
            return true;
        }

        bool IVenditaDAO.Crea(Vendita nuova)
        {
            return true;
        }

        bool IAppuntamentoDAO.Elimina(int ID)
        {
            return true;
        }

        bool IClienteDAO.Elimina(string IDCliente)
        {
            return true;
        }

        bool IDatoreLavoroDAO.Elimina(string ID)
        {
            return true;
        }

        bool IEsternoDAO.Elimina(string ID)
        {
            return true;
        }

        bool IFatturaDAO.Elimina(string numero, int anno)
        {
            return true;
        }

        bool IIntermediarioDAO.Elimina(string ID)
        {
            return true;
        }

        bool IPreventivoDAO.Elimina(ulong ID)
        {
            return true;
        }

        bool IVenditaDAO.Elimina(ulong ID)
        {
            return true;
        }

        List<MailInviata> IMailInviataDAO.GetListaMailInviate()
        {
            return new List<MailInviata>();
        }

        bool IPersonaDAO.InserisciEmail(Email email, Persona persona)
        {
            return true;
        }

        bool IClienteDAO.InserisciReferente(Referente referente, Cliente cliente)
        {
            return true;
        }

        bool IPersonaDAO.InserisciTelefono(Telefono telefono, Persona persona)
        {
            return true;
        }

        Appuntamento IAppuntamentoDAO.Leggi(string ID)
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

        Intermediario IIntermediarioDAO.Leggi(string ID)
        {
            return null;
        }

        List<Fattura> IFatturaDAO.LeggiTutteFatture()
        {
            return new List<Fattura>();
        }

        List<Vendita> IVenditaDAO.LeggiTutteVendite()
        {
            return new List<Vendita>();
        }

        List<Appuntamento> IAppuntamentoDAO.LeggiTuttiAppuntamenti()
        {
            return new List<Appuntamento>();
        }

        List<Cliente> IClienteDAO.LeggiTuttiClienti()
        {
            return new List<Cliente>();
        }

        List<DatoreLavoro> IDatoreLavoroDAO.LeggiTuttiDatoriLavoro()
        {
            return new List<DatoreLavoro>();
        }

        List<Preventivo> IPreventivoDAO.LeggiTuttiPreventivi()
        {
            return new List<Preventivo>();
        }

        bool IPersonaDAO.RimuoviEmail(Email email, Persona persona)
        {
            return true;
        }

        bool IClienteDAO.RimuoviReferente(Referente referente, Cliente cliente)
        {
            return true;
        }

        bool IPersonaDAO.RimuoviTelefono(Telefono telefono, Persona persona)
        {
            return true;
        }
    }
}