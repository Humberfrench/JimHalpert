using JimHalpert.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IEstadoRepository: IBaseRepository<Estado>
    {
        Task<IEnumerable<Estado>> Filtrar(string query);
    }
}