﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace JimHalpert.Entity
{
    public partial class TarefaItem
    {
        public int TarefaItemId { get; set; }
        public int TarefaId { get; set; }
        public byte Ordem { get; set; }
        public string Descricao { get; set; }
        public int ServicoId { get; set; }
        public int HorasOrcadas { get; set; }
        public int HorasGastas { get; set; }
        public decimal ValorHora { get; set; }

        public virtual Servico Servico { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}