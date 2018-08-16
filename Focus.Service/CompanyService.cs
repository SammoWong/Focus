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
    public class CompanyService : FocusServiceBase, ICompanyService
    {
        public async Task AddAsync(Company company)
        {
            using (var db = NewDbContext())
            {
                await db.Companies.AddAsync(company);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Company company)
        {
            using(var db = NewDbContext())
            {
                db.Companies.Update(company);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Company> GetByIdAsync(string id)
        {
            using (var db = NewDbContext())
            {
                return await db.Companies.SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            using(var db = NewDbContext())
            {
                return await db.Companies.ToListAsync();
            }
        }
    }
}
