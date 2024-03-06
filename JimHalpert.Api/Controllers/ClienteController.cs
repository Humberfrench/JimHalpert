using Dietcode.Api.Core;
using Dietcode.Core.DomainValidator;
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
    public class ClientesController : ApiControllerBase
    {
        private readonly IClienteServiceApp clienteServiceApp;
        public ClientesController(IClienteServiceApp clienteServiceApp)
        {
            this.clienteServiceApp = clienteServiceApp;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var retorno = await clienteServiceApp.ObterTodos();
            return Completed<List<ClienteViewModel>>(retorno);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var retorno = await clienteServiceApp.ObterPorId(id);
            return Completed<ClienteViewModel>(retorno);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var retorno = await clienteServiceApp.Excluir(id);
            return Completed<ValidationResult>(retorno);
        }

        [HttpPost("Gravar")]
        public async Task<IActionResult> Gravar(ClienteViewModel cliente)
        {
            var retorno = await clienteServiceApp.Gravar(cliente);
            return Completed<ValidationResult>(retorno);
        }

    }
}