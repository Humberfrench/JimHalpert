using System.Collections.Generic;
using JimHalpert.Application.Interface;
using JimHalpert.Application.ViewModel;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.DomainValidator;
using JimHalpert.Repository.Interfaces;

namespace JimHalpert.Application.Services
{
    public class EstadoServiceApp :BaseServiceApp, IEstadoServiceApp
    {
        private readonly IEstadoService service;
        public EstadoServiceApp(IEstadoService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public ValidationResult Gravar(EstadoViewModel aviao)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Estado>(aviao);
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

        public EstadoViewModel ObterPorId(int id)
        {
            var avioes = service.ObterPorId(id);
            var retorno = Mapper.Map<EstadoViewModel>(avioes);
            return retorno;
        }

        public IEnumerable<EstadoViewModel> ObterTodos()
        {
            var avioes = service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<EstadoViewModel>>(avioes);
            return retorno;

        }

        public IEnumerable<EstadoViewModel> Filtrar(string query)
        {
            var avioes = service.Filtrar(query);
            var retorno = Mapper.Map<IEnumerable<EstadoViewModel>>(avioes);
            return retorno;

        }
    }
}