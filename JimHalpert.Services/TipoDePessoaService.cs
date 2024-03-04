using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using JimHalpert.Extensions;
using System.Collections.Generic;

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

        public ValidationResult Gravar(TipoDePessoa tipoDePessoa)
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
                base.Adicionar(tipoDePessoa);
            }
            else
            {
                base.Atualizar(tipoDePessoa);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var tipoDePessoa = ObterPorId(id);
            if(tipoDePessoa == null)
            {
                validationResult.Add("Tipo de Pessoa inexistente");
                return validationResult;
            }

            base.Remover(tipoDePessoa);
            
            return validationResult;
        }

        public IEnumerable<TipoDePessoa> Filtrar(string query)
        {
            return repository.Filtrar(query);
        }
    }
}