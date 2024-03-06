using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IServicoService : IBaseService<Servico> 
    {
        Task<ValidationResult> Gravar(Servico servico);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<Servico>> Filtrar(string query);
    }
}
