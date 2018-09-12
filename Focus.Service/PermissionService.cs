using Focus.Domain.Entities;
using Focus.Model;
using Focus.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class PermissionService : FocusServiceBase, IPermissionService
    {
        public async Task<IEnumerable<Permission>> GetAsync(string masterId)
        {
            using(var db = NewDbContext())
            {
                return await db.Permissions.Where(e => e.MasterId == masterId).ToListAsync();
            }
        }

        //TODO:接口权限验证，需改进
        public async Task<string> GetButtonPermissionCodeByRoleId(string roleId)
        {
            var buttonService = Infrastructure.Ioc.Get<IButtonService>();
            var buttonResult = await buttonService.GetAllAsync();
            var permissions = await GetAsync(roleId);
            var treeResult = new List<TreeJsonModel>();
            var buttonPermissionCode = string.Empty;
            foreach (var item in buttonResult)
            {
                if (permissions.Any(p => roleId == "d3390e64-0ea4-47dc-9159-07c16ca905aa" || p.AccessId == item.Id))
                {
                    buttonPermissionCode = string.Join(',', item.Code);
                }
            }
            return buttonPermissionCode;
        }
    }
}
