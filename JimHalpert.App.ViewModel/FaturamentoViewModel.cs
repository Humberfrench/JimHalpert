namespace JimHalpert.App.ViewModel
{
    public class FaturamentoViewModel
    {
        public int FaturamentoId { get; set; }
        public int ClienteId { get; set; }
        public short Ano { get; set; }
        public byte Mes { get; set; }
        public decimal Valor { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}
