using Focus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAllAsync();

        Task<Article> GetByIdAsync(string id);

        Task AddAsync(Article article);

        Task UpdateAsync(Article article);

        Task DeleteAsync(Article article);
    }
}
