using JimHalpert.Domain.Entity;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IAviaoRepository: IBaseRepository<Aviao>
    {
        IEnumerable<Aviao> Filtrar(string query);
    }
}