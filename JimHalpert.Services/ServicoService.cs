using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
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

        public ValidationResult Gravar(Servico servico)
        {
            //validate
            if (servico.Nome.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Nome não preenchido");
                return validationResult;
            }

            if (servico.Descricao.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Descricao não preenchido");
                return validationResult;
            }

            //add or update
            if(servico.ServicoId == 0)
            {
                base.Adicionar(servico);
            }
            else
            {
                base.Atualizar(servico);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var servico = ObterPorId(id);
            if(servico == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            base.Remover(servico);
            
            return validationResult;
        }

        public IEnumerable<Servico> Filtrar(string query)
        {
            return repository.Filtrar(query);
        }
    }
}