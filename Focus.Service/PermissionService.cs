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
    public class PermissionService : FocusServiceBase, IPermissionService
    {
        public async Task<IEnumerable<Permission>> GetAsync(string masterId)
        {
            using(var db = NewDbContext())
            {
                return await db.Permissions.Where(e => e.MasterId == masterId).ToListAsync();
            }
        }
    }
}
