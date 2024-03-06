using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Services
{
    public class EstadoService : BaseService<Estado>, IEstadoService
    {
        private readonly IEstadoRepository repository;
        private readonly ValidationResult validationResult;
        public EstadoService(IBaseRepository<Estado> baseRepository, IEstadoRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Gravar(Estado aviao)
        {
            //validate
            if (aviao.NomeUf.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Nome não preenchido");
                return validationResult;
            }

            if (aviao.SiglaUf.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Sigla Uf não preenchido");
                return validationResult;
            }

            //add or update
            if(aviao.EstadoId == 0)
            {
                await base.Adicionar(aviao);
            }
            else
            {
                await base.Atualizar(aviao);
            }

            return validationResult;
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var aviao = await ObterPorId(id);
            if(aviao == null)
            {
                validationResult.Add("Avião inexistente");
                return validationResult;
            }

            await base.Remover(aviao);

            return validationResult;
        }

        public async Task<IEnumerable<Estado>> Filtrar(string query)
        {
            return await repository.Filtrar(query);
        }
    }
}