using Focus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Domain.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> Find(Expression<Func<T, bool>> filter);

        Task<bool> IsExistsAsync(Expression<Func<T, bool>> filter);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> filter);

        Task<int> GetCountAsync(Expression<Func<T, bool>> filter);

        Task AddAsync(T entity);

        Task BatchAddAsync(T[] entities);

        Task UpdateAsync(T entity);

        Task UpdateAsync(Expression<Func<T, object>> filter, T entity);

        Task UpdateAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity);

        Task DeleteAsync(T entity);
    }
}
