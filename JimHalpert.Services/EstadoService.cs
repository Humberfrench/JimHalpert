using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using JimHalpert.Extensions;
using System.Collections.Generic;

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

        public ValidationResult Gravar(Estado aviao)
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
                base.Adicionar(aviao);
            }
            else
            {
                base.Atualizar(aviao);
            }

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var aviao = ObterPorId(id);
            if(aviao == null)
            {
                validationResult.Add("Avião inexistente");
                return validationResult;
            }

            base.Remover(aviao);
            
            return validationResult;
        }

        public IEnumerable<Estado> Filtrar(string query)
        {
            return repository.Filtrar(query);
        }
    }
}