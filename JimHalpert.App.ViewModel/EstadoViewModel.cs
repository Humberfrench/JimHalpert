﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace JimHalpert.App.ViewModel
{
    public partial class EstadoViewModel
    {
        public EstadoViewModel()
        {
            Cidade = new HashSet<CidadeViewModel>();
        }

        public short EstadoId { get; set; }
        public string SiglaUf { get; set; }
        public string NomeUf { get; set; }

        public virtual ICollection<CidadeViewModel> Cidade { get; set; }
    }
}