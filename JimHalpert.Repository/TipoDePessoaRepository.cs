
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimHalpert.Repository
{
    public class TipoDePessoaRepository : BaseRepository<TipoDePessoa>, ITipoDePessoaRepository
    {
        public TipoDePessoaRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public async Task<IEnumerable<TipoDePessoa>> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM TipoDePessoa WHERE Descricao like '%{query}%'";

            return await this.Connection.QueryAsync<TipoDePessoa>(sql);
        }
    }
}