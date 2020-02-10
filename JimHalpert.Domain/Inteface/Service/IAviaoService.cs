using JimHalpert.Domain.Entity;
using JimHalpert.DomainValidator;
using System.Collections.Generic;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IAviaoService:IBaseService<Aviao>
    {
        ValidationResult Gravar(Aviao aviao);
        ValidationResult Excluir(int id);
        IEnumerable<Aviao> Filtrar(string query);
    }
}