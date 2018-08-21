using Focus.Domain.Entities;
using Focus.Model;
using Focus.Model.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface IModuleService
    {
        Task<IEnumerable<Module>> GetAllAsync();

        Task<IEnumerable<TreeJsonModel>> GetTreeAsync();

        Task<Module> GetByIdAsync(string id);

        Task UpdateAsync(Module module);

        Task AddAsync(Module module);

        Task<bool> HasChildren(string id);

        Task DeleteAsync(Module module);
    }
}
