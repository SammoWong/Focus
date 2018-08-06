using Focus.Domain.Entities;
using Focus.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class RoleService : FocusServiceBase, IRoleService
    {
        public async Task AddAsync(Role role)
        {
            using (var db = base.NewDbContext())
            {
                await db.Roles.AddAsync(role);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            using (var db = base.NewDbContext())
            {
                return await db.Roles.ToListAsync();
            }
        }
    }
}
