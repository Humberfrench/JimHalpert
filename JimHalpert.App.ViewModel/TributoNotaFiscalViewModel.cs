namespace JimHalpert.App.ViewModel
{
    public class TributoNotaFiscalViewModel
    {
        public int TributoNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public int TributoId { get; set; }
        public decimal Total { get; set; }

        public virtual NotaFiscalViewModel NotaFiscal { get; set; }
        public virtual TributoViewModel Tributo { get; set; }
    }
}
