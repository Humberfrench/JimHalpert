using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface IUsuarioServiceApp: IBaseService<UsuarioViewModel>
    {
        Task<MethodResult> Gravar(UsuarioDadosViewModel Usuario);
    }
}