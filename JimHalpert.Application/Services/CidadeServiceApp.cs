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

namespace JimHalpert.Application.Services
{
    public class CidadeServiceApp : BaseServiceApp<CidadeViewModel>, ICidadeServiceApp
    {
        private readonly ICidadeService service;
        public CidadeServiceApp(ICidadeService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public MethodResult Gravar(CidadeViewModel cidade)
        {
            BeginTransaction();
            var dadoIncluir = cidade.ConvertObjects<Cidade>();
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
            var cidades = service.ObterPorId(id);
            var retorno = cidades.ConvertObjects<CidadeViewModel>();
            return Ok(retorno);
        }

        public MethodResult ObterTodos()
        {
            var cidades = service.ObterTodos();
            var retorno = cidades.ConvertObjects<List<CidadeViewModel>>();
            if (retorno == null)
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }

        public MethodResult Filtrar(string query)
        {
            var cidades = service.Filtrar(query);
            var retorno = cidades.ConvertObjects<List<CidadeViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }
        public MethodResult ObterCidades(int ufId)
        {
            var cidades = service.ObterCidades(ufId);
            var retorno = cidades.ConvertObjects<List<CidadeViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }

    }
}