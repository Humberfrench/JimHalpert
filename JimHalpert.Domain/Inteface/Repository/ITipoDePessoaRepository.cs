using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface ITipoDePessoaRepository : IBaseRepository<TipoDePessoa>
    {
        IEnumerable<TipoDePessoa> Filtrar(string query);

    }
}
