namespace JimHalpert.App.ViewModel
{
    public class TributoViewModel
    {
        public TributoViewModel()
        {
            TributoNotaFiscal = new HashSet<TributoNotaFiscalViewModel>();
        }

        public int TributoId { get; set; }
        public string Descricao { get; set; }
        public decimal Percentual { get; set; }
        public bool RetemNaNota { get; set; }
        public decimal FaixaInicial { get; set; }
        public decimal FaixaFinal { get; set; }
        public decimal ValorDeducao { get; set; }

        public virtual ICollection<TributoNotaFiscalViewModel> TributoNotaFiscal { get; set; }
    }
}
