using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<ValidationResult> Gravar(NotaFiscal notaFiscal)
        {
            //validate
            //if (notaFiscal.NomeUf.IsNullOrEmptyOrWhiteSpace())
            //{
            //    validationResult.Add("Nome não preenchido");
            //    return validationResult;
            //}

            //if (notaFiscal.SiglaUf.IsNullOrEmptyOrWhiteSpace())
            //{
            //    validationResult.Add("Sigla Uf não preenchido");
            //    return validationResult;
            //}

            //add or update
            if(notaFiscal.NotaFiscalId == 0)
            {
                await base.Adicionar(notaFiscal);
            }
            else
            {
                await base.Atualizar(notaFiscal);
            }

            return validationResult;
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var notaFiscal = await ObterPorId(id);
            if(notaFiscal == null)
            {
                validationResult.Add("Avião inexistente");
                return validationResult;
            }

            await base.Remover(notaFiscal);

            return validationResult;
        }

        public async Task<IEnumerable<StatusNotaFiscal>> StatusNotaFiscais() 
        {
            return await statusNotaFiscalRepository.ObterTodos();
        }

        public async Task<StatusNotaFiscal> StatusNotaFiscalPorId(int id)
        {
            return await statusNotaFiscalRepository.ObterPorId(id);
        }
        public async Task<IEnumerable<Mes>> ObterListaMes()
        {
            return await mesRepository.ObterTodos();
        }

        public async Task<IEnumerable<NotaFiscal>> Filtrar(string query)
        {
            return null;// notaFiscalRepository.Filtrar(query);
        }
    }
}