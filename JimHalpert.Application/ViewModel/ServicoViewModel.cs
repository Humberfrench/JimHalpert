using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Application.ViewModel
{
    public class ServicoViewModel
    {
        public ServicoViewModel()
        {
            TarefaItem = new HashSet<TarefaItemViewModel>();
        }

        public int ServicoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<TarefaItemViewModel> TarefaItem { get; set; }

    }
}
