
using Dapper;
using JimHalpert.Application.ObjectValue;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Repository
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public async Task<IEnumerable<CidadeValue>> ObterCidades(int ufId)
        {
            var sql = $@"SELECT * FROM Cidade WHERE EstadoId = {ufId}";

            return await this.Connection.QueryAsync<CidadeValue>(sql);

        }

        public async Task<IEnumerable<Cidade>> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Cidade WHERE Nome like '%{query}%'";

            return await this.Connection.QueryAsync<Cidade>(sql);
        }
    }
}