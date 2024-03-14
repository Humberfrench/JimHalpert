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
using System.Threading.Tasks;

namespace JimHalpert.App.Services
{
    public class ClienteServiceApp : BaseServiceApp<ClienteViewModel>, IClienteServiceApp
    {
        private readonly IClienteService service;
        public ClienteServiceApp(IClienteService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public async Task<MethodResult<ValidationResult>> Gravar(ClienteViewModel cliente)
        {
            BeginTransaction();
            var dadoIncluir = cliente.ConvertObjects<Cliente>();
            var retorno = await service.Gravar(dadoIncluir);
            if (retorno.Valid)
            {
                //commit transaction
                Commit();
                //commit error
                if (!ValidationResults.Valid)
                {
                    return Ok(retorno);
                }
            }
            return Ok(retorno);

        }

        public async Task<MethodResult> Excluir(int id)
        {
            BeginTransaction();
            var retorno = await service.Excluir(id);
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

        public async Task<MethodResult<ClienteViewModel>> ObterPorId(int id)
        {
            var clientes = await service.ObterPorId(id);
            var retorno = clientes.ConvertObjects<ClienteViewModel>();
            if (retorno == null)
            {
                return Ok(new ClienteViewModel());
            }

            return Ok(retorno);
        }

        public async Task<MethodResult<List<ClienteViewModel>>> ObterTodos()
        {
            var clientes = await service.ObterTodos();
            var retorno = clientes.ConvertObjects<List<ClienteViewModel>>();
            if (!retorno.Any())
            {
                return Ok(new List<ClienteViewModel>());
            }

            return Ok(retorno);

        }

        public async Task<MethodResult<List<ClienteViewModel>>> Filtrar(string query)
        {
            var clientes = await service.Filtrar(query);
            var retorno = clientes.ConvertObjects<List<ClienteViewModel>>();
            if (!retorno.Any())
            {
                return Ok(new List<ClienteViewModel>());
            }

            return Ok(retorno);

        }
    }
}