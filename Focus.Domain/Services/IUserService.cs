using Focus.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Focus.Domain.Services
{
    public interface IUserService
    {
        Task AddAsync(User user);

        Task<Tuple<string, User>> LoginAsync(string account, string password);
    }
}
