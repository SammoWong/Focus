using Focus.Infrastructure.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Focus.Infrastructure.Web.Filters
{
    public class FocusAuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated && !context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                context.Result = new JsonResult(new StandardResult().Fail(StandardCode.Unauthorized, "未授权或没有相应权限"));
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
        }
    }
}