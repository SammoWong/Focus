using Focus.Domain.Entities;
using Focus.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAsync(string masterId);

        Task<string> GetButtonPermissionCodeByRoleId(string roleId);
    }
}
