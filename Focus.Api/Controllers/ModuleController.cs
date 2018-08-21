using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Focus.Domain.Entities;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Model;
using Focus.Model.Module;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [ApiController]
    public class ModuleController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Module")]
        public async Task<IActionResult> GetAllAsync()
        {
            var moduleService = Ioc.Get<IModuleService>();
            var modules = await moduleService.GetAllAsync();
            var result = new List<TreeJsonModel>();
            foreach (var item in modules)
            {
                var model = new TreeJsonModel
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Text = item.Name,
                    Url = item.Url,
                    Icon = item.Icon
                };
                result.Add(model);
            }
            return Ok(new StandardResult().Succeed(null, result.ToTreeModel()));
        }

        [HttpGet]
        [Route("api/Modules/Tree")]
        public async Task<IActionResult> GetTreeAsync()
        {
            var moduleService = Ioc.Get<IModuleService>();
            var result = await moduleService.GetTreeAsync();
            return Ok(new StandardResult().Succeed(null, result));
        }

        [HttpGet]
        [Route("api/Modules/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var moduleService = Ioc.Get<IModuleService>();
            var result = await moduleService.GetByIdAsync(id);
            return Ok(new StandardResult().Succeed(null, result));
        }

        [HttpPost]
        [Route("api/Module/Update")]
        public async Task<IActionResult> UpdateModuleAsync([FromForm]UpdateModuleInputModel model)
        {
            var moduleService = Ioc.Get<IModuleService>();
            var module = await moduleService.GetByIdAsync(model.Id);
            if (module == null)
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "模块菜单不存在"));

            module.Id = model.Id;
            module.Name = model.Name;
            module.ParentId = model.ParentId;
            module.Code = model.Code;
            module.Category = model.Category;
            module.Url = model.Url;
            module.Icon = model.Icon;
            module.Rank = model.Rank;
            module.SortNumber = model.SortNumber;
            module.IsExpanded = model.IsExpanded;
            module.Enabled = model.Enabled;
            module.Remark = model.Remark;
            module.ModifiedBy = CurrentUserId;
            module.ModifiedTime = DateTime.Now;
            await moduleService.UpdateAsync(module);
            return Ok(new StandardResult().Succeed("更新成功"));
        }

        [HttpPost]
        [Route("api/Module/Add")]
        public async Task<IActionResult> AddModuleAsync([FromForm]AddModuleInputModel model)
        {
            var moduleService = Ioc.Get<IModuleService>();
            var module = new Module
            {
                Id = Guid.NewGuid().ToString(),
                ParentId = model.ParentId,
                Name = model.Name,
                Code = model.Code,
                Category = model.Category,
                Url = model.Url,
                Icon = model.Icon,
                Rank = model.Rank,
                SortNumber = model.SortNumber,
                IsExpanded = model.IsExpanded,
                Enabled = model.Enabled,
                Remark = model.Remark,
                CreatedBy = CurrentUserId,
                CreatedTime = DateTime.Now
            };
            await moduleService.AddAsync(module);
            return Ok(new StandardResult().Succeed("添加成功"));
        }

        [HttpPost]
        [Route("api/Module/Delete")]
        public async Task<IActionResult> DeleteModuleAsync([FromForm]DeleteModuleInputModel model)
        {
            var moduleService = Ioc.Get<IModuleService>();
            if(await moduleService.HasChildren(model.Id))
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "删除失败：该模块含有子模块"));

            var module = await moduleService.GetByIdAsync(model.Id);
            await moduleService.DeleteAsync(module);
            return Ok(new StandardResult().Succeed("删除成功"));
        }
    }
}