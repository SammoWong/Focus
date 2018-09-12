using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Infrastructure.Web.Attributes;
using Focus.Infrastructure.Web.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    public class IdentityController : FocusApiControllerBase
    {
        //TODO:需改进
        [HttpGet]
        [Route("api/Identity")]
        public IActionResult Get()
        {
            var result = from c in HttpContext.User.Claims
                         select new { c.Type, c.Value };
            UserInfo user = new UserInfo();
            foreach (var item in result)
            {
                if (item.Type == nameof(user.Account).ToLower())
                {
                    user.Account = item.Value;
                }
                if (item.Type == nameof(user.Role).ToLower())
                {
                    user.Role = item.Value;
                }
                if(item.Type == nameof(user.Avatar).ToLower())
                {
                    user.Avatar = item.Value;
                }
            }
            return Ok(new StandardResult().Succeed(null, user));
        }
    }

    public class UserInfo
    {
        public string Account { get; set; }

        public string Role { get; set; }

        public string Avatar { get; set; }
    }
}