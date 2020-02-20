using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using JimHalpert.DomainValidator;
using JimHalpert.Extensions;
using System.Collections.Generic;

namespace JimHalpert.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository repository;
        private readonly ValidationResult validationResult;
        public ClienteService(IBaseRepository<Cliente> baseRepository, IClienteRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public ValidationResult Gravar(Cliente Cliente)
        {
            ////validate
            //if (Cliente.Nome.IsNullOrEmptyOrWhiteSpace())
            //{
            //    validationResult.Add("Nome não preenchido");
            //    return validationResult;
            //}

            //if (Cliente.Descricao.IsNullOrEmptyOrWhiteSpace())
            //{
            //    validationResult.Add("Descricao não preenchido");
            //    return validationResult;
            //}

            //add or update
            if(Cliente.ClienteId == 0)
            {
                base.Adicionar(Cliente);
            }
            else
            {
                base.Atualizar(Cliente);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var Cliente = ObterPorId(id);
            if(Cliente == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            base.Remover(Cliente);
            
            return validationResult;
        }

        public IEnumerable<Cliente> Filtrar(string query)
        {
            return repository.Filtrar(query);
        }
    }
}