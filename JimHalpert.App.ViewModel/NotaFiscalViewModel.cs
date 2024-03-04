namespace JimHalpert.App.ViewModel
{
    public class NotaFiscalViewModel
    {
        public NotaFiscalViewModel()
        {
            ArquivoNotaFiscal = new HashSet<ArquivoNotaFiscalViewModel>();
            ComposicaoNotaFiscal = new HashSet<ComposicaoNotaFiscalViewModel>();
            TributoNotaFiscal = new HashSet<TributoNotaFiscalViewModel>();
        }

        public int NotaFiscalId { get; set; }
        public string Numero { get; set; }
        public int ClienteId { get; set; }
        public string CodigoVerificacao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal ImpostoTotalRetido { get; set; }
        public decimal ValorLiquido { get; set; }
        public string Descricao { get; set; }
        public byte StatusNotaFiscalId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
        public virtual StatusNotaFiscalViewModel StatusNotaFiscal { get; set; }
        public virtual ICollection<ArquivoNotaFiscalViewModel> ArquivoNotaFiscal { get; set; }
        public virtual ICollection<ComposicaoNotaFiscalViewModel> ComposicaoNotaFiscal { get; set; }
        public virtual ICollection<TributoNotaFiscalViewModel> TributoNotaFiscal { get; set; }
    }
}
