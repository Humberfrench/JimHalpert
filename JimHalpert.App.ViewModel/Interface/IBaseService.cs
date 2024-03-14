using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface IBaseService <T>
    {
        Task<MethodResult<List<T>>> ObterTodos();
        Task<MethodResult<List<T>>> Filtrar(string query);
        Task<MethodResult<ValidationResult>> Gravar(T dado);
        Task<MethodResult> Excluir(int id);
        Task<MethodResult<T>> ObterPorId(int id);

    }
}
