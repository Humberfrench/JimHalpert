using JimHalpert.Domain.Entity;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IEstadoRepository: IBaseRepository<Estado>
    {
        IEnumerable<Estado> Filtrar(string query);
    }
}