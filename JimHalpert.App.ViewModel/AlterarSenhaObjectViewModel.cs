using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.App.ViewModel
{
    public class AlterarSenhaObjectViewModel
    {
        public AlterarSenhaObjectViewModel()
        {
            Login = string.Empty;
            SenhaNova = string.Empty;
            SenhaAtual = string.Empty;

        }

        public string Login { get; set; }
        public string SenhaNova { get; set; }
        public string SenhaAtual { get; set; }
    }
}
