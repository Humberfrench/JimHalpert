using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IServicoService : IBaseService<Servico> 
    { 
        ValidationResult Gravar(Servico servico);
        ValidationResult Excluir(int id);
        IEnumerable<Servico> Filtrar(string query);
    }
}
