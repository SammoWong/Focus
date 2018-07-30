using Focus.Domain.Entities;
using Focus.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Domain.Services
{
    public interface IDictionaryService
    {
        Task<IEnumerable<Model.TreeJsonModel>> GetDictionaryTypesAsync();

        Task<IEnumerable<DictionaryDetail>> GetDictionaryDetailsByTypeIdAsync(string typeId);
    }
}
