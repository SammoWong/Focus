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
        [Route("api/Permission/All")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(string roleId)
        {
            var moduleService = Ioc.Get<IModuleService>();
            var buttonService = Ioc.Get<IButtonService>();
            var moduleResult = await moduleService.GetAllAsync();
            var buttonResult = await buttonService.GetAllAsync();
            var treeResult = new List<TreeJsonModel>();
            foreach (var item in moduleResult)
            {
                var model = new TreeJsonModel
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Text = item.Name,
                    Icon = item.Icon
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
                    Icon = item.Icon
                };
                treeResult.Add(model);
            }
            return Ok(new StandardResult().Succeed(null, treeResult.ToTreeModel()));
        }
    }
}