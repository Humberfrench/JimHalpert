using System.Collections.Generic;
using JimHalpert.Application.Interface;
using JimHalpert.Application.ViewModel;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.DomainValidator;
using JimHalpert.Repository.Interfaces;

namespace JimHalpert.Application.Services
{
    public class TipoDePessoaServiceApp :BaseServiceApp, ITipoDePessoaServiceApp
    {
        private readonly ITipoDePessoaService service;
        public TipoDePessoaServiceApp(ITipoDePessoaService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public ValidationResult Gravar(TipoDePessoaViewModel tipoDePessoa)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<TipoDePessoa>(tipoDePessoa);
            var retorno = service.Gravar(dadoIncluir);
            if(retorno.IsValid)
            {
                //commit transaction
                Commit();
                //commit error
                if(!ValidationResults.IsValid)
                {
                    return ValidationResults;
                }
            }
            return retorno;

        }

        public ValidationResult Excluir(int id)
        {
            BeginTransaction();
            var retorno = service.Excluir(id);
            if (retorno.IsValid)
            {
                //commit transaction
                Commit();
                //commit error
                if (!ValidationResults.IsValid)
                {
                    return ValidationResults;
                }
            }
            return retorno;

        }

        public TipoDePessoaViewModel ObterPorId(int id)
        {
            var tipoDePessoas = service.ObterPorId(id);
            var retorno = Mapper.Map<TipoDePessoaViewModel>(tipoDePessoas);
            return retorno;
        }

        public IEnumerable<TipoDePessoaViewModel> ObterTodos()
        {
            var tipoDePessoas = service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<TipoDePessoaViewModel>>(tipoDePessoas);
            return retorno;

        }

        public IEnumerable<TipoDePessoaViewModel> Filtrar(string query)
        {
            var tipoDePessoas = service.Filtrar(query);
            var retorno = Mapper.Map<IEnumerable<TipoDePessoaViewModel>>(tipoDePessoas);
            return retorno;

        }
    }
}