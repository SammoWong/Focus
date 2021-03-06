﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Focus.Domain.Entities;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Model;
using Focus.Model.Dictionary;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [ApiController]
    public class DictionaryController : FocusApiControllerBase
    {
        [Route("api/DictionaryType/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDictionaryTypeAsync(string id)
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryType = await dictionaryService.GetDictionaryTypeById(id);
            if (dictionaryType == null)
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "数据类型不存在"));

            return Ok(new StandardResult().Succeed(null, dictionaryType));
        }

        [HttpPost]
        [Route("api/DictionaryType/Add")]
        public async Task<IActionResult> AddDictionaryType([FromForm]AddDictionaryTypeInputModel model)
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            if(await dictionaryService.IsDictionaryTypeExistAsync(model.Name))
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "此数据字典类型已存在"));

            var dictionaryType = new DictionaryType
            {
                Id = Guid.NewGuid().ToString(),
                ParentId = model.ParentId,
                Name = model.Name,
                SortNumber = model.SortNumber,
                Remark = model.Remark,
                Enabled = model.Enabled,
                CreatedBy = CurrentUserId,
                CreatedTime = DateTime.Now
            };
            await dictionaryService.AddDictionaryTypeAsync(dictionaryType);
            return Ok(new StandardResult().Succeed("添加成功"));
        }

        [HttpPost]
        [Route("api/DictionaryType/Update")]
        public async Task<IActionResult> UpdateDictionaryType([FromForm]UpdateDictionaryTypeInputModel model)
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryType = await dictionaryService.GetDictionaryTypeById(model.Id);
            if (dictionaryType == null)
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "数据类型不存在"));

            dictionaryType.ParentId = model.ParentId;
            dictionaryType.Name = model.Name;
            dictionaryType.SortNumber = model.SortNumber;
            dictionaryType.Enabled = model.Enabled;
            dictionaryType.Remark = model.Remark;
            dictionaryType.CreatedBy = CurrentUserId;
            dictionaryType.CreatedTime = DateTime.Now;
            await dictionaryService.UpdateDictionaryTypeAsync(dictionaryType);
            return Ok(new StandardResult().Succeed("修改成功"));
        }

        [Route("api/DictionaryTypes")]
        [HttpGet]
        public async Task<IActionResult> GetDictionaryTypesAsync()
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryTypes = await dictionaryService.GetDictionaryTypesAsync();
            var result = dictionaryTypes.Select(d => new TreeJsonModel
            {
                Id = d.Id,
                Text = d.Name,
                ParentId = d.ParentId
            }).ToList();
            return Ok(new StandardResult().Succeed(null, result.ToTreeModel()));
        }

        [HttpPost]
        [Route("api/DictionaryType/Delete")]
        public async Task<IActionResult> DeleteDictionaryTypeAsync([FromForm]DeleteDictionaryTypeInputModel model)
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryType = await dictionaryService.GetDictionaryTypeById(model.Id);
            if(dictionaryType == null)
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "数据字典类型不存在"));

            var dictionaryDetails = await dictionaryService.GetDictionaryDetailsByTypeIdAsync(model.Id);
            if (dictionaryDetails.Any())
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "删除失败：存在数据字典详情"));

            await dictionaryService.DeleteDictianaryTypeAsync(dictionaryType);
            return Ok(new StandardResult().Succeed("更新成功"));
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
        public async Task<IActionResult> UpdateDictionaryDetail([FromForm]UpdateDictionaryDetailInputModel model)
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            var dictionaryDetail = await dictionaryService.GetDictionaryDetailById(model.Id);
            if (dictionaryDetail == null)
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "数据字典不存在"));

            MapToEntity(model, dictionaryDetail);
            dictionaryDetail.ModifiedBy = CurrentUserId;
            dictionaryDetail.ModifiedTime = DateTime.Now;
            await dictionaryService.UpdateDictionaryDetailAsync(dictionaryDetail);
            return Ok(new StandardResult().Succeed("更新成功"));
        }

        [HttpPost]
        [Route("api/DictionaryDetail/Add")]
        public async Task<IActionResult> AddDictionaryDetail([FromForm]AddDictionaryDetailInputModel model)
        {
            var dictionaryService = Ioc.Get<IDictionaryService>();
            if (await dictionaryService.IsDictionaryDetailExistAsync(model.Name))
            {
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "此数据字典详情已存在"));
            }
            var dictionaryDetail = new DictionaryDetail()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                TypeId = model.TypeId,
                SortNumber = model.SortNumber,
                Enabled = model.Enabled,
                Remark = model.Remark,
                CreatedTime = DateTime.Now,
                CreatedBy = CurrentUserId
            };
            await dictionaryService.AddDictionaryDetailAsync(dictionaryDetail);
            return Ok(new StandardResult().Succeed("添加成功"));
        }

        //TODO:修改POST请求
        [HttpGet]
        [Route("api/DictionaryDetail/Delete")]
        public async Task<IActionResult> DeleteDictionaryDetail(string idStr)
        {
            if(string.IsNullOrEmpty(idStr))
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "字典详情不能为空"));
            
            var ids = idStr.Substring(0, idStr.Length - 1).Split(',').ToList();
            var dictionaryService = Ioc.Get<IDictionaryService>();
            await dictionaryService.BatchDeleteDictionaryDetailsAsync(ids, CurrentUserId);
            return Ok(new StandardResult().Succeed("删除成功"));
        }

        private void MapToEntity(UpdateDictionaryDetailInputModel model, DictionaryDetail entity)
        {
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.CreatedTime = model.CreatedTime;
            entity.SortNumber = model.SortNumber;
            entity.Enabled = model.Enabled;
            entity.Remark = model.Remark;
        }
    }
}