using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    [Route("[controller]")]
    public class CadastrosController : Controller
    {
        //Cadastros de tipo de clientes, tipo de pessoas 
        private readonly ITipoDeClienteServiceApp tipoDeClienteServiceApp;
        private readonly ITipoDePessoaServiceApp tipoDePessoaServiceApp;

        public CadastrosController(ITipoDeClienteServiceApp tipoDeClienteServiceApp,
                                   ITipoDePessoaServiceApp tipoDePessoaServiceApp)
        {
            this.tipoDeClienteServiceApp = tipoDeClienteServiceApp;
            this.tipoDePessoaServiceApp = tipoDePessoaServiceApp;
        }

        #region Tipo de Pessoas

        [HttpGet("Tipo/Pessoa")]
        public async Task<IActionResult> IndexTipoPessoa()
        {
            var model = new ModelViewItem<List<TipoDePessoaViewModel>>();

            model.Item = (await tipoDePessoaServiceApp.ObterTodos()).Content;

            return View("TipoPessoa");
        }

        [HttpGet("Tipo/Pessoa/New")]
        public async Task<IActionResult> IndexTipoPessoaNew()
        {
            var model = new ModelViewItem<TipoDePessoaViewModel>();

            model.Item = new TipoDePessoaViewModel();

            return View("TipoPessoaEdit");
        }

        [HttpGet("Tipo/Pessoa/Edit/{id}")]
        public async Task<IActionResult> IndexTipoPessoaEdit(int id)
        {
            var model = new ModelViewItem<TipoDePessoaViewModel>();

            model.Item = (await tipoDePessoaServiceApp.ObterPorId(id)).Content;

            return View("TipoPessoaEdit");
        }
        #endregion

        #region Tipo de Pessoas

        [HttpGet("Tipo/Cliente")]
        public async Task<IActionResult> IndexTipoCliente()
        {
            var model = new ModelViewItem<List<TipoDeClienteViewModel>>();

            model.Item = (await tipoDeClienteServiceApp.ObterTodos()).Content; 

            return View("TipoCliente");
        }

        [HttpGet("Tipo/Cliente/New")]
        public async Task<IActionResult> IndexTipoClienteNew()
        {
            var model = new ModelViewItem<TipoDeClienteViewModel>();

            model.Item = new TipoDeClienteViewModel();

            return View("TipoClienteEdit");
        }

        [HttpGet("Tipo/Cliente/Edit/{id}")]
        public async Task<IActionResult> IndexTipoClienteEdit(int id)
        {
            var model = new ModelViewItem<TipoDeClienteViewModel>();

            model.Item = (await tipoDeClienteServiceApp.ObterPorId(id)).Content;

            return View("TipoClienteEdit");
        }
        #endregion

    }
}
