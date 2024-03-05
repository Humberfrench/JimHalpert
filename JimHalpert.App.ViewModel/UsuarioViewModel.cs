using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.App.ViewModel
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Documento { get; set; }
        public int TentativasInvalidas { get; set; }
        public byte[] Senha { get; set; }
        public string SenhaTexto { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataLogin { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime ValidadeSenha { get; set; }
        public bool Admin { get; set; }
        public bool Ativo { get; set; }
    }
}
