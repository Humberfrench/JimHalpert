using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface ITipoDePessoaServiceApp
    {
        MethodResult ObterTodos();
        MethodResult Filtrar(string query);
        MethodResult Gravar(TipoDePessoaViewModel tipoDePessoa);
        MethodResult Excluir(int id);
        MethodResult ObterPorId(int id);
    }
}