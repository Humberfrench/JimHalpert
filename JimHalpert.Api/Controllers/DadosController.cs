using Dietcode.Api.Core;
using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ObterTiposDePessoas()
        {
            var retorno = await tipoDePessoaServiceApp.ObterTodos();
            return Completed<List<TipoDePessoaViewModel>>(retorno);
        }

        [HttpGet("Tipo/Pessoa/{id}")]
        public async Task<IActionResult> ObterTipoDePessoa(int id)
        {
            var retorno = await tipoDePessoaServiceApp.ObterPorId(id);
            return Completed<TipoDePessoaViewModel>(retorno);
        }

        [HttpGet("Tipo/Cliente")]
        public async Task<IActionResult> ObterTiposDeClientes()
        {
            var retorno = await tipoDeClienteServiceApp.ObterTodos();
            return Completed<List<TipoDeClienteViewModel>>(retorno);
        }

        [HttpGet("Tipo/Cliente/{id}")]
        public async Task<IActionResult> ObterTipoDeCliente(int id)
        {
            var retorno = await tipoDeClienteServiceApp.ObterPorId(id);
            return Completed<TipoDeClienteViewModel>(retorno);
        }

        [HttpGet("Tipo/Cidade/{uf}")]
        public async Task<IActionResult> ObterCidades(int uf)
        {
            var retorno = await cidadeServiceApp.ObterCidades(uf);
            return Completed<List<CidadeViewModel>>(retorno);
        }

        [HttpGet("Tipo/Cidade/Obter/{id}")]
        public async Task<IActionResult> ObterCidade(int id)
        {
            var retorno = await cidadeServiceApp.ObterPorId(id);
            return Completed<CidadeViewModel>(retorno);
        }

        [HttpGet("Tipo/Estado")]
        public async Task<IActionResult> ObterEstados()
        {
            var retorno = await estadoServiceApp.ObterTodos();
            return Completed<List<EstadoViewModel>>(retorno);
        }

        [HttpGet("Tipo/Estado/{id}")]
        public async Task<IActionResult> ObterEstado(int id)
        {
            var retorno = await estadoServiceApp.ObterPorId(id);
            return Completed<EstadoViewModel>(retorno);
        }

    }
}