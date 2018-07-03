using Focus.Application.Dtos.Module;
using Focus.Domain.Entities;
using Focus.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<ModuleDto>> GetAllAsync()
        {
            var modules = (await _moduleService.GetAllAsync()).Select(m => new ModuleDto()
            {
                Id = m.Id,
                Name = m.Name,
                Url = m.Url,
                Icon = m.Icon,
                Rank = m.Rank,
                IsExpanded = m.IsExpanded,
                ParentId = m.ParentId
            }).ToList();
            List<ModuleDto> moduleList = new List<ModuleDto>();
            foreach (var parent in modules.Where(t => t.ParentId == string.Empty))
            {
                foreach (var module in modules)
                {
                    if(module.ParentId == parent.Id)
                    {
                        parent.Children.Add(module);
                    }
                }
                moduleList.Add(parent);
            }
            return moduleList;
        }
    }
}
