using Dietcode.Core.DomainValidator;

namespace JimHalpert.App.ViewModel.Interface
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