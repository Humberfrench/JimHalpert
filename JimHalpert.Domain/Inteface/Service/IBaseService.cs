using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Service
{
    public interface IBaseService<TEntity>
    {
        Task Adicionar(TEntity obj);
        Task Atualizar(TEntity obj);
        Task Remover(TEntity obj);
        Task<TEntity> ObterPorId(int id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> Pesquisar(Expression<Func<TEntity, bool>> predicate);
    }
}