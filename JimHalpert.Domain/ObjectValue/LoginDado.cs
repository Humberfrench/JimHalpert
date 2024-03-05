using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.Domain.ObjectValue
{
    public class LoginDado
    {
        public LoginDado()
        {
            Login = string.Empty;
            Senha = string.Empty;

        }

        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
