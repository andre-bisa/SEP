﻿/*
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model;
using IngegneriaDelSoftware.Persistenza.Dao;

namespace IngegneriaDelSoftware.Persistenza.MySQL
{
    public class MySQLIntermediarioDAO : IIntermediarioDAO
    {
        public bool Aggiorna(Intermediario vecchio, Intermediario nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Crea(Intermediario nuovo)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string ID)
        {
            throw new NotImplementedException();
        }

        public Intermediario Leggi(string ID)
        {
            throw new NotImplementedException();
        }
    }
}