using Focus.Domain.Entities;
using Focus.Domain.Services;
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
        public async Task<IEnumerable<DictionaryType>> GetDictionaryTypesAsync()
        {
            using (var db = NewDbContext())
            {
                return await db.DictionaryTypes.Where(e => e.Enabled == true).OrderBy(e=>e.SortNumber).ToListAsync();
            }
        }
    }
}
