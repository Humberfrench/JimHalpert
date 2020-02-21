using System.Collections.Generic;
using System.Linq.Expressions;
using JimHalpert.Application.ViewModel;
using JimHalpert.DomainValidator;

namespace JimHalpert.Application.Interface
{
    public interface ICidadeServiceApp
    {
        IEnumerable<CidadeViewModel> ObterTodos();
        IEnumerable<CidadeViewModel> Filtrar(string query);
        ValidationResult Gravar(CidadeViewModel cidade);
        ValidationResult Excluir(int id);
        CidadeViewModel ObterPorId(int id);
        IEnumerable<CidadeViewModel> ObterCidades(int ufId);
    }
}