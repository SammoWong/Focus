using Focus.Domain.Entities;
using Focus.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

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

        public async Task<int> ExecuteSqlAsync(string sql)
        {
            return await _focusDbContext.Database.ExecuteSqlCommandAsync(sql);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> filter)
        {
            return Filter(filter);
        }

        /// <summary>
        /// 单个查询，且不被追踪
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await _focusDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter)
        {
            return await Filter(filter).CountAsync();
        }

        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> filter)
        {
            return await _focusDbContext.Set<T>().AnyAsync(filter);
        }

        public async Task UpdateAsync(T entity)
        {
            var entry = _focusDbContext.Entry(entity);
            entry.State = EntityState.Modified;
            await _focusDbContext.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            await _focusDbContext.Set<T>().Where(where).UpdateAsync(entity);
        }

        private IQueryable<T> Filter(Expression<Func<T, bool>> filter)
        {
            var dbSet = _focusDbContext.Set<T>().AsNoTracking().AsQueryable();
            if (dbSet != null)
                dbSet = dbSet.Where(filter);

            return dbSet;
        }
    }
}
