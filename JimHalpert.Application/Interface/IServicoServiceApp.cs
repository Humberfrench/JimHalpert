using System.Collections.Generic;
using System.Linq.Expressions;
using JimHalpert.Application.ViewModel;
using JimHalpert.DomainValidator;

namespace JimHalpert.Application.Interface
{
    public interface IServicoServiceApp
    {
        IEnumerable<ServicoViewModel> ObterTodos();
        IEnumerable<ServicoViewModel> Filtrar(string query);
        ValidationResult Gravar(ServicoViewModel servico);
        ValidationResult Excluir(int id);
        ServicoViewModel ObterPorId(int id);
    }
}