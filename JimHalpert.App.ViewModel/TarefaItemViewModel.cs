namespace JimHalpert.App.ViewModel
{
    public class TarefaItemViewModel
    {
        public int TarefaItemId { get; set; }
        public int TarefaId { get; set; }
        public byte Ordem { get; set; }
        public string Descricao { get; set; }
        public int ServicoId { get; set; }
        public int HorasOrcadas { get; set; }
        public int HorasGastas { get; set; }
        public decimal ValorHora { get; set; }

        public virtual ServicoViewModel Servico { get; set; }
        public virtual TarefaViewModel Tarefa { get; set; }

    }
}
