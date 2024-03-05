
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;

namespace JimHalpert.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public IEnumerable<Usuario> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Usuario WHERE Descricao Nome '%{query}%'";

            return this.Connection.Query<Usuario>(sql);
        }
    }
}