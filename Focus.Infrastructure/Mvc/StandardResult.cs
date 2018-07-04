using Microsoft.AspNetCore.Mvc;

namespace Focus.Infrastructure.Mvc
{
    public class StandardResult : ActionResult, IStandardResult
    {
        public StandardCode Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public IStandardResult Succeed(string message, object data = null)
        {
            Code = StandardCode.Success;
            Message = message;
            Data = data;
            return this;
        }

        public IStandardResult Fail(StandardCode code, string message, object data = null)
        {
            Code = code;
            Message = message;
            Data = data;
            return this;
        }
    }
}
