using Focus.Domain.Entities;
using Focus.Model;
using Focus.Model.Module;
using Focus.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class ModuleService : FocusServiceBase, IModuleService
    {
        public async Task<IEnumerable<TreeJsonModel>> GetTreeAsync()
        {
            using (var db = NewDbContext())
            {
                var modules = (await db.Modules
                            .OrderBy(e => e.SortNumber).ToListAsync())
                            .Select(d => new TreeJsonModel()
                            {
                                Id = d.Id,
                                Text = d.Name,
                                ParentId = d.ParentId
                            }).ToList();

                var treeJsonModel = new List<TreeJsonModel>();
                foreach (var parent in modules.Where(d => string.IsNullOrEmpty(d.ParentId)))
                {
                    foreach (var child in modules)
                    {
                        if (child.ParentId == parent.Id)
                        {
                            parent.Children.Add(child);
                        }
                    }
                    treeJsonModel.Add(parent);
                }
                return treeJsonModel;
            }
        }

        public async Task<Module> GetByIdAsync(string id)
        {
            using (var db = NewDbContext())
            {
                var module = await db.Modules.FirstOrDefaultAsync(e => e.Id == id);
                return module;
            }
        }

        public async Task UpdateAsync(Module module)
        {
            using (var db = NewDbContext())
            {
                db.Modules.Update(module);
                await db.SaveChangesAsync();
            }
        }

        public async Task AddAsync(Module module)
        {
            using (var db = NewDbContext())
            {
                await db.Modules.AddAsync(module);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> HasChildren(string id)
        {
            using(var db = NewDbContext())
            {
                return await db.Modules.AnyAsync(e => e.ParentId == id);
            }
        }

        public async Task DeleteAsync(Module module)
        {
            using(var db = NewDbContext())
            {
                db.Modules.Remove(module);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            using (var db = NewDbContext())
            {
                return await db.Modules.Where(e => e.Enabled == true).OrderBy(e => e.SortNumber).ToListAsync();
            }
        }
    }
}
