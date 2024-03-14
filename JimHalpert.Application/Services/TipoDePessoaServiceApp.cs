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

        public async Task<MethodResult<ValidationResult>> Gravar(TipoDePessoaViewModel TipoDePessoa)
        {
            BeginTransaction();
            var dadoIncluir = TipoDePessoa.ConvertObjects<TipoDePessoa>(); //Mapper.Map<TipoDePessoa>(TipoDePessoa);
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

        public async Task<MethodResult<TipoDePessoaViewModel>> ObterPorId(int id)
        {
            var TipoDePessoa = await service.ObterPorId(id);
            var retorno = TipoDePessoa.ConvertObjects<TipoDePessoaViewModel>(); //Mapper.Map<TipoDePessoaViewModel>(TipoDePessoas);
            if (retorno == null)
            {
                return Ok(new TipoDePessoaViewModel());
            }

            return Ok(retorno);
        }

        public async Task<MethodResult<List<TipoDePessoaViewModel>>> ObterTodos()
        {
            var TipoDePessoas = await service.ObterTodos();
            var retorno = TipoDePessoas.ConvertObjects<List<TipoDePessoaViewModel>>();//Mapper.Map<IEnumerable<TipoDePessoaViewModel>>(TipoDePessoas);
            if (!retorno.Any())
            {
                return Ok(new List<TipoDePessoaViewModel>());
            }

            return Ok(retorno);


        }

        public async Task<MethodResult<List<TipoDePessoaViewModel>>> Filtrar(string query)
        {
            var TipoDePessoas = await service.Filtrar(query);
            var retorno = TipoDePessoas.ConvertObjects<List<TipoDePessoaViewModel>>();
            if (!retorno.Any())
            {
                return Ok(new List<TipoDePessoaViewModel>());
            }

            return Ok(retorno);


        }
    }
}