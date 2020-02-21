using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JimHalpert.Application.Interface;
using JimHalpert.Application.ViewModel;
using JimHalpert.DomainValidator;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DadosController : ControllerBase
    {
        private readonly ITipoDePessoaServiceApp tipoDePessoaServiceApp;
        private readonly ITipoDeClienteServiceApp tipoDeClienteServiceApp;
        private readonly ICidadeServiceApp cidadeServiceApp;
        private readonly IEstadoServiceApp estadoServiceApp;
        public DadosController(ITipoDePessoaServiceApp tipoDePessoaServiceApp, 
                               ITipoDeClienteServiceApp tipoDeClienteServiceApp, 
                               ICidadeServiceApp cidadeServiceApp, 
                               IEstadoServiceApp estadoServiceApp)
        {
            this.tipoDePessoaServiceApp = tipoDePessoaServiceApp;
            this.tipoDeClienteServiceApp = tipoDeClienteServiceApp;
            this.cidadeServiceApp = cidadeServiceApp;
            this.estadoServiceApp = estadoServiceApp;
        }

        [HttpGet("Tipo/Pessoa")]
        public IList<TipoDePessoaViewModel> ObterTiposDePessoas()
        {
            return tipoDePessoaServiceApp.ObterTodos().ToList();
        }

        [HttpGet("Tipo/Pessoa/{id}")]
        public TipoDePessoaViewModel ObterTipoDePessoa(int id)
        {
            return tipoDePessoaServiceApp.ObterPorId(id);
        }

        [HttpGet("Tipo/Cliente")]
        public IList<TipoDeClienteViewModel> ObterTiposDeClientes()
        {
            return tipoDeClienteServiceApp.ObterTodos().ToList();
        }

        [HttpGet("Tipo/Cliente/{id}")]
        public TipoDeClienteViewModel ObterTipoDeCliente(int id)
        {
            return tipoDeClienteServiceApp.ObterPorId(id);
        }

        [HttpGet("Tipo/Cidade/{uf}")]
        public IList<CidadeViewModel> ObterCidades(int uf)
        {
            return cidadeServiceApp.ObterCidades(uf).ToList();
        }

        [HttpGet("Tipo/Cidade/Obter/{id}")]
        public CidadeViewModel ObterCidade(int id)
        {
            return cidadeServiceApp.ObterPorId(id);
        }

        [HttpGet("Tipo/Estado")]
        public IList<EstadoViewModel> ObterEstados()
        {
            return estadoServiceApp.ObterTodos().ToList();
        }

        [HttpGet("Tipo/Estado/{id}")]
        public EstadoViewModel ObterEstado(int id)
        {
            return estadoServiceApp.ObterPorId(id);
        }

    }
}