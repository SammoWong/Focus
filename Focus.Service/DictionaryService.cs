using Focus.Domain.Entities;
using Focus.Domain.Services;
using Focus.Model.Dictionary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class DictionaryService : FocusServiceBase, IDictionaryService
    {
        public async Task<IEnumerable<Model.TreeJsonModel>> GetDictionaryTypesAsync()
        {
            using (var db = NewDbContext())
            {
                var types = (await db.DictionaryTypes.Where(e => e.Enabled == true && e.IsDeleted == false)
                                                     .OrderBy(e => e.SortNumber).ToListAsync())
                                                     .Select(d => new Model.TreeJsonModel()
                                                     {
                                                         Id = d.Id,
                                                         Text = d.Name,
                                                         ParentId = d.ParentId
                                                     }).ToList();

                var dictionaryTypeList = new List<Model.TreeJsonModel>();
                foreach (var parent in types.Where(d => d.ParentId == string.Empty))
                {
                    foreach (var dictionaryType in types)
                    {
                        if (dictionaryType.ParentId == parent.Id)
                        {
                            parent.Children.Add(dictionaryType);
                        }
                    }
                    dictionaryTypeList.Add(parent);
                }
                return dictionaryTypeList;
            }
        }

        public async Task<IEnumerable<DictionaryDetail>> GetDictionaryDetailsByTypeIdAsync(string typeId)
        {
            using (var db = NewDbContext())
            {
                var dictionaryDetails = await db.DictionaryDetails.Where(e => e.TypeId == typeId)
                                                                  .OrderBy(e => e.SortNumber).ToListAsync();
                return dictionaryDetails;
            }
        }

        public async Task<DictionaryDetail> GetDictionaryDetailById(string id)
        {
            using (var db = NewDbContext())
            {
                var dictionaryDetail = await db.DictionaryDetails.FirstOrDefaultAsync(e => e.Id == id);
                return dictionaryDetail;
            }
        }

        public async Task UpdateDictionaryDetailAsync(DictionaryDetail entity)
        {
            using (var db = NewDbContext())
            {
                var entry = db.Entry(entity);
                entry.State = EntityState.Modified;
                await db.SaveChangesAsync();
                //db.DictionaryDetails.Update(entity);
                //await db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsDictionaryDetailExistAsync(string name)
        {
            using (var db = NewDbContext())
            {
                return await db.DictionaryDetails.AnyAsync(e => e.Name == name);
            }
        }

        public async Task AddDictionaryDetailAsync(DictionaryDetail entity)
        {
            using (var db = NewDbContext())
            {
                await db.DictionaryDetails.AddAsync(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task BatchDeleteDictionaryDetailsAsync(List<string> ids, string currentUserId)
        {
            using (var db = NewDbContext())
            {
                var entities = db.DictionaryDetails.Where(e => ids.Contains(e.Id));
                await entities.ForEachAsync(e =>
                {
                    e.IsDeleted = true;
                    e.DeletedTime = DateTime.Now;
                    e.DeletedBy = currentUserId;
                });
                await entities.ForEachAsync(e => db.Entry(e).State = EntityState.Modified);
                await db.SaveChangesAsync();
            }
        }
    }
}
