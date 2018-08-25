using System;
using System.Linq;
using System.Threading.Tasks;
using Focus.Domain.Entities;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Infrastructure.Web.Pagination;
using Focus.Model.User;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    public class UserController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Users")]
        public async Task<IActionResult> GetAllAsync([FromQuery]PaginationRequest request)
        {
            var service = Ioc.Get<IUserService>();
            var users = await service.GetAllAsync();
            return Ok(new StandardResult().Succeed(null, new PaginationResult(users.Count(), users.Skip(request.Start).Take(request.Take))));
        }

        [HttpPost]
        [Route("api/User/Add")]
        public async Task<IActionResult> AddAsync([FromForm]AddUserInputModel model)
        {
            var service = Ioc.Get<IUserService>();
            if (await service.IsAccountExist(model.Account))
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "账号已存在"));

            var salt = PasswordHelper.GenerateSalt();
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                RealName = model.RealName,
                Account = model.Account,
                Salt = salt,
                Password = PasswordHelper.ComputeHash("123456", salt),
                IdCard = model.IdCard,
                Email = model.Email,
                Birthday = model.Birthday,
                Mobile = model.Mobile,
                Gender = model.Gender,
                CreatedTime = DateTime.Now,
                CreatedBy = CurrentUserId,
                Enabled = model.Enabled
            };
            await service.AddAsync(user);
            return Ok(new StandardResult().Succeed("添加成功"));
        }

        [HttpPost]
        [Route("api/User/Update")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateUserInputModel model)
        {
            var service = Ioc.Get<IUserService>();
            var user = await service.GetUserById(model.Id);
            if(user == null)
            {
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "用户不存在"));
            }
            user.RealName = model.RealName;
            user.IdCard = model.IdCard;
            user.Email = model.Email;
            user.Birthday = model.Birthday;
            user.Mobile = model.Mobile;
            user.Gender = model.Gender;
            user.Enabled = model.Enabled;
            user.ModifiedBy = CurrentUserId;
            user.ModifiedTime = DateTime.Now;
            await service.UpdateAsync(user);
            return Ok(new StandardResult().Succeed("更新成功"));
        }

        [HttpPost]
        [Route("api/User/Delete")]
        public async Task<IActionResult> DeleteAsync([FromForm]DeleteUserInputModel model)
        {
            var service = Ioc.Get<IUserService>();
            var user = await service.GetUserById(model.Id);
            if (user == null)
            {
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "用户不存在"));
            }
            user.IsDeleted = true;
            user.DeletedBy = CurrentUserId;
            user.DeletedTime = DateTime.Now;
            await service.UpdateAsync(user);
            return Ok(new StandardResult().Succeed("删除成功"));
        }

        //TODO:不能直接返回带有include导航属性的实体
        [HttpGet]
        [Route("api/User/Detail")]
        public async Task<IActionResult> GetByIdAsync()
        {
            var service = Ioc.Get<IUserService>();
            var user = await service.GetUserById(CurrentUserId);
            if(user == null)
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "用户不存在"));

            var result = new
            {
                user.Id,
                user.RealName,
                user.Account,
                user.IdCard,
                user.Gender,
                user.Email,
                user.Mobile,
                user.Avatar,
                user.Birthday,
                user.CreatedTime,
                user.ModifiedTime,
                user.Organization,
                role = user.Role.Name
            };
            return Ok(new StandardResult().Succeed(null, result));
        }
    }
}