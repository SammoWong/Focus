using Focus.Domain.Entities;
using Focus.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Application
{
    public class RoleAppService
    {
        private readonly IRoleService _roleService;
        public RoleAppService(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _roleService.GetAllAsync();
        }
    }
}
