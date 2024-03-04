using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface ITipoDeClienteServiceApp
    {
        MethodResult ObterTodos();
        MethodResult Filtrar(string query);
        MethodResult Gravar(TipoDeClienteViewModel tipoDeCliente);
        MethodResult Excluir(int id);
        MethodResult ObterPorId(int id);
    }
}