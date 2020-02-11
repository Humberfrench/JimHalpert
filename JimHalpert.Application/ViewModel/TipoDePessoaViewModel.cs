using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Application.ViewModel
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
