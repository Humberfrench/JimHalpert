
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Repository
{
    public class TipoDeClienteRepository : BaseRepository<TipoDeCliente>, ITipoDeClienteRepository
    {
        public TipoDeClienteRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public async Task<IEnumerable<TipoDeCliente>> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM TipoDeCliente WHERE Descricao like '%{query}%'";

            return await this.Connection.QueryAsync<TipoDeCliente>(sql);
        }
    }
}