using Focus.Infrastructure.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure.Web.Filters
{
    public class FocusExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is Exception)
            {
                context.Result = new JsonResult(new StandardResult().Fail(StandardCode.InternalError, context.Exception.Message));
            }
        }
    }
}
