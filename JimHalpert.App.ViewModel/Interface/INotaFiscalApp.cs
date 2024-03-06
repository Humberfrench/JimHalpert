using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;

namespace JimHalpert.App.ViewModel.Interface
{
    public interface INotaFiscalServiceApp : IBaseService<NotaFiscalViewModel>
    {
        Task<IEnumerable<StatusNotaFiscalViewModel>> StatusNotaFiscais();
        Task<StatusNotaFiscalViewModel> StatusNotaFiscalPorId(int id);
        Task<IEnumerable<MesViewModel>> ObterListaMes();

    }
}