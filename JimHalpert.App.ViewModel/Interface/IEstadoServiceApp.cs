using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface IEstadoServiceApp
    {
        MethodResult ObterTodos();
        MethodResult Filtrar(string query);
        MethodResult Gravar(EstadoViewModel aviao);
        MethodResult Excluir(int id);
        MethodResult ObterPorId(int id);
    }
}