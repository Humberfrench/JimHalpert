using Dietcode.Core.DomainValidator;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Context;
using JimHalpert.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace JimHalpert.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly JimHalpertContext dbContext;
        private readonly ValidationResult validationResult;

        private bool _disposed;

        public UnitOfWork(IContextManager contextManager)
        {
            this.dbContext = contextManager.GetContext();
            validationResult = new ValidationResult();
        }

        public void BeginTransaction()
        {
            this._disposed = false;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ValidationResult SaveChanges()
        {
            try
            {
                var dados = this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }
            return validationResult;
        }


        public async Task<ValidationResult> SaveChangesAsync()
        {
            try
            {
                var dados = await this.dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }
            return validationResult;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
    }

}