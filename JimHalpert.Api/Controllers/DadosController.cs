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
    public class DadosController : ControllerBase
    {
        private readonly ITipoDePessoaServiceApp tipoDePessoaServiceApp;
        private readonly ITipoDeClienteServiceApp tipoDeClienteServiceApp;
        public DadosController(ITipoDePessoaServiceApp tipoDePessoaServiceApp, 
                                       ITipoDeClienteServiceApp tipoDeClienteServiceApp)
        {
            this.tipoDePessoaServiceApp = tipoDePessoaServiceApp;
            this.tipoDeClienteServiceApp = tipoDeClienteServiceApp;
        }

        [HttpGet("Tipo/Pessoa")]
        public IList<TipoDePessoaViewModel> ObterTiposDePessoas()
        {
            return tipoDePessoaServiceApp.ObterTodos().ToList();
        }
        [HttpGet("Tipo/Pessoa/{id}")]
        public TipoDePessoaViewModel ObterTipoDePessoa(int id)
        {
            return tipoDePessoaServiceApp.ObterPorId(id);
        }

        [HttpGet("Tipo/Cliente")]
        public IList<TipoDePessoaViewModel> ObterTiposDeClientes()
        {
            return tipoDePessoaServiceApp.ObterTodos().ToList();
        }
        [HttpGet("Tipo/Cliente/{id}")]
        public TipoDePessoaViewModel ObterTipoDeCliente(int id)
        {
            return tipoDePessoaServiceApp.ObterPorId(id);
        }
        //cidades
        [HttpGet("Tipo/Cliente")]
        public IList<TipoDePessoaViewModel> ObterTiposDeClientes()
        {
            return tipoDePessoaServiceApp.ObterTodos().ToList();
        }
        [HttpGet("Tipo/Cliente/{id}")]
        public TipoDePessoaViewModel ObterTipoDeCliente(int id)
        {
            return tipoDePessoaServiceApp.ObterPorId(id);
        }

    }
}