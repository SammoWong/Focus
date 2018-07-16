using Focus.Domain.Entities;
using Focus.Domain.Services;
using Focus.Model.Module;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class ModuleService : FocusServiceBase, IModuleService
    {
        public async Task<IEnumerable<ModuleOutputModel>> GetAllAsync()
        {
            using (var db = NewDbContext())
            {
                var modules = (await db.Modules.ToListAsync()).Select(m => new ModuleOutputModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Url = m.Url,
                    Icon = m.Icon,
                    Rank = m.Rank,
                    IsExpanded = m.IsExpanded,
                    ParentId = m.ParentId
                }).ToList();
                List<ModuleOutputModel> moduleList = new List<ModuleOutputModel>();
                foreach (var parent in modules.Where(t => t.ParentId == string.Empty))
                {
                    foreach (var module in modules)
                    {
                        if (module.ParentId == parent.Id)
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
}
