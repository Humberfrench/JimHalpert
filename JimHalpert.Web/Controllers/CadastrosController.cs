using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace JimHalpert.Web.Controllers
{
    [Route("[controller]")]
    public class CadastrosController : Controller
    {
        //Cadastros de tipo de clientes, tipo de pessoas 
        //https://localhost:44311/Cadastros/Tipo/Pessoa

        private readonly ITipoDeClienteServiceApp tipoDeClienteServiceApp;
        private readonly ITipoDePessoaServiceApp tipoDePessoaServiceApp;

        public CadastrosController(ITipoDeClienteServiceApp tipoDeClienteServiceApp,
                                   ITipoDePessoaServiceApp tipoDePessoaServiceApp)
        {
            this.tipoDeClienteServiceApp = tipoDeClienteServiceApp;
            this.tipoDePessoaServiceApp = tipoDePessoaServiceApp;
        }

        #region Tipo de Pessoas

        [HttpGet("Tipo/Pessoa"),AllowAnonymous]
        public async Task<IActionResult> IndexTipoPessoa()
        {
            var model = new ModelViewItem<List<TipoDePessoaViewModel>>();

            model.Item = (await tipoDePessoaServiceApp.ObterTodos()).Content;

            return View("TipoPessoa", model);
        }

        [HttpGet("Tipo/Pessoa/New"),AllowAnonymous]
        public async Task<IActionResult> NewTipoPessoa()
        {
            var model = new ModelViewItem<TipoDePessoaViewModel>();


            model.Item = new TipoDePessoaViewModel();

            return View("TipoPessoaEdit", model);
        }

        [HttpGet("Tipo/Pessoa/Edit/{id}"),AllowAnonymous]
        public async Task<IActionResult> EditTipoPessoa(int id)
        {
            var model = new ModelViewItem<TipoDePessoaViewModel>();

            model.Item = (await tipoDePessoaServiceApp.ObterPorId(id)).Content;

            return View("TipoPessoaEdit", model);
        }

        [HttpPost("Tipo/Pessoa/Save"), AllowAnonymous]
        public async Task<IActionResult> SaveTipoPessoa(TipoDePessoaViewModel tipoDePessoa)
        {
            var model = new ModelViewItem<TipoDePessoaViewModel>();

            model.Item = tipoDePessoa;

            var retorno = (await tipoDePessoaServiceApp.Gravar(tipoDePessoa)).Content;

            if (retorno.Invalid)
            {
                model.Erro = string.Join('-', retorno.Erros);
            }
            else
            {
                model.Mensagem = "Registro salvo com sucesso!";
            }

            return View("TipoPessoaeEdit", model);
        }

        #endregion

        #region Tipo de Cliente

        [HttpGet("Tipo/Cliente"),AllowAnonymous]
        public async Task<IActionResult> IndexTipoCliente()
        {
            var model = new ModelViewItem<List<TipoDeClienteViewModel>>();

            model.Item = (await tipoDeClienteServiceApp.ObterTodos()).Content; 

            return View("TipoCliente", model);
        }

        [HttpGet("Tipo/Cliente/New"),AllowAnonymous]
        public async Task<IActionResult> NewTipoCliente()
        {
            var model = new ModelViewItem<TipoDeClienteViewModel>();

            model.Item = new TipoDeClienteViewModel();

            return View("TipoClienteEdit", model);
        }

        [HttpGet("Tipo/Cliente/Edit/{id}"),AllowAnonymous]
        public async Task<IActionResult> EditTipoCliente(int id)
        {
            var model = new ModelViewItem<TipoDeClienteViewModel>();

            model.Item = (await tipoDeClienteServiceApp.ObterPorId(id)).Content;

            return View("TipoClienteEdit", model);
        }

        [HttpPost("Tipo/Cliente/Save"), AllowAnonymous]
        public async Task<IActionResult> SaveTipoCliente(TipoDeClienteViewModel tipoDeCliente)
        {
            var model = new ModelViewItem<TipoDeClienteViewModel>();

            model.Item = tipoDeCliente;

            var retorno = (await tipoDeClienteServiceApp.Gravar(tipoDeCliente)).Content;

            if(retorno.Invalid)
            {
                model.Erro = string.Join('-', retorno.Erros);
            }
            else
            {
                model.Mensagem = "Registro salvo com sucesso!";
            }

            return View("TipoClienteEdit", model);
        }


        #endregion

    }


}
