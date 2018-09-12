using Focus.Infrastructure.Web.Attributes;
using Focus.Infrastructure.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Focus.Infrastructure.Web.Filters
{
    public class FocusAuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (!context.HttpContext.User.Identity.IsAuthenticated && !context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                context.Result = new JsonResult(new StandardResult().Fail(StandardCode.Unauthorized, "未登陆或不允许匿名访问"));
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else
            {
                //HandlePermission(context);
            }
        }

        private void HandlePermission(AuthorizationFilterContext context)
        {
            var attributeList = new List<object>();
            attributeList.AddRange((context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(true));
            attributeList.AddRange((context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.DeclaringType.GetCustomAttributes(true));
            var authorizeAttributes = attributeList.OfType<FocusAuthorizeAttribute>().ToList();
            var claims = context.HttpContext.User.Claims;
            //从claims取出权限码，与当前Controller或Action标识的权限码做比较
            var buttonPermissionCode = context.HttpContext.User.Claims.Where(a => a.Type == "buttonPermissionCode").FirstOrDefault()?.Value;
            var permissionList = buttonPermissionCode?.Split(",");
            if (!authorizeAttributes.Any(s => permissionList.Contains(s.Code) || s.Code == "allowed"))
            {
                context.Result = new JsonResult(new StandardResult().Fail(StandardCode.Unauthorized, "未授权或没有相应权限"));
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
        }
    }
}