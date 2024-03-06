using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface ITipoDeClienteService : IBaseService<TipoDeCliente> 
    {
        Task<ValidationResult> Gravar(TipoDeCliente tipoDeCliente);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<TipoDeCliente>> Filtrar(string query);
    }
}
