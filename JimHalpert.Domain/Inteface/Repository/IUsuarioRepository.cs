using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> ObterUsuario(string login);
        Task<IEnumerable<Usuario>> Filtrar(string query);

    }
}
