using System.Collections.Generic;
using JimHalpert.Application.Interface;
using JimHalpert.Application.ViewModel;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.DomainValidator;
using JimHalpert.Repository.Interfaces;

namespace JimHalpert.Application.Services
{
    public class ClienteServiceApp :BaseServiceApp, IClienteServiceApp
    {
        private readonly IClienteService service;
        public ClienteServiceApp(IClienteService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
        }

        public ValidationResult Gravar(ClienteViewModel cliente)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Cliente>(cliente);
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

        public ClienteViewModel ObterPorId(int id)
        {
            var avioes = service.ObterPorId(id);
            var retorno = Mapper.Map<ClienteViewModel>(avioes);
            return retorno;
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            var avioes = service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<ClienteViewModel>>(avioes);
            return retorno;

        }

        public IEnumerable<ClienteViewModel> Filtrar(string query)
        {
            var avioes = service.Filtrar(query);
            var retorno = Mapper.Map<IEnumerable<ClienteViewModel>>(avioes);
            return retorno;

        }
    }
}