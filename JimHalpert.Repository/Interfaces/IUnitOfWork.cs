

using JimHalpert.DomainValidator;

namespace JimHalpert.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        ValidationResult SaveChanges();
    }
}