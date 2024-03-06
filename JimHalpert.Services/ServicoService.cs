using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<ValidationResult> Gravar(Servico servico)
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
                await base.Adicionar(servico);
            }
            else
            {
                await base.Atualizar(servico);
            }

            return validationResult;
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var servico = await ObterPorId(id);
            if(servico == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            await base.Remover(servico);
            
            return validationResult;
        }

        public async Task<IEnumerable<Servico>> Filtrar(string query)
        {
            return await repository.Filtrar(query);
        }
    }
}