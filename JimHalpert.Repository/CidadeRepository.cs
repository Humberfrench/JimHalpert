
using Dapper;
using JimHalpert.Application.ObjectValue;
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

        public IEnumerable<CidadeValue> ObterCidades(int ufId)
        {
            var sql = $@"SELECT * FROM Cidade WHERE EstadoId = {ufId}";

            return this.Connection.Query<CidadeValue>(sql);

        }

        public IEnumerable<Cidade> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Cidade WHERE Nome like '%{query}%'";

            return this.Connection.Query<Cidade>(sql);
        }
    }
}