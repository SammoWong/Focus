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
        //TODO:需要重构
        [HttpGet]
        [Route("api/AuthorizedModules")]
        public async Task<IActionResult> GetAuthorizedModuleAsync()
        {
            var moduleService = Ioc.Get<IModuleService>();
            var permissionService = Ioc.Get<IPermissionService>();
            var moduleResult = await moduleService.GetAllAsync();
            var permissions = await permissionService.GetAsync(CurrentRoleId);
            var treeResult = new List<TreeJsonModel>();
            foreach (var item in moduleResult)
            {
                if(permissions.Any(p=>p.AccessId == item.Id))
                {
                    var model = new TreeJsonModel
                    {
                        Id = item.Id,
                        ParentId = item.ParentId,
                        Text = item.Name,
                        Icon = item.Icon,
                        Url = item.Url
                    };
                    treeResult.Add(model);
                }
            }
            return Ok(new StandardResult().Succeed(null, treeResult.ToTreeModel()));
        }

        //TODO:可以重构为登陆一次性获取所有权限，不需要每次点击菜单加载按钮
        [HttpGet]
        [Route("api/Module/{moduleId}/AuthorizedButtons")]
        public async Task<IActionResult> GetAuthorizedButtonAsync(string moduleId)
        {
            var buttonService = Ioc.Get<IButtonService>();
            var permissionService = Ioc.Get<IPermissionService>();
            var buttonResult = await buttonService.GetButtonsByModuleIdAsync(moduleId);
            var permissions = await permissionService.GetAsync(CurrentRoleId);
            var result = buttonResult.Where(b => permissions.Any(p => p.AccessId == b.Id));
            return Ok(new StandardResult().Succeed(null, result));
        }

        [HttpGet]
        [Route("api/Master/{masterId}/Permission")]
        public async Task<IActionResult> GetAllAsync(string masterId)
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
                    Url = item.Url,
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
                    Url = item.Url,
                    State = new State { Selected = permissions.Any(p => p.AccessId == item.Id) }
                };
                treeResult.Add(model);
            }
            return Ok(new StandardResult().Succeed(null, treeResult.ToTreeModel()));
        }
    }
}