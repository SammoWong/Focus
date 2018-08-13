using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Domain.Entities;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Model.Button;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    public class ButtonController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Module/{moduleId}/Buttons")]
        public async Task<IActionResult> GetByModuleIdAsync(string moduleId)
        {
            var service = Ioc.Get<IButtonService>();
            var result = await service.GetButtonsByModuleIdAsync(moduleId);
            return Ok(new StandardResult().Succeed(null, result));
        }

        [HttpPost]
        [Route("api/Button/Add")]
        public async Task<IActionResult> AddAsync([FromForm]AddButtonInputModel model)
        {
            var service = Ioc.Get<IButtonService>();
            var button = new Button
            {
                Id = Guid.NewGuid().ToString(),
                ModuleId = model.ModuleId,
                Name = model.Name,
                Code = model.Code,
                Url = model.Url,
                Icon = model.Icon,
                JsEvent = model.JsEvent,
                SortNumber = model.SortNumber ?? 1,
                Enabled = model.Enabled,
                Remark = model.Remark
            };
            await service.AddAsync(button);
            return Ok(new StandardResult().Succeed("添加成功"));
        }

        [HttpPost]
        [Route("api/Button/Update")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateButtonInputModel model)
        {
            var service = Ioc.Get<IButtonService>();
            var button = await service.GetByIdAsync(model.Id);
            if (button == null)
                return NotFound(new StandardResult().Fail(StandardCode.ArgumentError, "按钮不存在"));

            button.Name = model.Name;
            button.Code = model.Code;
            button.JsEvent = model.JsEvent;
            button.Url = model.Url;
            button.Icon = model.Icon;
            button.SortNumber = model.SortNumber;
            button.Enabled = model.Enabled;
            button.Remark = model.Remark;
            await service.UpdateAsync(button);
            return Ok(new StandardResult().Succeed("修改成功"));
        }

        //TODO:修改为POST
        [HttpGet]
        [Route("api/Button/{id}/Delete")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var service = Ioc.Get<IButtonService>();
            var button = await service.GetByIdAsync(id);
            if (button == null)
                return NotFound(new StandardResult().Fail(StandardCode.ArgumentError, "按钮不存在"));

            await service.DeteleAsync(button);
            return Ok(new StandardResult().Succeed("删除成功"));
        }
    }
}