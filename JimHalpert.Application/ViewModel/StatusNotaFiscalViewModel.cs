using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Application.ViewModel
{
    public class StatusNotaFiscalViewModel
    {
        public StatusNotaFiscalViewModel()
        {
            NotaFiscal = new HashSet<NotaFiscalViewModel>();
        }

        public byte StatusNotaFiscalId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<NotaFiscalViewModel> NotaFiscal { get; set; }

    }
}
