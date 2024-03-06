
using Dapper;
using JimHalpert.Domain.Entity;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JimHalpert.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        //public new IEnumerable<Cliente> ObterTodos()
        //{
        //    return DbSet.Include(c => c.Cidade).ThenInclude(c => c.Estado)
        //                .Include(c => c.TipoDeCliente)
        //                .Include(c => c.TipoDePessoa)
        //                .ToList();
        //}

        //public new Cliente ObterPorId(int id)
        //{

        //    return DbSet.Include(c => c.Cidade).ThenInclude(c => c.Estado)
        //                .Include(c => c.TipoDeCliente)
        //                .Include(c => c.TipoDePessoa)
        //                .Where(c => c.ClienteId == id).FirstOrDefault();
        //}

        public async Task<IEnumerable<Cliente>> Filtrar(string query)
        {
            var sql = $@"SELECT * FROM Cliente WHERE Descricao like '%{query}%'";

            return await this.Connection.QueryAsync<Cliente>(sql);
        }
    }
}