using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IServicoRepository : IBaseRepository<Servico>
    {
        Task<IEnumerable<Servico>> Filtrar(string query);

    }
}
