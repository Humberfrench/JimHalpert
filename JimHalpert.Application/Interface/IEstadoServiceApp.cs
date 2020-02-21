using System.Collections.Generic;
using System.Linq.Expressions;
using JimHalpert.Application.ViewModel;
using JimHalpert.DomainValidator;

namespace JimHalpert.Application.Interface
{
    public interface IEstadoServiceApp
    {
        IEnumerable<EstadoViewModel> ObterTodos();
        IEnumerable<EstadoViewModel> Filtrar(string query);
        ValidationResult Gravar(EstadoViewModel aviao);
        ValidationResult Excluir(int id);
        EstadoViewModel ObterPorId(int id);
    }
}