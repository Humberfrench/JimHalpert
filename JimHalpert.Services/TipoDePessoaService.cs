using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Services
{
    public class TipoDePessoaService : BaseService<TipoDePessoa>, ITipoDePessoaService
    {
        private readonly ITipoDePessoaRepository repository;
        private readonly ValidationResult validationResult;
        public TipoDePessoaService(IBaseRepository<TipoDePessoa> baseRepository, ITipoDePessoaRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Gravar(TipoDePessoa tipoDePessoa)
        {
            //validate

            if (tipoDePessoa.Descricao.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Descricao não preenchido");
                return validationResult;
            }

            //add or update
            if(tipoDePessoa.TipoDePessoaId == 0)
            {
                await base.Adicionar(tipoDePessoa);
            }
            else
            {
                await base.Atualizar(tipoDePessoa);
            }

            return validationResult;
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDePessoa = await ObterPorId(id);
            if(tipoDePessoa == null)
            {
                validationResult.Add("Tipo de Pessoa inexistente");
                return validationResult;
            }

            await base.Remover(tipoDePessoa);
            
            return validationResult;
        }

        public async Task<IEnumerable<TipoDePessoa>> Filtrar(string query)
        {
            return await repository.Filtrar(query);
        }
    }
}