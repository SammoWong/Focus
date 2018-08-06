using Focus.Model.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleOutputModel>> GetAllAsync();
    }
}
