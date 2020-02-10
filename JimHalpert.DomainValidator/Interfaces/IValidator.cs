using JimHalpert.DomainValidator;

namespace JimHalpert.DomainValidator.Interfaces
{
    public interface IValidator<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
