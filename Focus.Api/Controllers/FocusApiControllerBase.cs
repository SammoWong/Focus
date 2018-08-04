using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [ApiController]
    public class FocusApiControllerBase : ControllerBase
    {
        protected bool IsAuthenticated => HttpContext.User.Identity.IsAuthenticated;

        protected string CurrentUserId => IsAuthenticated ? User.Claims.First(u => u.Type == "sub").Value : null;

        protected string CurrentUserName => IsAuthenticated ? User.Claims.First(u => u.Type == "account").Value : null;
    }
}