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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServiceApp servicoServiceApp;
        public ClientesController(IClienteServiceApp servicoServiceApp)
        {
            this.servicoServiceApp = servicoServiceApp;
        }

        [HttpGet]
        public IList<ClienteViewModel> ObterTodos()
        {
            return servicoServiceApp.ObterTodos().ToList();
        }
        [HttpGet("{id}")]
        public ClienteViewModel Obter(int id)
        {
            return servicoServiceApp.ObterPorId(id);
        }

        [HttpPost("Excluir/{id}")]
        public ValidationResult Excluir(int id)
        {
            return servicoServiceApp.Excluir(id);
        }
        [HttpPost("Gravar")]
        public ValidationResult Gravar(ClienteViewModel cliente)
        {
            return servicoServiceApp.Gravar(cliente);
        }

    }
}