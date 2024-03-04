using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface IClienteServiceApp
    {
        MethodResult ObterTodos();
        MethodResult Filtrar(string query);
        MethodResult Gravar(ClienteViewModel cliente);
        MethodResult Excluir(int id);
        MethodResult ObterPorId(int id);
    }
}