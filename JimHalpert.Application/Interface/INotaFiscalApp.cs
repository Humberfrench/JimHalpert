using System.Collections.Generic;
using System.Linq.Expressions;
using JimHalpert.Application.ViewModel;
using Dietcode.Core.DomainValidator;

namespace JimHalpert.Application.Interface
{
    public interface INotaFiscalServiceApp
    {
        IEnumerable<NotaFiscalViewModel> ObterTodos();
        IEnumerable<NotaFiscalViewModel> Filtrar(string query);
        ValidationResult Gravar(NotaFiscalViewModel servico);
        ValidationResult Excluir(int id);
        NotaFiscalViewModel ObterPorId(int id);
        IEnumerable<StatusNotaFiscalViewModel> StatusNotaFiscais();
        StatusNotaFiscalViewModel StatusNotaFiscalPorId(int id);
        IEnumerable<MesViewModel> ObterListaMes();

    }
}