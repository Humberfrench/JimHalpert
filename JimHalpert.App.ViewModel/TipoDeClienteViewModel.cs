namespace JimHalpert.App.ViewModel
{
    public class TipoDeClienteViewModel
    {
        public TipoDeClienteViewModel()
        {
            Cliente = new HashSet<ClienteViewModel>();
        }

        public byte TipoDeClienteId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ClienteViewModel> Cliente { get; set; }
    }
}
