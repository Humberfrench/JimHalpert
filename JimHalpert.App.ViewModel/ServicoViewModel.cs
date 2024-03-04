namespace JimHalpert.App.ViewModel
{
    public class ServicoViewModel
    {
        public ServicoViewModel()
        {
            TarefaItem = new HashSet<TarefaItemViewModel>();
        }

        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<TarefaItemViewModel> TarefaItem { get; set; }

    }
}
