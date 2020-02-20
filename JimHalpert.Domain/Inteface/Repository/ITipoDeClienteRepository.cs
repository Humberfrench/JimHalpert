using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface ITipoDeClienteRepository : IBaseRepository<TipoDeCliente>
    {
        IEnumerable<TipoDeCliente> Filtrar(string query);

    }
}
