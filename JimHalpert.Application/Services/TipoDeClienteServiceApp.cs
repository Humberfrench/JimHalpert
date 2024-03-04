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
    public class TipoDeClienteServiceApp : BaseServiceApp<TipoDeCliente>, ITipoDeClienteServiceApp
    {
        private readonly ITipoDeClienteService service;
        public TipoDeClienteServiceApp(ITipoDeClienteService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public MethodResult Gravar(TipoDeClienteViewModel tipoDeCliente)
        {
            BeginTransaction();
            var dadoIncluir = tipoDeCliente.ConvertObjects<TipoDeCliente>(); //Mapper.Map<TipoDeCliente>(tipoDeCliente);
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
            var tipoDeCliente = service.ObterPorId(id);
            var retorno = tipoDeCliente.ConvertObjects<TipoDeClienteViewModel>(); //Mapper.Map<TipoDeClienteViewModel>(tipoDeClientes);
            if (retorno == null)
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);
        }

        public MethodResult ObterTodos()
        {
            var tipoDeClientes = service.ObterTodos();
            var retorno = tipoDeClientes.ConvertObjects<List<TipoDeClienteViewModel>>();//Mapper.Map<IEnumerable<TipoDeClienteViewModel>>(tipoDeClientes);
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);


        }

        public MethodResult Filtrar(string query)
        {
            var tipoDeClientes = service.Filtrar(query);
            var retorno = tipoDeClientes.ConvertObjects<List<TipoDeClienteViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);


        }
    }
}