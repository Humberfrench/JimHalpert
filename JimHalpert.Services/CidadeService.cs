using JimHalpert.Application.ObjectValue;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Services
{
    public class CidadeService : BaseService<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository repository;
        private readonly ValidationResult validationResult;
        public CidadeService(IBaseRepository<Cidade> baseRepository, ICidadeRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Gravar(Cidade cidade)
        {
            //validate

            if (cidade.Nome.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Nome não preenchido");
                return validationResult;
            }

            //add or update
            if(cidade.CidadeId == 0)
            {
                await base.Adicionar(cidade);
            }
            else
            {
                await base.Atualizar(cidade);
            }

            return validationResult;
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDePessoa = await ObterPorId(id);
            if(tipoDePessoa == null)
            {
                validationResult.Add("Cidade inexistente");
                return validationResult;
            }

            await base.Remover(tipoDePessoa);

            return validationResult;
        }

        public async Task<IEnumerable<Cidade>> Filtrar(string query)
        {
            return await repository.Filtrar(query);
        }

        public async Task<IEnumerable<CidadeValue>> ObterCidades(int ufId)
        {
            return await repository.ObterCidades(ufId);
        }
    }
}