namespace JimHalpert.App.ViewModel
{
    public class TipoDePessoaViewModel
    {
        public TipoDePessoaViewModel()
        {
            Cliente = new HashSet<ClienteViewModel>();
        }

        public byte TipoDePessoaId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ClienteViewModel> Cliente { get; set; }

    }
}
