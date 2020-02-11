using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Application.ViewModel
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            //Faturamento = new HashSet<FaturamentoViewModel>();
            //NotaFiscal = new HashSet<NotaFiscalViewModel>();
            Tarefa = new HashSet<TarefaViewModel>();
        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Documento { get; set; }
        public byte TipoDeClienteId { get; set; }
        public byte TipoDePessoaId { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CadastroMunicipal { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int? CidadeId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual CidadeViewModel Cidade { get; set; }
        public virtual TipoDeClienteViewModel TipoDeCliente { get; set; }
        public virtual TipoDePessoaViewModel TipoDePessoa { get; set; }
        public virtual ICollection<FaturamentoViewModel> Faturamento { get; set; }
        public virtual ICollection<NotaFiscalViewModel> NotaFiscal { get; set; }
        public virtual ICollection<TarefaViewModel> Tarefa { get; set; }

    }
}
