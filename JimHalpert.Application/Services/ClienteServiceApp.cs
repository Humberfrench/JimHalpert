using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using System.Collections.Generic;
using System.Linq;

namespace JimHalpert.App.Services
{
    public class ClienteServiceApp : BaseServiceApp<ClienteViewModel>, IClienteServiceApp
    {
        private readonly IClienteService service;
        public ClienteServiceApp(IClienteService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public MethodResult Gravar(ClienteViewModel cliente)
        {
            BeginTransaction();
            var dadoIncluir = cliente.ConvertObjects<Cliente>();
            var retorno = service.Gravar(dadoIncluir);
            if (retorno.Valid)
            {
                //commit transaction
                Commit();
                //commit error
                if (!ValidationResults.Valid)
                {
                    return BadRequest(ConvertValidationErrors(ValidationResults.Erros.ToList()));
                }
            }
            return Ok(retorno);

        }

        public MethodResult Excluir(int id)
        {
            BeginTransaction();
            var retorno = service.Excluir(id);
            if (retorno.Valid)
            {
                //commit transaction
                Commit();
                //commit error
                if (!ValidationResults.Valid)
                {
                    return BadRequest(ConvertValidationErrors(ValidationResults.Erros.ToList()));
                }
            }
            return Ok(retorno);

        }

        public MethodResult ObterPorId(int id)
        {
            var clientes = service.ObterPorId(id);
            var retorno = clientes.ConvertObjects<ClienteViewModel>();
            if (retorno == null)
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);
        }

        public MethodResult ObterTodos()
        {
            var clientes = service.ObterTodos();
            var retorno = clientes.ConvertObjects<List<ClienteViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }

        public MethodResult Filtrar(string query)
        {
            var clientes = service.Filtrar(query);
            var retorno = clientes.ConvertObjects<List<ClienteViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }
    }
}