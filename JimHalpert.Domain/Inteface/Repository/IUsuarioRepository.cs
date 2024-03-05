using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        IEnumerable<Usuario> Filtrar(string query);

    }
}
