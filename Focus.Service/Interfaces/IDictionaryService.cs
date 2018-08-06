using Focus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface IDictionaryService
    {
        Task<IEnumerable<Model.TreeJsonModel>> GetDictionaryTypesAsync();

        Task<IEnumerable<DictionaryDetail>> GetDictionaryDetailsByTypeIdAsync(string typeId);

        Task<DictionaryDetail> GetDictionaryDetailById(string id);

        Task UpdateDictionaryDetailAsync(DictionaryDetail entity);

        Task<bool> IsDictionaryDetailExistAsync(string name);

        Task AddDictionaryDetailAsync(DictionaryDetail entity);

        Task BatchDeleteDictionaryDetailsAsync(List<string> ids, string currentUserId);
    }
}
