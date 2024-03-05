
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public async Task<IEnumerable<Usuario>> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Usuario WHERE Descricao Nome '%{query}%'";

            return await this.Connection.QueryAsync<Usuario>(sql);
        }

        public async Task<Usuario> ObterUsuario(string login)
        {
            return await DbSet.FirstOrDefaultAsync(u => 
                                     string.Equals(u.Login, login, System.StringComparison.CurrentCultureIgnoreCase));
        }
    }
}