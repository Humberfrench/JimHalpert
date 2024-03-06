using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JimHalpert.Domain.Inteface.Repository;
using JimHalpert.Domain.Inteface.Service;
using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;

namespace JimHalpert.Services
{

    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual async Task Adicionar(TEntity obj)
        {
            await this.repository.Adicionar(obj);
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            await this.repository.Atualizar(obj);
        }

        public virtual async Task Remover(TEntity obj)
        {
            await this.repository.Remover(obj);
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await this.repository.ObterPorId(id);
        }

        public virtual async Task<IEnumerable<TEntity>>ObterTodos()
        {
            return await this.repository.ObterTodos();
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public async Task<IEnumerable<TEntity>> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.repository.Pesquisar(predicate);
        }
    }
}
