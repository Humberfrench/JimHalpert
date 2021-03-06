﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Application.ViewModel
{
    public class ComposicaoNotaFiscalViewModel
    {
        public int ComposicaoNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public int TarefaId { get; set; }
        public decimal Total { get; set; }

        public virtual NotaFiscalViewModel NotaFiscal { get; set; }
        public virtual TarefaViewModel Tarefa { get; set; }
    }
}
