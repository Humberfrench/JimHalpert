using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;
using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Domain.Inteface.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JimHalpert.App.Services
{
    public class BaseServiceApp<T> : AppServiceBase, IBaseServiceApp where T : new ()
    {
        private readonly IUnitOfWork uow;
        protected ValidationResult ValidationResults;
        protected ValidationResult<T> ValidationResult;

        public BaseServiceApp(IUnitOfWork uow)
        {
            this.uow = uow;
            ValidationResults = new ValidationResult();
            ValidationResult = new ValidationResult<T>();
        }

        public void BeginTransaction()
        {
            uow.BeginTransaction();
        }

        public void Commit()
        {
            var retorno = uow.SaveChanges();
            if (!retorno.Valid)
            {
                retorno.Erros.ToList().ForEach(e => ValidationResults.Add(e.Message));
            }
        }

        protected ErrorValidation ConvertValidationErrors(List<ValidationError> erros)
        {
            string erro;
            if (erros.Count == 1)
            {
                erro = erros.First().Message;
            }
            else
            {
                erro = string.Join(" *** ", erros);
            }

            return new ErrorValidation
            {
                Code = "10000",
                Message = erro
            };

        }
        public async Task CommitAync()
        {
            var retorno = await uow.SaveChangesAsync();

            if (!retorno.Valid)
            {
                retorno.Erros.ToList().ForEach(e => ValidationResults.Add(e.Message));
            }
        }
    }
}
