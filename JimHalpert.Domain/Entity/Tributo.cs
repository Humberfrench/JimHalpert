﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace JimHalpert.Domain.Entity
{
    public partial class Tributo
    {
        public Tributo()
        {
            TributoNotaFiscal = new List<TributoNotaFiscal>();
        }

        public int TributoId { get; set; }
        public string Descricao { get; set; }
        public decimal Percentual { get; set; }
        public bool RetemNaNota { get; set; }
        public decimal FaixaInicial { get; set; }
        public decimal FaixaFinal { get; set; }
        public decimal ValorDeducao { get; set; }

        public virtual List<TributoNotaFiscal> TributoNotaFiscal { get; set; }
    }
}