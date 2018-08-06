using Focus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsAccountExist(string account);

        Task AddAsync(User user);

        Task<Tuple<string, User>> LoginAsync(string account, string password);

        Task<User> GetUserById(string id);

        Task<IEnumerable<User>> GetAllAsync();

        Task UpdateAsync(User user);
    }
}
