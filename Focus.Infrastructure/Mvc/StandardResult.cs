using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure.Mvc
{
    public class StandardResult : IStandardResult
    {
        public bool State { get; set; }

        public string Message { get; set; }

        public void Fail()
        {
            State = false;
        }

        public void Fail(string message)
        {
            State = false;
            Message = message;
        }

        public void Succeed()
        {
            State = true;
        }

        public void Succeed(string message)
        {
            State = true;
            Message = message;
        }
    }

    public class StandardResult<T> : StandardResult, IStandardResult<T>
    {
        public T Data { get; set; }
    }
}
