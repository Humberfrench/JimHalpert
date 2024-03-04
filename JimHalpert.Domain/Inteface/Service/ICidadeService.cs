using JimHalpert.Application.ObjectValue;
using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface ICidadeService : IBaseService<Cidade> 
    { 
        ValidationResult Gravar(Cidade cidade);
        ValidationResult Excluir(int id);
        IEnumerable<Cidade> Filtrar(string query);
        IEnumerable<CidadeValue> ObterCidades(int ufId);
    }
}
