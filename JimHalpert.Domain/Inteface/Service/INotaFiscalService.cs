using JimHalpert.Application.ObjectValue;
using JimHalpert.Domain.Entity;
using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface INotaFiscalService : IBaseService<NotaFiscal> 
    {
        Task<ValidationResult> Gravar(NotaFiscal nf);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<NotaFiscal>> Filtrar(string query);
        Task<IEnumerable<StatusNotaFiscal>> StatusNotaFiscais();
        Task<StatusNotaFiscal> StatusNotaFiscalPorId(int id);
        Task<IEnumerable<Mes>> ObterListaMes();
    }
}
