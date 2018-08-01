using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Domain.Entities;
using Focus.Domain.Services;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Model.Dictionary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        [Route("api/DictionaryTypes")]
        [HttpGet]
        public async Task<IActionResult> GetDictionaryTypesAsync()
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryTypes = await dictionaryService.GetDictionaryTypesAsync();
            return Ok(new StandardResult().Succeed(null, dictionaryTypes));
        }

        [Route("api/DictionaryType/{typeId}/DictionaryDetails")]
        [HttpGet]
        public async Task<IActionResult> GetDictionaryDetailsByTypeIdAsync(string typeId)
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryDetails = await dictionaryService.GetDictionaryDetailsByTypeIdAsync(typeId);
            return Ok(new StandardResult().Succeed(null, dictionaryDetails.ToList()));
        }

        [HttpPost]
        [Route("api/DictionaryDetail/Update")]
        public async Task<IActionResult> UpdateDictionaryDetail(UpdateDictionaryDetailInputModel model)
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryDetail = await dictionaryService.GetDictionaryDetailById(model.Id);
            if (dictionaryDetail == null)
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "数据字典不存在"));

            MapToEntity(model, dictionaryDetail);
            await dictionaryService.UpdateDictionaryDetailAsync(dictionaryDetail);
            return Ok(new StandardResult().Succeed("更新成功"));
        }

        private void MapToEntity(UpdateDictionaryDetailInputModel model, DictionaryDetail entity)
        {
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.SortNumber = model.SortNumber;
            entity.Enabled = model.Enabled;
            entity.Remark = model.Remark;
        }
    }
}