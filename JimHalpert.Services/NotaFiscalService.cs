using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using JimHalpert.Extensions;
using System.Collections.Generic;

namespace JimHalpert.Services
{
    public class NotaFiscalService : BaseService<NotaFiscal>, INotaFiscalService
    {
        private readonly INotaFiscalRepository notaFiscalRepository;
        private readonly IStatusNotaFiscalRepository statusNotaFiscalRepository;
        private readonly IMesRepository mesRepository;
        private readonly ValidationResult validationResult;
        public NotaFiscalService(IBaseRepository<NotaFiscal> baseRepository,
                                 IStatusNotaFiscalRepository statusNotaFiscalRepository,
                                 IMesRepository mesRepository,
                                 INotaFiscalRepository notaFiscalRepository) : base(baseRepository)
        {
            this.notaFiscalRepository = notaFiscalRepository;
            this.statusNotaFiscalRepository = statusNotaFiscalRepository;
            this.mesRepository = mesRepository;
            validationResult = new ValidationResult();
        }

        public ValidationResult Gravar(NotaFiscal aviao)
        {
            //validate
            //if (aviao.NomeUf.IsNullOrEmptyOrWhiteSpace())
            //{
            //    validationResult.Add("Nome não preenchido");
            //    return validationResult;
            //}

            //if (aviao.SiglaUf.IsNullOrEmptyOrWhiteSpace())
            //{
            //    validationResult.Add("Sigla Uf não preenchido");
            //    return validationResult;
            //}

            //add or update
            if(aviao.NotaFiscalId == 0)
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

        public IEnumerable<StatusNotaFiscal> StatusNotaFiscais() 
        {
            return statusNotaFiscalRepository.ObterTodos();
        }

        public StatusNotaFiscal StatusNotaFiscalPorId(int id)
        {
            return statusNotaFiscalRepository.ObterPorId(id);
        }
        public IEnumerable<Mes> ObterListaMes()
        {
            return mesRepository.ObterTodos();
        }

        public IEnumerable<NotaFiscal> Filtrar(string query)
        {
            return null;// notaFiscalRepository.Filtrar(query);
        }
    }
}