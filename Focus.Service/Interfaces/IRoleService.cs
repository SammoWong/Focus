using Focus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface IRoleService
    {
        Task AddAsync(Role role);

        Task<IEnumerable<Role>> GetAllAsync();

        Task<bool> IsRoleExistAsync(string name);

        Task<Role> GetByIdAsync(string id);

        Task UpdateAsync(Role role);

        Task DeleteAsync(Role role);

        Task<bool> HasUserContained(Role role);

        Task AddAsync(Role role, IEnumerable<Permission> permissions);
    }
}
