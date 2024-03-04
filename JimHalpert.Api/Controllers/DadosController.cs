using Dietcode.Api.Core;
using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JimHalpert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DadosController : ApiControllerBase
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
        public IActionResult ObterTiposDePessoas()
        {
            var retorno = tipoDePessoaServiceApp.ObterTodos();
            return Completed<List<TipoDePessoaViewModel>>(retorno);
        }

        [HttpGet("Tipo/Pessoa/{id}")]
        public IActionResult ObterTipoDePessoa(int id)
        {
            var retorno = tipoDePessoaServiceApp.ObterPorId(id);
            return Completed<TipoDePessoaViewModel>(retorno);
        }

        [HttpGet("Tipo/Cliente")]
        public IActionResult ObterTiposDeClientes()
        {
            var retorno = tipoDeClienteServiceApp.ObterTodos();
            return Completed<List<TipoDeClienteViewModel>>(retorno);
        }

        [HttpGet("Tipo/Cliente/{id}")]
        public IActionResult ObterTipoDeCliente(int id)
        {
            var retorno = tipoDeClienteServiceApp.ObterPorId(id);
            return Completed<TipoDeClienteViewModel>(retorno);
        }

        [HttpGet("Tipo/Cidade/{uf}")]
        public IActionResult ObterCidades(int uf)
        {
            var retorno = cidadeServiceApp.ObterCidades(uf);
            return Completed<List<CidadeViewModel>>(retorno);
        }

        [HttpGet("Tipo/Cidade/Obter/{id}")]
        public IActionResult ObterCidade(int id)
        {
            var retorno = cidadeServiceApp.ObterPorId(id);
            return Completed<CidadeViewModel>(retorno);
        }

        [HttpGet("Tipo/Estado")]
        public IActionResult ObterEstados()
        {
            var retorno = estadoServiceApp.ObterTodos();
            return Completed<List<EstadoViewModel>>(retorno);
        }

        [HttpGet("Tipo/Estado/{id}")]
        public IActionResult ObterEstado(int id)
        {
            var retorno = estadoServiceApp.ObterPorId(id);
            return Completed<EstadoViewModel>(retorno);
        }

    }
}