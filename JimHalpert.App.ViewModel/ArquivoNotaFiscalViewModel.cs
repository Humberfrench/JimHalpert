namespace JimHalpert.App.ViewModel
{
    public class ArquivoNotaFiscalViewModel
    {
        public int ArquivoNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public byte[] Arquivo { get; set; }

        public virtual NotaFiscalViewModel NotaFiscal { get; set; }
    }
}
