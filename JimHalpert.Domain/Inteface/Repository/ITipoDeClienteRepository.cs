using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface ITipoDeClienteRepository : IBaseRepository<TipoDeCliente>
    {
        Task<IEnumerable<TipoDeCliente>> Filtrar(string query);

    }
}
