using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Domain.Entities;
using Focus.Domain.Enums;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Model.Role;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    public class RoleController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Roles")]
        public async Task<IActionResult> GetAllAsync()
        {
            var service = Ioc.Get<IRoleService>();
            var roles = await service.GetAllAsync();
            return Ok(new StandardResult().Succeed(null, roles));
        }

        [HttpPost]
        [Route("api/Role/Add")]
        public async Task<IActionResult> AddAsync([FromForm]AddRoleInputModel model)
        {
            var service = Ioc.Get<IRoleService>();
            if (await service.IsRoleExistAsync(model.Name))
                return new JsonResult(new StandardResult().Fail(StandardCode.LogicError, "角色名已存在"));

            var role = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Code = model.Code,
                Description = model.Description,
                Enabled = model.Enabled,
                CreatedBy = CurrentUserId,
                CreatedTime = DateTime.Now,
                CompanyId = CurrentCompanyId
            };
            List<Permission> permissions = new List<Permission>();
            if (model.PermissionAccessIds != null)
            {
                var modules = await Ioc.Get<IModuleService>().GetAllAsync();
                var buttons = await Ioc.Get<IButtonService>().GetAllAsync();
                foreach (var accessId in model.PermissionAccessIds)
                {
                    Permission permission = new Permission
                    {
                        Id = Guid.NewGuid().ToString(),
                        MasterType = (short)PermissionMasterType.Role,
                        MasterId = role.Id,
                        AccessType = modules.Any(m => m.Id == accessId) ? (short)PermissionAccessType.Module : buttons.Any(b => b.Id == accessId) ? (short)PermissionAccessType.Button : (short)0,
                        AccessId = accessId,
                        Enabled = true,
                        CreatedBy = CurrentUserId,
                        CreatedTime = DateTime.Now,
                    };
                    permissions.Add(permission);
                }
            }
            await service.AddAsync(role, permissions);
            return Ok(new StandardResult().Succeed("添加成功"));
        }

        [HttpPost]
        [Route("api/Role/Update")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateRoleInputModel model)
        {
            var service = Ioc.Get<IRoleService>();
            var role = await service.GetByIdAsync(model.Id);
            if (role == null)
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "角色不存在"));

            role.Name = model.Name;
            role.Code = model.Code;
            role.Description = model.Description;
            role.Enabled = model.Enabled;
            role.ModifiedBy = CurrentUserId;
            role.ModifiedTime = DateTime.Now;
            await service.UpdateAsync(role);
            return Ok(new StandardResult().Succeed("修改成功"));
        }

        [HttpPost]
        [Route("api/Role/Delete")]
        public async Task<IActionResult> DeleteAsync([FromForm]DeleteRoleInputModel model)
        {
            var service = Ioc.Get<IRoleService>();
            var role = await service.GetByIdAsync(model.Id);
            if (role == null)
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "角色不存在"));

            if (await service.HasUserContained(role))
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "删除失败：该角色下包含用户"));

            await service.DeleteAsync(role);
            return Ok(new StandardResult().Succeed("删除成功"));
        }
    }
}