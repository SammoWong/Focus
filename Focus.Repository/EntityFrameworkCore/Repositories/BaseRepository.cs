using Focus.Domain.Entities;
using Focus.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Repository.EntityFrameworkCore.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly FocusDbContext _focusDbContext;
        public BaseRepository(FocusDbContext focusDbContext)
        {
            _focusDbContext = focusDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _focusDbContext.AddAsync(entity);
            await _focusDbContext.SaveChangesAsync();
        }

        public async Task BatchAddAsync(T[] entities)
        {
            await _focusDbContext.Set<T>().AddRangeAsync(entities);
            await _focusDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _focusDbContext.Set<T>().Remove(entity);
            await _focusDbContext.SaveChangesAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> filter)
        {
            return Filter(filter);
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await _focusDbContext.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter)
        {
            return await Filter(filter).CountAsync();
        }

        public Task<bool> IsExistsAsync(Expression<Func<T, bool>> filter)
        {
            return _focusDbContext.Set<T>().AnyAsync(filter);
        }

        public async Task UpdateAsync(T entity)
        {
            var entry = _focusDbContext.Entry(entity);
            entry.State = EntityState.Modified;
            await _focusDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expression<Func<T, object>> filter, T entity)
        {
            throw new Exception();
        }

        public async Task UpdateAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            throw new Exception();
        }

        private IQueryable<T> Filter(Expression<Func<T, bool>> filter)
        {
            var dbSet = _focusDbContext.Set<T>().AsQueryable();
            if (dbSet != null)
                dbSet = dbSet.Where(filter);

            return dbSet;
        }
    }
}
