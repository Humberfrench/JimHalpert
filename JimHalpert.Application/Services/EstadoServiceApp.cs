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
    public class EstadoServiceApp : BaseServiceApp<EstadoViewModel>, IEstadoServiceApp
    {
        private readonly IEstadoService service;
        public EstadoServiceApp(IEstadoService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public async Task<MethodResult<ValidationResult>> Gravar(EstadoViewModel estado)
        {
            BeginTransaction();
            var dadoIncluir = estado.ConvertObjects<Estado>();
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

        public async Task<MethodResult<EstadoViewModel>> ObterPorId(int id)
        {
            var estados = await service.ObterPorId(id);
            var retorno = estados.ConvertObjects<EstadoViewModel>();
            if (retorno == null)
            {
                return Ok(new EstadoViewModel());
            }

            return Ok(retorno);
        }

        public async Task<MethodResult<List<EstadoViewModel>>> ObterTodos()
        {
            var estados = await service.ObterTodos();
            var retorno = estados.ConvertObjects<List<EstadoViewModel>>();
            if (!retorno.Any())
            {
                return Ok(new List<EstadoViewModel>());
            }

            return Ok(retorno);

        }

        public async Task<MethodResult<List<EstadoViewModel>>> Filtrar(string query)
        {
            var estados = await service.Filtrar(query);
            var retorno = estados.ConvertObjects<List<EstadoViewModel>>();
            if (!retorno.Any())
            {
                return Ok(new List<EstadoViewModel>());
            }

            return Ok(retorno);

        }
    }
}