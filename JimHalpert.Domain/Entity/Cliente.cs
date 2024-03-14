﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace JimHalpert.Domain.Entity
{
    public partial class Cliente
    {
        public Cliente()
        {
            Faturamento = new List<Faturamento>();
            NotaFiscal = new List<NotaFiscal>();
            Tarefa = new List<Tarefa>();
        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Documento { get; set; }
        public int TipoDeClienteId { get; set; }
        public int TipoDePessoaId { get; set; }
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
        public int? EstadoId { get; set; }
        public int? CidadeId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual TipoDeCliente TipoDeCliente { get; set; }
        public virtual TipoDePessoa TipoDePessoa { get; set; }
        public virtual List<Faturamento> Faturamento { get; set; }
        public virtual List<NotaFiscal> NotaFiscal { get; set; }
        public virtual List<Tarefa> Tarefa { get; set; }
    }
}