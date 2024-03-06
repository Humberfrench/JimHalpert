using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository repository;
        private readonly ValidationResult validationResult;
        public ClienteService(IBaseRepository<Cliente> baseRepository, 
                              IClienteRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Gravar(Cliente cliente)
        {
            //validate
            if (cliente.Nome.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Nome não preenchido");
                return validationResult;
            }

            if (cliente.RazaoSocial.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Razão Social não preenchido");
                return validationResult;
            }

            if (cliente.Documento.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Documento não preenchido");
                return validationResult;
            }

            if (cliente.TipoDeClienteId == 0)
            {
                validationResult.Add("Tipo De Cliente não preenchido");
                return validationResult;
            }
            if (cliente.TipoDePessoaId == 0)
            {
                validationResult.Add("Tipo De Pessoa não preenchido");
                return validationResult;
            }

            //add or update
            if (cliente.ClienteId == 0)
            {
                cliente.DataAlteracao = DateTime.Now;
                cliente.DataCriacao = DateTime.Now;
                await base.Adicionar(cliente);
            }
            else
            {
                cliente.DataAlteracao = DateTime.Now;
                await base.Atualizar(cliente);
            }

            return validationResult;
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var cliente = await ObterPorId(id);
            if(cliente == null)
            {
                validationResult.Add("Cliente inexistente");
                return validationResult;
            }

            await base.Remover(cliente);

            return validationResult;
        }

        public async Task<IEnumerable<Cliente>> Filtrar(string query)
        {
            return await repository.Filtrar(query);
        }
    }
}