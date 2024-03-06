using JimHalpert.Application.ObjectValue;
using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        Task<IEnumerable<Cidade>> Filtrar(string query);
        Task<IEnumerable<CidadeValue>> ObterCidades(int ufId);
    }
}
