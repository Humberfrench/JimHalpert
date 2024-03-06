
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Repository
{
    public class ServicoRepository : BaseRepository<Servico>, IServicoRepository
    {
        public ServicoRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public async Task<IEnumerable<Servico>> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Servico WHERE Descricao like '%{query}%'";

            return await this.Connection.QueryAsync<Servico>(sql);
        }
    }
}