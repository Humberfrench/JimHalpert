using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface IUsuarioServiceApp
    {
        MethodResult ObterTodos();
        MethodResult Filtrar(string query);
        MethodResult Gravar(UsuarioDadosViewModel Usuario);
        MethodResult Excluir(int id);
        MethodResult ObterPorId(int id);
    }
}