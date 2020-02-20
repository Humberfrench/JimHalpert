
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;

namespace JimHalpert.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public IEnumerable<Cliente> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Cliente WHERE Descricao like '%{query}%'";

            return this.Connection.Query<Cliente>(sql);
        }
    }
}