using Focus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Focus.Domain.Services
{
    public interface IRoleService
    {
        Task AddAsync(Role role);

        Task<IEnumerable<Role>> GetAllAsync();
    }
}
