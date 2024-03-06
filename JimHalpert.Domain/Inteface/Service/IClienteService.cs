using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IClienteService : IBaseService<Cliente> 
    {
        Task<ValidationResult> Gravar(Cliente cliente);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<Cliente>> Filtrar(string query);
    }
}
