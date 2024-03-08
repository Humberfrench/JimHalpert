using Dietcode.Core.Lib;

namespace JimHalpert.Web.Models
{
    public class ModelBase
    {
        public ModelBase()
        {
            Erro = string.Empty;
            Mensagem = string.Empty;
            Caminho = string.Empty;
        }

        public string Erro { get; set; }
        public bool HasErro => !Erro.IsNullOrEmptyOrWhiteSpace();
        public string Mensagem { get; set; }
        public bool HasMensagem => !Mensagem.IsNullOrEmptyOrWhiteSpace();
        public string Caminho { get; set; }
    }
}
