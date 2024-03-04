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
    public class ServicosController : ApiControllerBase
    {
        private readonly IServicoServiceApp servicoServiceApp;
        public ServicosController(IServicoServiceApp servicoServiceApp)
        {
            this.servicoServiceApp = servicoServiceApp;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var retorno = servicoServiceApp.ObterTodos();
            return Completed<List<ServicoViewModel>>(retorno);
        }

        [HttpGet("{id}")]
        public IActionResult Obter(int id)
        {
            var retorno = servicoServiceApp.ObterPorId(id);
            return Completed<ServicoViewModel>(retorno);
        }

        [HttpPost("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var retorno = servicoServiceApp.Excluir(id);
            return Completed<ValidationResult>(retorno);
        }

        [HttpPost("Gravar")]
        public IActionResult Gravar(ServicoViewModel servico)
        {
            var retorno = servicoServiceApp.Gravar(servico);
            return Completed<ValidationResult>(retorno);
        }

    }
}