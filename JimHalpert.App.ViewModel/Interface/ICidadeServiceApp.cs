using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface ICidadeServiceApp : IBaseService<CidadeViewModel>
    {
        Task<MethodResult<List<CidadeViewModel>>> ObterCidades(int ufId);
    }
}