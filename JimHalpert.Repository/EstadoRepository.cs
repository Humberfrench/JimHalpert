
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Repository
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public async Task<IEnumerable<Estado>> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Estado WHERE Nome like '%{query}%'";

            return await this.Connection.QueryAsync<Estado>(sql);
        }
    }
}