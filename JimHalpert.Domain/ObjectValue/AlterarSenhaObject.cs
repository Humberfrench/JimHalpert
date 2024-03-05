using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.Domain.ObjectValue
{
    public class AlterarSenhaObject
    {
        public AlterarSenhaObject()
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
