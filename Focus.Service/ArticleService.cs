using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Domain.Entities;
using Focus.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Focus.Service
{
    public class ArticleService : FocusServiceBase, IArticleService
    {
        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            using (var db = NewDbContext())
            {
                return await db.Articles.OrderByDescending(e => e.IsTop).ThenByDescending(e => e.ModifiedTime).ThenByDescending(e => e.CreatedTime).ToListAsync();
            }
        }

        public async Task<Article> GetByIdAsync(string id)
        {
            using (var db = NewDbContext())
            {
                return await db.Articles.SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task AddAsync(Article article)
        {
            using (var db = NewDbContext())
            {
                await db.Articles.AddAsync(article);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Article article)
        {
            using (var db = NewDbContext())
            {
                db.Articles.Update(article);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Article article)
        {
            using (var db = NewDbContext())
            {
                db.Articles.Remove(article);
                await db.SaveChangesAsync();
            }
        }
    }
}
