using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Focus.Domain.Constants;
using Focus.Domain.Enums;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Infrastructure.Web.Extensions;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json.Linq;

namespace Focus.Api.Controllers
{
    public class FileController : FocusApiControllerBase
    {
        [HttpPost]
        [Route("api/[controller]/Upload")]
        //[Produces("application/json")]
        //[Consumes("application/json", "multipart/form-data")]
        public async Task<IActionResult> Upload()
        {
            //var files = formfiles.Files;
            var files = Request.Form.Files;
            if (files == null || files.Count <= 0)
                return BadRequest(new StandardResult().Fail(StandardCode.LogicError, "文件不能为空"));

            if (files.Any(f => f.Length > FocusConstants.Misc.MaxUploadFileSize))
                return Ok(new StandardResult().Fail(StandardCode.LogicError, string.Format("上传文件大小不能超过{0}MB", FocusConstants.Misc.MaxUploadFileSize / (1024 * 1024))));

            var fileSource = Enum.Parse<FileSource>(Request.Form["fileSource"].ToString());
            var service = Ioc.Get<IFileService>();
            if ((fileSource == FileSource.Article || fileSource == FileSource.Avatar) && !files.All(f => service.IsImage(f.FileName)))
                return BadRequest(new StandardResult().Fail(StandardCode.LogicError, "请选择图片上传"));

            var fileRootPath = AppSetting.FileRootPath + fileSource.GetDescriptionByName();
            var fileId = Guid.NewGuid().ToString();
            var fileName = service.GenerateFileName(Path.GetExtension(files[0].FileName), fileId);
            var fullPath = fileRootPath + "/" + fileName;
            if (!Directory.Exists(fileRootPath))
            {
                Directory.CreateDirectory(fileRootPath);
            }
            var fileEntity = new Domain.Entities.File
            {
                Id = fileId,
                Name = fileName,
                Path = fullPath,
                Type = fileSource,
                CreatedBy = CurrentUserId,
                CreatedTime = DateTime.Now
            };
            using (var stream = new FileStream(fileEntity.Path, FileMode.Create))
            {
                await files[0].CopyToAsync(stream);
            }
            await service.UploadAsync(fileEntity);
            return Ok(new StandardResult().Succeed("上传成功", AppSetting.ApiUrl + "/api/File/" + fileId));
        }

        [HttpPost]
        [Route("api/Avatar/Upload")]
        public async Task<IActionResult> UploadAvatarByBase64([FromBody]JObject data)
        {
            var imageBase64 = data["image"].ToObject<string>();
            if (!string.IsNullOrWhiteSpace(imageBase64))
            {
                var reg = new Regex("data:image/(.*);base64,");
                imageBase64 = reg.Replace(imageBase64, "");
                byte[] imageByte = Convert.FromBase64String(imageBase64);
                var fileRootPath = AppSetting.FileRootPath + FileSource.Avatar.GetDescriptionByName();
                if (!Directory.Exists(fileRootPath))
                {
                    Directory.CreateDirectory(fileRootPath);
                }
                var fileService = Ioc.Get<IFileService>();
                var fileId = Guid.NewGuid().ToString();
                var fileName = fileService.GenerateFileName(".png", fileId);
                string fullPath = fileRootPath + "/" + fileName;
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    using (var memoryStream = new MemoryStream(imageByte))
                    {
                        memoryStream.WriteTo(fileStream);
                    }
                }

                var userService = Ioc.Get<IUserService>();
                var user = await userService.GetUserById(CurrentUserId);
                var fileEntity = new Domain.Entities.File
                {
                    Id = fileId,
                    Name = fileName,
                    Path = fullPath,
                    Type = FileSource.Avatar,
                    CreatedBy = CurrentUserId,
                    CreatedTime = DateTime.Now
                };
                user.Avatar = "/api/File/" + fileId;

                await fileService.UploadAvatarAsync(fileEntity, user);
                return Ok(new StandardResult().Succeed("上传成功"));
            }
            return BadRequest(new StandardResult().Fail(StandardCode.LogicError, "请选择上传头像"));
        }

        [HttpGet]
        [Route("api/File/{fileId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Download(string fileId)
        {
            var service = Ioc.Get<IFileService>();
            var file = await service.GetByIdAsync(fileId);
            if (file == null)
                return BadRequest(new StandardResult().Fail(StandardCode.LogicError, "文件不存在"));

            var fileExt = Path.GetExtension(file.Path);
            var stream = new FileStream(file.Path, FileMode.Open);
            var provider = new FileExtensionContentTypeProvider();
            var contentType = provider.Mappings[fileExt];
            return File(stream, contentType, Path.GetFileName(file.Name));
        }
    }
}