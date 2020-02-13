using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.DomainValidator;
using JimHalpert.Extensions;
using System.Collections.Generic;

namespace JimHalpert.Services
{
    public class ServicoService : BaseService<Servico>, IServicoService
    {
        private readonly IServicoRepository repository;
        private readonly ValidationResult validationResult;
        public ServicoService(IBaseRepository<Servico> baseRepository, IServicoRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public ValidationResult Gravar(Servico Servico)
        {
            //validate
            if (Servico.Descricao.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Descricao não preenchido");
                return validationResult;
            }

            //add or update
            if(Servico.ServicoId == 0)
            {
                base.Adicionar(Servico);
            }
            else
            {
                base.Atualizar(Servico);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var Servico = ObterPorId(id);
            if(Servico == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            base.Remover(Servico);
            
            return validationResult;
        }

        public IEnumerable<Servico> Filtrar(string query)
        {
            return repository.Filtrar(query);
        }
    }
}