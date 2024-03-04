using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface ICidadeServiceApp
    {
        MethodResult ObterTodos();
        MethodResult Filtrar(string query);
        MethodResult Gravar(CidadeViewModel cidade);
        MethodResult Excluir(int id);
        MethodResult ObterPorId(int id);
        MethodResult ObterCidades(int ufId);
    }
}