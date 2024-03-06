using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IEstadoService:IBaseService<Estado>
    {
        Task<ValidationResult> Gravar(Estado aviao);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<Estado>> Filtrar(string query);
    }
}