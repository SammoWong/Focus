using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Model;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    public class PermissionController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Master/{masterId}/Permission")]
        public async Task<IActionResult> GetAsync(string masterId)
        {
            var moduleService = Ioc.Get<IModuleService>();
            var buttonService = Ioc.Get<IButtonService>();
            var permissionService = Ioc.Get<IPermissionService>();
            var moduleResult = await moduleService.GetAllAsync();
            var buttonResult = await buttonService.GetAllAsync();
            var permissions = await permissionService.GetAsync(masterId);
            var treeResult = new List<TreeJsonModel>();
            foreach (var item in moduleResult)
            {
                var model = new TreeJsonModel
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Text = item.Name,
                    Icon = item.Icon,
                    State = new State { Selected = permissions.Any(p => p.AccessId == item.Id) }
                };
                treeResult.Add(model);
            }
            foreach (var item in buttonResult)
            {
                var model = new TreeJsonModel
                {
                    Id = item.Id,
                    ParentId = item.ModuleId,
                    Text = item.Name,
                    Icon = item.Icon,
                    State = new State { Selected = permissions.Any(p => p.AccessId == item.Id) }
                };
                treeResult.Add(model);
            }
            return Ok(new StandardResult().Succeed(null, treeResult.ToTreeModel()));
        }
    }
}