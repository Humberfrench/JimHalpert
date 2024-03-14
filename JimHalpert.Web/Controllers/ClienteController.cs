using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    [Route("[controller]"), AllowAnonymous]
    public class ClienteController : Controller
    {
        private readonly IClienteServiceApp clienteServiceApp;
        private readonly ICidadeServiceApp cidadeServiceApp;
        private readonly IEstadoServiceApp estadoServiceApp;
        private readonly ITipoDeClienteServiceApp tipoDeClienteServiceApp;
        private readonly ITipoDePessoaServiceApp tipoDePessoaServiceApp;




        public ClienteController(IClienteServiceApp clienteServiceApp,
                                 ICidadeServiceApp cidadeServiceApp,
                                 IEstadoServiceApp estadoServiceApp,
                                 ITipoDeClienteServiceApp tipoDeClienteServiceApp,
                                 ITipoDePessoaServiceApp tipoDePessoaServiceApp)
        {
            this.clienteServiceApp = clienteServiceApp;
            this.cidadeServiceApp = cidadeServiceApp;
            this.estadoServiceApp = estadoServiceApp;
            this.tipoDeClienteServiceApp = tipoDeClienteServiceApp;
            this.tipoDePessoaServiceApp = tipoDePessoaServiceApp;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var clientes = (await clienteServiceApp.ObterTodos()).Content;

            var model = new ModelViewItem<List<ClienteViewModel>>();
            model.Item = clientes;

            return View(model);
        }

        [HttpGet("Edit/{id}"), AllowAnonymous]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new ModelViewItem<ClienteViewModel>();

            //validar cidade com o estado   
            ViewBag.Cidades = (await cidadeServiceApp.ObterTodos()).Content;
            ViewBag.Estados = (await estadoServiceApp.ObterTodos()).Content;
            ViewBag.TiposDeCliente = (await tipoDeClienteServiceApp.ObterTodos()).Content;
            ViewBag.TiposDePessoa = (await tipoDePessoaServiceApp.ObterTodos()).Content;

            model.Item = (await clienteServiceApp.ObterPorId(id)).Content;

            return View("Edit", model);
        }


    }
}
