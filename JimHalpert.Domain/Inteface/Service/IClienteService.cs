using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IClienteService : IBaseService<Cliente> 
    { 
        ValidationResult Gravar(Cliente cliente);
        ValidationResult Excluir(int id);
        IEnumerable<Cliente> Filtrar(string query);
    }
}
