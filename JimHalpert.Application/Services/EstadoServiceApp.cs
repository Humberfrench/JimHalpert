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
    public class EstadoServiceApp : BaseServiceApp<EstadoViewModel>, IEstadoServiceApp
    {
        private readonly IEstadoService service;
        public EstadoServiceApp(IEstadoService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public MethodResult Gravar(EstadoViewModel estado)
        {
            BeginTransaction();
            var dadoIncluir = estado.ConvertObjects<Estado>();
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
            var estados = service.ObterPorId(id);
            var retorno = estados.ConvertObjects<EstadoViewModel>();
            if (retorno == null)
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);
        }

        public MethodResult ObterTodos()
        {
            var estados = service.ObterTodos();
            var retorno = estados.ConvertObjects<List<EstadoViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }

        public MethodResult Filtrar(string query)
        {
            var estados = service.Filtrar(query);
            var retorno = estados.ConvertObjects<List<EstadoViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }
    }
}