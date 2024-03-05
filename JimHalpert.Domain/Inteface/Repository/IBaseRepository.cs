using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JimHalpert.Domain.Inteface.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable
    {
        void Adicionar(TEntity obj);

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        TEntity ObterPorId(int id);

        IEnumerable<TEntity> ObterTodos();

        IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate);

        Task AdicionarAsync(TEntity obj);

        Task AtualizarAsync(TEntity obj);

        Task RemoverAsync(TEntity obj);

        Task<TEntity> ObterPorIdAsync(int id);

        Task<IEnumerable<TEntity>> ObterTodosAsync();

        Task<IEnumerable<TEntity>> PesquisarAsync(Expression<Func<TEntity, bool>> predicate);

    }
}