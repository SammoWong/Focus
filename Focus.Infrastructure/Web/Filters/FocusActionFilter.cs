using Focus.Infrastructure.Web.Common;
using Focus.Infrastructure.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Focus.Infrastructure.Web.Filters
{
    public class FocusActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new JsonResult(new StandardResult().Fail(StandardCode.ArgumentError, context.ModelState.AllModelStateErrors().FirstOrDefault().Message));
            }
        }
    }
}
