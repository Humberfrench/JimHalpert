﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace JimHalpert.Domain.Entity
{
    public partial class StatusNotaFiscal
    {
        public StatusNotaFiscal()
        {
            NotaFiscal = new List<NotaFiscal>();
        }

        public int StatusNotaFiscalId { get; set; }
        public string Descricao { get; set; }

        public virtual List<NotaFiscal> NotaFiscal { get; set; }
    }
}