using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface ITipoDePessoaService : IBaseService<TipoDePessoa> 
    {
        Task<ValidationResult> Gravar(TipoDePessoa tipoDePessoa);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<TipoDePessoa>> Filtrar(string query);
    }
}
