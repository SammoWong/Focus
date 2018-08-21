using Focus.Domain.Entities;
using Focus.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class ButtonService : FocusServiceBase, IButtonService
    {
        public async Task<IEnumerable<Button>> GetAllAsync()
        {
            using (var db = NewDbContext())
            {
                return await db.Buttons.Where(e => e.Enabled == true).OrderBy(e => e.SortNumber).ToListAsync();
            }
        }

        public async Task AddAsync(Button button)
        {
            using (var db = NewDbContext())
            {
                await db.Buttons.AddAsync(button);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeteleAsync(Button button)
        {
            using(var db = NewDbContext())
            {
                db.Buttons.Remove(button);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Button>> GetButtonsByModuleIdAsync(string moduleId)
        {
            using(var db = NewDbContext())
            {
                return await db.Buttons.Where(e => e.Module.Id == moduleId).ToListAsync();
            }
        }

        public async Task<Button> GetByIdAsync(string id)
        {
            using(var db = NewDbContext())
            {
                return await db.Buttons.FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<Button>> GetPermissionButtonsByModuleIdAsync(string moduleId)
        {
            using (var db = NewDbContext())
            {
                return await db.Buttons.Where(e => e.Module.Id == moduleId && e.Enabled == true).ToListAsync();
            }
        }

        public async Task UpdateAsync(Button button)
        {
            using(var db = NewDbContext())
            {
                db.Buttons.Update(button);
                await db.SaveChangesAsync();
            }
        }
    }
}
