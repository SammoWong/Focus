using Focus.Domain.Entities;
using Focus.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class ModuleService : FocusServiceBase, IModuleService
    {
        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            using (var db = NewDbContext())
            {
                return await db.Modules.ToListAsync();
            }
        }
    }
}
