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
    public class ServicosController : ApiControllerBase
    {
        private readonly IServicoServiceApp servicoServiceApp;
        public ServicosController(IServicoServiceApp servicoServiceApp)
        {
            this.servicoServiceApp = servicoServiceApp;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var retorno = await servicoServiceApp.ObterTodos();
            return Completed<List<ServicoViewModel>>(retorno);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var retorno = await servicoServiceApp.ObterPorId(id);
            return Completed<ServicoViewModel>(retorno);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var retorno = await servicoServiceApp.Excluir(id);
            return Completed<ValidationResult>(retorno);
        }

        [HttpPost("Gravar")]
        public async Task<IActionResult> Gravar(ServicoViewModel servico)
        {
            var retorno = await servicoServiceApp.Gravar(servico);
            return Completed<ValidationResult>(retorno);
        }

    }
}