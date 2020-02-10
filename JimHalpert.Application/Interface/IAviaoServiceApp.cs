using System.Collections.Generic;
using System.Linq.Expressions;
using JimHalpert.Application.ViewModel;
using JimHalpert.DomainValidator;

namespace JimHalpert.Application.Interface
{
    public interface IAviaoServiceApp
    {
        IEnumerable<AviaoViewModel> ObterTodos();
        IEnumerable<AviaoViewModel> Filtrar(string query);
        ValidationResult Gravar(AviaoViewModel aviao);
        ValidationResult Excluir(int id);
        AviaoViewModel ObterPorId(int id);
    }
}