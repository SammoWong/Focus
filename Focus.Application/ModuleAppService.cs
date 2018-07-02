using Focus.Domain.Entities;
using Focus.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Application
{
    public class ModuleAppService
    {
        private readonly IModuleService _moduleService;
        public ModuleAppService(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            return await _moduleService.GetAllAsync();
        }
    }
}
