
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using System.Collections.Generic;

namespace JimHalpert.Repository
{
    public class ServicoRepository : BaseRepository<Servico>, IServicoRepository
    {
        public ServicoRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public IEnumerable<Servico> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Servico WHERE Descricao like '%{query}%'";

            return this.Connection.Query<Servico>(sql);
        }
    }
}