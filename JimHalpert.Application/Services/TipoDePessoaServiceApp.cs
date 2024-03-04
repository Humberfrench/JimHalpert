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
    public class TipoDePessoaServiceApp : BaseServiceApp<TipoDePessoaViewModel>, ITipoDePessoaServiceApp
    {
        private readonly ITipoDePessoaService service;

        public TipoDePessoaServiceApp(ITipoDePessoaService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public MethodResult Gravar(TipoDePessoaViewModel tipoDePessoa)
        {
            BeginTransaction();
            var dadoIncluir = tipoDePessoa.ConvertObjects<TipoDePessoa>(); //Mapper.Map<TipoDePessoa>(tipoDePessoa);
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
            var tipoDePessoas = service.ObterPorId(id);
            var retorno = tipoDePessoas.ConvertObjects<TipoDePessoaViewModel>(); //Mapper.Map<TipoDePessoaViewModel>(tipoDePessoas);

            if(retorno == null)
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);
        }

        public MethodResult ObterTodos()
        {
            var tipoDePessoas = service.ObterTodos();
            var retorno = tipoDePessoas.ConvertObjects<List<TipoDePessoaViewModel>>(); //Mapper.Map<IEnumerable<TipoDePessoaViewModel>>(tipoDePessoas);

            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }

        public MethodResult Filtrar(string query)
        {
            var tipoDePessoas = service.Filtrar(query);
            var retorno = tipoDePessoas.ConvertObjects<List<TipoDePessoaViewModel>>(); //Mapper.Map<IEnumerable<TipoDePessoaViewModel>>(tipoDePessoas);

            if (!retorno.Any())
            {
                return NotFound("Não foi encontrado registros");
            }

            return Ok(retorno);

        }
    }
}