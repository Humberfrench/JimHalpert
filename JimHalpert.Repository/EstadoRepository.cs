
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;

namespace JimHalpert.Repository
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public IEnumerable<Estado> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Estado WHERE Nome like '%{query}%'";

            return this.Connection.Query<Estado>(sql);
        }
    }
}