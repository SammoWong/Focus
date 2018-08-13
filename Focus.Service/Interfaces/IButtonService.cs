using Focus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface IButtonService
    {
        Task<Button> GetByIdAsync(string id);

        Task AddAsync(Button button);

        Task UpdateAsync(Button button);

        Task DeteleAsync(Button button);
            
        Task<IEnumerable<Button>> GetButtonsByModuleIdAsync(string moduleId);
    }
}
