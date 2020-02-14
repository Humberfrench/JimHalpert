using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JimHalpert.Application.Interface;
using JimHalpert.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoServiceApp servicoServiceApp;
        public ServicosController(IServicoServiceApp servicoServiceApp)
        {
            this.servicoServiceApp = servicoServiceApp;
        }

        [HttpGet]
        public IList<ServicoViewModel> ObterTodos()
        {
            return servicoServiceApp.ObterTodos().ToList();
        }
    }
}