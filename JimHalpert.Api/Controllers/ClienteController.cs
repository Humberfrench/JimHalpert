using Dietcode.Api.Core;
using Dietcode.Core.DomainValidator;
using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JimHalpert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ApiControllerBase
    {
        private readonly IClienteServiceApp clienteServiceApp;
        public ClientesController(IClienteServiceApp clienteServiceApp)
        {
            this.clienteServiceApp = clienteServiceApp;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var retorno = clienteServiceApp.ObterTodos();
            return Completed<List<ClienteViewModel>>(retorno);
        }

        [HttpGet("{id}")]
        public IActionResult Obter(int id)
        {
            var retorno = clienteServiceApp.ObterPorId(id);
            return Completed<ClienteViewModel>(retorno);
        }

        [HttpPost("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var retorno = clienteServiceApp.Excluir(id);
            return Completed<ValidationResult>(retorno);
        }

        [HttpPost("Gravar")]
        public IActionResult Gravar(ClienteViewModel cliente)
        {
            var retorno = clienteServiceApp.Gravar(cliente);
            return Completed<ValidationResult>(retorno);
        }

    }
}