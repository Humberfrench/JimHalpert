using JimHalpert.Application.ObjectValue;
using JimHalpert.Domain.Entity;
using JimHalpert.DomainValidator;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface INotaFiscalService : IBaseService<NotaFiscal> 
    { 
        ValidationResult Gravar(NotaFiscal nf);
        ValidationResult Excluir(int id);
        IEnumerable<NotaFiscal> Filtrar(string query);
        IEnumerable<StatusNotaFiscal> StatusNotaFiscais();
        StatusNotaFiscal StatusNotaFiscalPorId(int id);
        IEnumerable<Mes> ObterListaMes();
    }
}
