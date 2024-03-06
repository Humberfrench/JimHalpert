using Dietcode.Api.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface IBaseService <T>
    {
        Task<MethodResult> ObterTodos();
        Task<MethodResult> Filtrar(string query);
        Task<MethodResult> Gravar(T dado);
        Task<MethodResult> Excluir(int id);
        Task<MethodResult> ObterPorId(int id);

    }
}
