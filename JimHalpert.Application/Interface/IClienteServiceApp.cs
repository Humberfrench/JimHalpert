using System.Collections.Generic;
using System.Linq.Expressions;
using JimHalpert.Application.ViewModel;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.Application.Interface
{
    public interface IClienteServiceApp
    {
        IEnumerable<ClienteViewModel> ObterTodos();
        IEnumerable<ClienteViewModel> Filtrar(string query);
        ValidationResult Gravar(ClienteViewModel cliente);
        ValidationResult Excluir(int id);
        ClienteViewModel ObterPorId(int id);
    }
}