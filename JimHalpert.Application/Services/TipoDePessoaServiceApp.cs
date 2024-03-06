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
    public class TipoDePessoaServiceApp : BaseServiceApp<TipoDePessoaViewModel>, ITipoDePessoaServiceApp
    {
        private readonly ITipoDePessoaService service;

        public TipoDePessoaServiceApp(ITipoDePessoaService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public async Task<MethodResult> Gravar(TipoDePessoaViewModel tipoDePessoa)
        {
            BeginTransaction();
            var dadoIncluir = tipoDePessoa.ConvertObjects<TipoDePessoa>(); //Mapper.Map<TipoDePessoa>(tipoDePessoa);
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
                Commit();
                if (!ValidationResults.Valid)
                {
                    return BadRequest(ConvertValidationErrors(ValidationResults.Erros.ToList()));
                }
            }
            return Ok(retorno);
        }

        public async Task<MethodResult> ObterPorId(int id)
        {
            var tipoDePessoas = await service.ObterPorId(id);
            var retorno = tipoDePessoas.ConvertObjects<TipoDePessoaViewModel>();
            if (retorno == null)
            {
                return NotFound("Não foi encontrado registros");
            }
            return Ok(retorno);
        }

        public async Task<MethodResult> ObterTodos()
        {
            var tipoDePessoas = await service.ObterTodos();
            var retorno = tipoDePessoas.ConvertObjects<List<TipoDePessoaViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }
            return Ok(retorno);
        }

        public async Task<MethodResult> Filtrar(string query)
        {
            var tipoDePessoas = await service.Filtrar(query);
            var retorno = tipoDePessoas.ConvertObjects<List<TipoDePessoaViewModel>>();
            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }
            return Ok(retorno);
        }
    }
}