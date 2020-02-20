using System.Collections.Generic;
using JimHalpert.Application.Interface;
using JimHalpert.Application.ViewModel;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.DomainValidator;
using JimHalpert.Repository.Interfaces;

namespace JimHalpert.Application.Services
{
    public class TipoDeClienteServiceApp :BaseServiceApp, ITipoDeClienteServiceApp
    {
        private readonly ITipoDeClienteService service;
        public TipoDeClienteServiceApp(ITipoDeClienteService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public ValidationResult Gravar(TipoDeClienteViewModel tipoDeCliente)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<TipoDeCliente>(tipoDeCliente);
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

        public TipoDeClienteViewModel ObterPorId(int id)
        {
            var avioes = service.ObterPorId(id);
            var retorno = Mapper.Map<TipoDeClienteViewModel>(avioes);
            return retorno;
        }

        public IEnumerable<TipoDeClienteViewModel> ObterTodos()
        {
            var avioes = service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<TipoDeClienteViewModel>>(avioes);
            return retorno;

        }

        public IEnumerable<TipoDeClienteViewModel> Filtrar(string query)
        {
            var avioes = service.Filtrar(query);
            var retorno = Mapper.Map<IEnumerable<TipoDeClienteViewModel>>(avioes);
            return retorno;

        }
    }
}