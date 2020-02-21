using System.Collections.Generic;
using JimHalpert.Application.Interface;
using JimHalpert.Application.ViewModel;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.DomainValidator;
using JimHalpert.Repository.Interfaces;

namespace JimHalpert.Application.Services
{
    public class CidadeServiceApp :BaseServiceApp, ICidadeServiceApp
    {
        private readonly ICidadeService service;
        public CidadeServiceApp(ICidadeService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public ValidationResult Gravar(CidadeViewModel cidade)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Cidade>(cidade);
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

        public CidadeViewModel ObterPorId(int id)
        {
            var cidades = service.ObterPorId(id);
            var retorno = Mapper.Map<CidadeViewModel>(cidades);
            return retorno;
        }

        public IEnumerable<CidadeViewModel> ObterTodos()
        {
            var cidades = service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<CidadeViewModel>>(cidades);
            return retorno;

        }

        public IEnumerable<CidadeViewModel> Filtrar(string query)
        {
            var cidades = service.Filtrar(query);
            var retorno = Mapper.Map<IEnumerable<CidadeViewModel>>(cidades);
            return retorno;

        }
        public IEnumerable<CidadeValueViewModel> ObterCidades(int ufId)
        {
            var cidades = service.ObterCidades(ufId);
            var retorno = Mapper.Map<IEnumerable<CidadeValueViewModel>>(cidades);
            return retorno;

        }

    }
}