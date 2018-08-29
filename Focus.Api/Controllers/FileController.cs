using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Focus.Domain.Constants;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Focus.Api.Controllers
{
    public class FileController : FocusApiControllerBase
    {
        //TODO:思考是否需要建字段AvatarUrl和AvatarPath
        [HttpPost]
        [Route("api/Avatar/Upload")]
        [Consumes("application/json", "multipart/form-data")]
        public async Task<IActionResult> UploadAvatar(IFormCollection formfiles)
        {
            var files = formfiles.Files;
            if (files == null || files.Count <= 0)
                return BadRequest(new StandardResult().Fail(StandardCode.LogicError, "请选择上传头像"));

            if (files.Any(f => f.Length > FocusConstants.Misc.MaxUploadFileSize))
                return Ok(new StandardResult().Fail(StandardCode.LogicError, string.Format("上传文件大小不能超过{0}MB", FocusConstants.Misc.MaxUploadFileSize / (1024 * 1024))));

            if (!files.All(f => IsImage(f.FileName)))
                return BadRequest(new StandardResult().Fail(StandardCode.LogicError, "请选择图片上传"));

            var userService = Ioc.Get<IUserService>();
            var avatarRootPath = AppSetting.FileRootPath;
            var userId = formfiles["userId"][0];
            var user = await userService.GetUserById(userId);
            if (user == null)
                return BadRequest(new StandardResult().Fail(StandardCode.LogicError, "用户不存在"));

            var fileId = Guid.NewGuid().ToString();
            var fileName = GenerateFileName(user.Id, files[0].FileName);
            var fileEntity = new Focus.Domain.Entities.File
            {
                Id = fileId,
                Name = fileName,
                Path = avatarRootPath + "/" + fileName,
                Type = Domain.Enums.FileType.Avatar,
                CreatedBy = CurrentUserId,
                CreatedTime = DateTime.Now
            };
            user.Avatar = "/api/File/" + fileId;
            using(var stream = new FileStream(fileEntity.Path, FileMode.Create))
            {
                await files[0].CopyToAsync(stream);
            }
            var fileService = Ioc.Get<IFileService>();
            await fileService.UploadAvatarAsync(fileEntity, user);
            return Ok(new StandardResult().Succeed(null, "上传成功"));
        }

        [HttpGet]
        [Route("api/File/{fileId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadAvatar(string fileId)
        {
            var service = Ioc.Get<IFileService>();
            var file = await service.GetByIdAsync(fileId);
            if(file == null)
                return BadRequest(new StandardResult().Fail(StandardCode.LogicError, "头像不存在"));

            var fileExt = Path.GetExtension(file.Path);
            var stream = new FileStream(file.Path, FileMode.Open);
            var provider = new FileExtensionContentTypeProvider();
            var contentType = provider.Mappings[fileExt];
            return File(stream, contentType, Path.GetFileName(file.Name));
        }

        private bool IsImage(string fileName)
        {
            string[] allowExtensions = { ".jpg", ".gif", ".png", ".bmp" };
            var fileExt = Path.GetExtension(fileName).ToLower();
            return allowExtensions.Contains(fileExt);
        }

        private string GenerateFileName(string userId, string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return userId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
        }
    }
}