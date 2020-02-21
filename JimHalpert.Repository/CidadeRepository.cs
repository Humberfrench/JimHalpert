
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;

namespace JimHalpert.Repository
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public IEnumerable<Cidade> ObterCidades(int ufId)
        {
            var sql = $@"SELECT * FROM Cidade WHERE UfId like '%{ufId}%'";

            return this.Connection.Query<Cidade>(sql);

        }

        public IEnumerable<Cidade> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Cidade WHERE Nome like '%{query}%'";

            return this.Connection.Query<Cidade>(sql);
        }
    }
}