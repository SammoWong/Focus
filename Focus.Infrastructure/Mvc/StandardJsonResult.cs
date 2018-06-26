using Focus.Infrastructure.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Focus.Infrastructure.Mvc
{
    public class StandardJsonResult : ActionResult, IStandardResult
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

        public void Execute(Action action)
        {
            try
            {
                action();
                Succeed();
            }
            catch (Exception ex)
            {
                Fail(ex.Message);
            }
        }

        public async Task ExecuteAsync(Action action)
        {
            try
            {
                await Task.Run(action);
                Succeed();
            }
            catch (Exception ex)
            {
                Fail(ex.Message);
            }
        }
    }

    public class StandardJsonResult<T> : StandardJsonResult, IStandardResult<T>
    {
        public T Data { get; set; }
    }
}
