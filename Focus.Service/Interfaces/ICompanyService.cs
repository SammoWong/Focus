using Focus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompaniesAsync();

        Task UpdateAsync(Company company);

        Task<Company> GetByIdAsync(string id);

        Task AddAsync(Company company);
    }
}
