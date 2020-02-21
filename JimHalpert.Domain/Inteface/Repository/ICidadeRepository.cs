using JimHalpert.Application.ObjectValue;
using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        IEnumerable<Cidade> Filtrar(string query);
        IEnumerable<CidadeValue> ObterCidades(int ufId);
    }
}
