using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using JimHalpert.App.Services;
using JimHalpert.App.ViewModel;
using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JimHalpert.Application.Services
{
    public class CidadeServiceApp : BaseServiceApp<CidadeViewModel>, ICidadeServiceApp
    {
        private readonly ICidadeService service;
        public CidadeServiceApp(ICidadeService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public async Task<MethodResult> Gravar(CidadeViewModel cidade)
        {
            BeginTransaction();
            var dadoIncluir = cidade.ConvertObjects<Cidade>();
            var retorno = await service.Gravar(dadoIncluir);
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

        public async Task<MethodResult<CidadeViewModel>> ObterPorId(int id)
        {
            var cidades = await service.ObterPorId(id);
            var retorno = cidades.ConvertObjects<CidadeViewModel>();
            if (retorno == null)
            {
                return Ok(new CidadeViewModel());
            }

            return Ok(retorno);
        }

        public async Task<MethodResult<List<CidadeViewModel>>> ObterTodos()
        {
            var cidades = await service.ObterTodos();
            var retorno = cidades.ConvertObjects<List<CidadeViewModel>>();
            if (retorno == null)
            {
                return Ok(new List<CidadeViewModel>());
            }

            return Ok(retorno);

        }

        public async Task<MethodResult<List<CidadeViewModel>>> Filtrar(string query)
        {
            var cidades = await service.Filtrar(query);
            var retorno = cidades.ConvertObjects<List<CidadeViewModel>>();
            if (!retorno.Any())
            {
                return Ok(new List<CidadeViewModel>());
            }

            return Ok(retorno);

        }
        public async Task<MethodResult<List<CidadeViewModel>>> ObterCidades(int ufId)
        {
            var cidades = await service.ObterCidades(ufId);
            var retorno = cidades.ConvertObjects<List<CidadeViewModel>>();
            if (!retorno.Any())
            {
                return Ok(new List<CidadeViewModel>());
            }

            return Ok(retorno);

        }

    }
}