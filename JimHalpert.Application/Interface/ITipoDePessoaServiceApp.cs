using System.Collections.Generic;
using System.Linq.Expressions;
using JimHalpert.Application.ViewModel;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.Application.Interface
{
    public interface ITipoDePessoaServiceApp
    {
        IEnumerable<TipoDePessoaViewModel> ObterTodos();
        IEnumerable<TipoDePessoaViewModel> Filtrar(string query);
        ValidationResult Gravar(TipoDePessoaViewModel tipoDePessoa);
        ValidationResult Excluir(int id);
        TipoDePessoaViewModel ObterPorId(int id);
    }
}