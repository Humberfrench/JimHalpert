using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Repository.Context;
using JimHalpert.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JimHalpert.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        private readonly JimHalpertContext Context;
        private readonly IContextManager contextManager;

        public BaseRepository(IContextManager contextManager)
        {
            this.contextManager = contextManager;
            this.Context = contextManager.GetContext();
            this.DbSet = Context.Set<TEntity>();
        }

        //for dapper
        public IDbConnection Connection => new SqlConnection(contextManager.GetConnectionString);

        #region Async
        public virtual async Task Adicionar(TEntity obj)
        {
            await Task.Run(() =>
            {
                var entry = this.Context.Entry(obj);
                DbSet.Add(obj);
                entry.State = EntityState.Added;
            });
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            await Task.Run(() =>
            {
                var entry = this.Context.Entry(obj);
                DbSet.Attach(obj);
                entry.State = EntityState.Modified;
            });
        }

        public virtual async Task Remover(TEntity obj)
        {
            await Task.Run(() =>
            {
                var entry = this.Context.Entry(obj);
                DbSet.Remove(obj);
                entry.State = EntityState.Deleted;
            });
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            var resultado = await this.DbSet.FindAsync(id);
            return resultado;
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await this.DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosPaginado(int pagina, int registros)
        {
            var resultado = this.DbSet.Take(pagina).Skip(registros);
            return await this.DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.DbSet.Where(predicate).ToListAsync();
        }

        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}