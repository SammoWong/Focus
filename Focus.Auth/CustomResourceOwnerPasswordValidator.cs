using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Test;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Focus.Auth
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        /// <summary>
        /// 这里为了演示我们还是使用TestUser作为数据源，
        /// 正常使用此处应当传入一个 用户仓储 等可以从
        /// 数据库或其他介质获取我们用户数据的对象
        /// </summary>
        private readonly TestUserStore _users;
        private readonly ISystemClock _clock;

        public CustomResourceOwnerPasswordValidator(TestUserStore users, ISystemClock clock)
        {
            _users = users;
            _clock = clock;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //此处使用context.UserName, context.Password 用户名和密码来与数据库的数据做校验
            //if (_users.ValidateCredentials(context.UserName, context.Password))
            Focus.Service.UserService userService = new Focus.Service.UserService();
            var result = await userService.LoginAsync(context.UserName, context.Password);
            var user = result.Item2;
            if (user != null)
            {
                var testUser = _users.FindByUsername("");
                //var user = _users.FindByUsername(context.UserName);
                var claims = new List<Claim>() {
                    new Claim("Account",user.Account),
                    new Claim("Role",user.Role.Name),
                };
                //验证通过返回结果 
                //subjectId 为用户唯一标识 一般为用户id
                //authenticationMethod 描述自定义授权类型的认证方法 
                //authTime 授权时间
                //claims 需要返回的用户身份信息单元 此处应该根据我们从数据库读取到的用户信息 添加Claims 如果是从数据库中读取角色信息，那么我们应该在此处添加 此处只返回必要的Claim
                context.Result = new GrantValidationResult(
                    user.Id ?? throw new ArgumentException("Subject ID not set", nameof(user.Id)),
                    OidcConstants.AuthenticationMethods.Password, _clock.UtcNow.UtcDateTime,
                    claims: claims);
            }
            else
            {
                //验证失败
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
            }
            //return Task.CompletedTask;
        }
    }
    public class CustomProfileService : IProfileService
    {
        ///// <summary>
        ///// The logger
        ///// </summary>
        //protected readonly ILogger Logger;

        ///// <summary>
        ///// The users
        ///// </summary>
        //protected readonly TestUserStore Users;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="TestUserProfileService"/> class.
        ///// </summary>
        ///// <param name="users">The users.</param>
        ///// <param name="logger">The logger.</param>
        //public CustomProfileService(TestUserStore users, ILogger<TestUserProfileService> logger)
        //{
        //    Users = users;
        //    Logger = logger;
        //}

        /// <summary>
        /// 只要有关用户的身份信息单元被请求（例如在令牌创建期间或通过用户信息终点），就会调用此方法
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //context.LogProfileRequest(Logger);

            //判断是否有请求Claim信息
            if (context.RequestedClaimTypes.Any())
            {
                //根据用户唯一标识查找用户信息
                //var user = Users.FindBySubjectId(context.Subject.GetSubjectId());
                Focus.Service.UserService userService = new Focus.Service.UserService();
                var result = await userService.LoginAsync("admin", "123456");
                var user = result.Item2;
                var claims = new List<Claim>() {
                    new Claim("Account",user.Account),
                    new Claim("Role",user.Role.Name),
                };
                if (user != null)
                {
                    //调用此方法以后内部会进行过滤，只将用户请求的Claim加入到 context.IssuedClaims 集合中 这样我们的请求方便能正常获取到所需Claim
                    context.IssuedClaims = claims;
                    //context.AddRequestedClaims(claims);
                }
            }

            //context.LogIssuedClaims(Logger);

            //return Task.CompletedTask;
        }

        /// <summary>
        /// 验证用户是否有效 例如：token创建或者验证
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task IsActiveAsync(IsActiveContext context)
        {
            //Logger.LogDebug("IsActive called from: {caller}", context.Caller);

            //var user = Users.FindBySubjectId(context.Subject.GetSubjectId());
            Focus.Service.UserService userService = new Focus.Service.UserService();
            var result = await userService.LoginAsync("admin", "123456");
            var user = result.Item2;
            context.IsActive =  true;

            //return Task.CompletedTask;
        }
    }
}
