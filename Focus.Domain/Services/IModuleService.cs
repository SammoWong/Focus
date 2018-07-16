using Focus.Domain.Entities;
using Focus.Model.Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Focus.Domain.Services
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleOutputModel>> GetAllAsync();
    }
}
