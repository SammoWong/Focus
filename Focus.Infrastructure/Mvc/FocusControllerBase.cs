using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Infrastructure.Mvc
{
    public class FocusControllerBase : Controller
    {
        //public StandardJsonResult Execute(Action action)
        //{
        //    var result = new StandardJsonResult();
        //    result.Execute(action);
        //    return result;
        //}

        //public StandardJsonResult<T> Execute<T>(Func<T> func)
        //{
        //    var result = new StandardJsonResult<T>();
        //    result.Execute(() =>
        //    {
        //        result.Data = func();
        //    });
        //    return result;
        //}

        //public async Task<StandardJsonResult> ExecuteAsync(Action action)
        //{
        //    var result = new StandardJsonResult();
        //    await result.ExecuteAsync(action);
        //    return result;
        //}

        //public async Task<StandardJsonResult<T>> ExecuteAsync<T>(Func<Task<T>> func)
        //{
        //    var result = new StandardJsonResult<T>();
        //    await result.ExecuteAsync(async () =>
        //    {
        //        result.Data = await func();
        //    });
        //    return result;
        //}
    }
}
