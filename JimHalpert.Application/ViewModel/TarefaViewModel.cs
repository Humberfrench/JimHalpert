using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Application.ViewModel
{
    public class TarefaViewModel
    {
        public TarefaViewModel()
        {
            //ComposicaoNotaFiscal = new HashSet<ComposicaoNotaFiscal>();
            TarefaItem = new HashSet<TarefaItemViewModel>();
        }

        public int TarefaId { get; set; }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public decimal? ValorOrcado { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        //public virtual ClienteViewModel Cliente { get; set; }
        //public virtual ICollection<ComposicaoNotaFiscalViewModel> ComposicaoNotaFiscal { get; set; }
        public virtual ICollection<TarefaItemViewModel> TarefaItem { get; set; }

    }
}
