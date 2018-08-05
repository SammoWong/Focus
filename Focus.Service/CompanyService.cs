using Focus.Domain.Entities;
using Focus.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class CompanyService : FocusServiceBase, ICompanyService
    {
        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            using(var db = NewDbContext())
            {
                return await db.Companies.ToListAsync();
            }
        }
    }
}
