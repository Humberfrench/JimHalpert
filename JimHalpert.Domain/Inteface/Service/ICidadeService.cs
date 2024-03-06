using JimHalpert.Application.ObjectValue;
using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface ICidadeService : IBaseService<Cidade> 
    { 
        Task<ValidationResult> Gravar(Cidade cidade);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<Cidade>> Filtrar(string query);
        Task<IEnumerable<CidadeValue>> ObterCidades(int ufId);
    }
}
