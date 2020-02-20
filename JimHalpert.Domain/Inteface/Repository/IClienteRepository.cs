using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        IEnumerable<Cliente> Filtrar(string query);

    }
}
