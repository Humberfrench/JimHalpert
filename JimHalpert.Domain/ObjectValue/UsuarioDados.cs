using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.Domain.ObjectValue
{
    public class UsuarioDados
    {
        public UsuarioDados()
        {
            Login = string.Empty;
            Nome = string.Empty;
            Email = string.Empty;
            Celular = string.Empty;
            Documento = string.Empty;
            SenhaTexto = string.Empty;

        }

        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Documento { get; set; }
        public string SenhaTexto { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Admin { get; set; }
        public bool Ativo { get; set; }
    }
}
