using System.Collections.Generic;
using System.Linq.Expressions;
using JimHalpert.Application.ViewModel;
using JimHalpert.DomainValidator;

namespace JimHalpert.Application.Interface
{
    public interface ITipoDeClienteServiceApp
    {
        IEnumerable<TipoDeClienteViewModel> ObterTodos();
        IEnumerable<TipoDeClienteViewModel> Filtrar(string query);
        ValidationResult Gravar(TipoDeClienteViewModel tipoDeCliente);
        ValidationResult Excluir(int id);
        TipoDeClienteViewModel ObterPorId(int id);
    }
}