using System.Collections.Generic;
using System.Linq.Expressions;
using Dietcode.Core.DomainValidator;
using JimHalpert.Application.ViewModel;

namespace JimHalpert.Application.Interface
{
    public interface ICidadeServiceApp
    {
        IEnumerable<CidadeViewModel> ObterTodos();
        IEnumerable<CidadeViewModel> Filtrar(string query);
        ValidationResult Gravar(CidadeViewModel cidade);
        ValidationResult Excluir(int id);
        CidadeViewModel ObterPorId(int id);
        IEnumerable<CidadeValueViewModel> ObterCidades(int ufId);
    }
}