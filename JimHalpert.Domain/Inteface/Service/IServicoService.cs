using JimHalpert.DomainValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IServicoService<Servico>
    {
        ValidationResult Gravar(Servico aviao);
        ValidationResult Excluir(int id);
        IEnumerable<Servico> Filtrar(string query);
    }
}
