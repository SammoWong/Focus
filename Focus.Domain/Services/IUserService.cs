using Focus.Domain.Entities;
using System.Threading.Tasks;

namespace Focus.Domain.Services
{
    public interface IUserService
    {
        Task AddAsync(User user);
    }
}
