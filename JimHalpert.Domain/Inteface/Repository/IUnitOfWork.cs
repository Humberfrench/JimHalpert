using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        ValidationResult SaveChanges();
        Task<ValidationResult> SaveChangesAsync();
    }
}