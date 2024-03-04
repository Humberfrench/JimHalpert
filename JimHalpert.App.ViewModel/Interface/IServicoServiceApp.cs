using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface IServicoServiceApp
    {
        MethodResult ObterTodos();
        MethodResult Filtrar(string query);
        MethodResult Gravar(ServicoViewModel servico);
        MethodResult Excluir(int id);
        MethodResult ObterPorId(int id);
    }
}