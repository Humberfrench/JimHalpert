using System;
using System.Collections.Generic;

namespace JimHalpert.Application.ViewModel
{
    public class AviaoViewModel
    {
        public int AviaoId { get; set; }
        public string Modelo { get; set; }
        public int QuantidadeDePassageiros { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
