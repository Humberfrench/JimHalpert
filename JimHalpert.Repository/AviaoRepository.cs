
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;

namespace JimHalpert.Repository
{
    public class AviaoRepository : BaseRepository<Aviao>, IAviaoRepository
    {
        public AviaoRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public IEnumerable<Aviao> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Aviao WHERE Modelo like '%{query}%'";

            return this.Connection.Query<Aviao>(sql);
        }
    }
}