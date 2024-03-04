using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface ITipoDePessoaService : IBaseService<TipoDePessoa> 
    { 
        ValidationResult Gravar(TipoDePessoa tipoDePessoa);
        ValidationResult Excluir(int id);
        IEnumerable<TipoDePessoa> Filtrar(string query);
    }
}
