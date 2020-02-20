using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.DomainValidator;
using JimHalpert.Extensions;
using System.Collections.Generic;

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

        public ValidationResult Gravar(TipoDeCliente tipoDeCliente)
        {
            //validate

            if (tipoDeCliente.Descricao.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Descricao não preenchido");
                return validationResult;
            }

            //add or update
            if(tipoDeCliente.TipoDeClienteId == 0)
            {
                base.Adicionar(tipoDeCliente);
            }
            else
            {
                base.Atualizar(tipoDeCliente);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var tipoDeCliente = ObterPorId(id);
            if(tipoDeCliente == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            base.Remover(tipoDeCliente);
            
            return validationResult;
        }

        public IEnumerable<TipoDeCliente> Filtrar(string query)
        {
            return repository.Filtrar(query);
        }
    }
}