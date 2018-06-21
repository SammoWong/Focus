using Focus.Domain.Entities;
using System.Threading.Tasks;

namespace Focus.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(User user);
    }
}
