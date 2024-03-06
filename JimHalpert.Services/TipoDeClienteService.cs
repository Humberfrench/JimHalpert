using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Services
{
    public class TipoDeClienteService : BaseService<TipoDeCliente>, ITipoDeClienteService
    {
        private readonly ITipoDeClienteRepository repository;
        private readonly ValidationResult validationResult;
        public TipoDeClienteService(IBaseRepository<TipoDeCliente> baseRepository, ITipoDeClienteRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Gravar(TipoDeCliente tipoDeCliente)
        {
            //validate

            if (tipoDeCliente.Descricao.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Descricao não preenchido");
                return validationResult;
            }

            //add or update
            if (tipoDeCliente.TipoDeClienteId == 0)
            {
                await base.Adicionar(tipoDeCliente);
            }
            else
            {
                await base.Atualizar(tipoDeCliente);
            }

            return validationResult;
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDeCliente = await ObterPorId(id);
            if (tipoDeCliente == null)
            {
                validationResult.Add("Tipo de Cliente inexistente");
                return validationResult;
            }

            await base.Remover(tipoDeCliente);

            return validationResult;
        }

        public async Task<IEnumerable<TipoDeCliente>> Filtrar(string query)
        {
            return await repository.Filtrar(query);
        }
    }
}