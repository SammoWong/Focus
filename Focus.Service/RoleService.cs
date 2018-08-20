using Focus.Domain.Entities;
using Focus.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            using (var db = NewDbContext())
            {
                return await db.Roles.ToListAsync();
            }
        }

        public async Task<Role> GetByIdAsync(string id)
        {
            using(var db = NewDbContext())
            {
                return await db.Roles.SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<bool> IsRoleExistAsync(string name)
        {
            using(var db = NewDbContext())
            {
                return await db.Roles.AnyAsync(e => e.Name == name);
            }
        }

        public async Task UpdateAsync(Role role)
        {
            using(var db = NewDbContext())
            {
                db.Roles.Update(role);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Role role)
        {
            using(var db = NewDbContext())
            {
                db.Roles.Remove(role);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> HasUserContained(Role role)
        {
            using(var db = NewDbContext())
            {
                return await db.Roles.Where(e=>e.Id == role.Id).AnyAsync(e => e.Users.Count > 0);
            }
        }
    }
}
