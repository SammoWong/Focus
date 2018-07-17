using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure.Web.Common
{
    public interface IStandardResult
    {
        StandardCode Code { get; set; }

        string Message { get; set; }

        object Data { get; set; }

        IStandardResult Succeed(string message, object data = null);

        IStandardResult Fail(StandardCode code, string message, object data = null);
    }
}
