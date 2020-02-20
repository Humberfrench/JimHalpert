using System.Collections.Generic;
using JimHalpert.Application.Interface;
using JimHalpert.Application.ViewModel;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.DomainValidator;
using JimHalpert.Repository.Interfaces;

namespace JimHalpert.Application.Services
{
    public class ServicoServiceApp :BaseServiceApp, IServicoServiceApp
    {
        private readonly IServicoService service;
        public ServicoServiceApp(IServicoService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public ValidationResult Gravar(ServicoViewModel servico)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Servico>(servico);
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

        public ServicoViewModel ObterPorId(int id)
        {
            var avioes = service.ObterPorId(id);
            var retorno = Mapper.Map<ServicoViewModel>(avioes);
            return retorno;
        }

        public IEnumerable<ServicoViewModel> ObterTodos()
        {
            var avioes = service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<ServicoViewModel>>(avioes);
            return retorno;

        }

        public IEnumerable<ServicoViewModel> Filtrar(string query)
        {
            var avioes = service.Filtrar(query);
            var retorno = Mapper.Map<IEnumerable<ServicoViewModel>>(avioes);
            return retorno;

        }
    }
}