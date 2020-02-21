using JimHalpert.Domain.Entity;
using JimHalpert.DomainValidator;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IEstadoService:IBaseService<Estado>
    {
        ValidationResult Gravar(Estado aviao);
        ValidationResult Excluir(int id);
        IEnumerable<Estado> Filtrar(string query);
    }
}