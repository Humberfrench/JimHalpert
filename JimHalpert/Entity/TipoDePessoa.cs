﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace JimHalpert.Entity
{
    public partial class TipoDePessoa
    {
        public TipoDePessoa()
        {
            Cliente = new HashSet<Cliente>();
        }

        public byte TipoDePessoaId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}