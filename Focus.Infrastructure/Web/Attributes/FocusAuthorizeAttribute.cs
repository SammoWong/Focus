using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure.Web.Attributes
{
    public class FocusAuthorizeAttribute : AuthorizeAttribute
    {
        public string Code { get; set; }

        public FocusAuthorizeAttribute(string code)
        {
            Code = code;
        }
    }
}
