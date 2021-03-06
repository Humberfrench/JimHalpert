﻿using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IServicoRepository : IBaseRepository<Servico>
    {
        IEnumerable<Servico> Filtrar(string query);

    }
}
