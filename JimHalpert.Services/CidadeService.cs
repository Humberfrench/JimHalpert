using JimHalpert.Application.ObjectValue;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System.Collections.Generic;

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

        public ValidationResult Gravar(Cidade cidade)
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
                base.Adicionar(cidade);
            }
            else
            {
                base.Atualizar(cidade);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var tipoDePessoa = ObterPorId(id);
            if(tipoDePessoa == null)
            {
                validationResult.Add("Cidade inexistente");
                return validationResult;
            }

            base.Remover(tipoDePessoa);
            
            return validationResult;
        }

        public IEnumerable<Cidade> Filtrar(string query)
        {
            return repository.Filtrar(query);
        }

        public IEnumerable<CidadeValue> ObterCidades(int ufId)
        {
            return repository.ObterCidades(ufId);
        }
    }
}